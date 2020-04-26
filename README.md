# music-search-project
## "Lion Tunes"

### Summary
This is a project for SWENG 861. This is a .net core 3 c# MVC web applicaiton that uses an API to search for Songs and Singers.

### Description
Use case: A user can look up details about songs and artists by providing basic search criteria into the “LionTunes” web application such as song title or artist name and the application will shows relevant information. For songs the application will show data points such as artist, date released, lyrics if they are available, genre, and album information. For artists the application will show their albums in order of release (newest to oldest) with a listing of songs in each album. I will be using Microsoft .net core 3.1 with C# with MVC and Visual Studio as my Framework/Language/IDE. After searching for a good music API, I intend to use the MusicBrainz API for the music data. 

### Overview

1. Using MVC Framework
2. Using .net core, built in logger and dependncy injection for logging.
3. API calls are done using asyncrous methods to free up threads on the web server
4. API calls are limited to bring back 10 or less records and only include needed realted records per MusicBrainz documentation
5. Index Controller is where the search starts
6. Music Controller handels the routing and entry point for both Song(s) and Singer(s).
7. Views have logic that handel dispaly, this could be refactored to make better use of view models to keep the views lighter in the future.

### Run on your machine
*** NOTE - becuase .net core is cross platform, you can run this project on Windows, Linux, or Mac

1. Install .net core 3.1
2. navigate to the root foler of this project "music-search-project/LionTunes.Web/LionTunes.Web" in a command promot OR open using Visual Studio 2019. If you open with viual studio, just run the debugger to view. If you want to run via comand prompt follow the rest of the isntructions below. 
3. If you open with a coman promot, type 'dotnet restore' - wait for all the packages to restore
4. then type 'dotnet run' - it will start the applicaiton and let you know what web ports it is running for http and http (should be 5000 and 5001)
5. Once the applicaiton is running open a web browser and navigate to : https://localhost:5001/
6. To exit, close the browser and close the console .. this will shut off the web server.
