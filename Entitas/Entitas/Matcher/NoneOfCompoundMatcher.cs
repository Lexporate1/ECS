﻿namespace Entitas {
    public class NoneOfCompoundMatcher : AbstractCompoundMatcher {
        public NoneOfCompoundMatcher(IMatcher[] matchers) : base(matchers) {
        }

        public override bool Matches(Entity entity) {
            for (int i = 0, matchersLength = matchers.Length; i < matchersLength; i++) {
                if (matchers[i].Matches(entity)) {
                    return false;
                }
            }

            return true;
        }
    }

    public partial class Matcher {
        public static NoneOfCompoundMatcher NoneOf(params IMatcher[] matchers) {
            return new NoneOfCompoundMatcher(matchers);
        }
    }
}

