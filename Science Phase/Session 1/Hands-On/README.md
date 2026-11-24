# 📘 Session 1 — Hands-On Solution

## Overview

This hands-on exercise reinforces the core OOP concepts covered in **Session 1: OOP Foundations, Memory Model & Encapsulation**. You build a simple `Book` class and use it in `Program.cs` to explore:

- Class instantiation with `new`
- Reference-type aliasing (Stack → Heap)
- Null safety (`?.` and `??` operators)
- Static vs. instance members

> **Project:** `Session1` — .NET 10 Console Application

---

## Project Structure

```
Hands-On/
├── Models/
│   └── Book.cs               ← The Book class (blueprint)
├── Program.cs                 ← Main entry point (TODOs 4–7)
├── Session1.csproj     ← Project file (.NET 10)
└── Session1.slnx       ← Solution file
```

---

## Step-by-Step Solution

### 🔹 TODOs 1–3 — The `Book` Model (`Models/Book.cs`)

Before tackling the TODOs in `Program.cs`, the `Book` class must be built with three TODOs:

```csharp
namespace Session1.Models
{
    public class Book
    {
        // TODO 1: Properties — Instance + Static
        public static int TotalBooksCreated { get; private set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // TODO 2: Constructor — Increment TotalBooksCreated
        public Book()
        {
            TotalBooksCreated++;
        }

        // TODO 3: PrintSummary() — Format Price with :F2
        public void PrintSummary()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Price: ${Price:F2}");
            Console.WriteLine($"Stock: {Stock}");
        }
    }
}
```

| Element | Explanation |
|:---|:---|
| `TotalBooksCreated` | A **static** property — belongs to the `Book` class itself, not to any single instance. `private set` ensures only the class can modify it. |
| `Title`, `Price`, `Stock` | **Instance** properties — each `Book` object gets its own copy on the Heap. |
| `Book()` constructor | Runs every time `new Book()` is called; increments the shared counter. |
| `PrintSummary()` | An **instance method** that prints the calling object's data. `:F2` formats `decimal` to exactly 2 decimal places. |

---

### 🔹 TODO 4: Create and Initialize a Book (`Program.cs`)

```csharp
// TODO 4: Instantiate b1 with 'new', set Title, Price, and Stock
Book b1 = new Book();
b1.Title = "Youtobia";
b1.Price = 200.00m;
b1.Stock = 12;
```

**What happens in memory:**

```
STACK                              HEAP
+---------------------------+     +---------------------------+
| b1: 0x00A4F810 (address) -+---->| Title: "Youtobia"         |
+---------------------------+     | Price: 200.00             |
                                  | Stock: 12                 |
                                  +---------------------------+

Static Area: TotalBooksCreated = 1
```

- `new Book()` allocates an object on the **Heap** and runs the constructor (incrementing `TotalBooksCreated` to **1**).
- The Stack variable `b1` stores the **memory address** (reference) pointing to that Heap object.
- The `m` suffix on `200.00m` marks the literal as `decimal` (required for financial precision).

---

### 🔹 TODO 5: Reference Aliasing Trap

```csharp
// TODO 5: Assign b2 = b1 and modify b2.Stock; then call b1.PrintSummary()
Book b2 = b1;
b2.Stock = 14;
b1.PrintSummary();
```

**What happens in memory:**

```
STACK                              HEAP
+---------------------------+     +---------------------------+
| b1: 0x00A4F810 -----------+---->| Title: "Youtobia"         |
+---------------------------+     | Price: 200.00             |
| b2: 0x00A4F810 -----------+---->| Stock: 14  ← changed!    |
+---------------------------+     +---------------------------+
                                  (same object — one copy!)
```

**Output:**
```
Title: Youtobia
Price: $200.00
Stock: 14
```

> **Key Concept:** `b2 = b1` does **NOT** copy the object. It copies the **address**. Both `b1` and `b2` point to the **same** Heap object. When `b2.Stock = 14` runs, it modifies the one-and-only object — so `b1.PrintSummary()` prints `Stock: 14`, not `12`.

This is the **Reference Assignment Trap (Aliasing)** discussed in Section 4 of the lecture.

---

### 🔹 TODO 6: Null Safety Operators

```csharp
// TODO 6: Declare Book? missingBook = null; test ?.PrintSummary() and ?? fallback
Book? missingBook = null;
missingBook?.PrintSummary();
Console.WriteLine(missingBook?.Title ?? "No Book Selected");
```

**What happens:**

| Expression | Result | Why |
|:---|:---|:---|
| `Book? missingBook = null;` | `missingBook` holds `null` (points nowhere) | The `?` after `Book` signals nullable reference intent |
| `missingBook?.PrintSummary();` | Does **nothing** — no crash | `?.` (null-conditional) short-circuits: if `missingBook` is `null`, the entire call is skipped |
| `missingBook?.Title` | Evaluates to `null` | Same null-conditional logic |
| `?? "No Book Selected"` | Falls back to `"No Book Selected"` | `??` (null-coalescing) returns the left side if non-null, otherwise the right side |

**Output:**
```
No Book Selected
```

> **Key Concept:** Without `?.`, calling `missingBook.PrintSummary()` would crash with a `NullReferenceException`. The `?.` and `??` operators provide **safe null handling** without needing `if (missingBook != null)` checks everywhere.

---

### 🔹 TODO 7: Static Members in Action

```csharp
// TODO 7: Create one more Book instance and print Book.TotalBooksCreated
Book b3 = new Book();
Console.WriteLine($"TotalBooksCreated: {Book.TotalBooksCreated}");
```

**What happens:**

- `new Book()` runs the constructor again → `TotalBooksCreated` increments from **1** to **2**.
- Note: `missingBook` was declared `null` — `new Book()` was never called for it, so it didn't increment the counter.
- `TotalBooksCreated` is accessed via the **class name** (`Book.TotalBooksCreated`), not through an instance variable — because it's a **static** member.

**Output:**
```
TotalBooksCreated: 2
```

---

## Complete Program Output

When you run the project, the full console output is:

```
Title: Youtobia
Price: $200.00
Stock: 14
No Book Selected
TotalBooksCreated: 2
```

---

## How to Run

```bash
cd "Hands-On"
dotnet run
```

> Requires **.NET 10 SDK** or later.
