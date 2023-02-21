namespace M320_SmartHome {
    /// <summary>
    /// Zimmer mit Markisen
    /// </summary>
    public class ZimmerMitMarkisensteuerung : ZimmerMitAktor {
        public ZimmerMitMarkisensteuerung(Zimmer zimmer) : base(zimmer) {
        }

        /// <summary>
        /// Ist Markise offen?
        /// </summary>
        public bool MarkiseOffen { get; private set; }

        /// <summary>
        /// Verarbeitung von Wetterdaten für Markise
        /// </summary>
        /// <param name="wetterdaten">Wetterdaten vom Sensor</param>
        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            if(wetterdaten.Aussentemperatur > this.Zimmer.Temperaturvorgabe) {
                // Markise schliessen
                if(this.MarkiseOffen) {
                    if (wetterdaten.Regen) {
                        Console.WriteLine($"{this.Name}: Markise kann nicht geschlossen werden weils regnet.");
                    } else {
                        Console.WriteLine($"{this.Name}: Markise wird geschlossen.");
                        MarkiseOffen = false;
                    }
                } else if(wetterdaten.Regen) {
                    Console.WriteLine($"{this.Name}: Markise wird geöffnet weils regnet.");
                    MarkiseOffen = true;
                }
            } else {
                // Markise öffnen
                if (!this.MarkiseOffen) {
                    Console.WriteLine($"{this.Name}: Markise wird geöffnet.");
                    MarkiseOffen = true;
                }
            }

            base.VerarbeiteWetterdaten(wetterdaten);
        }
    }
}
