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
### Open and build the project
1. Open Visual Studio.
2. On the start window, select __Clone a repository__.
3. Copy the URL below and paste into __Repository location__.  
Then select the __Clone__ button.
    ```
    https://github.com/lKvasiKl/Meetup-API.git
    ```
4. Next, Visual Studio loads the solution(s) from the repository by using the __Folder View__  
in Solution Explorer. You can view a solution in __Solution View__ by double-clicking its .sln file.
5. At the top of the screen, find the __Build__ tab and clic it. Then clic __Build Solution__.  
Or just press __CTRL+SHIFT+B__ on your keyboard.

### Create a local database
1. Find the __MeetupDB__ folder and expand it.  
2. Then find the file __MeetupDB.publish.xml__ and double-clicking it.  
3. In the window that appears, click the __Publish__ button.

### Run the project
Now you can click on the __Run project button__ or click __F5__ on your keyboard.

