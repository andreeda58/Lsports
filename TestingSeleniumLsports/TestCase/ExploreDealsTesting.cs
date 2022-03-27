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
    [TestFixture]
    class ExploreDealsTesting:BaseTest
    {
        [TestCase("Eilat")]
        public void ExploreDealsClickedTest(string destination)
        {
            BookingHomePage bookingHomePage = new BookingHomePage(_driver);

           var isQualityHotels= bookingHomePage.GoToExploreDealsPage()
                .InputDestination(destination)
                .ExecuteDestinationSearch()
                .ReviewScoreClick();

            Assert.IsTrue(isQualityHotels);

            Logger.Instance.Add("well rated hotels test success");
            Thread.Sleep(10000);

        }


    }


}

