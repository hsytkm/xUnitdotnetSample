using System;
using TestTargetLibrary;
using Xunit;

namespace XUnitTestProject
{
    // Test classes must be public.
    public class ReferenceProject
    {
        private readonly IMyClass _myClass;

        public ReferenceProject(IMyClass myClass)
        {
            // 依存関係を Startup.cs で記述してインジェクション
            _myClass = myClass;
        }

        [Fact]
        public void InjectInterfaceTest()
        {
            Assert.Equal(int.MaxValue, _myClass.IntMaxProperty);
            Assert.Equal(int.MinValue, _myClass.GetIntMinMethod());
        }

    }
}
