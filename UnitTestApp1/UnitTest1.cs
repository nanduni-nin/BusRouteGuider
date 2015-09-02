using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using BusRouteGuider.ViewModel;
using BusRouteGuider;
using System.Collections.Generic;


namespace UnitTestApp1
{
    [TestClass]
    public class UnitTest1
    {
        /*Check if the data loads from the file correctly*/
        [TestMethod]
        public void TestLoadingData()
        {
            BusRouteGuider.View.SearchRoute alg = new BusRouteGuider.View.SearchRoute();
            String actual = alg.start();
            String Expected = "success";
            Assert.AreEqual(actual, Expected);
        }

        /*Check if the data from the file are properly added to the 'Route' dictionary*/
        [TestMethod]
        public void TestRouteDictionary()
        {
            BusRouteGuider.View.SearchRoute alg = new BusRouteGuider.View.SearchRoute();
            String routeIn = "Fort,Kiribathgoda,Miriswatha,Nittambuwa,Warakapola,Nelundeniya,Galigamuwa,Kegalle,Mawanella,Kadugannawa,Peradeniya,Kandy";
            String routeOut = "Kandy,Peradeniya,Kadugannawa,Mawanella,Kegalle,Galigamuwa,Nelundeniya,Warakapola,Nittambuwa,Miriswatha,Kiribathgoda,Fort";
            String expectedRoute = "Fort->Kiribathgoda->Miriswatha->Nittambuwa->Warakapola->Nelundeniya->Galigamuwa->Kegalle->Mawanella->Kadugannawa->Peradeniya->Kandy";
            String routeNumber = "001";
            BusRouteGuider.View.Route route = new BusRouteGuider.View.Route(routeNumber);
            route = alg.processInput(routeIn, route);
            route = alg.processInput(routeOut, route);
            Assert.AreEqual(route.getPath(), expectedRoute);
        }

        /*Check if the buses at a location functionality genearates correct results*/
        [TestMethod]
        public void TestBusesAtALocationFunctionality()
        {
            BusRouteGuider.View.SearchRoute alg = new BusRouteGuider.View.SearchRoute();
            String town = "Moratuwa";
            Dictionary<String, BusRouteGuider.View.Location> locations = alg.getAllLocations();
            LinkedList<BusRouteGuider.View.Route> list = locations[town].getRoutes();
            String expected = "success";
            String actual = "";
            foreach(BusRouteGuider.View.Route r  in list){
                if (r.getRouteNumber().Equals("430")) {
                    actual = "success";
                }
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLocationFunctionality()
        {
            BusRouteGuider.View.SearchRoute alg = new BusRouteGuider.View.SearchRoute();
            String actual = "";
            String expected = "success";
            Dictionary<String, BusRouteGuider.View.Location> locations = alg.getAllLocations();
            if(locations.ContainsKey("Warakapola")){
                actual = "success";
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRoutesInPath()
        {
            BusRouteGuider.View.SearchRoute alg = new BusRouteGuider.View.SearchRoute();
            alg.start();
            String routeNumber = "002";
            Dictionary<String, BusRouteGuider.View.Route> routes = alg.getAllRoutes();
            String path = routes[routeNumber].getPathForTesting();
            String expected = "Fort->Kiribathgoda->Miriswatha->Nittambuwa->Warakapola->Nelundeniya->Galigamuwa->Kegalle->Mawanella->Kadugannawa->Peradeniya->Kandy";
            Assert.AreEqual(expected,path);
        }



    }
}
