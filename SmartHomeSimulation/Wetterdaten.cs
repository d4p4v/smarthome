namespace M320_SmartHome {
    /// <summary>
    /// Die Wetterdaten, die von den Sensoren zurückgegeben können.
    /// </summary>
    public struct Wetterdaten {
        /// <summary>
        /// Die Temperatur von Aussen.
        /// </summary>
        public double Aussentemperatur { get; set; }
        /// <summary>
        /// Die Geschwindigkeit des Windes.
        /// </summary>
        public double Windgeschwindigkeit { get; set; }
        /// <summary>
        /// Ob es regnet oder nicht.
        /// </summary>
        public bool Regen { get; set; }
    }
}
