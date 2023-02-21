namespace M320_SmartHome {
    /// <summary>
    /// Die Zimmer Klasse.
    /// </summary>
    public abstract class Zimmer {
        /// <summary>
        /// Die gewünschte, kontrollierte Zimmertemperatur.
        /// </summary>
        public virtual double Temperaturvorgabe { get; set; }
        /// <summary>
        /// Wie viele Personen es im Zimmer hat.
        /// </summary>
        public virtual bool PersonenImZimmer { get; set; }
        /// <summary>
        /// Der Name des Zimmers.
        /// </summary>
        public string Name { get; }

        public Zimmer(string name) {
            this.Name = name;
        }
        /// <summary>
        /// Verarbeitet die gegebenen Wetterdaten.
        /// </summary>
        /// <param name="wetterdaten">Die Wetterdaten vom Sensor.</param>
        public virtual void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            Console.WriteLine($"Wetterdaten für {this.Name} verarbeitet: Temperaturvorgabe: {this.Temperaturvorgabe}°C, Personen im Zimmer: {(this.PersonenImZimmer ? "ja" : "nein")}.");
        }
    }
}
