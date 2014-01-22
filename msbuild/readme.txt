To run MSBuild from the command line for this project, copy the files in this directory to the following location:
C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0\WebApplications

Copy nuget.exe to c:\tools and add this to the system PATH

Then run this command from the project root folder:
msbuild .\build.targets