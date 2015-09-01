using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;
using System.Diagnostics;
using System.Collections;


namespace BusRouteGuider.View
{
    public class Algorithm
    {
        private SortedSet<String> tree;
        Dictionary<String, Location> locations;
        private int minCount;
        private int maxCount;

        public Algorithm() {
            tree = new SortedSet<string>();
            locations = new Dictionary<string, Location>();
            minCount = 5;
            maxCount = 0;
        }

        public async void getBusNumbers(String start, Dictionary<String, Location> dic)
        {
            //The list stores all the buses that will pass through this location
            List<String> series = new List<String>();
            //Get the object of the user defined location
            Location toFind = dic[start];
            //Traverse through routes that contain this location
            foreach (Route r in toFind.getRoutes()) {
                //If a route found, add to the list
                series.Add(r.getRouteNumber());
            }

            if (series.Count == 0) {
                //Create a message pop up box to isplay the results
                MessageDialog msgbox1 = new MessageDialog("Route too long", "Search Results");
                await msgbox1.ShowAsync();
                return;
            }

            //Display the results
            String t = "The buses that pass this location are," + Environment.NewLine;
            foreach (String s in series)
            {
                t = t + Environment.NewLine + Environment.NewLine +"       "+ s;
            }

            //Create a message pop up box to isplay the results
            MessageDialog msgbox2 = new MessageDialog(t,"Search Results");
            await msgbox2.ShowAsync();
            return;

        }

        public async void getRoutes(String start, String end, Dictionary<String, Location> dic, Boolean searchAll) {
            this.locations = dic;
            findRoutes(start, start, end, new LinkedList<String>(), new LinkedList<String>(), 3);

            if (searchAll) {
                String t = "";
                foreach (String s in tree) {
                    t = t + Environment.NewLine + s + Environment.NewLine;
                }
                MessageDialog msgbox1 = new MessageDialog(t, "Search Results");
                await msgbox1.ShowAsync();
                return;
            }

            LinkedList<String> selected1 = new LinkedList<String>();
            LinkedList<String> selected2 = new LinkedList<String>();
            LinkedList<String> selected3 = new LinkedList<String>();
            LinkedList<String> selected4 = new LinkedList<String>();

            foreach (String s in tree) {
                int count = 0;
                String[] array = s.Split(' ');
                foreach(String h in array){
                    if (System.Text.RegularExpressions.Regex.IsMatch(h, "^[0-9]+$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        count++;
                    }
                }
                               
                switch (count) {
                    case 1:
                        selected1.AddLast(s);
                        break;
                    case 2:
                        selected2.AddLast(s);
                        break;
                    case 3:
                        selected3.AddLast(s);
                        break;
                    case 4:
                        selected4.AddLast(s);
                        break;
                    default:
                        break;
            }
            minCount = Math.Min(count, minCount);
            maxCount = Math.Max(count, maxCount);
        }

        //Debug.WriteLine("Min is:" + minCount);
        String displayText;
        switch (minCount) {
            case 0:
                displayText = "No Root Found";
                break;
            case 1:
                displayText = "";
                foreach(String s in selected1){
                    displayText = displayText + s + "\n" + Environment.NewLine;
                }
                break;
            case 2:
                displayText = "";
                foreach(String s in selected2){
                    displayText = displayText + s + "\n" + Environment.NewLine;
                    ;
                }
                break;
            case 3:
                displayText = "";
                foreach(String s in selected3){
                    displayText = displayText + s + "\n" + Environment.NewLine;
                }
                break;
            case 4:
                displayText = "";
                foreach (String s in selected4)
                {
                    displayText = displayText + s + "\n" + Environment.NewLine;
                }
                break;
            default:
                displayText = "Route too Long";
                break;
        }

        MessageDialog msgbox2 = new MessageDialog(displayText, "Search Results");
        await msgbox2.ShowAsync();
        minCount = 5;
        tree.Clear();
    

        }

        public void findRoutes(String start, String current, String end, LinkedList<String> tempRoutes, LinkedList<String> tempLocations, int depth) {
            if (depth > 0) {

            if (current.Equals(end)) {

                String s = "";
                for (int i = 0; i < tempRoutes.Count; i++) {

                    if (i != 0) {
                        //Get the ith element from linkedlist tempLocations
                        LinkedListNode<String> _mark = tempLocations.First;
                        for (int p = 0; p < i; p++){
                            _mark = _mark.Next;
                        }               
                        s = s + " Drop at " + _mark.Value+" . ";
                    }
                    //Get the ith element from linkedlist tempRoutes
                    LinkedListNode<String> mark = tempRoutes.First;
                    for (int p = 0; p < i; p++){
                            mark = mark.Next;
                    }   
                    s = s + "Take " + " " + mark.Value + " . ";
                }

                s = s + " Get down at your destination, " + end;
                tree.Add(s);

            } else {
                Location location = locations[current];

                for (int i = 0; i < location.getRoutes().Count; i++) {

                    //Get the ith element of the linked list
                    LinkedListNode<Route> mark = location.getRoutes().First;
                    for (int p = 0; p < i; p++){
                           mark = mark.Next;
                    }  
                    Route route = mark.Value;
                    String l = locations[end].getName();
                    if (route.routeInContainsLocation(l)) {
                        Boolean isValid = true;
                        if (tempRoutes.Contains(route.getRouteNumber()) || tempLocations.Contains(location.getName())) {
                            isValid = false;
                        }
                        if (isValid) {
                            LinkedList<String> routesClone = new LinkedList<String>();
                            foreach(String s in tempRoutes){
                                 routesClone.AddLast(s);
                            }
                           
                            routesClone.AddLast(route.getRouteNumber());

                            LinkedList<String> locationsClone = new LinkedList<String>();
                            foreach(String s in tempLocations){
                                 locationsClone.AddLast(s);
                            }
                            
                            locationsClone.AddLast(location.getName());
                           
                            findRoutes(start, end, end, routesClone, locationsClone, depth);

                        }
                    } else {

                        if (!tempRoutes.Contains(route.getRouteNumber()) && !tempLocations.Contains(location.getName())) {

                            LinkedList<String> routesClone = new LinkedList<String>();
                            foreach(String s in tempRoutes){
                                 routesClone.AddLast(s);
                            }

                            routesClone.AddLast(route.getRouteNumber());

                            LinkedList<String> locationsClone = new LinkedList<String>();
                            foreach(String s in tempLocations){
                                 locationsClone.AddLast(s);
                            }
                            
                            locationsClone.AddLast(location.getName());

                            Boolean isValid = true;

                            foreach (String previous in tempLocations) {

                                foreach (Route r in locations[previous].getRoutes()) {
                                    if (r.routeInContainsLocation(location) && !locations[previous].getName().Equals(start)) {
                                        isValid = false;
                                    }
                                    if (r.routeOutContainsLocation(location) && !locations[previous].getName().Equals(start)) {
                                        isValid = false;
                                    }
                                }
                                if (previous.Equals(location.getName())) {
                                    isValid = false;
                                }
                            }

                            if (isValid) {
                                foreach (Location loc in route.getRouteIn()) {
                                    findRoutes(start, loc.getName(), end, routesClone, locationsClone, depth - 1);
                                }

                                foreach (Location loc in route.getRouteOut()) {
                                    findRoutes(start, loc.getName(), end, routesClone, locationsClone, depth - 1);
                                }
                            }
                        }
                    }
                }
            }
        }
        }
    }
}

