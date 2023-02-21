using M320_SmartHome;

namespace SmartHomeSimulation.Test
{
    [TestClass]
    public class Test_Heizungsventil
    {
        [TestMethod]
        public void Test15Grad() // Resultat: true
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(15, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnzimmer", 20);
            wohnung.SetPersonenImZimmer("Wohnzimmer", true);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var wohnzimmer = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Wohnzimmer");
            Assert.AreEqual(wohnzimmer.HeizungsventilOffen, true);
        }

        [TestMethod]
        public void Test25Grad() // Resultat: false
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(25, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnzimmer", 20);
            wohnung.SetPersonenImZimmer("Wohnzimmer", true);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var wohnzimmer = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Wohnzimmer");
            Assert.AreEqual(wohnzimmer.HeizungsventilOffen, false);
        }

        [TestMethod]
        public void TestMinus50Grad() // Resultat: true
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(-50, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnzimmer", 20);
            wohnung.SetPersonenImZimmer("Wohnzimmer", true);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var wohnzimmer = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Wohnzimmer");
            Assert.AreEqual(wohnzimmer.HeizungsventilOffen, true);
        }

        [TestMethod]
        public void Test100Grad() // Resultat: false
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(100, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnzimmer", 20);
            wohnung.SetPersonenImZimmer("Wohnzimmer", true);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var wohnzimmer = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Wohnzimmer");
            Assert.AreEqual(wohnzimmer.HeizungsventilOffen, false);
        }
    }
}