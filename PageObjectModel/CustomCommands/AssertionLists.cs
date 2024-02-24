using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.PageObjectModel.CustomCommands
{
    public static class AssertionLists
    {
        public static void ShouldBeTrue(this bool actual, string message)
        {
            Assert.IsTrue(actual, $"{message} expected true: actual {actual}");
            Console.WriteLine($"{message} expected true: actual {actual}");
        }

        public static void ShouldBeFalse(this bool actual, string message)
        {
            Assert.IsFalse(actual, $"{message} expected false: actual {actual}");
            Console.WriteLine($"{message} expected false: actual {actual}");
        }
        public static void ShouldBeEqual<T>(this T actual, T expected, string message)
        {
            Assert.AreEqual(expected, actual, $"{message} expected: {expected}, actual: {actual}");
            Console.WriteLine($"{message} expected: {expected}, actual: {actual}");
        }

    }
}
