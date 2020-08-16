using System;
using System.Drawing;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    // Test classes must be public.
    public class AssertCompares
    {
        [Fact]
        public void Boolean()
        {
            Assert.True(true);
            Assert.False(false);
        }

        [Fact]
        public void Equal()
        {
            Assert.Equal(3, 1 + 2);
            Assert.Equal(3.000001d, 1d + 2, precision: 5);
            Assert.NotEqual(4, 1 + 2);
        }

        [Fact]
        public void Range()
        {
            Assert.InRange(1, 0, 2);
            Assert.InRange("c", "a", "e");
            Assert.NotInRange(100, 0, 2);
            Assert.NotInRange("z", "a", "e");
        }

        [Fact]
        public void Collection()
        {
            var odds = new[] { 1, 3, 5, 7, 9 };

            Assert.Contains(1, odds);
            Assert.DoesNotContain(2, odds);
            Assert.All(odds, x => Assert.True((x & 1) == 1));

            Assert.NotEmpty(odds);
            Assert.Empty(Array.Empty<string>());

            Assert.Single(Enumerable.Range(0, 1));
        }

        [Fact]
        public void Pointer()
        {
            Assert.Null(null);
            Assert.NotNull(this);
            Assert.Same("abcd", "abcd");
            Assert.Same("", string.Empty);
            Assert.NotSame("", "aaa");
        }

        [Fact]
        public void String()
        {
            var s = "abcdefg";
            Assert.StartsWith("abc", s);
            Assert.EndsWith("efg", s);
            Assert.Contains("cd", s);
        }

        [Fact]
        public void Regex()
        {
            Assert.Matches("[a-z]", "a");
        }

        class Base { }
        class Derived : Base { }

        [Fact]
        public void Type()
        {
            Assert.IsType<double>(123d);
            Assert.IsType("mofu".GetType(), "nya-n");
            Assert.IsNotType<string>(this);
            Assert.IsNotType("hoge".GetType(), this);

            Assert.IsAssignableFrom<Base>(new Base());
            Assert.IsAssignableFrom<Base>(new Derived());
        }

        [Fact]
        public void Struct()
        {
            var point = new Point(1, 2);
            Assert.StrictEqual(new Point(1, 2), point);
            Assert.NotStrictEqual(new Point(2, 1), point);
        }

    }
}
