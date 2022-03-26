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
        [Test]
        public void ExploreDealsClickedTest()
        {
            BookingHomePage bookingHomePage = new BookingHomePage(_driver);

           var isQualityHotels= bookingHomePage.GoToExploreDealsPage()
                .InputDestination("Eilat")
                .ExecuteDestinationSearch()
                .ReviewScoreClick();

            Assert.IsTrue(isQualityHotels);
            Thread.Sleep(10000);

        }


    }


}

