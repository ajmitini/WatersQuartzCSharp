using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemoTest.WatersPeregrineHealthPages
{
    public class WatersQuartzEngineer_sConsolePage : BaseClass
    {
        private IWebElement EngineerConsolePage;
        
        public void ThenIAmOnEngineerConsolePage()
        {
            EngineerConsolePage = GetWebElementByClassName("container");
            Assert.True(EngineerConsolePage.Displayed, "Engineer Console page not displayed");
        }
       

        }
    }

