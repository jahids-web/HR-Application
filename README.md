# HR Application

The HR web application Api is a comprehensive solution designed to simplify and automate various HR processes. From employee onboarding to performance evaluations, payroll management, leave tracking, and more, our intuitive platform caters to the needs of organizations of all sizes, enhancing productivity and ensuring smooth HR operations.

</div>

## Demo
![Hr-Api jpg](https://github.com/jahids-web/HR-Application/assets/66508712/e0969c0f-58df-496b-9dca-2f8474113c90)

</br>

## Installation

Firstly, clone the project-
```
https://github.com/jahids-web/HR-Application
```
Secondly, Open the project in Visual Studio by running the `HR-Application.sln` solution file - 
```
cd HR-Application\HR-Application
```
There you will find a batch file named **`Hr-Application.Db.bak`**. 
Run that batch file to update the database - 

Step(1): `Apply Migration` _[option 2]_

Step(2): `Update All` _[option 1]_

or, You may manually run the `Update Database` using the following command
in the `Project Manager Console` in Visual Studio. 

```
dotnet ef database update -p .\Applications\HR_Api -c ApplicationDbContext
```

This will create a database named `HrDatabase` in your SQL Server 
(actually SSMS) and also the table(s) accordingly.

⚠️ **Your must-have `SQL Server and `SQL Server Management Studio` 
installed on your machine.**

    
## Environment Variables

In this path, 
there is a file named `appsettings.json`. 
If you face any issues updating the database then configure this line 
accordingly to your machine configuration - 
```
"ConnectionStrings": {
    "HrDatabase": "Server=DESKTOP-G86BGD8\\SQLEXPRESS;Database=Hr- 
    Application.Db;Trusted_Connection=True;MultipleActiveResultSets=true;"
  }
```
You may change the `Server` value according to your configuration.


## Tech Stack

**Backend:** ASP.NET (Core) 5,  Entity Framework (Core), SQL Server,
Fluent API

**Design Patterns:** Repository & Unit of Work Patterns

**Architecture:** Layered Architecture - n-Tier Architecture -
(Business Logic & Data Access Layer)

## Features
- Create employee
- View employees info
- Provide salary
- Approve Leave
- Delete Employee
- Leave apply
- View employee Present/leave report
- Present /Leave report
