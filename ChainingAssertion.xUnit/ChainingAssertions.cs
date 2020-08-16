using System;
using System.Linq;
using Xunit;

namespace ChainingAssertion.xUnit
{
    // neueccさんの拡張メソッドで書きやすくする
    public class ChainingAssertions
    {
        [Fact]
        public void Is()
        {
            // This same as Assert.Equal(25, Math.Pow(5, 2))
            Math.Pow(5, 2).Is(25);

            // This same as Assert.True("foobar".StartsWith("foo") && "foobar".EndWith("bar"))
            "foobar".Is(s => s.StartsWith("foo") && s.EndsWith("bar"));

            // This same as Assert.Equal(Enumerable.Range(1,5).ToArray(), new[]{1, 2, 3, 4, 5}.ToArray())
            Enumerable.Range(1, 5).Is(1, 2, 3, 4, 5);
        }

        [Fact]
        public void Collection()
        {
            var array = new[] { 1, 3, 7, 8 };

            array.Count().Is(4);
            array.Contains(8).IsTrue();         // IsTrue() == Is(true)
            array.All(i => i < 5).IsFalse();    // IsFalse() == Is(false)
            array.Any().Is(true);
            Array.Empty<int>().Any().Is(false); // IsEmpty
            array.OrderBy(x => x).Is(array);    // IsOrdered
        }

        [Fact]
        public void Null()
        {
            object obj = null;
            obj.IsNull();             // Assert.Null(obj)
            new object().IsNotNull(); // Assert.NotNull(obj)
        }

        [Fact]
        public void Not()
        {
            "foobar".IsNot("fooooooo");                     // Assert.NotEqual
            new[] { "a", "z", "x" }.IsNot("a", "x", "z");   // Assert.NotEqual
        }

        [Fact]
        public void ReferenceEqual()
        {
            // ValueTupleをTuple・匿名型と比較してみる https://qiita.com/dyoneda/items/e45fcd9a379922e8484a
            var tuple = Tuple.Create("foo");
            tuple.IsSameReferenceAs(tuple);                     // Assert.Same
            tuple.IsNotSameReferenceAs(Tuple.Create("foo"));    // Assert.NotSame
        }

        [Fact]
        public void Type()
        {
            "foobar".IsInstanceOf<string>();    // Assert.IsType
            (999).IsNotInstanceOf<double>();    // Assert.IsNotType
        }

        [Fact]
        public void AdvancedCollection()
        {
            var lower = new[] { "a", "b", "c" };
            var upper = new[] { "A", "B", "C" };

            // Comparer CollectionAssert, use IEqualityComparer<T> or Func<T,T,bool> delegate
            lower.Is(upper, StringComparer.InvariantCultureIgnoreCase);
            lower.Is(upper, (x, y) => x.ToUpper() == y.ToUpper());

            // or you can use Linq to Objects - SequenceEqual
            lower.SequenceEqual(upper, StringComparer.InvariantCultureIgnoreCase).Is(true);
        }

        #region StructuralEqual
        class MyClass1
        {
            public int IntProp { get; set; }
            public string StrField;
        }

        [Fact]
        public void StructuralEqual()
        {
            var mc1 = new MyClass1() { IntProp = 10, StrField = "foo" };
            var mc2 = new MyClass1() { IntProp = 10, StrField = "foo" };

            mc1.IsStructuralEqual(mc2);     // deep recursive value equality compare

            mc1.IntProp = 20;
            mc1.IsNotStructuralEqual(mc2, "message");
        }
        #endregion

        #region DynamicAccessor
        public class PrivateMock
        {
            private string _privateField = "homu";

            private string PrivateProperty
            {
                get => _privateField + _privateField;
                set => _privateField = value;
            }

            private string PrivateMethod(int count) =>
               string.Join("", Enumerable.Repeat(_privateField, count));
        }

        [Fact]
        public void DynamicAccessor()
        {
            // call private property.
            var actual = new PrivateMock().AsDynamic().PrivateProperty;
            Assert.Equal("homuhomu", actual);

            // dynamic can't invoke extension methods.
            // if you want to invoke "Is" then cast type.
            (new PrivateMock().AsDynamic().PrivateMethod(3) as string).Is("homuhomuhomu");

            // set value
            var mock = new PrivateMock().AsDynamic();
            mock.PrivateProperty = "mogumogu";
            (mock._privateField as string).Is("mogumogu");
        }
        #endregion

        /*-- more details see project home https://github.com/neuecc/ChainingAssertion --*/
    }
}
