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
        [Test]
        public void LearnMoreClickedTest()
        {
            BookingHomePage bookingHomePage = new BookingHomePage(_driver);

           var covidText= bookingHomePage
                .GoToCovidInfo()
                .GoToCorrectFrame()
                .ClickPassportBox()
                .TypeInputPassport("Israel")
                .SelectFromListBoxPassport()
                .ClickDepartureBox()
                .InputDeparture("Israel")
                .SelectFromListBoxDeparture()
                .ClickDestinationBox()
                .InputDestination("Paris")
                .SelectFromListBoxDestination()
                .SelectVacunationFilter()
                .GetText()
                ;

             Assert.That(covidText, Does.Contain("COVID-19"));
            Thread.Sleep(7000);
        }
    }
}
