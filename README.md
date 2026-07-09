# Bertolotto Stage

> **2-week IT internship** at [Bertolotto Porte](https://www.bertolottoporte.it/) — July 2026  
> Focus: document management, archive digitalization, and C# programming exercises.

---

## Overview

This repository contains three C# console applications developed during a summer internship at Bertolotto Porte. Each project follows the same pattern: read a semicolon-delimited CSV file via `OpenFileDialog`, apply business logic, and print a formatted report to the console.

---

## Projects

### 1. Warehouse Inventory (`progetto1/`)

Reads a product warehouse file and calculates inventory value.

- Parse product name, quantity, and unit price
- If quantity > 50, apply **10% discount** on that product's total
- Print modified products and total warehouse value

**Concepts**: File I/O, CSV parsing, conditional logic, try-catch error handling

### 2. Sales Order Management (`progetto2/`)

Reads a client order file and applies volume discounts.

- Calculate `quantity × price` per order
- If total > 500€, apply **15% discount**
- List discounted clients and total order value

**Concepts**: Structs, loops, discount logic, report formatting

### 3. Student Grade Management (`progetto3/`)

Reads a student grade file and determines pass/fail status.

- Calculate average of 3 grades per student
- If average >= 6, student is **promoted**
- Print promoted students and class average

**Concepts**: Averages, boolean flags, list filtering

---

## Tech Stack

| Technology        | Purpose                             |
| ----------------- | ----------------------------------- |
| **C# (.NET 10)**  | Console application                 |
| **Windows Forms** | `OpenFileDialog` for file selection |
| **.NET SDK**      | Build and run                       |

---

## Getting Started

```bash
# Clone the repo
git clone https://github.com/perassilorenzo/bertolotto-stage.git
cd bertolotto-stage

# Run any project (e.g., progetto1)
dotnet run --project progetto1
```

Each project will open a file dialog — select the corresponding `TEST.txt` to see the output.

---

## What I Learned

- Reading and parsing structured text files in C#
- Using `OpenFileDialog` for user-friendly file selection
- Structuring console applications with clear separation of concerns
- Error handling with try-catch blocks
- Working with .NET projects and build configuration
- Real-world IT workflows in a manufacturing company environment

---

## Context

This internship was part of my IT studies at ITIS. The first week focused on document management and archive digitalization — learning how a manufacturing company handles technical documentation, quality certifications, and digital archiving. The second week shifted to programming, applying the C# skills I developed in school to practical exercises.

---

<p align="center">
  <sub>Bertolotto Porte · Stage IT · Luglio 2026</sub>
  <br>
  <a href="https://github.com/perassilorenzo">perassilorenzo</a>
</p>
