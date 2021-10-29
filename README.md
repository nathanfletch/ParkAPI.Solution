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
* Use Postman or your favorite client to make http requests to localhost:5000. 
</details>

## Known Issues
* There are no known issues at this time.
* Please contact me if you find any bugs or have suggestions. 

## Future Plans
* Add more query parameters and endpoints.
* Add JSON Web Token authentication.

## License

_[MIT](https://opensource.org/licenses/MIT)_  

Copyright (c) 2021 Nathan Fletcher 

## Contact Information

_Nathan Fletcher @ github.com/nathanfletch_  