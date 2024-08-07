# Employee Management System

## Overview

The Employee Management System is an ASP.NET Core MVC application designed to facilitate the management of employee details within a company. This system supports role-based access control, enabling various functionalities depending on the user's role. It leverages SQL Server for data storage, Bootstrap for UI enhancements, and the ASP.NET Core Identity API for role management.

## Features

- **Role-based Access Control**:
  - **Admin**: 
    - Manage employees
    - View and manage employee feedback
  - **Manager**:
    - Approve or reject leave requests from employees
  - **Employee**:
    - Request leave
    - View leave request status (Pending, Approved, Rejected)
  - **Finance Department**:
    - Manage payroll on a month-wise basis for employees

## Technologies Used

- **ASP.NET Core MVC**: Framework used for building the web application.
- **SQL Server**: Database management system for storing employee data and application information.
- **Bootstrap**: Frontend framework used for enhancing the UI and ensuring a responsive design.
- **ASP.NET Core Identity API**: Provides role management and user authentication.

## Setup and Installation

### Prerequisites

- .NET 6.0 or later
- SQL Server (local or remote instance)
- Visual Studio 2022 or later (recommended) or any other compatible IDE

### Installation Steps

1. **Clone the Repository**:
   - Open a terminal or command prompt.
   - Clone the repository using Git:
     ```bash
     git clone https://github.com/shreya1201/EmployNet.git
     ```
   - Navigate to the project directory:
     ```bash
     cd EmployNet
     ```

2. **Connect to SQL Server**:
   - Open SQL Server Management Studio (SSMS) or your preferred SQL Server management tool.
   - Create a new database named `EmployNet`.

3. **Configure the Connection String**:
   - Open the project folder in your IDE (e.g., Visual Studio).
   - Locate the `appsettings.json` file in the project.
   - Update the `"DefaultConnection"` string with your SQL Server instance name and the `EmployNet` database name. Replace `YOUR_SERVER_NAME` with your actual server name. Example:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EmployNet;Trusted_Connection=True;"
       },
       ...
     }
     ```

4. **Apply Database Migrations**:
   - Open the NuGet Package Manager Console in Visual Studio (navigate to Tools > NuGet Package Manager > Package Manager Console).
   - Run the following command to apply the migrations and create the necessary tables in the `EmployNet` database:
     ```bash
     Update-Database
     ```
     
5. **Run the Application**:
   - Return to your terminal or command prompt.
   - Run the application using the following command:
     ```bash
     dotnet run
     ```
## Role-Based Credentials

To quickly get started, you can use the following credentials for each role:

- **Employee**:
  - **Email**: `user@gmail.com`
  - **Password**: `User@123`

- **Admin**:
  - **Email**: `admin@gmail.com`
  - **Password**: `Admin@123`

- **Manager**:
  - **Email**: `manager@gmail.com`
  - **Password**: `Manager@123`

- **Finance Department**:
  - **Email**: `finance@gmail.com`
  - **Password**: `Finance@123`
