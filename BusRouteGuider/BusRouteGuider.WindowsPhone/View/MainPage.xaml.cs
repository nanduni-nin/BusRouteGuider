using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BusRouteGuider
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Loaded data from the data file are stored in a dictionary
        Dictionary<String, Location> dic;
        Dictionary<String, Route> routes;

        public MainPage()
        {
            //Create the layout for GUI
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            //Create an object of SearchRoute class
            BusRouteGuider.ViewModel.SearchRoute processor = new ViewModel.SearchRoute();
            //Get the dictionary of Location objects
            dic = processor.getAllLocations();
            //Get the dictionary of Route objects
            routes = processor.getAllRoutes();
        }
        
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>

        private void StartToDestination_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            this.Frame.Navigate(typeof(StartToDestination),dic);
        }

        private void CurrentLocationToDestination_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(CurrentLocationToDestination),dic);
        }

        private void BusesAtCurrentLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(RoutesViaLocation),dic);
        }

        private void AllRoutes_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(ShowRoutes),routes);
        }

        private void Help_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(Help));
        }

        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(Map));
        }
       

        

       
        
    }
}
