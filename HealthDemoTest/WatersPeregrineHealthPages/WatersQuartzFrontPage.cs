using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemoTest.WatersPeregrineHealthPages
{
    public class WatersQuartzFrontPage : BaseClass
    {
        private IWebElement QuartzFrontPage;
        private IWebElement OpenButton;

        public void ThenIAmOnQuartzFrontPage()
        {
            QuartzFrontPage = GetWebElementById("applicationSelectButton");
            Assert.True(QuartzFrontPage.Displayed, "Waters Quartz front page not displayed");
        }
        public void WhenIClickOnOpenButton()
        {
            OpenButton = GetWebElementById("TUNE_INFO_ID");
            OpenButton.Click();

        }
    }
}
