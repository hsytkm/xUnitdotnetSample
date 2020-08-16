using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    // Test classes must be public.
    public class TheoriesClassData
    {
        private static string GetYoubi(DateTime date) =>
            date.ToString("dddd", new CultureInfo("ja-JP"));

        private class TestDataClass : IEnumerable<object[]>
        {
            private readonly IList<object[]> _testData = new[]
            {
                new object[] { new DateTime(2000, 1, 1), "土曜日" },
                new object[] { new DateTime(2020, 8, 16), "日曜日" }
            }
            .ToList();

            public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        // テストメソッド
        [Theory]
        [ClassData(typeof(TestDataClass))]
        public void TestDayOfWeek(DateTime date, string youbi)
        {
            Assert.Equal(youbi, GetYoubi(date));
        }
    }
}
