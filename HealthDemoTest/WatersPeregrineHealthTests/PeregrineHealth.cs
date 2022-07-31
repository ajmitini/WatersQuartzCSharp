using HealthDemoTest.WatersPeregrineHealthPages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemoTest.WatersPeregrineHealthTests
{
    public class PeregrineHealth
    {
        private WatersIodHomePage iodhomepage;
        private WatersQuartzFrontPage quartzfrontpage;
        private WatersQuartzEngineer_sConsolePage EngineerConsolePage;

        [SetUp]

        public void initialise()
        {
            BaseClass.LaunchBrowser("Chrome");
            iodhomepage = new WatersIodHomePage();
            quartzfrontpage = new WatersQuartzFrontPage();
            EngineerConsolePage = new WatersQuartzEngineer_sConsolePage();
        }
        [TearDown]
        public void TearDown()
        {
            BaseClass.CloseBrowser();
        }
        [Test]
        public void PeregrineHealthTest()
        {
            iodhomepage = BaseClass.GivenINavigateToWatersIodHomePage();
            iodhomepage.AndIAmOnWatersIodHomepage();
            iodhomepage.AndIClickOnPeregrineCreateButton();
            quartzfrontpage.ThenIAmOnQuartzFrontPage();
            quartzfrontpage.WhenIClickOnOpenButton();
            EngineerConsolePage.ThenIAmOnEngineerConsolePage();
        }
    }

   
    
    }

