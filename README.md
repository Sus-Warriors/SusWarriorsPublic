# Sus Warriors
Sus Warriors is an app to help doctors be more sustainable in the medicines that they prescribe. It has a front-facing UI that is supported by a backend and database.

## Front End
A Microsoft PowerApp Canvas project. It is supported by flows in Power Automate and connections to a backend server as well as an SQL database.

## Back End
The code in the current repository. It is an ASP.NET Core 8 Web API application. [Swagger Page](https://suswarriors-app.wittywater-dfc2f359.southeastasia.azurecontainerapps.io/swagger/index.html). It has connections to the SQL databsase using Entity Framework Core 8. The backend 

The backend server is hosted as a Container App on Microsoft Azure. In order to run the application that connects to the cloud database, the password must be filled in into the app settings, and the environment must be set to production. Alternatively, a local version can be run together with a local SQL server using `docker-compose up`.

## SQL Database
We are using Microsoft SQL Server as our database server of choice. It is hosted as a managed SQL database on Microsoft Azure.
