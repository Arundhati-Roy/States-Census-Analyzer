using System;
using System.Collections.Generic;
using System.Text;

namespace StatesCensusAnalyzer.POCO
{
    public class CensusDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;

        public CensusDAO(string v1, string v2, string v3, string v4)
        {
            this.state = v1;
            this.population = Convert.ToInt32(v2);
            this.area = Convert.ToInt32(v3);
            this.density = Convert.ToInt32(v4);
        }
        /*public void USCensusDAO(string v1, string v2, string v3, string v4)
        {
            this.state = v1;
            this.population = Convert.ToInt32(v2);
            this.area = Convert.ToInt32(v3);
            this.density = Convert.ToInt32(v4);
        }*/
    }
}
