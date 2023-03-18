

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        private static LoggerContext context = new LoggerContext();
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

            context.Logs.Add(new Log(activity, DateTime.Now));
            context.SaveChanges();
            currentSessionActivities.Add(activityLine);
        }
        
        static public IEnumerable<string> getCurrentSessionActivities()
        {
            return currentSessionActivities;
        }
        
        static public IEnumerable<string> getAllSessionActivities()
        {
           
            StreamReader sr = new
                StreamReader(logFileName);
          
            List<string> allLines = new List<string>();
            while (!sr.EndOfStream)
            {
                StringBuilder line = new StringBuilder(1048);
                line.Append(sr.ReadLine());
                allLines.Add(line.ToString());
            }
            sr.Close();
            return allLines;
        }
    }
}