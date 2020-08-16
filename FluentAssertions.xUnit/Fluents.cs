using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FluentAssertions.xUnit
{
    // FluentAssertions: テスト期待値を自然に記述できるメソッド拡張のライブラリ
    public class Fluents
    {
        [Fact]
        public void Numeric()
        {
            static int Add(int x, int y) => x + y;

            var expValue = 2;
            var actual = Add(1, 1);

            actual.Should().Be(expValue, "期待値と異なる");
            actual.Should().NotBe(expValue + 2);

            (1).Should().BePositive();
            (-1).Should().BeNegative();
            (6).Should().BeGreaterThan(3);
            (8).Should().BeLessOrEqualTo(8);

            (3.1).Should().BeOfType((1d).GetType());
            (1).Should().NotBeOfType(typeof(decimal));
        }

        [Fact]
        public void Boolean()
        {
            true.Should().BeTrue();
            false.Should().BeFalse();
            (!true).Should().Be(false);
        }

        [Fact]
        public void Collection()
        {
            var actual = new[] { 1, 3, 5, 7, 9 };

            actual.Should().NotBeEmpty()
                .And.HaveCount(5)
                .And.ContainInOrder(1, 3, 7);
        }

        [Fact]
        public void String()
        {
            var atoz = new string(Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToArray());

            atoz.Should().NotBeEmpty()
                .And.HaveLength(26)
                .And.StartWith("abc")
                .And.Contain("cd")
                .And.EndWith("xyz");

            atoz.Should().MatchRegex("[a-z]");
        }

    }
}
