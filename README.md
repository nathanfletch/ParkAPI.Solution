# Park API


#### An api about parks with park type and score.

#### _By Nathan Fletcher_

* This app uses .NET with Entity Framework Core to implement full CRUD functionality for park data.

## Technologies Used

* C#
* ASP.NET Core
* Restful Routing Conventions
* Entity Framework Core 
* Swagger

## Setup
<details>
<summary>Setup & Installation Instructions</summary>

#### Installations (if necessary)
* Install C# and .NET using the [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-5.0.100-macos-x64-installer)
* Install [MySql Community Server](https://dev.mysql.com/downloads/file/?id=484914)

#### Setup
* Clone this repository to your local machine
* Navigate to the ParkAPI.Solution folder and create a file named "appsettings.json" 
* Add the following code to the file:
  ```
  {
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=park_api;uid=root;pwd=[YOUR-PASSWORD-HERE];"
    }
  }
  ```
* Navigate to the ParkAPI folder and run the following commands:
* `dotnet restore` to install the necessary dependencies
* `dotnet build` to compile the project.
* `dotnet tool install --global dotnet-ef`
* `dotnet ef migrations add Initial`
* `dotnet ef database update`
* `dotnet run` to start the server.


</details>

## Data Loading
Now that you've got the project set up, you're ready to start making calls to the Park API from Postman or your favorite client.
There are 2 ways to load data:
* Call the post route over and over - only recommended for the extremely bored.
* Make a GET request to `http://localhost:5000/api/parks/load`. This will load a .csv file downloaded from [Kaggle](https://www.kaggle.com/danofer/sf-parks) into the database.


## API Documentation

## Swagger
Check out Swagger's auto-generated documentation at `http://localhost:5000/swagger`

## CORS
CORS is enabled only for these specific ports: `5000`, `5001`, `8080`, `8081`.
This is to allow a front end app running on 8080 to call this api.

## Endpoints

Base URL: `http://localhost:5000`

## HTTP Request Structure

```
GET /api/parks
GET /api/parks/load
POST /api/parks
GET /api/parks/{id}
PUT /api/parks/{id}
DELETE /api/parks/{id}
```

## GET /api/parks

A user can get all parks and customize the list using the following parameters:

| Parameter | Type | Default | Description | Example Query |
| :---: | :---: | :---: | :---: | --- |
| type | string | none | Get parks of the specified type. | api/parks/?type=sandbox |
| minScore | double | none | Gets parks with a higher score than the specified score | api/parks/?minScore=0.11 |
| maxScore | double | none | Gets parks with a lower score than the specified date | api/parks/?maxScore=0.9 |
| sorted | bool | false | Sorts parks by score (highest to lowest) | api/parks/?sorted=true |

### Example Query

`http://localhost:5000/api/parks/?minScore=2&sorted=true`

### Example of returned JSON:
```
[
  {
    "parkId": 5,
    "name": "Sands",
    "type": "Sandbox",
    "score": 0.88
  },
  {
    "parkId": 1,
    "name": "Monkey Park",
    "type": "Zoo",
    "score": 0.33
  }
]
```

## GET /api/parks/load

A user can populate the database with external data from a .csv file.
### Example query: 
`http://localhost:5000/api/parks/load`
### Example of returned JSON: same format as above.

## POST /api/parks

A user can add a park.
### Example query: 
`http:localhost:5000/api/parks/`
### Example of JSON that will be sent in the body:

```
{
  "name": "Highland",
  "type": "Basketball court",
  "score": 0.77
}
```
### Example of JSON that will be included in the return body:
```
{
  "parkId": 6,
  "name": "Highland Court",
  "type": "Basketball court",
  "score": 0.77
}
```

## GET /api/parks/{id}

A user can get one park by ID.
### Example query: 
`http:localhost:5000/api/parks/1`
### Example returned JSON:

```
{
  "parkId": 1,
  "name": "Monkey Park",
  "type": "Zoo",
  "score": 0.33
}
```

## PUT /api/parks/{id}

A user can update details about a park they created.
### Example query: 
`http://localhost:5000/api/parks/1`
### Example of JSON that will be sent in the body:
```
{
  "parkId": 1,
  "name": "Monkey Graveyard",
  "type": "Graveyard",
  "score": 1
}
```
### Example returned JSON: None


## DELETE /api/parks/{id}?

A user can delete a park.
### Example query: 
`http:localhost:5000/api/parks/1`
### Example returned JSON: None
   
<br>

## Known Issues
* There are no known bugs at this time.
* Please contact me if you find any bugs or have suggestions. 

## Future Plans
* Add more query parameters and endpoints.
* Create a JavaScript web app to run on port 8080 to call this API and demonstrate CORS functionality.

## License

_[MIT](https://opensource.org/licenses/MIT)_  

Copyright (c) 2021 Nathan Fletcher 

## Contact Information

_Nathan Fletcher @ github.com/nathanfletch_  