using StatesCensusAnalyzer.DTO;
using StatesCensusAnalyzer.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatesCensusAnalyzer
{
    public class IndianCensusAdapter:CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string,CensusDTO> LoadCensusData(string csvFilePath,string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach(string data in censusData.Skip(1))
            {
                if(!data.Contains(","))
                {
                    throw new CensusException("File contains wrong delimiter", CensusException.ExceptionType.Incorrect_Delimiter);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(column[1], new CensusDTO(new StateDAO(column[0], column[1], column[2], column[3])));
                if(csvFilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new CensusDAO(column[0], column[1], column[2], column[3])));
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
