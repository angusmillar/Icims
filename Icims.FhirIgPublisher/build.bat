del output\*.* /s/q
del temp\*.* /s/q
del qa\*.* /s/q

cd ..\Icims.ProfileGenerator
dotnet publish -c Release

cd .\bin\Release\netcoreapp2.2
dotnet .\Icims.ProfileGenerator.dll

cd ..\..\..\..\Icims.FhirIgPublisher
REM java.exe -Xmx1280m -jar org.hl7.fhir.publisher.cli-0.9.22-20190531.013250-1.jar -ig ig.json
java.exe -Xmx1280m -jar org.hl7.fhir.publisher.jar -ig ig.json
