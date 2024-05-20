# WeatherApp
Application to get weather forcasts for  list of locations


## Application Use
- Clone or download the repository and open the solution in VS.
- Run the application and you will be presented with the home page.
- After navigating to the Locations page you can see the saved locations and can upload a csv list of locations to the database.
- Each saved location shows high level information for its last retrieved weather forcast.
- There is a Delete button to remove unwanted locations.
- A Weather button is shown for each Location which provides a mechanism to open it in the Weather page and retrieve a new forcast.
- The Weather page displays the heading location data along with an full 7 day weather forcast.
- There are static About and Contact pages.


## Solution Structure 
There are individual projects for each item of functionality:
- DataAccess - Currently manages database connections usning Entity Framework 6.4. It also defines the Class stuctures for our internal data models in the entities folder, repositories to interact with them and services to interact with the outside world
- Interfaces - Stores interface definitions for our data objects implement.
- Models - A class library for Models, currently just contains LocationWeather as the Data Access entities define everything else, this could be extended to increase seperation though the data structure is currectly the same as the models would be.
- OpenMeteo - Open Meteo API specific functionality and data structures that are only referenced by the LocationWeather model.
- Utilities - A class library specifically for miscalleneous utilities currently contains 2 utility classes, once for processing csv files and one to simulate file uploads for testing
- Web - The main application itself where the 3 controllers and their views are defined as well as a folder for test definitions and a folder for Mock data that they use. The appSettings with the URL for the Open Meteo API and the connection string for the database is stored within the Web.config.
- Web.Tests - I set this up as a seperate test library but that meant hard coding file paths so I moved the tests into a folder in the the Web project as a temporary measure. 


## Considered functionality:
- The application recods a history of weather forcasts but currently just shows the latest and that could be extended.
- There is currently no way to remove a forcast from a location, though removing a location will remove the attached forcasts


## Technical Debt
1. Noted in NuGet that there are issues with the default installed packages that include security vulnerabilities which should be remidiated. However in order to keep the tech "old" I am taking an active decision to leave these for now.
2. Certificate error was being returned when running, which I have now installed on my machine so no longer get the error. I believe this is just the inbuilt IIS Express certificate VS installs and would not cause ongoing issues following a deployment with a genuine certificate.
3. Did not want to install additional software and add dependancies so have added a class "MockHttpPostedFileBase" to the Models folder in the tests project. This is to simulate a file being posted by a user as part of testing file uploads and processing and I would need to seek advice as to whether that was an effective way to do so.
4. The Models could be extended so that there is no direct reference to the DataAccess entities
