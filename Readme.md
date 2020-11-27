1. Creating thr Application
- Console App
	- Desktop App
- Project Important Sections
	- References
		- Standard .NET Assembly(?) references used for programming
			- They contains Standard .NET Classes
		- All these Assemblies (aka Libraries) are available from
			- Base Class Libraries (BCL) aka Framework Class Libraries (FCL)
			- System.dll
				- Highest level assembly/library in .NET
				- Contains classes for
					- DataTypes
					- Console
					- .... and many more
			- System.Data
				- Contains all classed for Database programming
			- System.Core
				- USed for LINQ
			- System.Xml
				- Used for XML Programming
			- System.Xml.Linq
				- Used for LIQ to XML
			- Microsoft.CSharp
				- C# Compiler Services
			- System.Net.Http
				- For Network Programming
				
	- Configuration File
		- App.Config
			- Application Configuration for Desktop Apps
				- WinForm , WPF, Comsole Apps
			- Contains .NET Framework Configuration to Execute the app 
		- Web.Config
			- COnfiguration for Web Apps
	- Code Files
		- Source Code
======================================================================================================
1. When any class is supposed to be used in the code file, make sure thst, its namespasce(?) 
is imported in the code file.
	- Namespace, is a logical collection of classes, related or not related with each othee
		but used for similar types of operations.
			- Related means, classes may have Based->Derived (inheritance) relationship
			- May be 'sealed' classs, means cnnot be derived, independant classes
		- All classes perform operations on similar resources
			- e.g. System.Data namspace
					- all classes are used for Database programming
			- e.g. System.IO
					- all classes are used for Stream or File operations
					

2. After Successful build the Project generats 3 files using Visual Studio
	- Assembly File
		- .exe / .dll
		- Every .NET Application generates assembly after successful build
			- .exe assembly
				- Self-Executable in .NET Framework
				- Console Appp, Windows Desktop App and Windows Service
			- .dll assembly
				- Must be used or referred in .exe assembly to get executed
				- Classs Library Projects
				- ASP.NET Web Forms, MVC Apps and Web API 
	- Deployment Configuration file
		- .exe.config
			- Merging between Assemble and Application Configuration File 
				(App.config / Web.confile)
	- Debugger File
		- .pdb file
			- Used in case of Code Debugging
			- This file will be generated only in case of Debug Mode
	- Each .NET Application Have 3 Modes	
		- Coding Mode, we write the code
		- Debug Mode	
			- Run the application in Debugging mode by applying breakpoints
			- Generally used to verify if the code works correctly
		- Running Mode or Production Mode
			- On Production Machine
			- No debugging is allowed
	- Use F5 to run the project in VS
	- F10 to debug using Step-Over
		- Skip the function / method call in debugging
	- F11 to debug using Step-into
		- Enter into method call and also debug easch line in called method
==========================================================================================
Access Specifiers
- Define the scope of Accessing Classes, Method,Proprties of the application / namespaces
	to other class or assembly
- public, accessible everywhere
- private, only within the class
	- Default for Methods, data members and propertis of the class
- protected, within the class and in derived class
- internal, only in containing namespace
	- Default for Class
- protected internal, only in containing namespace and in the derived class of other 
	namespace
=========================================================================================
DataTypes
1. Numeric
	- byte, 8 bits, System.Byte, 0-256
	- short and ushort, 16 bits, System.Int16,
	- int and uint, 32 bits, System.Int32
	- long and ulong, 64 bits, System.Int64
	- float, 32 bits, System.Float32
	- double, 64 bits, System.Float64
	- decimal, 64bytes, System.Decimal, 
	- BigInt highest size
2. String
	- char, 2 bytes, Uni-Code characters, special characters and Symbols, System.Char
	- string
		- Reference Type
		- System.String class
3. Date, System.Date
4. Boolean, bool, True / False
5. Object, object (keyword), System.Object 
==========================================================================================
Create an Instance of Class
- Using the 'new' keyword
- If the class is not instantiated using 'new' then the execption will be thrown as
	"Obnject reference is not set to an instance of the object"
