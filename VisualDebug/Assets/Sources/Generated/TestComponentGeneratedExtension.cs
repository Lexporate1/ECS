namespace Entitas {
    public partial class Entity {
        public TestComponent test { get { return (TestComponent)GetComponent(ComponentIds.Test); } }

        public bool hasTest { get { return HasComponent(ComponentIds.Test); } }

        public void AddTest(TestComponent component) {
            AddComponent(ComponentIds.Test, component);
        }

        public void AddTest(UnityEngine.Bounds newBounds, UnityEngine.Color newColor, UnityEngine.AnimationCurve newAnimationCurve, TestComponent.MyEnum newMyEnum, float newMyFloat, int newMyInt, UnityEngine.Rect newRect, string newMyString, UnityEngine.Vector2 newVector2, UnityEngine.Vector3 newVector3, UnityEngine.Vector4 newVector4, bool newMyBool, MyObject newCustomObject, object newMyObject, System.DateTime newDate) {
            var component = new TestComponent();
            component.bounds = newBounds;
            component.color = newColor;
            component.animationCurve = newAnimationCurve;
            component.myEnum = newMyEnum;
            component.myFloat = newMyFloat;
            component.myInt = newMyInt;
            component.rect = newRect;
            component.myString = newMyString;
            component.vector2 = newVector2;
            component.vector3 = newVector3;
            component.vector4 = newVector4;
            component.myBool = newMyBool;
            component.customObject = newCustomObject;
            component.myObject = newMyObject;
            component.date = newDate;
            AddTest(component);
        }

        public void ReplaceTest(UnityEngine.Bounds newBounds, UnityEngine.Color newColor, UnityEngine.AnimationCurve newAnimationCurve, TestComponent.MyEnum newMyEnum, float newMyFloat, int newMyInt, UnityEngine.Rect newRect, string newMyString, UnityEngine.Vector2 newVector2, UnityEngine.Vector3 newVector3, UnityEngine.Vector4 newVector4, bool newMyBool, MyObject newCustomObject, object newMyObject, System.DateTime newDate) {
            TestComponent component;
            if (hasTest) {
                WillRemoveComponent(ComponentIds.Test);
                component = test;
            } else {
                component = new TestComponent();
            }
            component.bounds = newBounds;
            component.color = newColor;
            component.animationCurve = newAnimationCurve;
            component.myEnum = newMyEnum;
            component.myFloat = newMyFloat;
            component.myInt = newMyInt;
            component.rect = newRect;
            component.myString = newMyString;
            component.vector2 = newVector2;
            component.vector3 = newVector3;
            component.vector4 = newVector4;
            component.myBool = newMyBool;
            component.customObject = newCustomObject;
            component.myObject = newMyObject;
            component.date = newDate;
            ReplaceComponent(ComponentIds.Test, component);
        }

        public void RemoveTest() {
            RemoveComponent(ComponentIds.Test);
        }
    }

    public static partial class Matcher {
        static AllOfMatcher _matcherTest;

        public static AllOfMatcher Test {
            get {
                if (_matcherTest == null) {
                    _matcherTest = Matcher.AllOf(new [] { ComponentIds.Test });
                }

                return _matcherTest;
            }
        }
    }
}