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
        
        public int MaxNumberOfUnequalChars(string inputString)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Input String");
            writer.WriteValue(inputString);

            int result = 0;
            int currentNumberOfUnequalChars = 0;
            inputString = inputString[0] + inputString + inputString[inputString.Length - 1];

            for (int i = 0; i < inputString.Length - 1; i++)
            {
                if (inputString[i] != inputString[i + 1])
                {
                    currentNumberOfUnequalChars++;
                }
                else
                {
                    currentNumberOfUnequalChars++;

                    if (result < currentNumberOfUnequalChars)
                    {
                        result = currentNumberOfUnequalChars;
                    }

                    currentNumberOfUnequalChars = 0;
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
