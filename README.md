# 🩸 Blood Bank Management System

A WinForms application for blood donation processes, inventory tracking, and donor-recipient coordination, etc.

## 🌟 Key Features
- Donor/Receiving unit management:
Information; Donor registration; Blood requirement management (hospitals/clinics/nursing homes)

- Real-time Blood Inventory: Blood type quantity tracking; Expiration date monitoring

- Automated Alerts: Low stock notifications

- Reporting Module: Statistical reports

- Role-based Access Control: Admin; Receiving units; Donors

## 🛠️ Technology Stack

- Language:	C# version 10.0
- Framework: .NET WinForms version	4.8
- ORM:	Entity Framework version	6.4.4
- UI Components:	Bunifu UI version	7.2.0
- Security:	BCrypt.Net-Next	version 4.0.3
- Database:	SQL Server version	2019

## 💻 System Requirements
- Development Environment: 
  
  Visual Studio 2022
  
  SQL Server Management Studio 20

- Runtime: 

  Windows 10/11

  .NET Framework 4.8

## 🚀 Installation
### 1. Clone the Repository
```bash
git clone https://github.com/TAKhoi1506/LTCSDL_Project.git
```
### 2. Database Setup

- Open SSMS and execute: Solution Items\BloodBank.sql

- Initialize triggers: Data\BloodStock.sql and Data\BloodRequirement.sql

### 3. Configure Connection
Modify the connection string in DAL\Domain\MyContext.cs:

```csharp
public MyContext() 
    : base(@"data source=YOURSERVER;initial catalog=BloodBank;integrated security=True")
{
}
```
### 4. Run the Application
- Open the solution in Visual Studio 2022

- Build the project (Ctrl+Shift+B)

- Run the main application (F5)

## 🖥️ Usage
### Login Credentials
- Admin: Username:	admin, password: admin123
- Hospital: Username:	hospital1, password:	123456
- Clinic: Username:	clinic1, password:	123456
- Nursing home: Username:	nursinghome1, password:	123456
- Donor: Username:	donor1, password:	123456

## 📊 Database Schema
See more in [Report](BloodBankManagementReport.docx)
