using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Formats.Asn1;
using System.Xml;

namespace StringLibrary
{
    public class StringProcessing
    {
        
        JsonWriter writer;
        public StringProcessing()
        {
            StreamWriter logFile = File.CreateText("StringProcessing.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Newtonsoft.Json.Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("String Processings");
            writer.WriteStartArray();
        }
        
        public int DoProcessing(string inputStr)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Input String");
            writer.WriteValue(inputStr);
            int result = 0;
            int currNumberOfUneqCh = 0;

            for (int i = 1; i < inputStr.Length; i++)
            {
                if (inputStr[i] != inputStr[i - 1])
                {
                    currNumberOfUneqCh++;
                }
                else
                {
                    if (result < currNumberOfUneqCh)
                    {
                        result = currNumberOfUneqCh;
                    }
                    currNumberOfUneqCh = 0;
                }
            }

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }
        
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
        
    }
}
