using System;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject
{
    // Test classes must be public.
    public class CtorDispose : IDisposable
    {
        private readonly ITestOutputHelper _output;

        public CtorDispose(ITestOutputHelper output)
        {
            // テスト開始の度にコールされる
            _output = output;
            _output.WriteLine("Ctor");
        }

        public void Dispose()
        {
            // テスト終了の度にコールされる
            _output.WriteLine("Dispose");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void Test(int x)
        {
            static bool IsOdd(int x) => (x & 1) == 1;

            _output.WriteLine("Test");
            Assert.True(IsOdd(x));
        }
    }
}
