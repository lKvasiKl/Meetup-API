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
