using System;
using System.Collections.Generic;

public interface ICompiler
{
    bool IsFileSupported(string name);
    void PrintCommand(string name);
}

public class PythonCompiler : ICompiler
{
    public bool IsFileSupported(string name)
    {
        return name.EndsWith(".py");
    }

    public void PrintCommand(string name)
    {
        Console.WriteLine($"python {name}");
    }
}

public class CSharpCompiler : ICompiler
{
    public bool IsFileSupported(string name)
    {
        return name.EndsWith(".cs");
    }

    public void PrintCommand(string name)
    {
        Console.WriteLine($"csc {name}");
    }
}

public class JavaCompiler : ICompiler
{
    public bool IsFileSupported(string name)
    {
        return name.EndsWith(".java");
    }

    public void PrintCommand(string name)
    {
        Console.WriteLine($"javac {name}");
    }
}

public class CompilerManager
{
    public static void Compile(List<ICompiler> compilers, string fileName)
    {
        foreach (var compiler in compilers)
        {
            if (compiler.IsFileSupported(fileName))
            {
                compiler.PrintCommand(fileName);
                return;
            }
        }
        Console.WriteLine("Unsupported file format.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<ICompiler> compilers = new List<ICompiler>
        {
            new PythonCompiler(),
            new CSharpCompiler(),
            new JavaCompiler()
        };

        // Приклад використання:
        CompilerManager.Compile(compilers, "source.py");
        CompilerManager.Compile(compilers, "source.cs");
        CompilerManager.Compile(compilers, "source.java");
        CompilerManager.Compile(compilers, "source.cpp"); // Unsupported file format.
    }
}

