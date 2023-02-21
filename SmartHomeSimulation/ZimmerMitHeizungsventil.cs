namespace M320_SmartHome {
    public class ZimmerMitHeizungsventil : ZimmerMitAktor {
        public ZimmerMitHeizungsventil(Zimmer zimmer) : base(zimmer) {
        }

        /// <summary>
        /// Ist das Heizungsventil offen?
        /// </summary>
        public bool HeizungsventilOffen { get; private set; }

        /// <summary>
        /// Verarbeitung von Wetterdaten beim Heizungsventil.
        /// </summary>
        /// <param name="wetterdaten">Die Wetterdaten vom Sensor.</param>
        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            if(wetterdaten.Aussentemperatur < this.Zimmer.Temperaturvorgabe) {
                // Ventil öffnen
                if(!this.HeizungsventilOffen) {
                    Console.WriteLine($"{this.Name}: Heizungsventil wird geöffnet.");
                    HeizungsventilOffen = true;
                }
            } else {
                // Ventil schliessen
                if (this.HeizungsventilOffen) {
                    Console.WriteLine($"{this.Name}: Heizungsventil wird geschlossen.");
                    HeizungsventilOffen= false;
                }
            }

            base.VerarbeiteWetterdaten(wetterdaten);
        }
    }
}
