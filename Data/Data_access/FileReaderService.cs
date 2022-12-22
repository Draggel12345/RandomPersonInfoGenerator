using RandomPersonInfoGenerator.Data.Exception_custom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace RandomPersonInfoGenerator.Data.Data_access
{
    public class FileReaderService
    {
        //Files that will only be read from, hence the const.
        private const string MALE_NAMES = "firstname_males.txt";
        private const string FEMALE_NAMES = "firstname_females.txt";
        private const string LAST_NAMES = "last_names.txt";

        private string GetFilePath(string fileName)
        {
            string path = null;
            //Moved the RandomPersonInfo..\Data\(Name files) to a new folder(FilesForReading).
            string folderName = "FilesForReading"; //New location..\source\FilesForReading\(Name files)
            string backTracking = @"..\..\..\..\.."; // <=> repos\RandomMockUpTest\bin\Debug\net6.0
            try
            {
                string runningDir = AppDomain.CurrentDomain.BaseDirectory;
                string sourceDir = Path.Combine(runningDir, backTracking);
                string filesDir = Path.Combine(sourceDir, folderName);
                string file = Path.Combine(sourceDir, folderName, fileName);

                if (!Directory.Exists(filesDir))
                {
                    throw new DirectoryNotFoundException();
                }
                else if (!File.Exists(file))
                {
                    throw new FileNotFoundException();
                }

                path = file;
            }
            //Using custom made exception exstenstion method for lovely display of error message.
            //2 catches => 1:Directory not found. 2:File not found.
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }
            catch (DirectoryNotFoundException ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }

            return path;
        }

        public List<string> GetMaleFirstNames()
        {
            var results = new List<string>();
            try
            {
                //Read File Text => .Join("", File...etc) puts all text together.
                string sortNames = string.Join("", File.ReadAllLines(GetFilePath(MALE_NAMES)));
                //sortNames => Split(',') => single first name => index 0 == names[name], repeats loop etc...
                string[] names = sortNames.Split(',');
                //Add each name to results-list.
                foreach (var name in names)
                {
                    results.Add(name);
                }

            }
            //Using custom made exception exstenstion method for lovely display of error message.
            //2 catches => 1:IO problems. 2:Other problems.
            catch (IOException ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }

            return results;
        }

        public List<string> GetFemaleFirstNames()
        {
            var results = new List<string>();
            try
            {
                //Read File Text => .Join("", File...etc) puts all text together.
                string sortNames = string.Join("", File.ReadAllLines(GetFilePath(FEMALE_NAMES)));
                //sortNames => Split(',') => single first name => index 0 == names[name], repeats loop etc...
                string[] names = sortNames.Split(',');
                //Add each name to results-list.
                foreach (var name in names)
                {
                    results.Add(name);
                }

            }
            //Using custom made exception exstenstion method for lovely display of error message.
            //2 catches => 1:IO problems. 2:Other problems.
            catch (IOException ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }

            //Returns either the list or null, null checking will be done in service.
            return results;
        }

        public List<string> GetLastNames()
        {
            var results = new List<string>();
            try
            {
                //Read File Text => .Join("", File...etc) puts all text together.
                string sortNames = string.Join("", File.ReadAllLines(GetFilePath(LAST_NAMES)));
                //sortNames => Split(',') => single last name => index 0 == names[name], repeats loop etc...
                string[] names = sortNames.Split(',');
                //Add each name to results-list.
                foreach (var name in names)
                {
                    results.Add(name);
                }

            }
            //Using custom made exception exstenstion method for lovely display of error message.
            //2 catches => 1:IO problems. 2:Other problems.
            catch (IOException ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }

            //Returns either the list or null, null checking will be done in service.
            return results;
        }
    }
}