==========================================================================================
- The .NET Framework provides following Services to the Application
	- Compiles the Source Code using 
		- Common Language Service (CLS)
			- Verifies LHS = RHS, if match then only the line is interpreted and compiles
			- Syngtax Check
				- Statement termination using ';'
			- Data Type Check with allowed value based on size of the data type
		- Base Class Library or Framework Class Library
			- Make sure that, the classes are referred with its namespaces
			- If the class is used from the different library, then that librery must
				be referenced in current project.
	- Common Language Runtime (CLR)
		- Accepts the Compiled Assembly as Input (.exe /.dll)
		- Uses Just-In-Time compiler to Execute the assermbly using fopllwoing step
			- Load the Assembly in AppDomain (Precess provided by CLR to the executing App)
		- Provides Memory Management

Source Code ----> Language Specific Compiler With Standard Classes (CLS and FCL)
					---> Output into Assembly (.exe / .dll) 
							---> Input to CLR
									--> Execute it with Jit and Memory Management

.NET Framework Supports XCOPY deployment. 
	- Copy assembly from Dev. machine to Prod. machine, provided the Prod. machine has
		.NET Framework, the app will work.
==========================================================================================
What CLR class contains?
1. Data Members
2. Method
3. Properties
	- Intelligent fields
		- They provide a logic to execute the Private Data member
			- set(value), use to set the 'value' to the data member
				- Internally this is a setter() method
			- get, return the value of the data member
				- Internally this is a getter() method
	- Type properties
		- Read/Write
			- getter and setter
		- Read only properties
			- only getter
	- New Sytax for properties C# 3.0+ 
		- Property w/o private data member also known as "AUTO-IMPLEMENTED-PROPERTIES"
		- USe Auto-Implemenetd proeprties for creating Data Classes or Entity Classes
		
4. Events

==========================================================================================
Collections
- Each Collection class implements IEnumerbale interface
- Array is a class that implments IENumerable interface
- Any array by default bacomes an instance of Array class

===========================================================================================
Exercise with Self Study
1. Learn the Inheritance in C#
	- Explore the following
		- Protected Access Specifier
		- Overloading
		- Overriding
			- Day 2: How many times an abstract or virtual method of the base class can be
					overriden?
			- Can we have Private or Protected virtual or abstract method?
			- Can we override Private or Protected virtual or abstract method using public
				method?
		- Shadowing
2. Learn Boxing and UnBoxing
===========================================================================================

Day 2: 

To support Language Integrated Queries (LINQ) Microsoft have added following features in 
	C# Programming
1. Auto-Implemneted Properties
2. Extension Methods
3. Lambda Expression
	- This is a mechanism which 'hides a method implementation(?)' and execute it as 
		a Binary Expression (?)
	- Prerequisites
		- Must know Delegates	
			- It is a type using which a method can be invoked (called) and executed using its
				reference
					- To Execute a method using delegate folloiwng rule must be satisfied
						- The Delegate Signeture (Input and output parameters) must match
						with the mathod signeture
			- This is also used for Performing 'Asynchrnous Operations'in.NET 
			- Used to declare Events in .NET
	- If the method accepts 'delegate' as its input parameter, then this method can
		be passed with Lamdba Expression as input parameter

		- Must know Anonymous Method
4. Generics
	- Type-Safe data structures can store specific type of data for specif type instance
	- Generic Class, Methods, delegates, events, propetris, interfaces, data member



Extension Methods
- In Application we may have multiple Sealed classes 
		- The sealed class can not be inherited or extended
- Extension methods are those methods which will contain extended functionality for the
the sealed classes or the classes which you cannot afford to modify.
- Rules for Creating Extension methods
	- The class containing extension method must be 'static'
	- The method to be uses as extension method must be 'static'
	- The 'first parameter' of the method must be 'this' referred instance of the class	
		using which the method will be called
- Every Collectionand Array has an access of extension method declared in Eumumerable class
 because each collection and Array implements IEnumerable interface
	- Each collection will access
		- Select<T>, Where<T>, Order<T>, OtrderBy<T>, extension methods
==========================================================================================
Language Integratyed Query (LINQ)
1. A Programmable Structure to read data from Collections/Object
		using Database like Queries
2. Added by Mictosoft in .NET 3.5 and C# 3.0+
3. Provide a facility to read data from IEnumerable types (aka Collection types) using
	 Query Operators
