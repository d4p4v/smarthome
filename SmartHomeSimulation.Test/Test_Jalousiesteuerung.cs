using M320_SmartHome;

namespace SmartHomeSimulation.Test
{
    [TestClass]
    public class Test_Jalousiesteuerung
    {
        [TestMethod]
        public void TestHoehereAussentemp() // Resultat: true
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(25, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Küche", 20);
            wohnung.SetPersonenImZimmer("Küche", false);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");
            Assert.AreEqual(kueche.JalousieHeruntergefahren, true);
        }

        [TestMethod]
        public void TestTiefereAussentemp() // Resultat: false
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(15, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Küche", 20);
            wohnung.SetPersonenImZimmer("Küche", false);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");
            Assert.AreEqual(kueche.JalousieHeruntergefahren, false);
        }

        [TestMethod]
        public void TestPersonImRaum() // Resultat: false
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(25, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Küche", 20);
            wohnung.SetPersonenImZimmer("Küche", false);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");
            Assert.AreEqual(kueche.JalousieHeruntergefahren, true);
        }


        [TestMethod]
        public void TestHoehereTempPersonImRaum() // Resultat: false
        {
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(25, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Küche", 20);
            wohnung.SetPersonenImZimmer("Küche", true);
            wohnung.GenerateWetterdaten(zeitdauerMinuten);

            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");
            Assert.AreEqual(kueche.JalousieHeruntergefahren, false);
        }
    }
}