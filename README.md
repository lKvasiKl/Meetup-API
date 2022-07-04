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

# Swagger and endpoints #
After starting the project, Swagger opens up for you.  
Now you are an unauthorized user and only `Auth` endpoints are available to you.  

## Auth
### [POST] /Auth/Register
You can use this endpoint to register a new profile.  
All new users have the role _User_.

Register request body:
```
{
  "email": "user@example.com",
  "password": "string"
}
```
### [POST] /Auth/Login
You can use this endpoint to log in and get jwt token.  
Initially, there are two users in the database under whose data you can log in.
1. User with role _User_
  "email": "user@example.com",  
  "password": "string12"
2. User with role _Admin_
  "email": "admin@gmail.com",  
  "password": "12345qwerty"

Log in _Admin_ responce body:
```
{
  "id": "6eb4f502-c17c-4202-a199-ae14171b3bcb",
  "email": "admin@gmail.com",
  "role": {
    "id": 1,
    "name": "Admin"
  },
  "jwt": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjZlYjRmNTAyLWMxN2MtNDIwMi1hMTk5LWFlMTQxNzFiM2JjYiIsIkVtYWlsIjoiYWRtaW5AZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2NTY5NTA3MTh9.jVVity3UQwNtX4fqDFoQwS3Lem_JixZTWR7o_E-5wE8"
}
```

After you have received the jwt token, you need copy it and use it for Authorization.  
Click on the __Authorize__ button at the top of the Swagger window.  
In the window that opens, write `bearer insert_jwt`, where _insert_jwt_ - copied jwt token.

## Event
This block contains the main endpoints of the application.  
If you have an account with the _User_ role, you can only use __GET__ requests. 
If you have an account with the _Admin_ role, you can use all endpoints.  

### [POST] /Event
Endpoint for adding a new event in DB. One event can have several organizers and ыpeakers.  
To add, their name is indicated. They must also exist in the database.  
Date and time must be written in the format `yyyy-dd-mmThh-mm`  
>We cannot add a new event with an organizer (speaker) that is not in the database.  

Add event request body:
```
{
  "title": "string",
  "topic": "string",
  "description": "string",
  "schedule": "string",
  "dateTime": "2022-07-04T14:30",
  "place": "string",
  "organizers": [
    {
      "name": "Organizer One"
    }
  ],
  "speakers": [
    {
      "name": "Speaker Four"
    }
    {
      "name": "Speaker Two"
    }
  ]
}
```

### [GET] /Event
Endpoint to receive all events.

### [GET] /Event/{id}
Endpoint to receive event by id.

### [PUT] /Event/{id}
Endpoint for editing an event by id. Contains exactly the same request body as for adding event.

### [DELETE] /Event/{id}
Deletes the event with the specified id.

## Organizer
Auxiliary endpoints available only to users with the _Admin_ role.  

### [POST] /Organizer
Endpoint for adding new organizer in DB.

Add organizer request body:
```
{
  "name": "The Best Organizer"
}
```

### [GET] /Organizer
Endpoint to receive all organizers.

### [GET] /Organizer/{id}
Endpoint to receive organizer by id.

### [PUT] /Organizer/{id}
Endpoint for editing an organizer by id. Contains exactly the same request body as for adding organizer.

### [DELETE] /Organizer/{id}
Deletes the organizer with the specified id.

## Speaker
Auxiliary endpoints available only to users with the _Admin_ role.  

### [POST] /Speaker
Endpoint for adding new speaker in DB.

Add speaker request body:
```
{
  "name": "The Best Speaker"
}
```

### [GET] /Speaker
Endpoint to receive all speakers.

### [GET] /Speaker/{id}
Endpoint to receive speaker by id.

### [PUT] /Speaker/{id}
Endpoint for editing a speaker by id. Contains exactly the same request body as for adding speaker.

### [DELETE] /Speaker/{id}
Deletes the speaker with the specified id.
