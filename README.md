# webapi-dotnet
The reason is - The dotnet ef tool is no longer part of the .NET Core SDK in ASP.NET Core 3.0.
 this tool was changed from being built-in to requiring an explicit install:

So to resolve the problem, you can install the dotnet-ef locally in your solution rather than adding it globally.

Steps to install locally.

Create a local manifest file via dotnet new tool-manifest

Go to the config folder:

cd .\.config

Install the tool via dotnet tool install dotnet-ef --version versionNumber. It'll be successfully installed and its commands will be accessible within the project.