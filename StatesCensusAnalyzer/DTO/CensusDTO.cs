using StatesCensusAnalyzer.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatesCensusAnalyzer.DTO
{
    public class CensusDTO
    {
        public int serialNo;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        public CensusDTO(StateDAO stateCode)
        {
            this.serialNo = stateCode.serialNumber;
            this.stateName = stateCode.stateName;
            this.tin = stateCode.tin;
            this.stateCode = stateCode.stateCode;
        }
        public CensusDTO(CensusDAO censusData)
        {
            this.state = censusData.state;
            this.population = censusData.population;
            this.area = censusData.area;
            this.density = censusData.density;
        }
        /*public CensusDTO(USCensusDAO usCensusData)
        {
            this.stateCode = usCensusData.stateId;
            this.population = censusData.population;
            this.area = censusData.area;
            this.density = censusData.density;
        }*/
    }
}
