# Meetup-API #
Modsen test task. CRUD Web API for working with events.  
Runs on .Net Core using EF Core, MS SQL, AutoMapper, FluentValidation and Swagger.
Authentication in the application is carried out through a bearer token.

# About #
All application endpoints are available only to registered users.  
Therefore, the application has registration and login using credentials.  
Registered users can have one of the following roles: User or Admin.

### User can:
+ get information about all events;
+ get event information.

### Admin can:
+ add new event (organizer, speaker);
+ get information about all events (organisers, speakers);
+ get event (organizer, speaker) information;
+ update information about event (organizer, speaker);
+ delete event (organizer, speaker).

# Project start instructions #
1. Open Visual Studio.
2. On the start window, select __Clone a repository__.
3. Copy the URL below and paste into __Repository location__.  
Then select the __Clone__ button
4. Next, Visual Studio loads the solution(s) from the repository by using the ___Folder View__  
in Solution Explorer. You can view a solution in __Solution View__ by double-clicking its .sln file.  
Or, you can select the __Switch Views__ button, and then select __Program.cs__ to view a solution's code.
