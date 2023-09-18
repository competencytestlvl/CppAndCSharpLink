using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSide
{
    public static class WrapperClass
    {
        #region dllImports
        // Target your c++ dll here -- add project reference to this dll in C# project also
        private const string _dllImportPath = @"..\..\..\..\x64\Debug\CppSide.dll";

        // Declare the c++ function you want to call using the DllImport attribute.
        // Specify the name of the c++ DLL and the calling convention (CallingConvention.Cdecl for C++).
        [DllImport(_dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Instantiate(int x);

        [DllImport(_dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(IntPtr t, int y);

        [DllImport(_dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Multiply(IntPtr t, int y);
        #endregion
    }
}
