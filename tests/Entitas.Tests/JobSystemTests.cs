﻿using System;
using FluentAssertions;
using Xunit;

namespace Entitas.Tests
{
    [Collection(nameof(JobSystemTests))]
    public class JobSystemTests
    {
        readonly TestContext _context;

        public JobSystemTests()
        {
            TestContext.ComponentNames = new[] { "User" };
            TestContext.ComponentTypes = new[] { typeof(UserComponent) };
            _context = new TestContext();
        }

        [Fact]
        public void ProcessesEntity()
        {
            var system = new TestJobSystem(_context, 2);
            var e = _context.CreateEntity();
            e.AddUser("e", -1);
            system.Execute();
            e.GetUser().Name.Should().Be("e-Processed");
        }

        [Fact(Skip = "Please run test individually")]
        public void ProcessesAllEntitiesWhenCountIsDividableByNumThreads()
        {
            var system = new TestJobSystem(_context, 2);
            for (var i = 0; i < 4; i++)
                _context.CreateEntity().AddUser($"e{i}", -1);

            system.Execute();

            var entities = _context.GetEntities();
            entities.Length.Should().Be(4);
            for (var i = 0; i < entities.Length; i++)
                entities[i].GetUser().Name.Should().Be($"e{i}-Processed");

            entities[0].GetUser().Age.Should().Be(entities[1].GetUser().Age);
            entities[2].GetUser().Age.Should().Be(entities[3].GetUser().Age);
            entities[0].GetUser().Age.Should().NotBe(entities[2].GetUser().Age);
        }

        [Fact]
        public void ProcessesAllEntitiesWhenCountIsNotDividableByNumThreads()
        {
            var system = new TestJobSystem(_context, 4);
            for (var i = 0; i < 103; i++)
                _context.CreateEntity().AddUser($"e{i}", -1);

            system.Execute();

            var entities = _context.GetEntities();
            entities.Length.Should().Be(103);
            for (var i = 0; i < entities.Length; i++)
                entities[i].GetUser().Name.Should().Be($"e{i}-Processed");
        }

        [Fact]
        public void ThrowsWhenThreadThrows()
        {
            var system = new TestJobSystem(_context, 2);
            system.exception = new Exception("Test Exception");
            for (var i = 0; i < 10; i++)
                _context.CreateEntity().AddUser($"e{i}", -1);

            FluentActions.Invoking(() => system.Execute()).Should().Throw<Exception>();
        }

        [Fact]
        public void RecoversFromException()
        {
            var system = new TestJobSystem(_context, 2);
            system.exception = new Exception("Test Exception");
            for (var i = 0; i < 10; i++)
                _context.CreateEntity().AddUser($"e{i}", -1);

            var didThrow = 0;
            try
            {
                system.Execute();
            }
            catch (Exception)
            {
                didThrow += 1;
            }

            didThrow.Should().Be(1);
            system.exception = null;
            system.Execute();
        }
    }
}
