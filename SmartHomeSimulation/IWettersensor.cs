using M320_SmartHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M320_SmartHome
{
    /// <summary>
    /// Das Interface für die Sensoren, die Wetterdaten aufnehmen.
    /// </summary>
    public interface IWettersensor
    {
        /// <summary>
        /// Liest Wetterdaten vom jeweiligen Sensor.
        /// </summary>
        /// <returns>Wetterdaten des Sensors</returns>
        public Wetterdaten GetWetterdaten();
    }
}
