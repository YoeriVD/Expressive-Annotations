using System;

namespace ExpressiveAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class CantTouchThisAttribute : Attribute
    {
        public Stop Stop { get; set; }

        public CantTouchThisAttribute(Stop stop)
        {
            Stop = stop;
        }
    }
}
