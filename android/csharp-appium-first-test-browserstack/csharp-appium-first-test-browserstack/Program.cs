using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Drawing;


namespace csharp_appium_first_test_browserstack
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("userName", "");
            browserstackOptions.Add("accessKey", "");
            browserstackOptions.Add("appiumVersion", "2.6.0");
            browserstackOptions.Add("buildName", "SwipeUp_8.0");

            AppiumOptions caps = new AppiumOptions();

            caps.AddAdditionalAppiumOption("bstack:options", browserstackOptions);

            //caps.PlatformName = "android";
            //caps.PlatformVersion = "13.0";
            //caps.DeviceName = "Samsung Galaxy S23";

            //caps.PlatformName = "android";
            //caps.PlatformVersion = "9.0";
            //caps.DeviceName = "Google Pixel 3";

            caps.PlatformName = "android";
            caps.PlatformVersion = "13.0";
            caps.DeviceName = "Samsung Galaxy S23";

            caps.App = "bs://sample.app";


            // Initialize the remote WebDriver using BrowserStack remote URL
            // and desired capabilities defined above
            AppiumDriver driver = new AndroidDriver(
                   new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            Thread.Sleep(2000);

            var finger = new PointerInputDevice(PointerKind.Touch);
            var start = new Point(550, 1612);
            var end = new Point(543, 1600);
            var swipe = new ActionSequence(finger);
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, start.X, start.Y, TimeSpan.Zero));
            swipe.AddAction(finger.CreatePointerDown(MouseButton.Left));
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, end.X, end.Y, TimeSpan.FromMilliseconds(1000)));
            swipe.AddAction(finger.CreatePointerUp(MouseButton.Left));
            driver.PerformActions(new List<ActionSequence> { swipe });

            driver.Quit();
        }
    }
}