# PhoneBook
Phonebook is a simple C# Windows Form(.NET Core) project that allows user to CRUD operations.


# Database
In the project, MSSQL was used as a database. The database contains a single table and its structure is as follows;
ID, Name, Surname, Company, InfoType, Info


# Classes
Main class of the project is Form1. All operations revolve around this class.
The data taken from the database is stored in a list (People) that we can call database for the code. 
We perform operations on this list and apply changes to the main database (MSSQL).

Contact class is the class in which all the information of the persons is kept. It corresponds to a row in the database.
This class inherits from Person that is an abstract class.
Contact class has an attribute named Information. This class kept the Information Type and Information informations.
Report class kept the locations ordered by person count and some other informations about the database.

Since the application is written as windows form, it can be understood better if it is run.

# Tests
All test functions that can be written are tried to be written. Windws form event functions do not have unit tests.
