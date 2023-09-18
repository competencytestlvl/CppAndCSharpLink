# CppAndCSharpLink

Simple demo of using C# code to call C++ code and methods


## Getting Started

### Pre-requisites:

1. Visual Studio
2. .Net Framework
3. Compatible compiler

## Usage
### Step 1: Create the C++ Library
Create a new C++ project in Visual Studio. Choose "Dynamic-Link Library (DLL)" as the project type.

### Step 2: Add a header file `YourHeaderFile.h`
	
	#pragma once
	class Sample {
		int x;
	public:
		Sample(int x);
		int add(int x);
		int multiply(int x);
	};

	// Helper methods for constructor and other method
	extern "C" _declspec(dllexport) void* Instantiate(int x) {
		return (void*) new Sample(x);
	}

	extern "C" _declspec(dllexport) int Add(Sample* t, int y) {
		return t->add(y);
	}

	extern "C" _declspec(dllexport) int Multiply(Sample* t, int y) {
		return t->multiply(y);
	}
	
	
### Step 3: Add a C++ source file `YourSourceFile.cpp`

	
	#include "pch.h"
	#include "sample.h"

	// Example Constructor
	Sample::Sample(int x) {
		this->x = x;
	}

	// Example methods below
	int Sample::add(int y) {
		return this->x + y;
	}

	int Sample::multiply(int y) {
		return this->x + y;
	}
	
	
### Step 4: Adjust Visual Studio Configuration Settings

- To enable C# code to interact with the c++ code:

Right Click on the C# project > Properties > Configuration Properties > Advanced > Common Language Runtime Support > Select **Common Language Runtime Support (/clr)**
	
	
### Step 5: Build the C++ project. 
This will generate a DLL (e.g., **YourDllName.dll**) in the output directory
	

### Step 6: Create a C# Project


### Step 7: Include Relevant namespaces to C# project
	
	// Write this code on top of your c# source file
	
	using System.Runtime.InteropServices;
	

### Step 8: Include Relevant namespaces to C# project
	1. Create a wrapper class to encapsulate all the dll methods
	2. Declare the C++ function you want to call using the DllImport attribute. 
	3. Specify the name of the C++ DLL and the calling convention (CallingConvention.Cdecl for C++).
	4. Define some C# methods that wraps the import c++ functions

	
	public static class WrapperClass
    {
        #region dllImports
        // Target the cpp dll here -- add project reference to this dll in C# project also
        private const string _dllImportPath = @"filePathofYourDll";

        // Declare the C++ function you want to call using the DllImport attribute.
        // Specify the name of the C++ DLL and the calling convention (CallingConvention.Cdecl for C++).
        [DllImport(_dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Instantiate(int x);

        [DllImport(_dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(IntPtr t, int y);

        [DllImport(_dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Multiply(IntPtr t, int y);
        #endregion
    }
	

### Step 9: Call the C++ function using the wrapper methods in a separate main class
	
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
	
	
### Step 10: Build and run your C# project

## Note
- This serves as a minimalistic and simple demonstration of C# and C++ code interaction
- Extra caution should be taken by the user to ensure type safety
