Wisconsin Department of Verterns Affairs Interview Application
==============================================================

## About this application

This is a application for the Wisconsin Department of Verterns Affairs Interview.

This application shows the relationship between a Group and an User/Person. A group must be greated first before the user. Both Group and User entities have CRUD operations. This application utilizes Bootstrap 4 for moble UI.

If your local sqlserver is "ProjectsV13", then no changes are needed. Follow the steps:
1) Build Project
2) Update database with "dotnet ef database update"
3) Run Project

If you local sqlserver is "mssqllocaldb", follow the steps below:
1) Open project and go to appsettings.json
2) Change connection string from "ProjectsV13" to "mssqllocaldb"
3) Build Project
4) Update database with "dotnet ef database update"
5) Run Project

.NET Core 2.1
