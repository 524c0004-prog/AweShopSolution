[README.md](https://github.com/user-attachments/files/24015758/README.md)
# AweShopSolution – Final Project (Software Engineering)

A multi-application retail management system implemented with a **3-tier architecture**, including **Desktop (WinForms)** and **Web (ASP.NET MVC)** applications sharing the same **Business Logic Layer (BLL)**, **Data Access Layer (DAL)**, and **SQL Server database**.

This project was developed as part of the **Software Engineering Final Project** and demonstrates real-world system design, implementation, testing, and source control practices.

---

## 🚀 System Overview

AweShop is a simplified store management platform designed to support:

- Product CRUD management
- Order processing
- User authentication
- Inventory updates
- Reporting module
- Shared business logic between Desktop & Web apps

### Solution Structure

```
AweShopSolution/
 ├── AweShop.Web           (ASP.NET MVC Application)
 ├── AweShop.Desktop       (WinForms Application)
 ├── AweShop.BLL           (Business Logic Layer)
 ├── AweShop.DAL           (Data Access Layer - Repository Pattern)
 ├── AweShop.Models        (Shared Entity Models)
 └── AweShop.Tests         (Unit Testing Project - MSTest)
```

---

## 🏛 Architecture

The system follows a strict **3-tier architecture**:

### 1️⃣ Presentation Layer
- WinForms (Desktop)
- ASP.NET MVC (Web)

### 2️⃣ Business Logic Layer (BLL)
Handles:
- Validation logic
- Order workflows
- Inventory update rules
- Product price validation

### 3️⃣ Data Access Layer (DAL)
- Repository Pattern using ADO.NET
- Encapsulated SQL logic via repositories

### 4️⃣ Shared Models
- DTOs and entity classes shared across all layers

---

## 🗄 Database Design

SQL Server tables:

- Users
- Products
- Inventory
- Orders
- OrderDetails

The ERD defines relationships between products, inventory, and orders.

---

## 🧪 Unit Testing

Unit tests are implemented using **MSTest** inside AweShop.Tests.

### Tested Feature:
`ProductService.IsPriceValid(decimal price)`

Techniques:
- Boundary Value Analysis
- Equivalence Partitioning

All test cases passed successfully (evidence shown in final report).

---

## 🔧 Technologies Used

| Component        | Technology |
|------------------|-----------|
| Desktop App      | WinForms (.NET Framework) |
| Web App          | ASP.NET MVC |
| Backend Logic    | C# – BLL |
| Data Layer       | ADO.NET + Repository Pattern |
| Database         | SQL Server |
| Testing          | MSTest |
| Version Control  | Git + GitHub |

---

## 👥 Team Members & Contributions

### 1. Lê Thanh Danh
- Implemented Web UI components
- OrderService workflow development
- DAL refactoring and naming consistency
- UI improvements (labels/messages)

### 2. Phan Thao Nhi
- Initial project setup
- BLL refactoring
- DAL repository enhancements
- ProductService validation logic
- Unit test creation

Contribution history is visible in GitHub commit logs.

---

## 📁 Folder Structure

```
AweShopSolution/
 ├── AweShop.Web
 ├── AweShop.Desktop
 ├── AweShop.BLL
 ├── AweShop.DAL
 ├── AweShop.Models
 ├── AweShop.Tests
 ├── AweShopSolution.sln
 └── README.md
```

---

## 📦 How to Run the Project

### Requirements
- Visual Studio 2022
- .NET Framework 4.x
- SQL Server
- Git (optional)

### Steps
1. Clone the repository:
```
git clone https://github.com/<your-username>/AweShopSolution.git
```

2. Open `AweShopSolution.sln` in Visual Studio  
3. Configure SQL connection string in AweShop.DAL  
4. Run Desktop or Web applications  
5. Open **Test Explorer** → run MSTest unit tests  

---

## 📝 Final Report Contents

- Requirements Specification (FR/NFR)
- UI/UX Design
- UML Diagrams (Use Case, Sequence, ERD, Class Diagram)
- System Architecture
- Implementation Summary
- Testing & Evidence
- GitHub Source Control Documentation
- Traceability Matrix
- Conclusion & Limitations

---

## 🏁 Project Status

✔ Completed  
✔ Successfully Tested  
✔ Final Report Submitted  

---

## 🙌 Acknowledgements

This project was created for educational purposes as part of the Software Engineering course.  
Special thanks to instructors and teammates for their guidance and collaboration.
