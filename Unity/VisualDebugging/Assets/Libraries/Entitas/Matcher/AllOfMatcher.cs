namespace Entitas {
    public class AllOfMatcher : AbstractMatcher {
        public AllOfMatcher(int[] indices) : base(indices) {
        }

        public override bool Matches(Entity entity) {
            return entity.HasComponents(indices);
        }
    }
}
