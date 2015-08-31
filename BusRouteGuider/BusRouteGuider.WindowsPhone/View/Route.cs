using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BusRouteGuider.View
{
    public class Route
    {
        
        private String routeNumber;
        private LinkedList<Location> routeIn, routeOut;

        public Route(String routeNumber) {
            this.routeNumber = routeNumber;
            routeIn = new LinkedList<Location>();
            routeOut = new LinkedList<Location>();
        }

        public void setRouteNumber(String routeNumber) {
            this.routeNumber = routeNumber;
        }

        public String getRouteNumber() {
            return routeNumber;
        }

        public String getPath() { 
            String s = "";
            foreach(Location loc in routeIn){
                s = s + loc.getName() + "->" ;
            }
            return s;
        }

        public void addLocationToRouteIn(Location location) {
            routeIn.AddLast(location);
            location.addRoute(this);
        }

        public LinkedList<Location> getRouteIn() {
            return routeIn;
        }

        public void addLocationToRouteOut(Location location) {
            routeOut.AddLast(location);
            location.addRoute(this);
        }

        public LinkedList<Location> getRouteOut() {
            return routeOut;
        }

        public Boolean routeInContainsLocation(String location) {
            foreach (Location loc in routeIn) {
                if (loc.getName().Equals(location)) {
                    return true;
                }
            }
            return false;
        }

        public LinkedListNode<Location> getRouteInStartLocation() {
            return routeIn.First;
        }

        public LinkedListNode<Location> getRouteInEndLocation(){
            return routeIn.First;
        }

        public LinkedListNode<Location> getRouteOutStartLocation(){
            return routeOut.First;
        }

        public LinkedListNode<Location> getRouteOutEndLocation(){
            return routeOut.Last;
        }
         

        public Boolean routeInContainsLocation(Location location) {

            foreach (Location loc in routeIn) {
                if (loc.getName().Equals(location.getName())) {
                    return true;
                }
            }
            return false;
        }

        public Boolean routeOutContainsLocation(Location location) {

            foreach (Location loc in routeOut) {
                if (loc.getName().Equals(location.getName())) {
                    return true;
                }
            }
            return false;
        }

       
       /* public String toString() {

            String route = "Route In : ";

            for (int i = 0; i < routeIn.Count; i++) {
                route = route + routeIn.F);
                if (i != routeIn.Count - 1) {
                    route = route + " -> ";
                }
            }
        
            route = route + "\nRoute Out: ";
        
            for (int i = 0; i < routeOut.Count; i++) {
                route = route + routeOut.get(i);
                if (i != routeOut.Count - 1) {
                    route = route + " -> ";
                }
            }
        
            return route;
        
        }
        */
    
        /*public void printData(){          
            Debug.WriteLine(this.toString());
        }
         */
        
    }
}
