# MeetingScheduler #
Simple meetings scheduler application to create and register/unregister for meetings. 
- - - - 
### Technology : ### 
C#, ASP.Net Web API 2, MSSQL, StructureMap, JSON Web Token(JWT).

### Objective : ###
1. Study and use .net technology : ASP.Net Web API 2(complete pipeline, Filters, IdentityModel implementaion etc.)
2. To prepare a layered project structure which uses loosely coupled modules that interact with each other.
3. Proper use of object oriented fundamentals and SOLID principles.
4. Make application ready to be unit tested using MSTest or any other test project so as to follow Test Driven Development(TDD).
5. Use Design Patterns and Dependency injection.
6. Use Token based authentication.

### Environment to run the application ###
1. Postman <https://www.getpostman.com/> or Restlet client <https://client.restlet.com/> to make calls to Web Api.
2. Web Server : e.g.IIS to host Web Api.
3. MSSQL : To store data.

### Steps ###
These need to be done for now. Till One click installation is ready.
1. Download the code. 
2. Publish web site and host it in a Web Server.
3. Run Sql script file named : MeetingSchedulerScript.Sql
4. Use Postman or DHC restlet client to make calls. Refer to the calls attached for Post body and URLs

### Going further ###
Due to time constraint some things are not implemented or taken care of during the development
1. Add unit tests and follow Test Driven Development(TDD)
2. One click installation : Write a batch/shell file which will install the application completely, ready to use.
3. Add UI.


### Note ###
For a simple CRUD operation like this, layered architecture is surely an overkill so there might be some non-adherence to standard practices.


