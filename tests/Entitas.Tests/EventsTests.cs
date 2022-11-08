﻿using FluentAssertions;
using Xunit;

namespace Entitas.Tests
{
    public class EventsTests
    {
        readonly Contexts _contexts;
        readonly AnyStandardEventEventSystem _eventSystem;
        readonly FlagEntityEventEventSystem _flagEventSystem;

        public EventsTests()
        {
            _contexts = new Contexts();
            _eventSystem = new AnyStandardEventEventSystem(_contexts);
            _flagEventSystem = new FlagEntityEventEventSystem(_contexts);
        }

        [Fact]
        public void CanRemoveListenerInCallback()
        {
            var eventTest = new RemoveEventTest(_contexts, false);
            _contexts.test1.CreateEntity().AddStandardEvent("Test1");
            _eventSystem.Execute();
            eventTest.Value.Should().Be("Test1");
        }

        [Fact]
        public void CanRemoveListenerInCallbackInTheMiddle()
        {
            var eventTest1 = new RemoveEventTest(_contexts, false);
            var eventTest2 = new RemoveEventTest(_contexts, false);
            var eventTest3 = new RemoveEventTest(_contexts, false);

            _contexts.test1.CreateEntity().AddStandardEvent("Test1");
            _eventSystem.Execute();

            eventTest1.Value.Should().Be("Test1");
            eventTest2.Value.Should().Be("Test1");
            eventTest3.Value.Should().Be("Test1");
        }

        [Fact]
        public void CanRemoveListenerInCallbackAndRemoveComponent()
        {
            var eventTest = new RemoveEventTest(_contexts, true);
            _contexts.test1.CreateEntity().AddStandardEvent("Test1");
            _eventSystem.Execute();
            eventTest.Value.Should().Be("Test1");
        }

        [Fact]
        public void CanRemoveFlagListenerInCallback()
        {
            var eventTest = new RemoveEventTest(_contexts, false);
            eventTest.Listener.isFlagEntityEvent = true;
            _flagEventSystem.Execute();
            eventTest.Value.Should().Be("true");
        }

        [Fact]
        public void CanRemoveFlagListenerInCallbackAndRemoveComponent()
        {
            var eventTest = new RemoveEventTest(_contexts, true);
            eventTest.Listener.isFlagEntityEvent = true;
            _flagEventSystem.Execute();
            eventTest.Value.Should().Be("true");
        }

        class RemoveEventTest : IAnyStandardEventListener, IFlagEntityEventListener
        {
            public Test1Entity Listener => _listener;
            public string Value => _value;

            readonly bool _removeComponentWhenEmpty;
            readonly Test1Entity _listener;

            string _value;

            public RemoveEventTest(Contexts contexts, bool removeComponentWhenEmpty)
            {
                _removeComponentWhenEmpty = removeComponentWhenEmpty;
                _listener = contexts.test1.CreateEntity();
                _listener.AddAnyStandardEventListener(this);
                _listener.AddFlagEntityEventListener(this);
            }

            public void OnAnyStandardEvent(Test1Entity entity, string value)
            {
                _listener.RemoveAnyStandardEventListener(this, _removeComponentWhenEmpty);
                _value = value;
            }

            public void OnFlagEntityEvent(Test1Entity entity)
            {
                _listener.RemoveFlagEntityEventListener(this, _removeComponentWhenEmpty);
                _value = "true";
            }
        }
    }
}
