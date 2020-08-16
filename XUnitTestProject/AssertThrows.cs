using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    // Test classes must be public.
    public class AssertThrows
    {
        [Fact]
        public void Throws()
        {
            static void NotImpl() => throw new NotImplementedException();
            static int Div(int x, int y) => x / y;

            Assert.Throws<NotImplementedException>(NotImpl);
            var ex = Assert.ThrowsAny<Exception>(NotImpl);      // 基底クラス

            Assert.Throws<DivideByZeroException>(() => Div(1, 0));
        }

        private static async Task<string> ReadAllTextAsync(string file)
        {
            if (file is null) throw new ArgumentNullException(nameof(file));
            if (!File.Exists(file)) throw new FileNotFoundException(file);

            using var sr = new StreamReader(file);
            return await sr.ReadToEndAsync();
        }

        [Fact]
        public async Task ThrowsAsync()
        {
            var ex0 = await Assert.ThrowsAsync<ArgumentNullException>(() => ReadAllTextAsync(null));
            var ex1 = await Assert.ThrowsAsync<FileNotFoundException>(() => ReadAllTextAsync(""));
        }

        //[Fact]
        //public async Task ReadAllTextReturnsFileContent()
        //{
        //    var s = await ReadAllTextAsync("test");
        //    Assert.Equal("hogehoge", s);
        //}

    }
}
