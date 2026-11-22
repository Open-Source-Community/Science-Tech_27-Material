

# Introduction to C#

> **Welcome!** Dive into our interactive Canva slides and the accompanying video explanation to get the most out of this C# introduction.

**Explore the Canva slide deck:**
[Canva Slides](https://canva.link/7sz3e5wmsh5i5l6)

**Watch the detailed explanation video:**
[Explanation Video](https://drive.google.com/drive/folders/1a8jUFAvoMcmvQ9OAvB0GVn4zeqBTB7A6?usp=sharing)



A short, practical introduction to C# for committee members.

**C#** (pronounced "C sharp") is a modern, object-oriented, strongly typed language created by Microsoft. It runs on the **.NET** platform and is used for web apps, desktop apps, mobile apps, games (Unity), APIs, and more.

---

## Part 1: How C# Code Becomes Machine Code

Your computer's CPU only understands machine code. C# gets there in several steps:

```
C# Source Code (.cs)
        │
        ▼
   C# Compiler (Roslyn)
        │
        ▼
 IL Code + Metadata  (.dll / .exe  = "Assembly")
        │
        ▼
 CLR (Common Language Runtime)
        │
        ▼
   JIT Compiler
        │
        ▼
 Machine Code  →  CPU executes it
```

### 1. Source Code (`.cs`)
The human-readable code you write.

```csharp
Console.WriteLine("Hello, World!");
```

### 2. C# Compiler (Roslyn)
Roslyn is the compiler that comes with the .NET SDK. It:
- Checks your syntax and types (errors appear here, at compile time).
- Converts your code into **IL**, not directly into machine code.

### 3. IL (Intermediate Language)
- Also called **CIL** or **MSIL**.
- A low-level, CPU-independent instruction set.
- Because it is not tied to any CPU or OS, the same compiled file can run on Windows, Linux, and macOS.

### 4. Assembly (`.dll` or `.exe`)
The output file of compilation. It contains:
- The **IL code**
- **Metadata** (descriptions of your types, methods, and references to other assemblies)

### 5. CLR (Common Language Runtime)
The engine that runs your program. It is responsible for:
- Loading the assembly
- **Memory management** (Garbage Collector frees unused objects automatically)
- Type safety and security checks
- Exception handling
- Starting the JIT compiler

### 6. JIT (Just-In-Time) Compiler
- Converts IL into **machine code** at runtime, right before a method runs for the first time.
- The result is cached, so the method is not recompiled on later calls.
- The machine code is specific to the CPU the program is running on.

### 7. Execution
The CPU runs the machine code and your program produces output.

> **Note:** .NET also supports **AOT (Ahead-of-Time)** compilation, which produces machine code at build time instead of at runtime. This gives faster startup but is less flexible.

### Quick Summary

| Part | Role |
|------|------|
| Source code | What you write |
| Roslyn | Compiles C# to IL |
| IL | CPU-independent intermediate code |
| Assembly | `.dll`/`.exe` file holding IL + metadata |
| CLR | Runtime that manages and runs the program |
| JIT | Turns IL into machine code while running |

---

## Part 1.5: Code Organization: Solutions, Projects, and Namespaces

Before writing more code, it helps to know how a real C# application is organized. There are three levels, from largest to smallest:

```
Solution  (.sln)          groups related projects
 └── Project  (.csproj)   compiles into ONE assembly (.dll / .exe)
      └── Namespace        groups types by name inside the code
           └── Class, struct, enum, interface...
```

### 1. Solution (`.sln`)

A **solution** is only a **container** that groups related projects, so you can open, build, and test them together.
- It contains no code and produces no output of its own.
- It exists for your tools (the IDE). The CLR never sees it.

A typical solution splits the work into several projects:

```
Shop.sln
 ├── Shop.App      (console or web app, the entry point)
 ├── Shop.Core     (class library: models and business logic)
 └── Shop.Tests    (test project)
```

### 2. Project (`.csproj`)

A **project** is the unit that gets compiled. It is a folder with an XML file (`.csproj`) and your `.cs` files.
- **One project builds into one assembly**: a `.dll` (library) or an `.exe` (application). This is the Roslyn step from the compilation process in Part 1.
- Building creates a `bin/` folder (the output, including the `.dll`) and an `obj/` folder (temporary files).

Common project types: console app, class library, web API, and test project.

Projects can **reference** each other. If `Shop.App` references `Shop.Core`, it can use the **public** types inside it.

### 3. Namespace

A **namespace** is a named container for your types (classes, enums, and so on). It does two things:
- **Organizes** code logically, for example `Shop.Models` and `Shop.Services`.
- **Avoids name clashes.** Two classes can both be called `Order` if they live in different namespaces.

```csharp
namespace Shop.Models;          // file-scoped namespace (modern style)

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

The older style from section 2.1 wraps the types in braces instead:

```csharp
namespace Shop.Models
{
    public class Product { /* ... */ }
}
```

Things to remember:
- `using System;` works the same way: `Console` lives in the `System` namespace.
- A namespace is a **code-level** idea. It is not a file or a folder, although by convention it matches the folder path.
- One namespace can be spread over many files, and even over several assemblies.
- Modern .NET adds common `using` lines automatically (*implicit usings*), such as `System` and `System.Collections.Generic`. That is why `List<T>` works in the examples without a `using`.

### Putting it together

`Shop.Core/Product.cs` holds the `Product` class from above in `namespace Shop.Models;`. `Shop.App/Program.cs` uses it:

```csharp
using Shop.Models;

Product p = new Product { Name = "Pen", Price = 5m };
Console.WriteLine($"{p.Name} costs {p.Price}");
```

A class must be `public` to be used from another project.

### Quick Summary

| Part | What it is | Output |
|------|------------|--------|
| Solution | Container of projects | None (for tools only) |
| Project | Folder + `.csproj` with code | One assembly (`.dll` / `.exe`) |
| Namespace | Named group of types in code | None (just naming) |

---

## Part 2: C# Syntax Basics

### 2.1 Your First Program

```csharp
Console.WriteLine("Hello, World!");
```

Modern C# allows this "top-level statements" style. The older, full form looks like this:

```csharp
using System;

namespace MyApp
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

Key points:
- Every statement ends with a semicolon `;`
- Code blocks are wrapped in curly braces `{ }`
- C# is **case-sensitive** (`name` and `Name` are different)
- Comments: `// single line` and `/* multi line */`

### 2.2 Variables and Data Types

A variable stores a value. In C#, every variable has a **type**.

```csharp
int age = 20;                 // whole number
double price = 19.99;         // decimal number
float temperature = 36.6f;    // smaller decimal (needs f)
decimal money = 100.50m;      // precise decimal, good for money (needs m)
bool isStudent = true;        // true or false
char grade = 'A';             // single character
string name = "Moaaaz";       // text
```

**Common types**

| Type | Description | Example |
|------|-------------|---------|
| `int` | Whole numbers | `42` |
| `long` | Larger whole numbers | `9000000000L` |
| `double` | Decimal numbers | `3.14` |
| `decimal` | High-precision decimals | `10.5m` |
| `bool` | True / false | `true` |
| `char` | One character | `'x'` |
| `string` | Text | `"Hello"` |

**Type inference with `var`**: the compiler figures out the type for you.

```csharp
var city = "Cairo";   // string
var count = 10;       // int
```

**Constants**: values that never change.

```csharp
const double Pi = 3.14159;
```

**String interpolation**: put variables inside text.

```csharp
string name = "Sara";
int age = 22;
Console.WriteLine($"My name is {name} and I am {age} years old.");
```

### 2.3 Input and Output

```csharp
Console.Write("Enter your name: ");       // no new line
string name = Console.ReadLine();         // read text
Console.WriteLine($"Hello, {name}!");     // with new line
```

Converting text to a number:

```csharp
Console.Write("Enter your age: ");
int age = int.Parse(Console.ReadLine());
```

### 2.4 Operators

```csharp
// Arithmetic
int a = 10, b = 3;
Console.WriteLine(a + b);   // 13
Console.WriteLine(a - b);   // 7
Console.WriteLine(a * b);   // 30
Console.WriteLine(a / b);   // 3  (integer division)
Console.WriteLine(a % b);   // 1  (remainder)

// Comparison  (result is bool)
a == b    // equal
a != b    // not equal
a > b     // greater than
a < b     // less than
a >= b    // greater or equal
a <= b    // less or equal

// Logical
true && false   // AND  -> false
true || false   // OR   -> true
!true           // NOT  -> false

// Shortcuts
a++;       // a = a + 1
a--;       // a = a - 1
a += 5;    // a = a + 5
```

### 2.5 If Conditions

```csharp
int score = 75;

if (score >= 90)
{
    Console.WriteLine("Excellent");
}
else if (score >= 60)
{
    Console.WriteLine("Pass");
}
else
{
    Console.WriteLine("Fail");
}
```

**Ternary operator** (a short if/else):

```csharp
string result = score >= 60 ? "Pass" : "Fail";
```

### 2.6 Switch

Use `switch` when comparing one value against many options.

```csharp
int day = 3;

switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    default:
        Console.WriteLine("Another day");
        break;
}
```

Modern **switch expression**:

```csharp
string dayName = day switch
{
    1 => "Monday",
    2 => "Tuesday",
    3 => "Wednesday",
    _ => "Another day"
};
```

### 2.7 Loops

**`for`**: use when you know how many times to repeat.

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);   // 0 1 2 3 4
}
```

**`while`**: repeat while a condition is true.

```csharp
int n = 0;
while (n < 5)
{
    Console.WriteLine(n);
    n++;
}
```

**`do...while`**: runs at least once, then checks the condition.

```csharp
int x = 0;
do
{
    Console.WriteLine(x);
    x++;
} while (x < 5);
```

**`foreach`**: go through every item in a collection.

```csharp
string[] fruits = { "Apple", "Banana", "Orange" };

foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
```

**Loop control**
- `break`: exit the loop immediately
- `continue`: skip to the next iteration

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 3) continue;   // skip 3
    if (i == 7) break;      // stop at 7
    Console.WriteLine(i);
}
```

### 2.8 Arrays and Lists

**Array**: fixed size.

```csharp
int[] numbers = { 10, 20, 30, 40 };
Console.WriteLine(numbers[0]);       // 10 (index starts at 0)
Console.WriteLine(numbers.Length);   // 4
```

**List**: flexible size.

```csharp
List<string> names = new List<string>();
names.Add("Ali");
names.Add("Mona");
names.Remove("Ali");
Console.WriteLine(names.Count);      // 1
```

**Dictionary**: key/value pairs.

```csharp
Dictionary<string, int> ages = new Dictionary<string, int>();
ages["Ali"] = 20;
ages["Mona"] = 22;
Console.WriteLine(ages["Mona"]);     // 22
```

### 2.9 Methods

A method is a reusable block of code.

```csharp
static int Add(int a, int b)
{
    return a + b;
}

static void SayHello(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

// Calling them
int sum = Add(5, 3);       // 8
SayHello("Committee");
```

- `static` : belongs to the class, not an object (for now, just use it)
- `int` / `void` : return type (`void` means returns nothing)
- Parameters are the inputs inside the parentheses

