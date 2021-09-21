# Deployment Notes


### Database
Migrations are automatically handled when the backend project starts up.

Please ensure the Connectionstring in the appsetting.Development.json is valid on your local machine.

### Backend
To get the backend up and running, start by navigating to the API project located at `src\BestShop.Api\BestShop.Api`

To run the application, open up a command prompt and run the command `dotnet run`. If you do not have the .NET CLI installed, please open Visual Studio and start a debug session.

### Frontend
The frontend is an Angualr project, so please ensure you have the angular CLI and Node installed.

Navigate to `\src\frontend\bet-shop` and run the command `npm install`

Once all packages have been installed, please run the command `ng serve` to start up the application

The port no. for where the frontend application is running will be displayed in the command prompt.
