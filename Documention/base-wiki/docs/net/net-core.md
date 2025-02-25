# .NET Core Documentation

## Introduction

Welcome to the .NET Core documentation. This guide will help you understand the basics of .NET Core and how to get started with it.

## Table of Contents

1. [Overview](#overview)
2. [Installation](#installation)
3. [Hello World Example](#hello-world-example)
4. [Resources](#resources)

## Overview

.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, and internet-connected applications.

## Installation

To install .NET Core, follow these steps:

1. Download the .NET Core SDK from the [official website](https://dotnet.microsoft.com/download).
2. Follow the installation instructions for your operating system.

## Hello World Example

Here is a simple "Hello World" example in .NET Core:

```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

To run this example:

1. Save the code in a file named `Program.cs`.
2. Open a terminal and navigate to the directory containing `Program.cs`.
3. Run the following commands:

```bash
dotnet new console
dotnet run
```

## Resources

- [.NET Core Documentation](https://docs.microsoft.com/dotnet/core/)
- [.NET Core GitHub Repository](https://github.com/dotnet/core)