### 2.10 Classes and Objects (OOP Basics)

C# is object-oriented. A **class** is a blueprint; an **object** is a thing built from it.

```csharp
class Student
{
    // Properties
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor
    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Method
    public void Introduce()
    {
        Console.WriteLine($"Hi, I'm {Name} and I'm {Age}.");
    }
}

// Using it
Student s = new Student("Omar", 21);
s.Introduce();
```

The four pillars of OOP (to be covered in detail later):
1. **Encapsulation**: hide data, expose it through controlled access
2. **Inheritance**: a class reuses another class's members
3. **Polymorphism**: the same call behaves differently by object type
4. **Abstraction**: expose only what is necessary

### 2.11 Exception Handling

Handle errors without crashing the program.

```csharp
try
{
    int number = int.Parse("abc");   // will fail
}
catch (FormatException)
{
    Console.WriteLine("That is not a valid number.");
}
finally
{
    Console.WriteLine("This always runs.");
}
```

---

## Part 3: Advanced Topics (Where to Go Next)

These are not covered here. They are the next steps for anyone who wants to go deeper:

- **Delegates and Events**: variables that hold methods; the basis of callbacks and event-driven code
- **Lambda Expressions**: short inline anonymous functions (`x => x * 2`)
- **LINQ (Language Integrated Query)**: query collections and databases with clean, readable syntax
- **Generics**: write type-safe code that works with any type (`List<T>`)
- **Interfaces and Abstract Classes**: define contracts and shared behavior
- **Async / Await and Tasks**: write non-blocking, asynchronous code
- **Multithreading and Parallel Programming**
- **Nullable Reference Types and Pattern Matching**
- **Records, Structs, and Enums**
- **Extension Methods**
- **Reflection and Attributes**
- **File I/O and Serialization (JSON)**
- **Entity Framework Core**: work with databases using C# objects
- **ASP.NET Core**: build web apps and APIs
- **Dependency Injection**
- **Unit Testing**

### Deep Dive: The `=>` Operator

The arrow `=>` is read as **"goes to"** (or "lambda arrow"). It appears in C# in three main places, and each one means something different. Do not confuse it with `>=` (greater or equal) or `=` (assignment).

#### 1. Lambda expressions

A lambda is a short, nameless method written inline. The left side is the **parameters**, the right side is the **body**. Compare a normal method with a lambda that does the same thing:

