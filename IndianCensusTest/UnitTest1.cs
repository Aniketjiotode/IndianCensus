using NUnit.Framework;
using IndianStatesCensusAnalyser;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\91962\Desktop\cs day3\IndianCensus\IndianCensusTest\CsvFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\91962\Desktop\cs day3\IndianCensus\IndianCensusTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\91962\Desktop\cs day3\IndianCensus\IndianCensusTest\CsvFiles\IndianStateCesusDelimeter.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\91962\Desktop\cs day3\IndianCensus\IndianCensusTest\CsvFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\91962\Desktop\cs day3\IndianCensus\IndianCensusTest\CsvFiles\IndianStateCensus.txt";
        static string indianStateCodeFilePath = @"C:\Users\91962\Desktop\cs day3\IndianCensus\IndianCensusTest\CsvFiles\IndiaStateCodes.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\91962\Desktop\cs day3\IndianCensus\IndianCensusTest\CsvFiles\IndiaStateCodes.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\91962\Desktop\cs day3\IndianCensus\IndianCensusTest\CsvFiles\DelimiterIndiaStateCodes.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\91962\Desktop\cs day3\IndianCensus\IndianCensusTest\CsvFiles\WrongHeaderIndiaStateCodes.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        //count
        //TC 1.1
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(5, totalRecord.Count);
        }
        //TC 2.1
        [Test]
        public void GivenIndianCodeFilePath_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        //Wrong File Path
        //Tc 1.2
        [Test]
        public void GivenWrongIndianCensusCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        //TC 2.2
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        //WrongFileType
        //TC 1.3
        [Test]
        public void GivenWrongIndianStateCensusFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        //TC 2.3 
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.eType);
        }
        //FileWithWrongDelimeter
        //TC 1.4
        [Test]
        public void GivenWrongIndianCensusDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        //TC 2.4
        [Test]
        public void GivenWrongIndianStateCodeDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.eType);
        }
        //WrongHeader
        //TC 1.5
        [Test]
        public void GivenWrongIndianCensusDataFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        //TC 2.5
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateCodeException.eType);
        }
    }
}