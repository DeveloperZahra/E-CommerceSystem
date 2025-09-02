# E-Commerce System

## Overview

This project is an E-Commerce Backend System designed to manage products, users, orders, and reviews.
It provides RESTful APIs for order processing, product management, user authentication, and business analytics.

As part of Phase 2, new features, enhancements, and stricter business rules were added to extend the base system.


## Database Schema

Entities & Relationships:

** Users

Manages customers & admins (fields: UID, UName, Email, Password, Role, etc.)

One User → Many Orders

One User → Many Reviews

** Products

Manages product catalog (fields: PID, ProductName, Description, Price, Stock, OverallRating)

One Product → Many Reviews

Many Products ↔ Many Orders (via OrderProducts)

** Orders

Contains order details (fields: OID, OrderDate, TotalAmount, UID, Status)

One Order → Many OrderProducts

** OrderProducts

Join table for many-to-many (Order ↔ Product) with quantity

** Reviews

Stores product reviews (fields: ReviewID, Rating, Comment, UID, PID)


** Category

CategoryId, Name, Description

One Category → Many Products


** Supplier

SupplierId, Name, ContactEmail, Phone

One Supplier → Many Products

![](1.png)


# Project Structure

E-CommerceSystem/

│
├─ Controllers/             # Web API controllers (Products, Orders, Users, Reviews, Categories, Suppliers, Reports, Auth)

├─ Services/                # Business services (interfaces + implementations)

├─ Repository/              # Repositories (data access / EF Core)

├─ DTOs/
│  ├─ Requests/             # Create/Update input DTOs
│  └─ Responses/            # Output DTOs (what APIs return)

├─ Models/                  # EF Core entities

├─ Mapping/                 # AutoMapper profiles

├─ Migrations/              # EF Core migrations

├─ Middleware/              # Error handling, logging, etc.

├─ Infrastructure/          # Auth, Email, Pdf/Invoice helpers, FileStorage

├─ appsettings*.json        # Configuration (DB, JWT, Mail, Serilog)

├─ Program.cs               # Composition root (DI, middleware, endpoints)

└─ README.md

## Features:

**1) New Models + CRUD + DTOs + AutoMapper**

* Category and Supplier added with full CRUD.
* *All controllers use DTOs and AutoMapper (no manual mapping).

**2) Services Enhancements**

* Products: Pagination & Filtering
```sql
GET /api/products?search=iphone&minPrice=100&maxPrice=1500&page=1&pageSize=20
```
* Order Summary Service

Aggregates Orders + Users + Products (totals, lines, amounts).

* Product Image Upload
```sal
POST /api/products/{id}/image
```  
(multipart/form-data).

* Order Cancellation
```sql
POST /api/orders/{id}/cancel 
```
(restores stock, sends email).

* Order Status Tracking
```sql 
Lifecycle: Pending → Paid → Shipped → Delivered (or Cancelled).
```
* Email Notifications

Sent when an order is placed or canceled.

* Invoice Generation (PDF)
```sql
GET /api/orders/{id}/invoice returns a PDF
```
**3) Security & Authentication**

* JWT + Refresh Tokens (refresh stored in DB; tokens stored in Cookies).

* Passwords stored as BCrypt hashes.

*Role-based authorization: Admin, Customer, Manager.

**4) Business Rules (Enforced in Services)**

* A user can only review products they purchased.

* A user cannot add more than one review to the same product.

* Optimistic Concurrency on products & orders via RowVersion (timestamp):

     Clients must send the latest RowVersion when updating.

 **5) Reports & Analytics (Admin)**

* Best-selling products:``` /api/admin/reports/best-sellers?from=2025-01-01&to=2025-01-31```

* Revenue reports (daily/monthly): ``` /api/admin/reports/revenue?granularity=month&from=...&to=...```

* Top-rated products: ```/api/admin/reports/top-rated```

* Most active customers:``` /api/admin/reports/active-customers```
