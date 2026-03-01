# Shop Management System - Implementation Guide

## Database Tables

### 1. Users (Authentication)
- **userID** (INT, PK, IDENTITY)
- **username** (NVARCHAR(50))
- **password** (NVARCHAR(50))
- **role** (NVARCHAR(50))

### 2. Supplier
- **supplierID** (INT, PK, IDENTITY)
- **supplierName** (NVARCHAR(50))
- **country** (NVARCHAR(50))
- **supplierEmail** (NVARCHAR(50))

### 3. Product
- **prodID** (INT, PK, IDENTITY)
- **prodName** (NVARCHAR(50))
- **supplier** (INT, FK → Supplier.supplierID)
- **quantity** (INT)
- **price** (DECIMAL(18,2))
- **registeredDate** (DATETIME)

### 4. Sales
- **salID** (INT, PK, IDENTITY)
- **product** (INT, FK → Product.prodID)
- **saleDate** (DATETIME)

## Database Relationships
```
Users (Independent - Authentication)

Supplier (1) ──→ (Many) Product
                    ↓
                  (Many)
                   Sales
```

## Implemented Features

### 0. Authentication System
**Login Form:**
- Username and Password fields
- Login validation against Users table
- Link to signup form
- Default credentials: admin/admin

**Signup Form:**
- Username, Password, Role fields
- Auto-creates Users table if not exists
- Duplicate username validation
- Link back to login

### 1. Dashboard
**Navigation Hub:**
- Supplier Management button
- Product Management button
- Sales Management button
- Centralized access to all modules

### 2. Supplier Management (supplier.cs)
**Controls:**
- textBox1: Supplier Name
- textBox2: Country
- textBox3: Supplier Email
- button1: Save (Add new supplier)
- button2: Update (Update selected supplier)
- button3: Delete (Delete selected supplier)
- dataGridView1: Display all suppliers

**Operations:**
- Add new supplier with validation
- Update existing supplier (select from grid first)
- Delete supplier (select from grid first)
- Auto-load suppliers on form load
- Click row to populate fields for editing

### 3. Product Management (Product.cs)
**Controls:**
- textBox1: Product Name
- textBox2: Quantity
- textBox3: Price
- comboBox1: Supplier dropdown
- button1: Add Product
- button2: Update Product
- button3: Delete Product
- dataGridView1: Display products with supplier names
- Back to Dashboard button

**Operations:**
- Add new product with supplier selection
- Update existing product (select from grid first)
- Delete product (select from grid first)
- Auto-load products with supplier names (JOIN)
- Auto-load suppliers in dropdown
- Click row to populate fields for editing

### 4. Sales Management (sales.cs)
**Controls:**
- comboBox1: Product selection dropdown
- textBox2: Quantity to sell
- button1: Record Sale
- button3: Delete Sale
- dataGridView1: Display all sales with product names
- Back to Dashboard button

**Operations:**
- Record new sale with product and quantity selection
- Automatically reduces product stock by quantity sold
- Stock validation (prevents selling if insufficient quantity)
- Delete sale (select from grid first)
- Auto-load products in dropdown
- Auto-load sales with JOIN to show product names
- Click row to select sale for deletion

### 3. Product Management
**Note:** Product management is fully implemented in Product.cs with complete CRUD operations.

## Database Connection
Connection string in App.config:
```xml
<connectionStrings>
    <add name="MIDTERM"
    connectionString="Data Source=Pacifique\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True;TrustServerCertificate=True"
    providerName="System.Data.SqlClient"/>
</connectionStrings>
```

## NuGet Packages Added
- System.Data.SqlClient (v4.8.6)
- System.Configuration.ConfigurationManager (v8.0.0)

## Key Features
✅ User Authentication (Login/Signup)
<br>
✅ Dashboard navigation
<br>
✅ Full CRUD operations for Supplier, Product, and Sales
<br>
✅ Foreign key relationships maintained
<br>
✅ Automatic stock reduction on sales
<br>
✅ Stock validation (prevents overselling)
<br>
✅ Parameterized queries (SQL injection prevention)
<br>
✅ Input validation
<br>
✅ Auto-refresh after operations
<br>
✅ Success/Error messages
<br>
✅ DataGridView click to select and populate fields
<br>
✅ Password masking in login/signup

## How to Use
1. Build the project to restore NuGet packages
2. Ensure SQL Server is running with ShopDB database
3. Run the application
4. **Login** with admin/admin OR **Sign Up** for a new account
5. Navigate through Dashboard to access:
   - Supplier Management
   - Product Management
   - Sales Management
6. Each form has a "Back to Dashboard" button for easy navigation

## SQL Scripts (Complete Database Setup)
```sql
-- 1. Create Users Table (Authentication)
CREATE TABLE Users (
    userID INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) NOT NULL,
    password NVARCHAR(50) NOT NULL,
    role NVARCHAR(50) NOT NULL
);

-- 2. Create Supplier Table
CREATE TABLE Supplier (
    supplierID INT PRIMARY KEY IDENTITY(1,1),
    supplierName NVARCHAR(50),
    country NVARCHAR(50),
    supplierEmail NVARCHAR(50)
);

-- 3. Create Product Table
CREATE TABLE Product (
    prodID INT PRIMARY KEY IDENTITY(1,1),
    prodName NVARCHAR(50),
    supplier INT FOREIGN KEY REFERENCES Supplier(supplierID),
    quantity INT,
    price DECIMAL(18,2),
    registeredDate DATETIME
);

-- 4. Create Sales Table
CREATE TABLE Sales (
    salID INT PRIMARY KEY IDENTITY(1,1),
    product INT FOREIGN KEY REFERENCES Product(prodID),
    saleDate DATETIME
);

-- 5. Insert Default Admin User
INSERT INTO Users (username, password, role) VALUES ('admin', 'admin', 'Admin');
```
