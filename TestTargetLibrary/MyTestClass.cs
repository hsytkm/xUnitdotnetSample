using System;

namespace TestTargetLibrary
{
    public interface IMyClass
    {
        int IntMaxProperty { get; }
        int GetIntMinMethod();
    }

    /*internal*/ class MyInternalClass : IMyClass
    {
        public int IntMaxProperty { get; } = int.MaxValue;
        public int GetIntMinMethod() => int.MinValue;
    }
}
