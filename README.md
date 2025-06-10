# eShift Logistics System

A Windows Forms-based desktop application built with C# and MySQL, designed for **Household Goods Transport Management**. Developed using the **Model-View-Controller (MVC)** architecture in **Visual Studio 2022**, this application streamlines eShift's operations including customer registration, job creation, load assignment, transport unit management, reporting, and more.

---

## 🚀 Features

### 👥 User Roles
- **Admin**
  - Manage Customers
  - Manage Jobs and Loads
  - Manage Drivers, Assistants, Containers
  - Manage Product Types
  - Generate Reports (PDF, Excel)
- **Customer**
  - Register and Login
  - Create Transport Jobs
  - View Job Status
  - Manage Own Profile

---

### 📋 Modules

| Module                      | Description                              |
|-----------------------------|------------------------------------------|
| **Login System**            | Secure Admin and Customer login          |
| **Customer Management**     | Add, edit, delete customer profiles      |
| **Job Management**          | Create, update, approve/decline jobs     |
| **Load Management**         | Assign transport units to loads          |
| **Transport Units**         | Manage drivers, assistants, containers   |
| **Product Management**      | Add/edit/delete goods/product types      |
| **Reporting**               | Generate customer and job reports        |
| **Email Notifications**     | Send updates to customers (MailKit)      |

---

## 🧱 Tech Stack

- **Language:** C# (.NET 8)
- **Database:** MySQL 9.0
- **UI:** Windows Forms (WinForms)
- **Architecture:** MVC (Model-View-Controller)
- **Reporting:** [FastReport.OpenSource](https://github.com/FastReports/FastReport)
- **Email Service:** [MailKit](https://github.com/jstedfast/MailKit)
- **IDE:** Visual Studio 2022

---

## 🛠️ Installation

### Prerequisites

- Visual Studio 2022
- .NET 8 SDK 
- MySQL Server 9.0+
- NuGet Packages:
  - `MySql.Data`
  - `MailKit`
  - `FastReport.OpenSource`

### Steps

1. **Clone the repository**
    ```bash
    git clone https://github.com/Lprabodha/eShift-logistics-system
    ```
2. **Open in Visual Studio 2022**
    - Open the `.sln` file in Visual Studio.

3. **Setup MySQL Database**
    - Import `eShiftDB.sql` from the `/Database` folder.

4. **Update Connection String**
    - Update the connection string in `App.config` or `DatabaseHelper.cs` as per your MySQL setup.

5. **Build and Run**
    - Press **F5** to build and launch the application.

---

## 📂 Project Structure

```
eShiftProject/
├── Models/
├── Views/
├── Controllers/
├── Helpers/
├── Resources/
├── Database/
├── Reports/
├── Program.cs
└── App.config
```

---

## 📸 Screenshots

*(Add screenshots here of Dashboard, Job Management, Reports, etc.)*

---

## 📧 Email Configuration

To enable email notifications:

1. Go to `EmailHelper.cs`
2. Update your SMTP settings:
    ```csharp
    client.Connect("smtp.gmail.com", 587, false);
    client.Authenticate("your-email@gmail.com", "your-app-password");
    ```
    ⚠️ **Use an App Password or environment variables for security.**

---

## 📈 Reports

- Report templates are stored in the `Reports/` folder (`.frx` files).
- Generate reports via `ReportForm.cs`.
- Export supported: **PDF**, **Excel**.

---

## 🤝 Contributing

1. Fork the repo
2. Create a new branch (`feature/YourFeature`)
3. Commit your changes
4. Open a pull request

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
