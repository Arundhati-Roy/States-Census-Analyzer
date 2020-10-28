using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StatesCensusAnalyzer
{
    public abstract class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilepath, string dataHeader)
        {
            string[] censusData;
            if (Path.GetExtension(csvFilepath) != ".csv")
            {
                throw new CensusException("Inavlid File Type", CensusException.ExceptionType.Invalid_File_Type);
            }
            if (!File.Exists(csvFilepath))
            {
                throw new CensusException("File not found",CensusException.ExceptionType.File_Not_Found);
            }
            censusData = File.ReadAllLines(csvFilepath);
            if(censusData[0]!=dataHeader)
            {
                throw new CensusException("Incorrect header in Data", CensusException.ExceptionType.Incorrect_Header);
            }
            return censusData;
        }
    }
}
