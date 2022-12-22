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
            string folderName = "RandomPersonInfoGenerator";
            string runningDir = AppContext.BaseDirectory;
            string vsStudioProjDir = Path.Combine(runningDir, "..", "..", "..");

            //Repos name is diffrent to projects name.
            //Checks to see if the folder exist.
            string file = Path.Combine(vsStudioProjDir, folderName, "Data", fileName);
            if (!File.Exists(file))
            {
                //If false(null), change the name too the repo-folders name. 
                folderName = "RandomPersonGenerator";
                return Path.Combine(vsStudioProjDir, folderName, "Data", fileName);
            }
            else
            {
                return Path.Combine(vsStudioProjDir, folderName, "Data", fileName);
            }
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
            //3 catches => 1:File not found. 2:IO problems. 3:Other problems.  
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }
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
            //3 catches => 1:File not found. 2:IO problems. 3:Other problems.  
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }
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
            //3 catches => 1:File not found. 2:IO problems. 3:Other problems.  
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ExceptionExstensions.GetExceptionFootprints(ex));
            }
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
