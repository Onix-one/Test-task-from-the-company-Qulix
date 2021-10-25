# "ProjectZ"
How to start:
1) Click button "Code" and "Open with Visual Studio"
2) Use file ProjectZDb.sql into Microsoft SQL Server Management Studio 18 (After that, a full database will be generated.)
3) Run the project in Visual Studio
# SQL script ProjectZDb.sql is located into folder ProjectZ


# Task description.
Develop an application for registering employees of companies.

The application must allow the following data to be entered, edited and deleted:
1. Employee
a. Identifier
b. Surname
c. First name
d. middle name
e. Date of employment
f. Position (Developer | QA | Business analyst | Manager)
g. Company
2. Company
a. Identifier
b. Name of
c. Organizational and legal form (for example, LLC, CJSC, etc.)

The application must contain the following basic elements:
1). Main Menu
a. Employees: The form "List of employees" is displayed
b. Companies: The form "List of companies" is displayed

2). Form "List of employees"
a. Columns:
i. Identifier
ii. Surname
iii. First name
iv. middle name
v. Employment date
vi. Position (Developer | Tester | Business Analyst | Manager)
vii. Company
b. Form-level commands
i. Add: The employee input form is displayed in add mode
c. Recording Level Commands
i. Edit: The employee input form is displayed in edit mode
ii. Delete: The current entry is deleted

3). Form "List of companies"
a. Columns:
i. Identifier
ii. Name of
iii. Company size
iv. Organizational and legal form
b. Form-level commands
i. Add: Displays a company entry form in add mode
c. Recording Level Commands
i. Edit: The company entry form is displayed in edit mode
ii. Delete: The current entry is deleted

4). Employee entry form
a. Fields:
i. Identifier: the serial number of the employee (generated automatically)
unavailable for modification
ii. Surname
iii. Name
iv. middle name
v. Employment date
vi. Position (Developer | Tester | Business Analyst | Manager)
vii. Company: selected from the list of companies
b. Commands:
i. Save: the entered data is saved in the database; control is transferred to the "List of employees" form
ii. Cancel: control is transferred to the "List of workers" form

5). Company entry form
a. Fields:
i. Identifier
ii. Name
iii. Organizational and legal form
b. Commands:
i. Save: the entered data is saved in the database; management is transferred to the form "List of companies"
ii. Cancel: management is transferred to the "List of Companies" form

A note on terminology: “command” refers to any control used to
start an operation, for example, it can be a button, an icon, a hyperlink, etc.
Parts of the assignment in italics are given lower priority than the rest.
Please also note that the forms for adding / editing entities must be
are separated from list forms.
Any improvements to the functionality of the app are greatly appreciated. (For example, the possibility
devices of an employee to several companies, adding sorting or filtering, performing
validation of the input data, etc.) - if this does not conflict with the quality of development.
The application must have a web interface.
The application must be implemented with the following restrictions:
- Three-layer architecture;
- Using the best practices and recommendations;
- Development environment: Visual Studio, .NET Framework or .NET Core.
- The programming language is C #.
- Technology: ASP.NET MVC.
- Database –MS SQL.
- The use of third-party libraries is prohibited (including mappers, containers, etc. If there is a need for them, you must implement them yourself), except for libraries for accessing data.
- To access data, you need to use pure ADO.NET or a very light ORM (not LINQ,
not EF, not NHibernate and the like).
* Using ADO.NET and avoiding third party libraries is very important because will allow us to evaluate your work, the ability to correctly design systems, as well as fundamental knowledge of many parameters.
The project should include:
- all files required to build and run the application.
- script (s) to automatically build and install the application and create a database.
Source codes should be neatly formatted, all interface methods should contain comments describing their purpose, and a consistent code naming and formatting system is encouraged. You must demonstrate your “programming culture” to the maximum extent possible.
An explanatory note describing how to install and work with the application is encouraged.
One day is usually allotted for the completion of such a task.
