using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using System.Diagnostics;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusRouteGuider
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Map : Page
    {
        public Map()
        {
            //Navigation achieved
            Debug.WriteLine("Map reached");
            //Create the GUI
            this.InitializeComponent();
            //Set functionality for the phone's back buttons
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private async void setPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator();
            if (geolocator.LocationStatus == PositionStatus.Disabled) {
                MessageDialog msgbox = new MessageDialog("Turn GPS ON", "ERROR");
                await msgbox.ShowAsync();
                return;
            }

            geolocator.DesiredAccuracyInMeters = 50;
           
            //Get the gps coordinates of current location
            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                     maximumAge: TimeSpan.FromMinutes(5),
                     timeout: TimeSpan.FromSeconds(10)
                    );

                var myPosition = new Windows.Devices.Geolocation.BasicGeoposition();
                myPosition.Latitude = geoposition.Coordinate.Latitude;
                myPosition.Longitude = geoposition.Coordinate.Longitude;

                var myPoint = new Windows.Devices.Geolocation.Geopoint(myPosition);
                if (await MyMap.TrySetViewAsync(myPoint, 10D))
                {
                    // Haven't really thought that through!
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }        

            
        }

        //Provides zooming effect
        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (MyMap != null)
                MyMap.ZoomLevel = e.NewValue;
        }

        //Set the functionality for the phone's back button to move one page back
        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null && rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                e.Handled = true;
            }
        }
    }
}
