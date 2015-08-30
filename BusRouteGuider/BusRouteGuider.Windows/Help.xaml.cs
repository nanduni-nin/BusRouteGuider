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
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

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
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.popUpStartToDest.IsOpen = false;
            this.popUpCurrentToDest.IsOpen = false;
            this.popUpAllRoutes.IsOpen = false;
            this.popUpBusesAtLocation.IsOpen = false;
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
    }
}
