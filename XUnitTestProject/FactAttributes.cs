using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    // Test classes must be public.
    public class FactAttributes
    {
        [Fact]
        public void Simple()
        {
            Assert.Equal(3, (1 + 2));
        }

        [Fact(DisplayName = "1+1=2 dayo!")]
        public void DisplayName()
        {
            Assert.Equal(2, (1 + 1));
        }

        [Fact(Skip = "Skip this.")]
        public void Skip()
        {
            Assert.True(false);
        }

        [Fact(Timeout = 100)]
        public async Task Timeout()
        {
            await Task.Delay(50);
            Assert.True(true);
        }
    }
}
