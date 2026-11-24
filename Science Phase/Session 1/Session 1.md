## 1. Welcome & The Big Picture

> 📊 **Canva Slides:** [Session 1 – Canva Presentation](https://www.canva.com/design/DAHbx0LhHKU/P_aO2dl2QLWPRXufF3InQQ/edit?utm_content=DAHbx0LhHKU&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)

Welcome to your software engineering journey! In this session, you are taking your first steps into **Object-Oriented Programming (OOP)** using **C#**, learning how to model real-world entities in memory, understand how .NET manages them under the hood, and protect business rules through encapsulation.

Before we write code, let's understand why OOP exists.

### Why OOP? The Problem with Procedural Code
Imagine you are building a store without OOP. You might have individual variables scattered everywhere:
```csharp
string product1Name = "Laptop";
decimal product1Price = 1200.00m;
int product1Stock = 5;

string product2Name = "Keyboard";
decimal product2Price = 80.00m;
int product2Stock = 20;
```
Now imagine your store grows to **10,000 products**. You would need 30,000 disconnected variables! What happens if you want to pass a product into a function? You would have to pass every variable individually. If you change a price, how do you make sure the stock isn't corrupted?

**Object-Oriented Programming solves this chaos.** It allows us to bundle **data (state)** and the **actions that operate on that data (behavior)** together into a single, organized unit called an **Object**.

```
┌───────────────────────────────────────────────────────────┐
│                        OBJECT                        │
│                                                      │
│   State (Data / What it knows):                      │
│   • Name: "Laptop"                                   │
│   • Price: $1200.00                                  │
│   • Stock: 5                                         │
│                                                      │
│   Behavior (Methods / What it does):                 │
│   • DisplayDetails()                                 │
│   • AdjustStock()                                    │
└───────────────────────────────────────────────────────────┘
```

---

## 2. Core Concepts: Blueprint vs. Real-World Instance

### The Class: The Blueprint
A **class** is a blueprint, template, or recipe. It defines what attributes and actions an object *will have*, but it does not represent any specific item itself.
- Analogy: An architectural blueprint of a house is **not** a house. You cannot live inside a blueprint, sleep in its bedrooms, or open its front door.

### The Object: The Instance
An **object** is the actual physical house built from that blueprint. It occupies memory in the computer.
- You can use one single blueprint to build **hundreds of distinct houses**, each with its own wall color, occupant, and furniture.

- **Class: Product (Blueprint)**
  - *Instantiated via `new Product()`* → **Object 1 in Memory**
    - **Id:** PROD-001
    - **Name:** Laptop
    - **Price:** $1899.99
  - *Instantiated via `new Product()`* → **Object 2 in Memory**
    - **Id:** PROD-002
    - **Name:** Mechanical Keyboard
    - **Price:** $129.50

---

## 3. C# Syntax: Defining Your First Class

Let's look at how we declare a class in C#:

```csharp
namespace NexusCommerce.Models
{
    // The 'class' keyword defines a new custom type
    public class Product
    {
        // 1. Properties (State / Data)
        // 'string' is text; 'decimal' is precision money; 'int' is whole numbers
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // 2. Methods (Behavior / Actions)
        // 'void' means this method performs an action but returns no value
        public void DisplayDetails()
        {
            Console.WriteLine($"[Product #{Id}] {Name} - ${Price:F2} | In Stock: {StockQuantity}");
        }
    }
}
```

### Breaking Down the Syntax:
1. `namespace`: A container that groups related classes together to avoid name clashes (e.g., `NexusCommerce.Models`). Remember that a namespace only exists once at least one `.cs` file declares it.
2. `public`: An access modifier meaning anyone in our project (or referencing projects) can see and use this class.
3. `{ get; set; }`: C# auto-properties. A shorthand way to let outside code read (`get`) and update (`set`) the data.
4. `string.Empty`: An empty string (`""`), preventing annoying `null` reference warnings in modern C#.
5. `:F2`: A formatting string that prints decimals with exactly two decimal places (e.g., `$1899.99`).

---

## 4. How Objects Live in Memory: Stack vs. Heap

This is one of the most crucial concepts for a beginner to grasp. In C# and .NET, memory is divided into two primary zones:

1. **The Stack**: Fast, temporary memory. It holds method local variables and value types.
2. **The Heap**: Large, general-purpose memory. It holds **all reference-type objects** created with `new`.

When you write:
```csharp
Product laptop = new Product();
laptop.Id = "PROD-001";
laptop.Name = "Developer Laptop";
laptop.Price = 1899.99m;
laptop.StockQuantity = 12;
```

Here is what happens under the hood:
1. `Product laptop`: A variable named `laptop` is allocated on the **Stack**. At this exact moment, it doesn't hold product data; it holds an empty pointer (`null`).
2. `new Product()`: The `new` keyword requests a block of memory on the **Heap** large enough to store `Id`, `Name`, `Price`, and `StockQuantity`.
3. `=`: The memory address (reference) of that Heap block is stored inside the Stack variable `laptop`.

```
STACK (Pointers & Locals)             HEAP (Actual Objects)
+----------------------------+        +----------------------------------+
| variable: laptop           |        | Object Header & Type Pointer     |
| value: 0x00A4F810 (Addr) --+------->| Id: "PROD-001"                   |
+----------------------------+        | Name: "Developer Laptop"         |
                                      | Price: 1899.99                   |
                                      | StockQuantity: 12                |
                                      +----------------------------------+
```

### The Reference Assignment Trap (Aliasing)
What happens when you assign one object variable to another?
```csharp
Product p1 = new Product();
p1.Price = 1899.99m;

Product p2 = p1; // NOTE: This does NOT copy the object!
p2.Price = 1799.99m;

Console.WriteLine(p1.Price); // Outputs: 1799.99!
```

> [!WARNING]
> **Why did `p1.Price` change?**  
> `p2` did **not** make a new product. It simply copied the **Heap address**. Both `p1` and `p2` point to the exact same memory box on the Heap! Changing the object through `p2` immediately affects what `p1` sees.

### Null Safety & The Null-Conditional Operator (`?.`)
Because reference variables default to `null` when uninitialized, calling a method or reading a property on `null` crashes your program with a `NullReferenceException`.
- Use `?.` (null-conditional operator) to safely access members only if the reference is not `null`:
  ```csharp
  Product? item = null;
  item?.DisplayDetails(); // Does nothing instead of crashing!
  ```
- Use `??` (null-coalescing operator) to provide a fallback value:
  ```csharp
  string displayName = item?.Name ?? "Unknown Product";
  ```

---

## 5. Value Types vs. Reference Types (Why `class` Is Better Than `struct` for Entities)

| Characteristic | Value Types (`int`, `double`, `decimal`, `bool`, `struct`) | Reference Types (`class`, `string`, `record`, arrays) |
| :--- | :--- | :--- |
| **Storage Location** | Directly on the Stack (or inline inside a containing Heap object) | Actual data on Heap; memory pointer on Stack |
| **Assignment (`a = b`)**| Copies the actual value | Copies the memory address reference |
| **Default Value** | `0`, `false`, `0.0` (or all fields zeroed out for `struct`) | `null` (points nowhere) |
| **Inheritance** | Cannot inherit from another `struct` or `class` | Supports full class inheritance hierarchies |
| **Memory Cleanup** | Reclaimed immediately when method exits | Reclaimed later by the **Garbage Collector (GC)** |

### Why Use `class` Instead of `struct` Here?
C# also has the `struct` keyword, which looks similar to `class` in syntax—and coming from C/C++, beginners often wonder why we don't just use `struct` for `Product` or `Customer`. For domain entities, **`class` is vastly superior** for four key reasons:

1. **Shared Identity & Single Source of Truth:**  
   With a `class`, passing `laptop` into a `Cart` or `Order` passes a lightweight 8-byte memory address. If `laptop.AdjustStock(-1)` runs, every place referencing that `Product` sees the updated stock. With a `struct`, every assignment or method call **copies the entire data block**—so updating stock on one copy silently leaves stale stock everywhere else!
2. **Preventing Zero-Initialized Invalid States:**  
   In C#, `new ProductStruct[10]` or `default(ProductStruct)` automatically creates structs with all fields set to `0` or `null` **without running your constructor**—bypassing your validation rules (`Price > 0`, non-empty `Name`). A `class` defaults to `null`, forcing callers through your validated constructor before any instance can exist.
3. **Performance When Passing Large Objects:**  
   A `class` copies only a tiny pointer when passed to methods. A `struct` with multiple strings, decimals, and dates copies every single byte on the Stack every time you pass it into a method or return it.
4. **Full OOP Extensibility:**  
   Structs cannot inherit from base classes (`Product` -> `PhysicalProduct` / `DigitalProduct`). Classes unlock inheritance and polymorphism as your system grows.

> [!TIP]
> **Rule of Thumb:** Reserve `struct` for tiny, immutable, pure-value data points (like `Point(int X, int Y)` or `Color(byte R, byte G, byte B)`). Use `class` for all real-world business entities (`Product`, `Customer`, `Order`).

---

## 6. Instance vs. Static Members (`static`)

So far, every property and method we wrote belongs to an **instance** (an individual object on the Heap). Each `Product` has its own `Name` and `Price`.

Sometimes, however, data or behavior belongs to the **class blueprint itself**, shared across *all* instances. We mark these with the `static` keyword.

### 1. Static Fields & Properties (Shared State)
Suppose we want to track how many `Product` objects have ever been created in our system:
```csharp
public class Product
{
    // Belongs to the Product class itself — only ONE copy exists in memory!
    public static int TotalProductsCreated { get; private set; }

    public string Name { get; set; } = string.Empty;

    public Product()
    {
        TotalProductsCreated++; // Increments the shared counter every time 'new Product()' runs
    }
}
```
You access `static` members using the **Class Name**, not a variable name:
```csharp
Product p1 = new Product();
Product p2 = new Product();

Console.WriteLine(Product.TotalProductsCreated); // Outputs: 2
```

### 2. Static Methods & Utility Classes
A `static` method runs on the class itself without needing `new`. Because there is no specific object instance, **a `static` method cannot access instance properties or use `this`**.

```csharp
public static class IdGenerator
{
    private static int _counter = 1000;

    public static string NextProductId()
    {
        _counter++;
        return $"PROD-{_counter}";
    }
}

// Usage:
string newId = IdGenerator.NextProductId(); // "PROD-1001"
```

| Feature | Instance Member | `static` Member |
| :--- | :--- | :--- |
| **Belongs to** | A specific object on the Heap | The class definition itself |
| **How to call** | `laptop.DisplayDetails()` | `Product.TotalProductsCreated` |
| **Can access instance data?** | Yes (via `this`) | **No** (compiler error) |
| **Can access static data?** | Yes | Yes |

---

## 7. The Four Pillars of OOP

Now that you understand how classes and objects live in memory, let's look at the big picture of Object-Oriented Programming. Every OOP language—including C#—is built upon **four core pillars**:

1. **Encapsulation** — Bundling data and methods together while hiding internal state and protecting business rules from invalid modifications *(our main focus in the second half of this session)*.
2. **Abstraction** — Exposing only essential features while hiding complex underlying implementation details *(covered in upcoming sessions)*.
3. **Inheritance** — Allowing specialized child classes to reuse and extend behavior from a shared parent class *(covered in upcoming sessions)*.
4. **Polymorphism** — Treating different specialized objects through a common base type while letting each execute its own specific behavior *(covered in upcoming sessions)*.

---

### 🔄 Part 1 Recap: OOP Foundations & Memory Model

Before moving into **Encapsulation**, lock in the core rules from Sections 1–7:

| Concept | Key Takeaway |
| :--- | :--- |
| **Blueprint vs. Instance** | A `class` defines structure and behavior at compile time; `new` allocates a distinct runtime object on the **Heap**. |
| **Stack vs. Heap** | Value types and object references live on the **Stack**, while actual `class` object data lives on the **Heap**. Assigning `p2 = p1` copies the **memory address**, not the object itself. |
| **Null Safety** | Uninitialized reference variables default to `null`. Use `?.` (null-conditional) and `??` (null-coalescing) to prevent `NullReferenceException` crashes. |
| **`class` vs. `struct`** | Always use `class` for business entities (`Product`, `Customer`) to preserve shared identity, enforce constructors, avoid copying overhead, and support inheritance. Reserve `struct` for tiny, immutable value types. |
| **Instance vs. `static`** | Instance members belong to individual objects on the Heap (`laptop.DisplayDetails()`), whereas `static` members belong to the class blueprint itself (`Product.TotalProductsCreated`). |
| **The Four Pillars of OOP** | **Encapsulation**, **Abstraction**, **Inheritance**, and **Polymorphism** form the foundation of object-oriented design. |

> **Quick Mental Check:** Look at the snippet below—what prints on the last line?
> ```csharp
> Product p1 = new Product { Price = 500m };
> Product p2 = p1;
> p2.Price = 350m;
> Console.WriteLine(p1.Price); // Prints 350 — both variables point to the same Heap object!
> ```
> *Next up:* Right now, nothing stops someone from writing `p2.Price = -350m`. Let's see how **Encapsulation** shuts that door permanently.

---

## 8. Encapsulation & Defending Domain Invariants

Earlier, we created a `Product` class with public `{ get; set; }` properties. Look closely at what happens when all properties are open like that:
```csharp
Product phone = new Product();
phone.Price = -999.00m;    // 💥 Corrupted data!
phone.StockQuantity = -50;  // 💥 Impossible inventory!
```
The compiler will happily accept this, but your business will go bankrupt! If any random line of code can tamper with an object's internal data, you can **never trust your system**.

> [!IMPORTANT]
> **Definition:** **Encapsulation** is the OOP principle of bundling data and the methods that operate on that data together, while **hiding internal state** and strictly controlling how that state is accessed or modified.

### Real-World Analogy: The Bank ATM
Think of a bank ATM. You don't get to reach inside the machine with your hands, open the vault, and take cash out. Instead:
- The cash is locked inside a secure vault (**private state**).
- You interact with the ATM through a screen, buttons, and card slot (**public interface**).
- When you ask for $100, the machine validates your PIN and checks your balance (**invariants**). Only if rules are satisfied does it dispense cash!

### Invariants: The Golden Rules of an Entity
An **invariant** is a condition or business rule that must **ALWAYS be true** for an object throughout its entire lifetime.

In our `NexusCommerce` store:
1. A Product's `Price` must **always be strictly greater than zero** ($> 0$).
2. A Product's `StockQuantity` must **never be negative** ($\ge 0$).
3. A Product's `Name` must **never be null or empty whitespace**.

If an object is allowed to violate its invariants, it enters an **invalid state**. Encapsulation guarantees that an object is born valid (via constructors) and stays valid forever (via guarded properties and domain methods).

---

## 9. Access Modifiers & Immutability

To enforce encapsulation properly across multi-file and multi-project .NET solutions (such as `NexusCommerce.Models` vs. `NexusCommerce.Console`), you must control **who** can see and modify each member.

### C# Access Modifiers

| Modifier | Who Can Access It? | Typical Use Case |
| :--- | :--- | :--- |
| `public` | Any code in any project | Public APIs, methods, and readable properties |
| `private` | **Only** code inside the exact same class | Backing fields (`_price`), internal helper methods |
| `protected` | Inside the same class **and** any child classes that inherit from it | Base class helpers and constructors meant for subclasses |
| `internal` | Any code within the **same project (assembly)**, hidden from outside projects | Internal services or models shared within one library |

### Protecting Mutation: `private set`, `init`, and `readonly`
1. **`private set`**: External code can read the property, but only methods inside the class can change it.
   ```csharp
   public int StockQuantity { get; private set; }
   ```
2. **`init` (Init-Only Setters)**: Allows setting the property *only* during object creation (in a constructor or object initializer `{ ... }`), making it completely read-only afterward!
   ```csharp
   public string Id { get; init; } = string.Empty;
   ```
3. **`readonly` Fields**: A private field that can only be assigned when declared or inside a constructor, preventing accidental reassignment inside methods later.
   ```csharp
   private readonly DateTime _createdAt = DateTime.UtcNow;
   ```
4. **`required` Modifier (C# 11+)**: Forces anyone instantiating the class to set the property via an object initializer (`new Product { Id = "..." }`), even if no constructor enforces it—preventing forgotten properties at compile time.
   ```csharp
   public required string Id { get; init; }
   ```

---

## 10. Backing Fields vs. Guarded Properties

### Fields vs. Properties: Why Not Just Use Normal Variables?
In C#, a **Field** is a raw variable declared directly inside a class (e.g., `public decimal Price;`), while a **Property** wraps that variable with `get` and `set` accessors (`public decimal Price { get; set; }`).

Even when a property has no validation logic yet (`{ get; set; }`), **always prefer public properties over public fields**:
1. **Future-Proof Encapsulation:** If you start with a public field and later add validation logic (turning it into a property), every external file or library using your class must be recompiled. Starting with an auto-property lets you add validation later without breaking callers.
2. **Granular Access Control:** Properties let you mix visibility—for example, `public int StockQuantity { get; private set; }` (anyone can read, only the class can write). A raw field is all-or-nothing.
3. **Framework & Tooling Support:** Data binding, JSON serializers (`System.Text.Json`), and ORMs like Entity Framework Core target **properties** by default and ignore raw fields.

In C#, how do we stop outside code from corrupting data? We use **Private Backing Fields** paired with **Guarded Properties**.

```
Outside Code ───► [ Public Property (The Bouncer / Validation) ] ───► [ Private Field (The Safe) ]
```

### The Syntax:
```csharp
public class Product
{
    // 1. Private backing fields (prefixed with an underscore by convention)
    private string _name = string.Empty;
    private decimal _price;
    private int _stockQuantity;

    // 2. Guarded Property for Price (starts with a capital letter by convention)
    public decimal Price
    {
        get => _price; // Expression-bodied getter: reads the private field
        set
        {
            // The 'value' keyword represents whatever the caller tried to assign
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Product price must be greater than zero.");
            }
            _price = value; // Only assign if rule passes!
        }
    }
}
```

### What Happens When Rules Are Broken?
If someone tries:
```csharp
product.Price = -50m;
```
The setter intercepts the assignment, detects `value <= 0`, and immediately throws an `ArgumentOutOfRangeException`. The private field `_price` remains completely untouched!

### Guarding String Invariants: `string.IsNullOrWhiteSpace`
Names and IDs must not be blank. C# provides the utility `string.IsNullOrWhiteSpace(...)` to catch `null`, `""`, or spaces like `"   "`.

```csharp
public string Name
{
    get => _name;
    set
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Product name cannot be empty or whitespace.", nameof(value));
        }
        _name = value.Trim(); // .Trim() strips accidental leading/trailing spaces
    }
}
```

---

## 11. Constructors: Ensuring Entities are Born Valid

A **Constructor** is a special method with the same name as the class (and no return type) that executes immediately when `new` is called. It guarantees that an object cannot exist in memory without valid initial data.

```csharp
public class Product
{
    // Parameterized Constructor
    public Product(string id, string name, decimal price, int initialStock)
    {
        // Route parameter values through properties so validation runs immediately!
        Id = id;
        Name = name;
        Price = price;
        StockQuantity = initialStock;
    }
}
```

> [!NOTE]
> Once you define any parameterized constructor, C# **stops generating** the default empty `new Product()` constructor automatically. That is a good thing—it forces callers to supply valid initial values!

### Constructor Overloading & Chaining (`: this(...)`)
You can provide multiple constructors for different scenarios and chain them together so validation logic is never duplicated:
```csharp
// Constructor overload: Allows creating a product with 0 starting stock
public Product(string id, string name, decimal price) 
    : this(id, name, price, 0) // Delegates to the 4-parameter constructor!
{
}
```

The `: this(...)` syntax is called **Constructor Chaining**. The chained constructor executes *before* the body of the outer constructor runs.

---

## 12. Domain Methods: Tell, Don't Ask

Instead of letting external code directly alter `StockQuantity`:
```csharp
// ❌ Dangerous procedural style:
item.StockQuantity = item.StockQuantity - 5;
```
We make `StockQuantity` `{ get; private set; }` (or backed by `_stockQuantity`) and provide explicit, self-validating **domain methods** that express business actions:

```csharp
// ✅ Idiomatic OOP:
public void AdjustStock(int amount)
{
    int newStock = _stockQuantity + amount;
    if (newStock < 0)
    {
        throw new InvalidOperationException(
            $"Cannot reduce stock below zero. Current stock: {_stockQuantity}, requested adjustment: {amount}");
    }
    _stockQuantity = newStock;
}
```

Now, consuming code simply calls:
```csharp
item.AdjustStock(-5); // Clean, intent-revealing, and safe!
```

---

## 13. Common Exceptions to Know

When an invariant is violated, throw the appropriate standard .NET exception:

| Exception Type | When to Throw | Example |
| :--- | :--- | :--- |
| `ArgumentException` | An invalid argument was passed (e.g. empty string) | `if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(...)` |
| `ArgumentOutOfRangeException` | A number is outside the allowed range | `if (price <= 0) throw new ArgumentOutOfRangeException(...)` |
| `ArgumentNullException` | A required argument was `null` | `if (customer == null) throw new ArgumentNullException(...)` |
| `InvalidOperationException` | The action is invalid given the object's current state | `if (stock - qty < 0) throw new InvalidOperationException(...)` |

---

## 14. Putting It All Together: Complete `Product`, `Customer` & `Program.cs`

### `Product.cs`
```csharp
using System;

namespace NexusCommerce.Models
{
    public class Product
    {
        private string _name = string.Empty;
        private decimal _price;
        private int _stockQuantity;

        public static int TotalProductsCreated { get; private set; }

        public string Id { get; init; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Product name cannot be empty.", nameof(value));
                _name = value.Trim();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Price must be greater than zero.");
                _price = value;
            }
        }

        public int StockQuantity
        {
            get => _stockQuantity;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Stock cannot be negative.");
                _stockQuantity = value;
            }
        }

        public Product(string id, string name, decimal price, int initialStock)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Product ID is required.", nameof(id));

            Id = id.Trim();
            Name = name;
            Price = price;
            StockQuantity = initialStock;

            TotalProductsCreated++;
        }

        public Product(string id, string name, decimal price)
            : this(id, name, price, 0)
        {
        }

        public void AdjustStock(int amount)
        {
            int newStock = _stockQuantity + amount;
            if (newStock < 0)
                throw new InvalidOperationException($"Insufficient stock. Current: {_stockQuantity}, Change: {amount}");

            _stockQuantity = newStock;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"[Product #{Id}] {Name} - ${Price:F2} | In Stock: {StockQuantity}");
        }
    }
}
```

### `Customer.cs`
```csharp
using System;

namespace NexusCommerce.Models
{
    public class Customer
    {
        private string _fullName = string.Empty;
        private string _email = string.Empty;

        public string Id { get; init; }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Customer name cannot be empty.", nameof(value));
                _fullName = value.Trim();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
                    throw new ArgumentException("A valid email address is required.", nameof(value));
                _email = value.Trim();
            }
        }

        public Customer(string id, string fullName, string email)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Customer ID is required.", nameof(id));

            Id = id.Trim();
            FullName = fullName;
            Email = email;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"[Customer #{Id}] {FullName} <{Email}>");
        }
    }
}
```

### `Program.cs`
```csharp
using System;
using NexusCommerce.Models;

namespace NexusCommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiating valid entities via constructors
            Product laptop = new Product("PROD-001", "Developer Workstation Laptop", 1899.99m, 12);
            Customer customer = new Customer("CUST-001", "Amr Mostafa", "amr.mostafa@example.com");

            // Calling instance behaviors
            laptop.DisplayDetails();
            customer.DisplayDetails();

            // Safe domain mutation
            laptop.AdjustStock(-2);
            laptop.DisplayDetails();

            // Accessing static member via class name
            Console.WriteLine($"Total Products Created: {Product.TotalProductsCreated}");
        }
    }
}
```

---

## 15. Common Beginner Mistakes

### Foundations Mistakes

#### ❌ Mistake 1: Forgetting the `new` Keyword
```csharp
Product laptop;
laptop.DisplayDetails(); // ❌ Compiler Error!
```
✅ **Correct:**
```csharp
Product laptop = new Product("PROD-001", "Laptop", 1200m);
laptop.DisplayDetails();
```

#### ❌ Mistake 2: Using `float` or `double` for Money
```csharp
double price = 19.99; // ❌ Binary floating-point rounding errors occur in financial math!
```
✅ **Correct:** Always use `decimal` for financial calculations:
```csharp
decimal price = 19.99m; // Note the 'm' suffix
```

#### ❌ Mistake 3: Confusing Instance Members with `static` Members
```csharp
Product.DisplayDetails(); // ❌ Compiler Error! DisplayDetails is an instance method, not static!
```
✅ **Correct:** Call instance methods on an instantiated variable, and `static` members on the class name:
```csharp
Product myItem = new Product("PROD-001", "Laptop", 1200m);
myItem.DisplayDetails(); // ✅ Instance call
Console.WriteLine(Product.TotalProductsCreated); // ✅ Static call
```

### Encapsulation Mistakes

#### ❌ Mistake 4: Infinite Recursion in Property Setters
```csharp
public decimal Price
{
    get => Price; // ❌ Calls itself endlessly! StackOverflowException!
    set => Price = value; // ❌ Calls itself endlessly! StackOverflowException!
}
```
✅ **Correct:** Always read and write to the **private backing field** `_price`:
```csharp
public decimal Price
{
    get => _price;
    set => _price = value;
}
```

#### ❌ Mistake 5: Leaving State Publicly Settable When It Should Be Controlled
If stock should only change via sales or restocks, never expose a public setter (`public int StockQuantity { get; set; }`). Use `{ get; private set; }` and expose a validated domain method like `AdjustStock(int amount)`.

#### ❌ Mistake 6: Assigning Backing Fields Directly in Constructors (Bypassing Validation)
```csharp
public Product(string id, string name, decimal price, int initialStock)
{
    _price = price; // ❌ Bypasses the Price setter validation! Allows negative prices!
}
```
✅ **Correct:** Assign through the guarded properties (`Price = price;`) inside your constructor so validation runs on creation too.

---

### 🔄 Session 01 Recap: OOP Foundations, Memory & Encapsulation

Before starting the Knowledge Check, review the full Session 01 synthesis across both parts:

#### Part 1: OOP Foundations & Memory Model
| Concept | Key Takeaway |
| :--- | :--- |
| **Blueprint vs. Instance** | A `class` defines structure and behavior at compile time; `new` allocates a distinct runtime object on the **Heap**. |
| **Stack vs. Heap** | Value types and object references live on the **Stack**, while actual `class` object data lives on the **Heap**. Assigning `p2 = p1` copies the **memory address**, not the object itself. |
| **Null Safety** | Uninitialized reference variables default to `null`. Use `?.` (null-conditional) and `??` (null-coalescing) to prevent `NullReferenceException` crashes. |
| **`class` vs. `struct`** | Always use `class` for business entities (`Product`, `Customer`) to preserve shared identity, enforce constructors, avoid copying overhead, and support inheritance. Reserve `struct` for tiny, immutable value types. |
| **Instance vs. `static`** | Instance members belong to individual objects on the Heap (`laptop.DisplayDetails()`), whereas `static` members belong to the class blueprint itself (`Product.TotalProductsCreated`). |
| **The Four Pillars of OOP** | **Encapsulation**, **Abstraction**, **Inheritance**, and **Polymorphism** form the foundation of object-oriented design. |

#### Part 2: Encapsulation, Construction & Invariants
| Concept | Key Takeaway |
| :--- | :--- |
| **Encapsulation & Invariants** | Encapsulation hides internal state behind a controlled public interface so business rules (**invariants** like `Price > 0` and `StockQuantity >= 0`) can never be violated. |
| **Access Modifiers & Immutability** | Restrict visibility with `private`, `protected`, and `internal`, and lock down mutation using `private set` (internal updates only), `init` (set once at creation), `readonly` fields, and `required` properties. |
| **Backing Fields & Guarded Properties** | Always prefer properties over raw public fields. Pair private backing fields (`_price`) with public properties (`Price`) to validate incoming `value` assignments and strings (`string.IsNullOrWhiteSpace`) before state changes. |
| **Constructors & Chaining** | Parameterized constructors guarantee entities are **born valid** by routing arguments through guarded properties, while `: this(...)` chains overloads without duplicating validation. |
| **Domain Methods** | Expose intent-revealing methods like `AdjustStock(int amount)` instead of letting callers directly overwrite sensitive state. |
| **Standard Guard Exceptions** | Fail fast with `ArgumentException`, `ArgumentOutOfRangeException`, `ArgumentNullException`, or `InvalidOperationException` whenever an invariant is broken. |

> **Pre-Flight Warm-Up (Spot the 3 Bugs Before Starting Section 16):**
> ```csharp
> public class Coupon
> {
>     private decimal _discount;
>     public decimal Discount
>     {
>         get => _discount;
>         set => Discount = value; // Bug 1: Infinite recursion (should assign _discount)
>     }
>     public Coupon(decimal discount)
>     {
>         _discount = discount;     // Bug 2: Bypasses Discount setter validation
>     }
> }
> // Bug 3: Calling an instance property on a null reference (or on the class name Coupon.Discount)
> Coupon? x = null;
> x.Discount = 10; // Runtime NullReferenceException!
> ```

---

## 16. Knowledge Check & Self-Assessment (Session 01)

Test your understanding before starting the lab task:

1. **What is the difference between a class and an object?**  
   *Answer:* A class is the compile-time blueprint defining properties and methods. An object is the actual runtime instance allocated in Heap memory.
2. **Why is `class` preferred over `struct` for entities like `Product` and `Customer`?**  
   *Answer:* Classes share a single identity via references (preventing stale copies), enforce constructor validation (structs can be zero-initialized bypassing constructors), avoid expensive copying of large data, and support inheritance.
3. **If `Product b = a;`, how many Product objects exist in memory?**  
   *Answer:* Exactly one. Both variables `a` and `b` hold memory addresses pointing to that single object on the Heap.
4. **What is the difference between an instance member and a `static` member?**  
   *Answer:* An instance member belongs to a specific object on the Heap (each object gets its own copy). A `static` member belongs to the class itself—only one copy exists in memory, accessed via the class name.
5. **What are the four pillars of OOP?**  
   *Answer:* Encapsulation, Abstraction, Inheritance, and Polymorphism.
6. **What is an invariant, and how do constructors and properties protect it?**  
   *Answer:* An invariant is a business rule that must always remain true throughout an object's lifecycle. Constructors ensure the object is born valid, while private backing fields and guarded setters/domain methods reject any invalid state changes.
7. **When would you use `private set` versus `init` versus `protected`?**  
   *Answer:* Use `private set` for values that change internally over time via class methods (like `StockQuantity`); use `init` for values set once at creation that never change afterward (like `Id`); use `protected` for members hidden from outside callers but accessible to child classes.
8. **Why should you prefer public auto-properties (`{ get; set; }`) over public fields (`public decimal Price;`) even before adding validation?**  
   *Answer:* Properties allow you to add validation logic later without breaking binary compatibility for callers, provide granular visibility (`{ get; private set; }`), and are required by .NET serializers and ORMs like Entity Framework Core.
9. **What does constructor chaining (`: this(...)`) accomplish?**  
   *Answer:* It lets one constructor overload delegate initialization to another constructor in the same class, eliminating duplicated validation and setup code.