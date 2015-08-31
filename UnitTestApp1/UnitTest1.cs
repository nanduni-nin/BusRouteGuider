using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using BusRouteGuider.ViewModel;
using BusRouteGuider;

namespace UnitTestApp1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BusRouteGuider.View.SearchRoute alg = new BusRouteGuider.View.SearchRoute();
            String actual = alg.start();
            String Expected = "success";
            Assert.AreEqual(actual, Expected);
        }
    }
}
