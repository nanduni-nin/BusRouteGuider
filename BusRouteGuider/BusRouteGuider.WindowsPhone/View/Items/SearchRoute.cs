using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using Windows.Storage;
using System.Threading.Tasks;
using System.Windows;


/*
    This class contains the logic for reading the data file, inerting data into the data structures and searching the route
 */
namespace BusRouteGuider.View
{
    public class SearchRoute
    {
        private static Dictionary<String, Route> routes;            //Stores all the available routes
        private static Dictionary<String, Location> locations;      //Stores all the available locations  Banadarawela - Bandarawela Object
        
        //Constructor for the class
        public SearchRoute() {            
            start();
        }

        //Intialize the data structures
        public String start() { 
            routes = new Dictionary<String, Route>();
            locations = new Dictionary<String, Location>();
            loadData();
            Debug.WriteLine("++++++++++++++++++++++++");
            return "success";
        }


        //Loading data from data file
        public async void loadData() {
            Debug.WriteLine("Load Data Came");
            String[] lines;
            String[] temp;
            Route route;

            //Reading the text file
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await folder.GetFileAsync("data.txt");
            var contents =  await Windows.Storage.FileIO.ReadTextAsync(file);

            //Seperate into variables
            lines = contents.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            //Clear the buffers
            routes.Clear();
            //Read line by line to get the route number and the locations through the route
            for (int i = 0; i < lines.Length; i++)
            {
                temp = lines[i].Split('|');
                route = new Route(temp[0]);
                //Debug.WriteLine(temp[0] + "-------" + temp[1] + "------------" + temp[2]);
                route = processInput(temp[1], route);
                route = processInput(temp[2], route);
                
                //if else statements for preventing any exceptions due to duplicate key values
                if (!routes.ContainsKey(temp[0]))
                {
                    routes.Add(temp[0], route);
                }
            }

        }

             
        //Add the data into the data structures
        public Route processInput(String temp, Route route) {
            Location location = null;
            String[] tempLocations = temp.Split(',');

            //fill the dictionarires for routes and locations
            foreach (String s in tempLocations) {
                if (!locations.ContainsKey(s)) {
                    location = new Location(s);
                    route.addLocationToRouteIn(location);
                    locations.Add(s, location);
                } else {
                    Location value;
                    if (locations.TryGetValue(s, out value)) {
                        route.addLocationToRouteIn(locations[s]);
                    }
                }
            }
            return route;
        }

        //Get the locations dictionary
        public Dictionary<String, Location> getAllLocations() {
            return locations;
        }

        //Get the routes dictionary
        public Dictionary<String, Route> getAllRoutes() {
            return routes;
        }
    }
}
