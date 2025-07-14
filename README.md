# 🚛 eShift Logistics System

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-00000F?style=for-the-badge&logo=mysql&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)

**A comprehensive Windows Forms desktop application for Household Goods Transport Management**

[Features](#-features) • [Installation](#-installation) • [Architecture](#-architecture) • [Usage](#-usage) • [Contributing](#-contributing)

</div>

---

## 📖 Overview

eShift Logistics System is a robust desktop application built with **C# (.NET 8)** and **MySQL**, designed specifically for **Household Goods Transport Management**. The system implements a clean **3-layer architecture** with **Repository Pattern** and **Service Layer** for scalable and maintainable code.


### 🎯 Key Objectives
- Streamline household goods transportation operations
- Provide comprehensive fleet and personnel management
- Implement role-based access control for Admin and Customer users
- Generate detailed business reports with export capabilities
- Automate email notifications for enhanced customer communication
- Maintain centralized data management with MySQL database

---

## 🚀 Features

### 👥 User Roles & Capabilities

#### 🔑 **Admin Dashboard**
- **Customer Management**: Complete CRUD operations for customer profiles
- **Job & Load Management**: Create, assign, track, and finalize transport jobs
- **Fleet Management**: Comprehensive truck, driver, and assistant management
- **Transport Unit Management**: Create and manage transport units (truck + driver + assistant combinations)
- **Product Catalog**: Maintain product types and pricing
- **Advanced Reporting**: Generate detailed PDF and Excel reports
- **Email System**: Automated customer notifications


#### 👤 **Customer Portal**
- **Self-Registration**: Create and manage customer accounts
- **Job Requests**: Submit detailed transport job requests with multiple items
- **Real-time Tracking**: Monitor job status and progress
- **Profile Management**: Update personal and contact information
- **Communication**: Receive automated email notifications

---

### 📋 Core System Modules

| Module | Description | Key Components |
|--------|-------------|----------------|
| 🔐 **Authentication** | Secure login system | Login validation, session management |
| 👥 **Customer Management** | Customer lifecycle management | Registration, profiles, status tracking |
| 📋 **Job Management** | End-to-end job processing | Creation, approval, assignment, tracking |
| 🚛 **Vehicle Management** | Fleet and personnel management | Trucks, drivers, assistants, units |
| 📦 **Product Management** | Goods catalog management | Product types, categories, pricing |
| 📊 **Reporting System** | Business intelligence | Custom reports, analytics, exports |
| 📧 **Email Service** | Automated communication | Job notifications, status updates |
| ✅ **Validation System** | Data integrity | Input validation, business rules |


---

## 🏗️ System Architecture

### **3-Layer Architecture with Repository Pattern**

```
eShift Logistics System
├── 🎨 Presentation Layer (Forms)
│   ├── Admin Forms
│   │   ├── AdminDashboardForm
│   │   ├── CustomerForm
│   │   ├── JobManagementForm
│   │   ├── VehicleManagementForm
│   │   └── ProductManagementForm
│   ├── Customer Forms
│   │   ├── CustomerDashboardForm
│   │   ├── RequestPickupForm
│   │   ├── JobSummaryForm
│   │   └── MyProfileForm
│   └── Shared Forms
│       ├── LoginForm
│       └── CustomerRegistrationForm
│
├── 🔧 Business Logic Layer (Services)
│   ├── Interface Layer
│   │   ├── IJobService
│   │   ├── IDriverService
│   │   ├── IProductService
│   │   └── IUserService
│   └── Service Implementation
│       ├── JobService
│       ├── DriverService
│       ├── ProductService
│       └── UnitService
│
├── 💾 Data Access Layer (Repository)
│   ├── Interface Layer
│   │   ├── IJobRepository
│   │   ├── IDriverRepository
│   │   ├── IProductRepository
│   │   └── IUserRepository
│   └── Service Implementation
│       ├── JobRepository
│       ├── DriverRepository
│       ├── ProductRepository
│       └── UserRepository
│
├── 📊 Models (Data Entities)
│   ├── User
│   ├── Job
│   ├── Load
│   ├── TransportUnit
│   ├── Driver
│   ├── Assistant
│   └── Product
│
├── 🛠️ Helpers & Utilities
│   ├── DatabaseHelper
│   ├── EmailHelper
│   ├── SessionManager
│   └── PlaceholderHelper
│
└── ✅ Validators
    ├── AssistantValidator
    ├── DriverValidator
    ├── JobValidator
    └── UserValidator
```

---

## 🛠️ Tech Stack

### **Core Technologies**
- **Language**: C# (.NET 8.0)
- **Database**: MySQL 9.0+
- **UI Framework**: Windows Forms (WinForms)
- **Architecture**: 3-Layer Architecture with Repository Pattern
- **IDE**: Visual Studio 2022

### **Key Dependencies**
| Package | Purpose | Usage |
|---------|---------|-------|
| `MySql.Data` | Database connectivity | Entity data operations |
| `MailKit` | Email services | Customer notifications |
| `ClosedXML` | Excel generation | Spreadsheet reports and data export |
| `QuestPDF` | PDF generation | Professional PDF reports and documents |
| `System.Windows.Forms` | Desktop UI | Forms and controls |

---

## 📂 Detailed Project Structure

```
eShift-Logistics-System/
├── 📁 Business/                    # Business Logic Layer
│   ├── 📁 Interface/               # Service contracts
│   │   ├── IAssistantService.cs
│   │   ├── IDriverService.cs
│   │   ├── IEmailService.cs
│   │   ├── IJobService.cs
│   │   ├── IJobStatusService.cs
│   │   ├── IProductService.cs
│   │   ├── IReportService.cs
│   │   ├── ITruckService.cs
│   │   ├── IUnitService.cs
│   │   └── IUserService.cs
│   └── 📁 Services/                # Business logic implementation
│       ├── AssistantService.cs
│       ├── DriverService.cs
│       ├── EmailService.cs
│       ├── JobService.cs
│       ├── JobStatusService.cs
│       ├── ProductService.cs
│       ├── ReportService.cs
│       ├── TruckService.cs
│       ├── UnitService.cs
│       └── UserService.cs
│
├── 📁 Forms/                       # Presentation Layer
│   ├── 📁 Admin/                   # Admin interface
│   │   ├── AddEditAssistantForm.cs
│   │   ├── AddEditDriverForm.cs
│   │   ├── AddEditProductForm.cs
│   │   ├── AddEditTransportUnitForm.cs
│   │   ├── AddEditTruckForm.cs
│   │   ├── AdminDashboardForm.cs
│   │   ├── AdminReportForm.cs
│   │   ├── CustomerForm.cs
│   │   ├── DashboardViewForm.cs
│   │   ├── JobDetailsForm.cs
│   │   ├── JobManagementForm.cs
│   │   ├── ProductManagementForm.cs
│   │   ├── ReportForm.cs
│   │   └── VehicleManagementForm.cs
│   ├── 📁 Customer/                # Customer interface
│   │   ├── CustomerDashboardForm.cs
│   │   ├── CustomerDashboardViewForm.cs
│   │   ├── JobSummaryForm.cs
│   │   ├── MyJobForm.cs
│   │   ├── MyJobsForm.cs
│   │   ├── MyProfileForm.cs
│   │   └── RequestPickupForm.cs
│   ├── 📁 Shared/                  # Common forms
│   │   ├── CustomerRegistrationForm.cs
│   │   └── LoginForm.cs
│
├── 📁 Helpers/                     # Utility classes
│   ├── CommonHelper.cs
│   ├── DatabaseHelper.cs
│   ├── EmailHelper.cs
│   ├── PlaceholderHelper.cs
│   └── SessionManager.cs
│
├── 📁 Models/                      # Data entities
│   ├── Assistant.cs
│   ├── Driver.cs
│   ├── Enums.cs
│   ├── Job.cs
│   ├── JobProduct.cs
│   ├── JobStatusLog.cs
│   ├── Load.cs
│   ├── Product.cs
│   ├── TransportUnit.cs
│   ├── Truck.cs
│   └── User.cs
│
├── 📁 Repository/                  # Data Access Layer
│   ├── 📁 Interface/               # Repository contracts
│   │   ├── IAssistantRepository.cs
│   │   ├── IDriverRepository.cs
│   │   ├── IJobRepository.cs
│   │   ├── IJobStatusRepository.cs
│   │   ├── IProductRepository.cs
│   │   ├── IReportRepository.cs
│   │   ├── ITruckRepository.cs
│   │   ├── IUnitRepository.cs
│   │   └── IUserRepository.cs
│   └── 📁 Service/                 # Repository implementation
│       ├── AssistantRepository.cs
│       ├── DriverRepository.cs
│       ├── JobRepository.cs
│       ├── JobStatusRepository.cs
│       ├── ProductRepository.cs
│       ├── ReportRepository.cs
│       ├── TruckRepository.cs
│       ├── UnitRepository.cs
│       └── UserRepository.cs
│
├── 📁 Validators/                  # Input validation
│   ├── AssistantValidator.cs
│   ├── DriverValidator.cs
│   ├── JobValidator.cs
│   ├── LoginValidator.cs
│   ├── ProductValidator.cs
│   ├── TransportUnitValidator.cs
│   ├── TruckValidator.cs
│   └── UserValidator.cs
│
├── 📄 Program.cs                   # Application entry point
├── 📄 README.md                    # Project documentation
└── 📄 .gitattributes              # Git configuration
```

---

## 🚀 Installation & Setup

### 📋 Prerequisites

Ensure you have the following installed:

- **Visual Studio 2022** (Community/Professional/Enterprise)
- **.NET 8 SDK** or later
- **MySQL Server 9.0+** with MySQL Workbench
- **Windows 10/11** (x64 recommended)

### 🔧 Installation Steps

1. **Clone the Repository**
   ```bash
   git clone https://github.com/Lprabodha/eShift-logistics-system.git
   cd eShift-logistics-system
   ```

2. **Open in Visual Studio**
   - Launch Visual Studio 2022
   - Open the solution file: `eShift-Logistics-System.sln`

3. **Database Configuration**
   ```sql
   -- Create the main database
   CREATE DATABASE eShiftDB;
   USE eShiftDB;
   
   -- Import schema (execute the provided SQL script)
   SOURCE path/to/eShiftDB.sql;
   ```

4. **Update Connection String**
   
   Update `DatabaseHelper.cs` or `App.config`:
   ```csharp
   private static string connectionString = 
       "Server=localhost;Database=eShiftDB;Uid=root;Pwd=yourpassword;";
   ```

5. **Install NuGet Packages**
   ```bash
   # In Package Manager Console
   Install-Package MySql.Data
   Install-Package MailKit
   Install-Package ClosedXML
   Install-Package QuestPDF
   ```

6. **Configure Email Settings**
   
   Update `EmailHelper.cs`:
   ```csharp
   private static readonly string SmtpServer = "smtp.gmail.com";
   private static readonly string EmailAddress = "your-email@gmail.com";
   private static readonly string AppPassword = "your-app-password";
   ```

7. **Build and Run**
   - Press **F5** or click **Start** to build and launch
   - Default admin login: Check database or create new account

---

## 🎯 Usage Guide

### 🔐 **Getting Started**

1. **First Launch**
   - The application starts with `AdminDashboardForm` (as configured in `Program.cs`)
   - Use the login system to authenticate users
   - Admin accounts have full system access

2. **Admin Workflow**
   ```
   Login → Dashboard → Manage Customers/Jobs/Fleet → Generate Reports
   ```

3. **Customer Workflow**
   ```
   Register → Login → Request Pickup → Track Job Status
   ```

### 📊 **Key Operations**

#### **Job Management Process**
1. Customer submits pickup request via `RequestPickupForm`
2. Admin reviews and assigns transport unit via `JobManagementForm`
3. System calculates costs using `JobService.CalculateEstimatedCost()`
4. Job status updates automatically trigger email notifications
5. Reports can be generated at any stage

#### **Fleet Management**
1. Add trucks, drivers, and assistants individually
2. Create transport units by combining truck + driver + assistant
3. Assign units to jobs based on availability and capacity
4. Track unit utilization through reporting system

---

## 📧 Email Configuration

The system uses **MailKit** for sending automated notifications:

### **Supported Email Events**
- Job request submissions
- Job status changes (Accepted/Declined/In Progress/Completed)
- Customer registration confirmations
- Admin alerts and notifications

### **SMTP Configuration**
```csharp
// EmailHelper.cs configuration
public static class EmailHelper
{
    private static readonly string SmtpServer = "smtp.gmail.com";
    private static readonly int SmtpPort = 587;
    private static readonly bool EnableSsl = true;
    
    // Use environment variables in production
    private static readonly string SenderEmail = Environment.GetEnvironmentVariable("ESHIFT_EMAIL");
    private static readonly string AppPassword = Environment.GetEnvironmentVariable("ESHIFT_PASSWORD");
}
```

---

## 📊 Reporting System

### **Report Generation Libraries**

The system uses modern, powerful libraries for document generation:

#### **📈 ClosedXML - Excel Reports**
- **Customer Reports**: Detailed customer lists with contact information
- **Job Analytics**: Job performance metrics and financial data
- **Fleet Utilization**: Vehicle and driver performance statistics
- **Financial Reports**: Revenue analysis and cost breakdowns

```csharp
// Example: Generating Excel report with ClosedXML
using (var workbook = new XLWorkbook())
{
    var worksheet = workbook.Worksheets.Add("Customer Report");
    worksheet.Cell("A1").Value = "Customer Name";
    worksheet.Cell("B1").Value = "Total Jobs";
    // ... populate data
    workbook.SaveAs("CustomerReport.xlsx");
}
```

#### **📄 QuestPDF - Professional PDF Reports**
- **Job Invoices**: Professional invoicing with company branding
- **Transport Documents**: Delivery receipts and job summaries
- **Business Reports**: Executive summaries and analytics
- **Customer Statements**: Account statements and transaction history

```csharp
// Example: Generating PDF report with QuestPDF
Document.Create(container =>
{
    container.Page(page =>
    {
        page.Header().Text("eShift Logistics - Job Report");
        page.Content().Column(column =>
        {
            column.Item().Text($"Job Number: {job.JobNumber}");
            column.Item().Text($"Customer: {job.Customer.Name}");
            // ... add more content
        });
    });
}).GeneratePdf("JobReport.pdf");
```

### **Available Report Types**
| Report Category | Excel (ClosedXML) | PDF (QuestPDF) |
|-----------------|-------------------|----------------|
| **Customer Management** | ✅ Customer lists, contact details | ✅ Customer statements, profiles |
| **Job Analytics** | ✅ Performance metrics, data analysis | ✅ Job invoices, delivery receipts |
| **Fleet Management** | ✅ Utilization statistics, schedules | ✅ Vehicle reports, maintenance logs |
| **Financial Reports** | ✅ Revenue analysis, cost breakdowns | ✅ Executive summaries, statements |
| **Operational Reports** | ✅ KPI dashboards, trend analysis | ✅ Operational summaries, compliance |

### **Export Features**
- **Multiple Formats**: Seamlessly export to both Excel and PDF
- **Custom Templates**: Branded report templates with company logos
- **Automated Generation**: Scheduled reports and automatic distribution
- **Interactive Data**: Excel reports with charts, pivot tables, and formulas
- **Professional Layout**: PDF reports with consistent formatting and styling

---

## 🧪 Testing & Validation

### **Built-in Validation**
The system includes comprehensive validators for:
- User input validation (`UserValidator`, `JobValidator`)
- Business rule enforcement (`DriverValidator`, `AssistantValidator`)
- Data integrity checks (`ProductValidator`, `TransportUnitValidator`)

### **Testing Approach**
- Manual testing through comprehensive UI workflows
- Database integrity testing with sample data
- Email functionality testing with test accounts
- Report generation testing across different data sets
- PDF and Excel export validation

---

## 🔧 Troubleshooting

### **Common Issues & Solutions**

#### ❌ Database Connection Failed
```
Error: Unable to connect to MySQL server
```
**Solutions:**
- Verify MySQL service is running
- Check connection string credentials
- Ensure database exists and is accessible
- Verify firewall settings

#### ❌ Email Sending Failed
```
Error: SMTP authentication failed
```
**Solutions:**
- Enable 2FA and use App Password for Gmail
- Verify SMTP server settings
- Check network connectivity
- Review email helper configuration

#### ❌ Report Generation Error
```
Error: Cannot generate PDF/Excel report
```
**Solutions:**
- Verify ClosedXML and QuestPDF packages are installed
- Check file permissions in output directory
- Ensure sufficient disk space
- Verify data source availability
- Check for missing fonts (PDF generation)

#### ❌ Package Installation Issues
```bash
# If you encounter package conflicts
dotnet restore --force
# Or clean and rebuild
dotnet clean
dotnet build
```

---

## 🚧 Development Roadmap

### **Version 2.0 (Planned)**
- [ ] **Web Interface**: ASP.NET Core web application
- [ ] **Mobile App**: Cross-platform mobile application
- [ ] **Real-time Tracking**: GPS integration for live tracking
- [ ] **Advanced Analytics**: Business intelligence dashboard with interactive charts
- [ ] **API Integration**: RESTful API for third-party integrations
- [ ] **Enhanced Reports**: Advanced reporting with data visualization

### **Version 1.5 (In Development)**
- [ ] **Enhanced Security**: Advanced authentication and authorization
- [ ] **Performance Optimization**: Database query optimization and caching
- [ ] **Extended Reporting**: More comprehensive business reports with QuestPDF templates
- [ ] **Excel Automation**: Advanced ClosedXML features with charts and pivot tables
- [ ] **Audit Trail**: Complete system activity logging
- [ ] **Multi-language Support**: Localization framework

---

## 🤝 Contributing

We welcome contributions to enhance the eShift Logistics System!

### **Development Guidelines**

1. **Fork & Clone**
   ```bash
   git fork https://github.com/Lprabodha/eShift-logistics-system.git
   git clone https://github.com/YOUR_USERNAME/eShift-logistics-system.git
   ```

2. **Create Feature Branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **Code Standards**
   - Follow C# naming conventions and best practices
   - Implement proper error handling and logging
   - Add XML documentation for public methods
   - Follow the existing architecture patterns
   - Write meaningful commit messages
   - Test report generation functionality

4. **Testing**
   - Test your changes thoroughly
   - Verify database operations
   - Test UI functionality across different scenarios
   - Ensure email notifications work correctly
   - Validate PDF and Excel report generation

5. **Submit Pull Request**
   - Provide clear description of changes
   - Reference any related issues
   - Ensure all validations pass

### **Code Review Process**
- All pull requests require review
- Maintain backward compatibility
- Follow security best practices
- Document any breaking changes

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for complete details.

```
MIT License

Copyright (c) 2025 Lprabodha

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
```

---

## 📞 Support & Contact

- **🐛 Bug Reports**: [Create an Issue](https://github.com/Lprabodha/eShift-logistics-system/issues/new?template=bug_report.md)
- **💡 Feature Requests**: [Request Feature](https://github.com/Lprabodha/eShift-logistics-system/issues/new?template=feature_request.md)
- **📧 Developer Contact**: [@Lprabodha](https://github.com/Lprabodha)
- **📂 Project Repository**: [eShift Logistics System](https://github.com/Lprabodha/eShift-logistics-system)

---

## 🙏 Acknowledgments

- **ClosedXML** team for excellent Excel generation capabilities
- **QuestPDF** developers for modern, flexible PDF generation
- **MailKit** developers for robust email functionality  
- **MySQL** community for reliable database solutions
- **Microsoft** for .NET framework and Visual Studio
- **Open Source Community** for continuous inspiration and support

---

<div align="center">

**⭐ If you find this project helpful, please consider giving it a star! ⭐**

**🚛 Built with ❤️ for efficient logistics management**

Made by [Lprabodha](https://github.com/Lprabodha) | © 2025

</div>