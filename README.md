# WebHCDemo
Link demo: https://hanhchinh.somee.com/

Deploy to somee:
Create project with your language and version. I use ASP .NET CORE 3.1 to implement this project. 
Create free account in somee
Use SQL Server management studio to create database.
    Step 1: Connect to local database (default)
    Step 2: Select Task -> BackUp
    (Step 3): Remove the default link, replace it with a destination address other than the file name .bak
Create any database on somee and restore the backed-up file.
Create publish file in visual studio.
    Step 1: Right click on the Project, select Publish
    Step 2: Create a new folder publish
    Step 3: Choose an arbitrary path
    Step 4: At Configuration select edit
    Step 5: Check the 2 fields in the database and Migration
    Step 6: Proceed to Publish
    Step 7: Compress .zip
Note: The free account can only store up to 150mb, if the volume of the entire file + .zip file >= 150mb, you will have to split it into small downloads.

At the host, access the file manager to upload files.
Note: If the server is running, stop the server at Tasks and upload the file.
Select Upload and upload the .zip or file.
Select Up to deploy to the server.
Turn on the server (if it's off) and done.

Note: You don't need to edit .config because it's not missing anything. If you get an error when opening the host, you should review the code or create a new project and then rebuild the project structure on that new project.


