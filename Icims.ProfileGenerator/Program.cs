using System;
using Icims.Profile;
using System.IO;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Icims.ProfileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string OutputDirectoryName = "output";
            DirectoryInfo TargetOutputDirectoryInfo = GetOutPutDirectory(OutputDirectoryName);
            if (!TargetOutputDirectoryInfo.Exists)
            {
                throw new ApplicationException($"The output directory does not exists: '{TargetOutputDirectoryInfo.FullName}'");
            }

            //Delete all files in the directory
            Console.WriteLine($"Output directory is : {TargetOutputDirectoryInfo.FullName}");
            Console.WriteLine("Delete resource in output directory");
            if (TargetOutputDirectoryInfo.GetFiles().Length == 0)
                Console.WriteLine("No resource in output directory to delete");
            foreach (FileInfo file in TargetOutputDirectoryInfo.GetFiles())
            {
                Console.WriteLine($"Delete {file.Name}");
                file.Delete();
            }

            Console.WriteLine("Generate resources");
            var ResourceList = ProfileFactory.GetAllResources();
            foreach (Resource Res in ResourceList)
            {
                var AnnotationList = Res.Annotations(typeof(IcimsResourceAnnotation));
                if (AnnotationList.FirstOrDefault() is IcimsResourceAnnotation IcimsAnnotation)
                {
                    Console.WriteLine($"Resource: {IcimsAnnotation.Filename}.xml");
                    FhirXmlSerializer FhirXmlSerializer = new FhirXmlSerializer();
                    FhirXmlSerializer.Settings.Pretty = true;
                    File.WriteAllText(Path.Combine(TargetOutputDirectoryInfo.FullName, IcimsAnnotation.Filename + ".xml"), FhirXmlSerializer.SerializeToString(Res));
                }

            }
            Console.WriteLine($"Total of {ResourceList.Count} resources output");
        }

        private static DirectoryInfo GetOutPutDirectory(string OutputDirectoryName)
        {
            var test = System.IO.Directory.GetCurrentDirectory();
            // Console.WriteLine($"#####################################################################");
            // Console.WriteLine($"OLD Path {test}");
            // Console.WriteLine($"#####################################################################");
            DirectoryInfo CurrentDirectory = new DirectoryInfo(System.IO.Directory.GetCurrentDirectory());
            DirectoryInfo TargetOutputDirectoryInfo = new DirectoryInfo(CurrentDirectory.FullName);
            bool found = false;
            while (!found)
            {
                if (CurrentDirectory.Parent == null)
                {
                    throw new ApplicationException($"The path the application was run from was expectd to have a parent directory named 'Icims.ProfileGenerator'");
                }
                if (CurrentDirectory.Name == "Icims.ProfileGenerator")
                {
                    TargetOutputDirectoryInfo = new DirectoryInfo(System.IO.Path.Combine(CurrentDirectory.Parent.FullName, $@"Icims.FhirIgPublisher\{OutputDirectoryName}"));
                    found = true;
                }
                else
                {
                    CurrentDirectory = CurrentDirectory.Parent;
                    // Console.WriteLine($"TempPath {CurrentDirectory.FullName}");
                }
            }
            // Console.WriteLine($"#####################################################################");
            // Console.WriteLine($"New Path {TargetOutputDirectoryInfo.FullName}");
            // Console.WriteLine($"#####################################################################");
            return TargetOutputDirectoryInfo;
        }
    }
}
