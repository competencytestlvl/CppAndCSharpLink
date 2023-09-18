using CSharpSide;
using System.Runtime.InteropServices;

namespace CsharpAndCppLink
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region callDllMethods

            IntPtr i = WrapperClass.Instantiate(2);
            int total = WrapperClass.Add(i, 3);

            int total2 = WrapperClass.Multiply(i, 10);
            Console.WriteLine("Total Add method: " + total + ", Total Multiply method: " + total2);

            #endregion
        }
    }
}