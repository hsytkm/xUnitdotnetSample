using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    // Test classes must be public.
    public class TheoriesInline
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(-1)]
        public void DirectIsOdd(int x)
        {
            Assert.True((x & 1) == 1);
        }

        [Theory]
        [InlineData(1, 1, 2)]   // 1 + 1 = 2
        [InlineData(2, 3, 5)]
        //[InlineData(1, 1, 3)]
        public void DirectAdd(int x, int y, int answer)
        {
            Assert.Equal(answer, x + y);
        }

        public static IReadOnlyList<object[]> MemberDataProperty =>
            Enumerable.Range(5, 2).Select(x => new object[] { x, x, x + x }).ToList();

        public static IEnumerable<object[]> MemberDataMethod(int from, int count) =>
            Enumerable.Range(from, count).Select(x => new object[] { x, x, x + x });

        [Theory]
        [MemberData(nameof(MemberDataProperty))]
        [MemberData(nameof(MemberDataMethod), 10, 3)]
        public void MemberData(int x, int y, int answer)
        {
            Assert.Equal(answer, x + y);
        }

    }
}
