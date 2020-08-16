using System;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject
{
    // Test classes must be public.
    public class OutputMessage
    {
        private readonly ITestOutputHelper _output;

        public OutputMessage(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test()
        {
            static bool IsEven(int x) => (x & 1) == 0;

            var source = new Random().Next(100);
            var expValue = source * 2;

            _output.WriteLine($"Random source={source}, Check value={expValue}");
            Assert.True(IsEven(expValue));
        }
    }
}
