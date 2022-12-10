# WebHCDemo
Link demo: https://hanhchinh.somee.com/

Deploy to somee:<br />
Create project with your language and version. I use ASP .NET CORE 3.1 to implement this project. <br />
Create free account in somee<br />
Use SQL Server management studio to create database.<br />
    Step 1: Connect to local database (default)<br />
    Step 2: Select Task -> BackUp<br />
    (Step 3): Remove the default link, replace it with a destination address other than the file name .bak<br />
Create any database on somee and restore the backed-up file.<br />
Create publish file in visual studio.<br />
    Step 1: Right click on the Project, select Publish<br />
    Step 2: Create a new folder publish<br />
    Step 3: Choose an arbitrary path<br />
    Step 4: At Configuration select edit<br />
    Step 5: Check the 2 fields in the database and Migration<br />
    Step 6: Proceed to Publish<br />
    Step 7: Compress .zip<br />
Note: The free account can only store up to 150mb, if the volume of the entire file + .zip file >= 150mb, you will have to split it into small downloads.<br />
<br />
At the host, access the file manager to upload files.<br />
Note: If the server is running, stop the server at Tasks and upload the file.<br />
Select Upload and upload the .zip or file.<br />
Select Up to deploy to the server.<br />
Turn on the server (if it's off) and done.<br />
<br />
Note: You don't need to edit .config because it's not missing anything. If you get an error when opening the host, you should review the code or create a new project and then rebuild the project structure on that new project.<br />


