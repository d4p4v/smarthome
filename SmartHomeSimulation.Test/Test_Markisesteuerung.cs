using M320_SmartHome;

namespace SmartHomeSimulation.Test
{
    [TestClass]
    public class Test_Markisesteuerung
    {
        [TestMethod]
        public void TestRegenWind() // Resultat: true
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(25, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");
            Assert.AreEqual(wintergarten.MarkiseOffen, true);
        }

        [TestMethod]
        public void TestWind() // Resultat: false
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(25, 35, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");
            Assert.AreEqual(wintergarten.MarkiseOffen, false);
        }

        [TestMethod]
        public void TestHoehereAussentemp() // Resultat: false
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(25, 20, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");
            Assert.AreEqual(wintergarten.MarkiseOffen, false);
        }

        [TestMethod]
        public void TestHoehereTempKeinWindKeinRegen() // Resultat: true
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(15, 35, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");
            Assert.AreEqual(wintergarten.MarkiseOffen, true);
        }
    }
}