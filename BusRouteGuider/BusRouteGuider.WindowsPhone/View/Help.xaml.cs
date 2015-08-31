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
using System.Diagnostics;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusRouteGuider
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Help : Page
    {
        public Help()
        {
            //Navigation achieved
            Debug.WriteLine("Help reached");
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
            this.popUpStartToDest.IsOpen = false;
            this.popUpCurrentToDest.IsOpen = false;
            this.popUpAllRoutes.IsOpen = false;
            this.popUpBusesAtLocation.IsOpen = false;
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

        private void rdBtnStartDest_Click(object sender, RoutedEventArgs e)
        {
            this.popUpStartToDest.IsOpen = true;
            this.popUpCurrentToDest.IsOpen = false;
            this.popUpAllRoutes.IsOpen = false;
            this.popUpBusesAtLocation.IsOpen = false;
        }

        private void rdBtnCurrentDest_Click(object sender, RoutedEventArgs e)
        {
            this.popUpCurrentToDest.IsOpen = true;
            this.popUpAllRoutes.IsOpen = false;
            this.popUpBusesAtLocation.IsOpen = false;
            this.popUpStartToDest.IsOpen = false;
        }

        private void rdBtnAllRoutes_Click(object sender, RoutedEventArgs e)
        {
            this.popUpAllRoutes.IsOpen = true;
            this.popUpStartToDest.IsOpen = false;
            this.popUpCurrentToDest.IsOpen = false;
            this.popUpBusesAtLocation.IsOpen = false;
        }

        private void rdBtnBusesAtLocation_Click(object sender, RoutedEventArgs e)
        {
            this.popUpBusesAtLocation.IsOpen = true;
            this.popUpAllRoutes.IsOpen = false;
            this.popUpStartToDest.IsOpen = false;
            this.popUpCurrentToDest.IsOpen = false;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Help));
        }

        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }

       

        private void Map_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(Map));

        }

    }
}
