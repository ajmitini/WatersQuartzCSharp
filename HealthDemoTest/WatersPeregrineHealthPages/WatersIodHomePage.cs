using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HealthDemoTest.WatersPeregrineHealthPages
{
    public class WatersIodHomePage : BaseClass
    {
        private IWebElement logo;
        private IList<IWebElement> createButton;

        public void AndIAmOnWatersIodHomepage()
        {
            logo = GetWebElementByClassName("card-block");
            Assert.True(logo.Displayed, "Waters Iod homepage not displayed");  
        }
       
        public WatersQuartzFrontPage AndIClickOnPeregrineCreateButton()
        {
            Thread.Sleep(10000);
            createButton = GetWebElementsByCSSSelector(".btn.btn-success.create-button");
            createButton[1].Click();

            Thread.Sleep(10000);

            SwitchToTab(1);

            Thread.Sleep(30000);

            return new WatersQuartzFrontPage();
        }

        
        }
    }

