using Logging;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingSeleniumLsports.TestCase
{
    class CovidInfoTesting:BaseTest
    {
        [TestCase("Israel", "Israel", "Paris")]
        public void LearnMoreClickedTest(string passport, string departure,string destination)
        {
            BookingHomePage bookingHomePage = new BookingHomePage(_driver);

           var covidText= bookingHomePage
                .GoToCovidInfo()
                .GoToCorrectFrame()
                .ClickPassportBox()
                .TypeInputPassport(passport)
                .SelectFromListBoxPassport()
                .ClickDepartureBox()
                .InputDeparture(departure)
                .SelectFromListBoxDeparture()
                .ClickDestinationBox()
                .InputDestination(destination)
                .SelectFromListBoxDestination()
                .SelectVacunationFilter()
                .GetText()
                ;

             Assert.That(covidText, Does.Contain("COVID-19"));

            Logger.Instance.Add("Corona Info Test Success");
            Thread.Sleep(7000);
        }
    }
}
