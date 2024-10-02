# C# Flow Control

In this post, I will discuss flow control in C#. Although often considered a "basic" or beginner-friendly topic, it's a fundamental concept in C# and most programming languages.

Flow control refers to how you manage the execution path of your software. In C#, there are several statements that handle this:

- `if`
- `if-else`
- `if-else-if`
- `switch`
- `for`
- `while`
- `do-while`
- `foreach`
- `break` / `continue`

---

## The `if` Statement

The `if` statement evaluates a Boolean condition and executes a block of code if the condition is `true`. Writing effective `if` statements is crucial for maintaining clean, readable, and efficient code.

Below are some key guidelines, inspired by best practices from Steve McConnell's *Code Complete* and other industry standards, to help you write better `if` statements in C#.

### Example:

```csharp
int threshold = 25;
int userInput = 25; 

if (userInput == threshold)
{
    Console.WriteLine("The input matches the threshold! 🥳");
}
```

In the example above, the `if` block executes only if `userInput` equals `25`. If the condition evaluates to `true`, the message is printed.

### 1. Use Clear Conditions

The condition inside an `if` statement should be simple and easy to understand. Avoid writing complex or convoluted expressions that make the logic hard to follow. If necessary, break the condition into smaller, clearer variables or expressions.

#### Example:

**Before:**

```csharp
if ((x > 10 && y < 20) || (x < 5 && y > 30))
{
    // Complex logic...
}
```

**After:**

```csharp
bool isInValidRange = (x > 10 && y < 20);
bool isOutOfRange = (x < 5 && y > 30);

if (isInValidRange || isOutOfRange)
{
    // Clearer logic...
}
```

Breaking down the condition into descriptive Boolean variables improves readability and makes the logic easier to understand.

### 2. Avoid Nested `if` Statements

While nesting `if` statements can sometimes be necessary, excessive nesting makes the code hard to follow. Instead of deeply nested `if` blocks, consider using guard clauses or early returns, which make your code flatter and easier to read.

#### Example:

**Before:**

```csharp
if (user != null)
{
    if (user.IsActive)
    {
        if (user.HasPermissions)
        {
            // Perform action...
        }
    }
}
```

**After (Using Guard Clauses):**

```csharp
if (user == null) return;
if (!user.IsActive) return;
if (!user.HasPermissions) return;

// Perform action...
```

Using guard clauses reduces unnecessary nesting and makes the main flow of the code more apparent.

### 3. Favor Positive Conditions

Whenever possible, write conditions in a positive manner. Positive conditions are easier to understand and often make your code more readable. For example, instead of negating a condition, use its positive equivalent.

#### Example:

**Before (Negative Condition):**

```csharp
if (!isInvalid)
{
    // Logic for valid case...
}
```

**After (Positive Condition):**

```csharp
if (isValid)
{
    // Logic for valid case...
}
```

This change makes the condition clearer and reduces cognitive load when reading the code.

### 4. Handle Edge Cases and Errors First (Guard Clauses)

Guard clauses allow you to handle edge cases and errors early in your code, preventing unnecessary complexity. By handling invalid conditions upfront, the main logic becomes more readable and manageable.

#### Example:

```csharp
if (customer == null)
{
    throw new ArgumentNullException(nameof(customer));
}

if (!customer.IsActive)
{
    Console.WriteLine("Customer account is inactive.");
    return;
}

// Continue with core logic for active customers...
```

By handling invalid conditions immediately, you keep the main logic simple and focused.

### 5. Put the Normal Case First

As Steve McConnell suggests in *Code Complete*, always handle the normal or expected case first in an `if` block. This keeps the focus on the main flow of logic, while exceptional cases can be handled afterward. This makes the code easier to follow.

#### Example:

**Before:**

```csharp
if (!isAuthorized)
{
    // Handle unauthorized case...
}
else
{
    // Main logic for authorized case...
}
```

**After (Normal Case First):**

```csharp
if (isAuthorized)
{
    // Main logic for authorized case...
}
else
{
    // Handle unauthorized case...
}
```

Placing the normal case first makes the core logic clear, with exceptional cases handled separately.

### 6. Consider Using `switch` for Multiple Conditions

When dealing with multiple conditions related to a single variable, a `switch` statement is often more readable than a series of `if-else` blocks. It provides a structured way to handle multiple cases, making it easier to see all the conditions at a glance.

#### Example:

**Before (Multiple `if` Statements):**

```csharp
if (status == "Pending")
{
    // Handle pending status...
}
else if (status == "Approved")
{
    // Handle approved status...
}
else if (status == "Rejected")
{
    // Handle rejected status...
}
```

**After (`switch` Statement):**

```csharp
switch (status)
{
    case "Pending":
        // Handle pending status...
        break;
    case "Approved":
        // Handle approved status...
        break;
    case "Rejected":
        // Handle rejected status...
        break;
    default:
        // Handle unknown status...
        break;
}
```

Using a `switch` statement provides a clearer and more maintainable structure when dealing with multiple cases.

### 7. Refactor Complex `if` Logic

If your `if` conditions become too complex, it’s a sign that you should refactor the code. Extracting logic into separate methods or using design patterns (like the **Strategy Pattern**) can simplify decision-making and improve code readability.

#### Example:

```csharp
if (ShouldSendNotification(user, notificationType))
{
    SendNotification(user, notificationType);
}
```

By abstracting the logic into a method, you encapsulate the decision-making process and keep the `if` statement concise.

### 8. Test and Document Your Conditions

Always ensure that your conditions are thoroughly tested, including edge cases, null checks, and unexpected inputs. Use comments to document complex conditions or edge cases, making your code easier to maintain.

#### Example:

```csharp
// Ensure the user is not null and has the necessary permissions
if (user != null && user.HasPermissions)
{
    // Perform action...
}
```

A simple comment clarifies the intent of the condition and makes the code easier to understand for others.

---

### Conclusion

Writing effective `if` statements in C# requires careful attention to clarity, readability, and maintainability. By following these best practices:

- Use clear and concise conditions.
- Avoid deep nesting through guard clauses.
- Favor positive conditions.
- Put the normal case first.

You can create code that is not only easy to read but also maintainable and less prone to errors.

