# Soft Books Sacco Management System

## 💰 The Low-Cost, Dynamic Sacco Management Solution

The **Soft Books Sacco Management System** is a comprehensive, multi-user, client/server solution for small to large organizations. Built to be dynamic and compliant with Kenyan financial regulations, it promotes **accountability**, **transparency**, and **efficiency** in Sacco operations.

-----

## ✨ Key Features

This system integrates all aspects of Sacco functions, offering unparalleled flexibility and control:

  - **Unlimited Capacity**: Supports an unlimited number of members and users.
  - **Client/Server Architecture**: A desktop application built with **C\# Windows Forms** connects to a central **Microsoft SQL Server database** for secure, multi-user access.
  - **Modular Design**: The system comprises various integrated modules that function interdependently as a collective resource planning tool. These include:
      - **Authentication**: Manages user logins and permissions.
      - **Administrator**: Provides a control panel for system managers to handle user accounts, roles, and settings.
      - **Customer**: A central hub for member management, including registration and profile tracking.
      - **Data Access Layer**: Separates application logic from the database, handling all data communication.
      - **Database Administration**: Administrative tools for database backup, restore, and user management.
      - **Loans**: Automates the entire loan life cycle, including applications, interest calculations, and repayment tracking.
      - **Reports**: Generates a comprehensive suite of financial and operational reports in **PDF** and **Excel** formats.
      - **Savings**: Manages member savings, share contributions, and dividend disbursements.
      - **Search**: Provides powerful search functionality to quickly locate members, loans, or transactions.
      - **Tellers**: Manages daily cash transactions, including member deposits and withdrawals.
  - **Member & Loan Management**: Streamlines the processes of member registration, savings, and loan management.
  - **Automated Reporting**: Instantly generates all transactional reports and financial statements, eliminating manual work.
  - **Flexible Accounting**: The system provides a flexible chart of accounts, allowing users to define their own general ledger codes.
  - **Versatile Use**: Ideal for in-house use, hosted environments, or for accountants representing multiple client organizations.

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

The Soft Books SACCO system offers a user-friendly interface for managing all SACCO-related tasks.

### Core Modules Explained

  - **Authentication**: This module is the system's security gatekeeper, managing user logins and password verification.
  - **Administrator**: Provides a control panel for system managers to create user accounts, assign roles, and configure settings.
  - **Customer**: The central hub for member management, from new registrations to profile updates.
  - **Data Access Layer (DAL)**: A foundational component that handles all communication between the application and the SQL Server database.
  - **Database Administration**: A tool for managing the database through backups, restores, and user management.
  - **Loans**: Automates the entire loan life cycle, including applications, interest calculation, and repayment tracking.
  - **Reports**: Generates comprehensive financial and operational reports in PDF and Excel formats.
  - **Savings**: Manages member savings, share contributions, and dividend disbursements.
  - **Search**: A powerful tool to quickly locate specific members, accounts, or transactions.
  - **Tellers**: Manages daily cash transactions, including member deposits and withdrawals.

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