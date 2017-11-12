﻿using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Fabl;
using Fabl.Appenders;

namespace Entitas.CodeGeneration.CodeGenerator.CLI {

    public class Client : AbstractCommand {

        public override string trigger { get { return "client"; } }
        public override string description { get { return "Start client mode (default port is 3333)"; } }
        public override string example { get { return "entitas client port command"; } }

        string _command;

        protected override void run() {
            var port = 0;
            try {
                port = int.Parse(_rawArgs[1]);
                _command = string.Join(" ", _rawArgs.Skip(2).ToArray());
            } catch (Exception) {
                port = 3333;
                _command = string.Join(" ", _rawArgs.Skip(1).ToArray());
            }

            var client = new TcpClientSocket();
            client.OnConnect += onConnected;
            client.OnReceive += onReceive;
            client.OnDisconnect += onDisconnect;
            client.Connect(IPAddress.Parse("127.0.0.1"), port);

            while (true) { }
        }

        void onConnected(TcpClientSocket client) {
            client.Send(Encoding.UTF8.GetBytes(_command));
        }

        void onReceive(AbstractTcpSocket socket, Socket client, byte[] bytes) {
            fabl.Info(Encoding.UTF8.GetString(bytes));
            socket.Disconnect();
        }

        void onDisconnect(AbstractTcpSocket socket) {
            Environment.Exit(0);
        }
    }
}
