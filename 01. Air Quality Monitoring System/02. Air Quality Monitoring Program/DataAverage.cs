using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Quality_Monitoring
{
    // 데이터 평균값 클래스

    public class DataAverage
    {
        public double Temp { get; set; }
        public double Hum { get; set; }
        public double O2 { get; set; }
        public double CO2 { get; set; }
        public double PM10 { get; set; }
        public double PM25 { get; set; }
    }
}
