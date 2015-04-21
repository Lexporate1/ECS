﻿using System.Collections.Generic;
using Entitas.CodeGenerator;
using NSpec;

class describe_Properties : nspec {

    void when_creating_properties() {
        it["is empty"] = () => new Properties().Count.should_be(0);
        it["creates emtpy string when empty"] = () => new Properties().ToString().should_be(string.Empty);
        it["adds every property from input string and trims whitespace"] = () => {
            var p = new Properties(
                        "Some.Test=some value\n" +
                        "Some.Other.Test  =  other value  \n"
                    );

            var expectedProperties = new Dictionary<string, string> {
                { "Some.Test", "some value" },
                { "Some.Other.Test", "other value" }
            };

            p.Count.should_be(expectedProperties.Count);
            foreach (var kv in expectedProperties) {
                p[kv.Key].should_be(kv.Value);
            }
        };

        it["creates newline seperated property list for every property"] = () => {
            var properties =
                "Some.Test=some value\n" +
                "Some.Other.Test  =  other value \n";
            new Properties(properties).ToString().should_be(
                "Some.Test = some value\n" +
                "Some.Other.Test = other value\n"
            );
        };

        it["is mutable and trims whitespace"] = () => {
            var p = new Properties(
                        "Some.Test=some value\n" +
                        "Some.Other.Test  =  other value \n");

            p["Some.Test"] = " new value ";
            p.ToString().should_be(
                "Some.Test = new value\n" +
                "Some.Other.Test = other value\n"
            );
        };

        it["can add new properties"] = () => {
            var p = new Properties();
            p["newKey"] = "new value";
            p["newKey"].should_be("new value");
            p.ToString().should_be("newKey = new value\n");
        };

        it["contains key"] = () => new Properties("validKey = value").ContainsKey("validKey").should_be_true();
        it["doesn't contain key"] = () => new Properties().ContainsKey("invalidKey").should_be_false();
    }
}

