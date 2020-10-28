using StatesCensusAnalyzer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using static StatesCensusAnalyzer.CensusAnalyzer;

namespace StatesCensusAnalyzer
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(
            Country country,
            string csvFilepath,
            string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyzer.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilepath, dataHeaders);
               /* case (CensusAnalyzer.Country.US):
                    return new IndianCensusAdapter.LoadCensusData(csvFilepath, dataHeaders);*/
                default:
                    throw new CensusException("No such country", CensusException.ExceptionType.No_Such_Country);
            }
        }

       /* internal class LoadCsvData : Dictionary<string, CensusDTO>
        {
            private Country country;
            private string csvFilepath;
            private string dataHeaders;

            public LoadCsvData(Country country, string csvFilepath, string dataHeaders)
            {
                this.country = country;
                this.csvFilepath = csvFilepath;
                this.dataHeaders = dataHeaders;
            }
            public Dictionary<string, CensusDTO> LoadCSVData(
            Country country,
            string csvFilepath,
            string dataHeaders)
            {
                switch (country)
                {
                    case (CensusAnalyzer.Country.INDIA):
                        return new IndianCensusAdapter().LoadCensusData(csvFilepath, dataHeaders);
                    *//*case (CensusAnalyzer.Country.US):
                        return new IndianCensusAdapter.LoadCensusData(csvFilepath, dataHeaders);*//*
                    default:
                        throw new CensusException("No such country", CensusException.ExceptionType.No_Such_Country);
                }
            }
        }*/
    }
}
