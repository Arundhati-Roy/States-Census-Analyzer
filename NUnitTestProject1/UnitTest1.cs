using NUnit.Framework;
using StatesCensusAnalyzer;
using StatesCensusAnalyzer.DTO;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCensusFilePath = @"C:\Users\priyadarshini roy\source\repos\StatesCensusAnalyzer\StatesCensusAnalyzer\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\priyadarshini roy\source\repos\StatesCensusAnalyzer\StatesCensusAnalyzer\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\priyadarshini roy\source\repos\StatesCensusAnalyzer\StatesCensusAnalyzer\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianCensusFileType = @"C:\Users\priyadarshini roy\source\repos\StatesCensusAnalyzer\StatesCensusAnalyzer\CSVFiles\WrongIndiaStateCensusData.txt";
        static string wrongIndianCensusFilePath = @"C:\Users\priyadarshini roy\source\repos\StatesCensusAnalyzer\StatesCensusAnalyzer\CSVFiles\IndiaData.csv";

        static string indianStateCodeFilePath = @"C:\Users\priyadarshini roy\source\repos\StatesCensusAnalyzer\StatesCensusAnalyzer\CSVFiles\IndiaStateCode.csv";
        static string wrongHeadersStateCodefilePath = @"C:\Users\priyadarshini roy\source\repos\StatesCensusAnalyzer\StatesCensusAnalyzer\CSVFiles\DelimiterIndiaStateCode.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\priyadarshini roy\source\repos\StatesCensusAnalyzer\StatesCensusAnalyzer\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\priyadarshini roy\source\repos\StatesCensusAnalyzer\StatesCensusAnalyzer\CSVFiles\IndiaStateCensusData.txt";

        CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;


        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void TC1_1_GivenStateCensus_CheckToEnsureNumberOfRecords()
        {
            totalRecord = censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        [Test]
        public void TC1_2_GivenStateCensus_GiveCustomException_ForIncorrectPath()
        {
            var censusException=Assert.Throws<CensusException>(()=> censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianCensusFilePath, wrongHeaderIndianCensusFilePath));
            var stateException = Assert.Throws<CensusException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianCensusFilePath, wrongHeadersStateCodefilePath));
            Assert.AreEqual(CensusException.ExceptionType.File_Not_Found, censusException.type);
            Assert.AreEqual(CensusException.ExceptionType.File_Not_Found,stateException.type);
        }
        [Test]
        public void TC1_3_GivenStateCensus_GiveCustomException_ForWrongFileType()
        {
            var censusException = Assert.Throws<CensusException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianCensusFileType, wrongHeaderIndianCensusFilePath));
            var stateException = Assert.Throws<CensusException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCodeFileType, wrongHeadersStateCodefilePath));
            Assert.AreEqual(CensusException.ExceptionType.Invalid_File_Type,censusException.type);
            Assert.AreEqual(CensusException.ExceptionType.Invalid_File_Type,stateException.type);
        }

        [Test]
        public void TC1_4_GivenStateCensus_GiveCustomException_ForIncorrectDelimiter()
        {
            var censusException = Assert.Throws<CensusException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusException.ExceptionType.Incorrect_Delimiter, censusException.type);
            Assert.AreEqual(CensusException.ExceptionType.Incorrect_Delimiter, stateException.type);
        }
        [Test]
        public void TC1_5_GivenStateCensus_GiveCustomException_ForIncorrectHeader()
        {
            var censusException = Assert.Throws<CensusException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongHeaderIndianCensusFilePath, wrongHeaderIndianCensusFilePath));
            var stateException = Assert.Throws<CensusException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongHeadersStateCodefilePath, wrongHeadersStateCodefilePath));
            Assert.AreEqual(CensusException.ExceptionType.Incorrect_Header, censusException.type);
            Assert.AreEqual(CensusException.ExceptionType.Incorrect_Header, stateException.type);
        }
    }
}