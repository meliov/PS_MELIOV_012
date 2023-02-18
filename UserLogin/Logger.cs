using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        
        private static string logFileName =  "C:/Users/Ahmed/Desktop/kalibrations/uni-bullshit/ps/logs.txt";

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                                             + LoginValidation.CurrentUsername + ";"
                                             + LoginValidation.CurrentUserRole + ";"
                                             + activity;
            if (File.Exists(logFileName)) 
            { 
                File.AppendAllText(logFileName, activityLine);
            }  
            
            currentSessionActivities.Add(activityLine);
        }
        
        static public void getCurrentSessionActivities()
        {
            foreach (var activity in currentSessionActivities)
            {
                Console.WriteLine(activity+ "\n");
            }
        }
        
        static public void getAllSessionActivities()
        {
           
            StreamReader sr = new
                StreamReader(logFileName); 
            StringBuilder line = new StringBuilder(1048);
            while (!sr.EndOfStream)
            {
                line.Append(sr.ReadLine());
                Console.WriteLine(line);
                line.Clear();
            }
            sr.Close();

        }
    }
}