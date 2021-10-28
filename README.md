<div align="center">
  <h1>SimpleSurveys 📝</h1>
  A easy-to-use web app where you can create and participate in surveys.
</div>

## Installation
### .NET SDK
#### Check Installed Versions
First we need to make sure that the .NET 5.0 SDK is installed.
For that open a command prompt or powershell window and paste the following command:
```
dotnet --list-sdks
```
If the output is the follwing;
> 'dotnet' is not recognized as an internal or external command, operable program or batch file.

you don't have .NET installed. You can head to [Install .NET 5.0 SDK](#install-net-50-sdk) to install the latest version.

If you recieve an output similar to this;

> 2.1.500 [C:\program files\dotnet\sdk]  
> 3.1.100 [C:\program files\dotnet\sdk]  
> 5.0.100 [C:\program files\dotnet\sdk]  

you already have .NET installed. If any of the listed versions starts with `5.0` you already have the correct version installed. You can head to [MSSQL Server](#mssql-server).

If none of the versions are of `.NET 5.0` head to the next step, [Install .NET 5.0 SDK](#install-net-50-sdk).

#### Install .NET 5.0 SDK
To download the `.NET 5.0 SDK` you can click on the following link: [Download .NET SDK x64](https://download.visualstudio.microsoft.com/download/pr/8a504918-9508-464d-80c6-4da7f9cc9ac6/f9d6ad00bbd798bafb549101b5b4a4c0/dotnet-sdk-5.0.402-win-x64.exe)

More information about the latest versions can be found here: [Download .NET](https://dotnet.microsoft.com/download)

After downloading the installer, you can run it.

In the installer click on Install:  
<img src="https://raw.githubusercontent.com/speyck/simple-surveys/main/docs/dotnet-installation/step-1.png" width="400px" />

After the installation finished, you can close the installer:  
<img src="https://raw.githubusercontent.com/speyck/simple-surveys/main/docs/dotnet-installation/step-2.png" width="400px" />

You can test your installation by executing following command again:
```
dotnet --list-sdks
```
There should be a new entry with `5.0`.

You need to open a new command prompt/powershell window if you didn't have .NET installed before for the commands to work.

### MSSQL Server
For the application to run there also has to be a mssql server running in the background. You can do this either by using a local sql-express server or your own.

#### SQL-Express Server

SQL-Express is targeted for developers, so you if you'd like to run the app on the internet I'd reccomend you [using your own mssql server](#custom-mssql-server).

First of all, you need to download the server installer. There are two avaliable versions (more info [here](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15)):

- [SQL Server Express 2019](https://go.microsoft.com/fwlink/?LinkID=866658)
- [SQL Server Express 2017](https://go.microsoft.com/fwlink/?LinkID=853017)

I would always take the latest version, 2019.

After downloading the `.exe` you can execute it. The installer is fairly simple and only has a few steps:

1. After opening the installer click on `Basic`  
   <img src="https://raw.githubusercontent.com/speyck/simple-surveys/main/docs/sqlexpress-installation/step-1.png" width="400px" />
2. Then accept the License Terms and Pricacy Statement  
   <img src="https://raw.githubusercontent.com/speyck/simple-surveys/main/docs/sqlexpress-installation/step-2.png" width="400px" />
3. And then in the next window you can choose the installation location  
   <img src="https://raw.githubusercontent.com/speyck/simple-surveys/main/docs/sqlexpress-installation/step-3.png" width="400px" />
4. After this, the server should be installed and running. You can close the window  
   <img src="https://raw.githubusercontent.com/speyck/simple-surveys/main/docs/sqlexpress-installation/step-4.png" width="400px" />

You do not have to create any databases or edit any connection strings in the application. The database is being created and updated on each app start and the connection string is the same for each sql-express installation.

The application should now be able to run on your machine!

#### Custom MSSQL Server
You need a bit more knowledge if you would want to use your own mssql server. 

First get your connection string. The sql-express connection string looks like this:

> Server=localhost\\SQLEXPRESS;Database=SimpleSurveys;Trusted_Connection=True;

yours should look similar.

Now, after you got your connection string, you can put it into the settings of the application. 

1. From the root (git) directory head into `\SimpleSurveys\Server`. 
2. Then open the `appsettings.json` file with any editor. 
3. Paste your connection string into the value of `DefaultConnection`.

If your connection string has right to the whole server, you should be fine. If you only provide right to a specific database, make sure that you have the database created on your server already and provided the information in the connection string correctly.

You should now be able to run the app.

## Running the application
Running the application is very easy. In the root directory simply open the `start.bat` file and the application should start.

You can stop the application at any time by pressing <kbd>CTRL</kbd>+<kbd>C</kbd> in the command prompt window.

The first time doing this may take a while, as it is downloading all needed nuget packages and building the whole aplication. Make sure that you are connected to the internet properly so the missing nuget packages can be downloaded.
