﻿using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Entitas.Migration.Tests
{
    public class M0190Tests
    {
        static string FixturePath => TestExtensions.GetProjectRoot() + "/src/Entitas.Migration/fixtures/M0190";

        readonly M0190 _migration;

        public M0190Tests()
        {
            _migration = new M0190();
        }

        [Fact]
        public void FindsAllReactiveSystems()
        {
            var updatedFiles = _migration.Migrate(FixturePath);
            updatedFiles.Length.Should().Be(3);
            updatedFiles.Any(file => file.fileName == Path.Combine(FixturePath, "RenderPositionSystem.cs")).Should().BeTrue();
            updatedFiles.Any(file => file.fileName == Path.Combine(FixturePath, "RenderRotationSystem.cs")).Should().BeTrue();
            updatedFiles.Any(file => file.fileName == Path.Combine(FixturePath, Path.Combine("SubFolder", "RenderSelectedSystem.cs"))).Should().BeTrue();
        }

        [Fact]
        public void MigratesToNewApi()
        {
            var updatedFiles = _migration.Migrate(FixturePath);
            var reactiveSystemFile = updatedFiles.First(file => file.fileName == Path.Combine(FixturePath, "RenderRotationSystem.cs"));
            reactiveSystemFile.fileContent.Should().Be(@"using Entitas;

public class RenderRotationSystem : IReactiveSystem {
    public IMatcher trigger { get { return Matcher.AllOf(CoreMatcher.Rotation, CoreMatcher.View); } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    public void Execute(System.Collections.Generic.List<Entity> entities) {
        // Do sth
    }
}
");
        }
    }
}
