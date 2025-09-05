# Soft Books SACCO Management System

## 💰 The Low-Cost, Dynamic SACCO Management Solution

The **Soft Books SACCO Management System** is a comprehensive, multi-user, client/server solution designed to provide small, mid-sized, and large organizations with a powerful, yet low-cost, tool for managing their operations. The system is built to be dynamic and fully compliant with ever-changing financial regulations in Kenya, ensuring organizations stay ahead of policy changes while promoting **accountability**, **transparency**, and **efficiency**.

-----

## ✨ Key Features

This system integrates all aspects of SACCO functions, offering unparalleled flexibility and control:

  - **Unlimited Capacity**: Supports an unlimited number of members and users.
  - **Client/Server Architecture**: A desktop application built with **C\# Windows Forms** connects to a central **Microsoft SQL Server database** for secure, multi-user access.
  - **Member & Loan Management**: Streamlines the processes of member registration, savings, and loan management. The system automatically calculates interest, tracks repayments, and manages outstanding balances.
  - **Automated Reporting**: Instantly generates all transactional reports and financial statements, eliminating the need for manual work. Reports are produced in **PDF format** for easy portability and sharing.
  - **Flexible Accounting**: The system provides a **flexible chart of accounts**, allowing users to define their own general ledger codes and accounts.
  - **Versatile Use**: Ideal for in-house use, hosted environments, or for accountants representing multiple client organizations. It is tailored to meet the needs of various groups, including SACCOs, welfare groups, and chamas.

-----

## 💻 Installation

The installation process has two main components: the **Microsoft SQL Server Database (backend)** and the **C\# Windows Forms Application (client)**.

### Server Setup (SQL Server)

1.  **Install SQL Server**: Install a supported version of Microsoft SQL Server on a central server.
2.  **Restore Database**: Restore the `SoftBooksSACCO.bak` file or run the SQL scripts to create the database schema.
3.  **Create User**: Create a dedicated SQL Server user with appropriate permissions.
4.  **Configure Network Access**: Ensure the server is configured to accept remote connections on port 1433.

### Client Setup (C\# Windows Forms Application)

There are two methods to set up the client application on a user's workstation:

  - **Method 1: Using the Installer**: The easiest way is to run the provided `setup.msi` file. You may need to manually update the database connection string afterward.
  - **Method 2: Building from Source**: For developers, clone the repository, open the `SoftBooksSACCO.sln` file in **Visual Studio 2010**, update the database connection string in `App.config`, and then build and run the solution.

-----

## 🚀 Usage

The Soft Books SACCO system offers a user-friendly interface for managing all SACCO-related tasks, categorized into several key modules:

  - **Administration & Configuration**: Manage users, roles, and permissions; perform database backups and restores; and configure general system settings.
  - **Member Management**: Add, edit, and manage member profiles, including savings, shares, and contributions.
  - **Loan Management**: Process loan applications, manage approvals, and track repayment schedules.

### Reporting

The system provides a comprehensive suite of reports, which can be viewed and exported to **PDF** and **Excel**:

  - **Member Reports**: Member lists, statements, and contribution schedules.
  - **Loan Reports**: Loan repayment schedules, outstanding loan balances, and payment history.
  - **Financial Reports**: Balance sheets and income statements.

-----

## 🛠️ Technology Stack

  - **Client**: C\# / .NET Framework (Windows Forms)
  - **Development Environment**: Visual Studio 2010
  - **Database**: Microsoft SQL Server

-----

## 📜 License & Contribution

This project is licensed under the **MIT License**. Contributions are welcome\! Please fork the repository, create a feature branch, and open a pull request.

-----

## 📧 Contact

For support, feature requests, or collaboration, please contact the project lead:

  - **Name**: Kevin Mutugi Kithinji
  - **Email**: kevinmutugikithinji254@gmail.com
  - **Website**: [https://kevin-mutugi-kithinji-portfolio.onrender.com/](https://www.google.com/search?q=https://kevin-mutugi-kithinji-portfolio.onrender.com/)