```csharp
// Normal method
static int Double(int x)
{
    return x * 2;
}

// The same logic as a lambda (no name, no return keyword):
//     x => x * 2
```

Lambdas are mostly written **directly inside a method call**, to tell that method what to do with each item:

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

// Keep only the even numbers
var evens = numbers.Where(n => n % 2 == 0);       // 2 4 6

// Transform each number
var squares = numbers.Select(n => n * n);         // 1 4 9 16 25 36

// Find the first number bigger than 3
int firstBig = numbers.Find(n => n > 3);          // 4

// Do something with each item
numbers.ForEach(n => Console.WriteLine(n));
```

Read `n => n % 2 == 0` as: "for each `n`, check if `n % 2 == 0`."

**Several parameters** need parentheses:

```csharp
List<string> names = new List<string> { "Mona", "Ali", "Omar" };

// Sort by name length (a and b are two names being compared)
names.Sort((a, b) => a.Length - b.Length);        // Ali Mona Omar
```

**Statement lambda**: when the body needs several lines, use braces:

```csharp
numbers.ForEach(n =>
{
    if (n % 2 == 0)
        Console.WriteLine($"{n} is even");
    else
        Console.WriteLine($"{n} is odd");
});
```

A lambda can also be stored in a variable. That uses delegates, which are listed in the topics above.

#### 2. Expression-bodied members

When a method, property, or constructor is just **one expression**, `=>` replaces the braces and the `return` keyword.

```csharp
class Circle
{
    private string _name = "circle";

    public double Radius { get; set; }

    // Read-only property: recalculated every time it is read
    public double Area => Math.PI * Radius * Radius;

    // Method
    public double Diameter() => Radius * 2;

    // Property with get and set
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    // Constructor
    public Circle(double radius) => Radius = radius;
}
```

The long form of the method above would be:

```csharp
public double Diameter()
{
    return Radius * 2;
}
```

Both do exactly the same thing. This is only shorter syntax.

#### 3. Switch expression arms

In a **switch expression** (see section 2.6), `=>` separates each pattern from the value it returns.

```csharp
int score = 75;

string result = score switch
{
    >= 90 => "Excellent",
    >= 60 => "Pass",
    _     => "Fail"
};
```

Here `=>` means "if the pattern on the left matches, the result is the value on the right".

#### Rules to remember (lambdas and expression-bodied members)

**1. The expression after `=>` replaces the body.**
- If the code returns a value, the value of the expression is returned automatically. Do not write `return`.
- If the code returns nothing (`void`), the expression is simply executed.

```csharp
// Returns a value: no 'return' keyword
public int Double(int x) => x * 2;
numbers.Where(n => n > 3);

// Returns nothing: the expression is just run
public void SayHi() => Console.WriteLine("Hi!");
numbers.ForEach(n => Console.WriteLine(n));
```

The right side must be a **single expression**: a calculation, a method call, an assignment, or a ternary (`x > 0 ? "pos" : "neg"`). Statements like `if`, `for`, and `while` are not expressions, so they cannot go directly after the arrow.

**2. Use braces when the body has more than one statement.**
- In a **lambda**, add braces. This is called a statement lambda, and if it returns a value you must write `return` yourself.

```csharp
names.Sort((a, b) =>
{
    int diff = a.Length - b.Length;
    return diff;
});
```

- In an **expression-bodied member** (method, property, constructor), you cannot put braces after `=>`. If the body needs more than one statement, drop the arrow and use the normal block body.

```csharp
// Not allowed:  public double Diameter() => { ... }

// Use the normal form instead
public double Diameter()
{
    double result = Radius * 2;
    return result;
}
```

| | One expression | Several statements |
|---|---|---|
| Lambda | `x => x * 2` | `x => { ...; return ...; }` |
| Expression-bodied member | `int Double(int x) => x * 2;` | Not possible: use a normal `{ }` body without `=>` |

#### Quick summary

| Where | Meaning | Example |
|-------|---------|---------|
| Lambda expression | Parameters "go to" the body | `x => x * 2` |
| Expression-bodied member | One-line method or property | `public int Double() => 2 * Value;` |
| Switch expression | Pattern "gives" a result | `1 => "Monday"` |

---

## Useful Resources

- Official docs: https://learn.microsoft.com/dotnet/csharp/
- Microsoft Learn C# path: https://learn.microsoft.com/training/paths/get-started-with-csharp/
- Try C# online: https://dotnetfiddle.net

---

*Prepared for committee members. Questions are welcome!*
