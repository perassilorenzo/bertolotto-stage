# Bertolotto Stage

> **2-week IT internship** at [Bertolotto Porte](https://www.bertolottoporte.it/) — July 2026
> Focus: programming exercises, file parsing, and simple business reporting in C#.

---

## Overview

This repository contains ten C# console applications created during a summer internship at Bertolotto Porte. Each project reads a semicolon-delimited text file with `OpenFileDialog`, processes the data, and prints a report to the console.

The projects cover real-world business cases such as inventory control, order tracking, billing, payroll, temperature monitoring, and client status reporting.

---

## Projects

### `progetto1` — Warehouse inventory

- Reads product name, quantity, and unit price
- Marks products with quantity > 50 as modified
- Calculates total inventory value
- Prints modified products and total warehouse price

### `progetto2` — Sales order discounts

- Reads client orders with quantity and price
- Applies a 25% discount on orders over 500€
- Lists clients who received the discount
- Prints the total order value

### `progetto3` — Student grades

- Reads student names and three grades
- Calculates each student average
- Marks students as promoted if average >= 6
- Prints promoted students and class average

### `progetto4` — Client bill penalties

- Reads client usage and cost data
- Computes each bill amount
- Adds a 25€ penalty for bills over 500€
- Lists clients with penalties and total billing cost

### `progetto5` — Employee pay and bonus

- Reads employee hours and hourly wage
- Calculates salary per employee
- Adds a 200€ bonus for employees with more than 160 hours
- Prints employees with bonus and total salary

### `progetto6` — Weekly temperature report

- Reads daily temperatures for cities
- Computes average and maximum temperature per city
- Flags cities with a max temperature above 35°C
- Prints city reports, the highest temperature, and average temperature

### `progetto7` — Invoice tracking

- Reads invoice number, client, amount, and payment status
- Calculates totals for paid and unpaid invoices
- Counts unpaid invoices
- Lists clients with unpaid invoices

### `progetto8` — Product availability

- Reads product code, name, quantity, and availability status
- Lists unavailable products
- Calculates available and unavailable quantities
- Prints the count of unavailable products

### `progetto9` — Order status overview

- Reads order number, client, category, amount, and delivery status
- Lists clients with unsubmitted orders
- Calculates submitted and unsubmitted totals
- Prints the client with the highest order amount, average amount, and category counts

### `progetto10` — Work order monitoring

- Reads work order data with client, service type, hours, price, and status
- Lists clients with ongoing jobs
- Computes total revenue for completed and open jobs
- Prints ongoing job count, average price, max price client, and total hours worked

### `filecopier` — File copy utility

- Copies a file from one location to another via Windows dialogs
- Uses `OpenFileDialog` for source and `FolderBrowserDialog` for destination
- Overwrites existing files automatically
- Handles specific exceptions: permissions, file-in-use, I/O errors
- Console stays open after operation

---

## Tech Stack

- `C#` with `.NET 10`
- `System.Windows.Forms` for `OpenFileDialog`
- Console output for reports
- Simple file parsing with `StreamReader`

---

## How to Run

```powershell
cd "\\10.0.0.238\OpenShare\CED\LORENZO\progetti-stage"

dotnet run --project progetto1
```

Replace `progetto1` with any project folder from `progetto1` to `progetto10`, or `filecopier`.

Each project opens a file chooser. Use the matching `TEST.txt` file inside the project folder to run the example data.

---

## Notes

- All projects use semicolon-delimited input files.
- The applications are console-based but rely on a Windows file picker for input selection.
- The code demonstrates basic data processing, conditional logic, and reporting.

---

## Internship Summary

During this internship, I practiced C# development with real file-based workflows. I learned how to parse structured text files, implement business rules, handle exceptions, and present results clearly on the console.

---

<p align="center">
  <sub>Bertolotto Porte · Stage IT · Luglio 2026</sub>
  <br>
  <a href="https://github.com/perassilorenzo">perassilorenzo</a>
</p>
