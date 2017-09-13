using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;

////////////////////////////////////////////////////////////////////////////
//	Copyright 2017 : Vladimir Novick    https://www.linkedin.com/in/vladimirnovick/  
//
//         https://github.com/Vladimir-Novick/CSharp-JSON
//
//    NO WARRANTIES ARE EXTENDED. USE AT YOUR OWN RISK. 
//
// To contact the author with suggestions or comments, use  :vlad.novick@gmail.com
//
////////////////////////////////////////////////////////////////////////////


namespace SGcombo.JsonUtils
{

    public class CorrectionData
    {

        public string source { get; private set; }
        public string destination { get; private set; }

        public CorrectionData(string _source,string _destination)
        {
            source = _source;
            destination = _destination;
        }
    }

    
        public T ReadObjectFromJsonFile(String Filepath, List<CorrectionData> dataCorrection = null, Boolean debug = false)
        {
            string json = string.Empty;

            T value;


           

            using (StreamReader read = new StreamReader(Filepath))
            {
                json = read.ReadToEnd();
                if (dataCorrection != null)
                {

                    foreach (CorrectionData item in dataCorrection)
                    {
                        json = Regex.Replace(json, item.source, item.destination);
                    }

                }

                if (debug)
                {
                    File.WriteAllText(Filepath + ".debug", json);
                }


               value = (T)JsonConvert.DeserializeObject(json, typeof(T));



            }
            return value;
        }
    
    public class ReadJsonFromFile<T>
    {
        public List<T> ReadListObjectJsonFile(String Filepath, List<CorrectionData> dataCorrection = null, Boolean debug = false)
        {
            string json = string.Empty;

            List<T> value = new List<T>();

            Type dataType = value.GetType();

            using (StreamReader read = new StreamReader(Filepath))
            {
                json = read.ReadToEnd();
                if (dataCorrection != null)
                {

                    foreach (CorrectionData item in dataCorrection)
                    {
                        json = Regex.Replace(json,item.source, item.destination);
                    }
                   
                }

                if (debug)
                {
                    File.WriteAllText(Filepath + ".debug", json);
                }


                value = (List<T>)JsonConvert.DeserializeObject(json, dataType);
              


            }
            return value;
        }
    }


}