4. Query Operators are Extension methods for IENumerable interface
	e.g
		- Select<T>(Function Predicat aka delegate aka Lambda Expression)
		- Where<T>(Function Predicat aka delegate aka Lambda Expression)
		- OrderBy<T>(Function Predicat aka delegate aka Lambda Expression)
		- OrderByDescending<T>(Function Predicat aka delegate aka Lambda Expression)
		- GroupBy<T>(Function Predicat aka delegate aka Lambda Expression)
5. Two types of LINQ Queries
	- Declaratibe Queries, implemented using Extension Methods
	- Implerative Queries, implemented using Query Syntax with keyword matching
		with extension methods
		e.g. Select method ---> select keyword
			Where ---> where


==========================================================================================


Exercise 2: Create an extensoin methods for String class for following Operations
	1. Find out number of repeatations of the character
		e.g. str.FindRepeat('f'); --> Return number of time 'f' is occured inn string
		e.g. Successfuly Implemented feture.
			- f occures 2 times
	2. Find out the indexes on which a specific character is present in string
		e.g. str.FindIndexes('f'); --> return indexes on whihc 'f' occures in string
			e.g. Successfuly Implemented feture.
			- f is at 6 and 23
	3. FInmout number of word ins string
		 e.g. 	str.FindWords();
	4. Findout number of statements in staring
		e.g. str.FindStatements();
Exercise 3: Self-Study
	- Understand Generic and take an experience using code to 
	Create Generic Class, method, interface
	- UInderstand Interfaces
		- Take practical experince of 
			- Creating interface
			- implement single and multiple interfaces in class
			- What will happen is a class implement multiple intarfaces and interfaces
				have same method with same signeture. 

==========================================================================================
Exercise 4: Create a C# Comnsole Applicatiom that will manage the Employee Imformation in
List of Employees and will perform following operations on it
1. List all EMployees
2. List All Employees for a Specific Department
3. Add New Employee
4. Delete an Employee based on EmpNo
5. Update a Salary of specifc Employee based on EmpNo
6. Find Second Max Salaried Employee for each department

Menu Driven App using Swich Case

DEMO Friday
===========================================================================================
Exercise 1 On ADO.NET COnnected Architecture
Create a menu-driven app for Performing CRUD operations on Dept and Emp Table with
Following
1. CRUD on Emp  and Dept tables using Seperate Data Access classes
2. CReatew a Report class containing  methods for
	- Get All Employees based on DeptName
	- Get Employees having Max Salary per department
	- List all Employees for paying Tax with following rules
		- Salary between 100000 to 500000 is 15%
		- Salary between 500001 to 1000000 is 20 %
		- 30% more than 10L
		- 0 less than 1L


Exercise 2: Create Stored Procedures doe Performing CRUD Operations in Emp and Dept Tables and Execute them using ADO.NET (Immediately)

Exercise 3: Create a Stored Procedute for 
 List all Employees for paying Tax with following rules
		- Salary between 100000 to 500000 is 15%
		- Salary between 500001 to 1000000 is 20 %
		- 30% more than 10L
		- 0 less than 1L
and execute it using ADO.NET

Exercise 4: Use Disconnected Architecture for following
1. Create Data and load it from tables from SQL Server Database e.g. Dept, Emp, Person, etc. Display Values in XML
2. Explore ReadXml() ReadXmlSchema(), WriteXml() and WroteXmlSchema() methods
3. Generate DataTable, Columns, Rows, and COnstraints usign code. (Create atleast 5 tables)
4. Week-End Assignment
	- Create a Table Dept (DeptNo (PK.), DeptName, Location, Capacity) and Emp (EmpNo (P.K.;), EmpName, Designation, Salary,DeptNo (F.K.)),
	- Write a Stored Procedute for Inserting Records in Employee Table, but make sure that, if the Capacity of Department is already 
	reached to max e.g. if It department has capacity as 100 and new employee it tried to unsert in Emp table for IT Department, then
	Stored Proc should return error. Write this login in STored Proc.


Exercise 5: Use Diconected Archi. to perform CURD Operations on EMp Table.
=============================================================================================================================================
