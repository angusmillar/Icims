*** Installing the application as a Windows service ***
To make application run as Windows service.

1. Publish application to some folder
2. Copy the folder to a suitable place on the server, e.g: C:\IcimsProxyService
3. Configure the appsettings.json file by opening in a text editor. Below are the documented commands:

   - NameOfThisService: The name the service refers to it's self in logging statements, can be anything.
   - PrimaryMRNAssigningAuthorityCode: The AssigningAuthority code used to identify the primary Medicare Record number in HL7 Messages PID-3.4
   - Endpoint: The base Restful endpoint where data will be sent to Icims as POST actions ([base]/add, [base]/update, [base]/merge)
   - AuthorizationToken: The basic secret hash for Authorisation to the Icims service.  
   - Logging/Loglevel/Default: the default minimum logging level
   - AllowedHosts: Restrict which hosts can connect to the service. 
      "*" means any host, "example.com;localhost" would mean either requests from example.com of localhost.

  Example AppSettings.json file:      
  {
    "IcimsSiteContext": {
      "NameOfThisService": "Icims Proxy Service",
      "PrimaryMRNAssigningAuthorityCode": "RMH",
      "Endpoint": "http://localhost:60823/api/mock/",
      "AuthorizationToken": "Basic [hash here]="
    },
    "Logging": {
      "LogLevel": {
        "Default": "Warning"
      }
    },
    "AllowedHosts": "*"
  }


4. Open command window with administrative permissions
5. Register application as Windows service using the following command (space after “binPath=“ is mandatory)

sc create Icims binPath= “path to my application exe”
 
For example:
sc create Icims binPath= “C:\IcimsProxyService\Icims.Api.exe”

Start service
 
sc start AspNetWindowsService
or 
use the Windows Services tool (Windows Key and type 'Services')
 
When service is started open a browser and navigate to http://localhost:5000/api/hl7v2 to check see that the web application running.

Mirth will need to be setup to POST to http://localhost:5000/api/hl7v2

Before releasing new version of service the current running instance must be stopped. 
For this we can use command sc stop AspNetWindowsService or the Windows Services tool. 

To remove service run the following command: sc delete Icims.




#########################################################################################
The following article was followed to set-up the base infrastructure to run a .NET Core Web API as a Windows Service 
https://gunnarpeipman.com/aspnet/aspnet-core-windows-service/

Note: The project file had to be manually edited to add the element: <RuntimeIdentifier>win7-x64</RuntimeIdentifier> 
So that file named 'Icims.Api.csproj' looks like this:
---------------------------------------------------------------
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>
    <RuntimeIdentifier>win7-x64</RuntimeIdentifier>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.App" />
    <PackageReference Include="Microsoft.AspNetCore.Hosting.WindowsServices" Version="2.2.0" />
    <PackageReference Include="Microsoft.AspNetCore.Razor.Design" Version="2.2.0" PrivateAssets="All" />
  </ItemGroup>

</Project>
---------------------------------------------------------------

