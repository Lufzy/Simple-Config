using System.Collections.Generic;
using System.IO;
using System;

namespace Config // https://github.com/Lufzy/Simple-Config - https://www.unknowncheats.me/forum/c-/240230-simple-config-system.html
{
    class Config
    {
        public static Dictionary<string, dynamic> Settings = new Dictionary<string, dynamic>();

        public static void Save(string configName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = @"\" + configName + @".ini";

            if(File.Exists(path + filename))
            {
                using (StreamWriter outputFile = new StreamWriter(path + filename))
                {
                    foreach (var values in Settings)
                    {
                        outputFile.WriteLine(values);
                    }
                    outputFile.Close();
                }
            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(path + filename))
                {
                    foreach (var values in Settings)
                    {
                        outputFile.WriteLine(values);
                    }
                    outputFile.Close();
                }
            }
        }

        public static void Load(string configName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = @"\" + configName + @".ini";
            char[] charsToTrim = { ' ', };
            string line;

            StreamReader file = new StreamReader(path + filename);
            while ((line = file.ReadLine()) != null)
            {
                string[] character = line.Split(charsToTrim);
                string key = character[0].TrimEnd(',').TrimStart('[');
                string value = character[1].TrimEnd(']');
                Settings[key] = value;
            }
            file.Close();
        }

        public static T GetValue<T>(string value)
        {
            try
            {
                return (T)Convert.ChangeType(Settings[value], typeof(T));
            }
            catch { return default(T);  }
        }

        public static void SetValue<T>(string value, dynamic sObject) // https://stackoverflow.com/questions/1243717/how-to-update-the-value-stored-in-dictionary-in-c
        {
            dynamic val;
            if (Settings.TryGetValue(value, out val))
            {
                // yay, value exists!
                Settings[value] = sObject;
            }
            else
            {
                // darn, lets add the value
                Settings.Add(value, sObject);
            }
        }
    }
}
