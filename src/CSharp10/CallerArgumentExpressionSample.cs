using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace CSharp10
{
    public static class Ensure
    {
        public static void ItIsNotEmpty(int[] array, [CallerArgumentExpression("array")] string arrayExpression = null!)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), $"Argument ('{arrayExpression}') was null.");
            if (array.Length == 0)
                throw new ArgumentException($"Argument ('{arrayExpression}') was empty.", nameof(array));
        }
    }

    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class CallerArgumentExpressionSample
    {
        private static void TraceMessage(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine("message: " + message);
            Console.WriteLine("member name: " + memberName);
            Console.WriteLine("source file path: " + sourceFilePath);
            Console.WriteLine("source line number: " + sourceLineNumber);
        }

        public static void Main(string[] args)
        {
            // old api CallerXXXAttribute
            TraceMessage("Test message");

            // only C# 10 compiler

            //var array = new int[] { 1, 2, 3 };
            //int[] array = null!;
            //Ensure.ItIsNotEmpty(array); // case 1

            //Ensure.ItIsNotEmpty(new int[]{}); // case 2

            Ensure.ItIsNotEmpty(GetArray()); // case 3

            int[] GetArray()
            {
                return Array.Empty<int>();
            }
        }
    }
}