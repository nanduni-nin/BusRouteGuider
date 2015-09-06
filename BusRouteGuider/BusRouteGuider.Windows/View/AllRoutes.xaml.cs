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
    public sealed partial class AllRoutes : Page
    {
        public AllRoutes()
        {
            //Navigation achieved
            Debug.WriteLine("Show routes reached");
            //Create the GUI
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Dictionary<String, Route> dic = e.Parameter as Dictionary<String, Route>;
            Debug.WriteLine("**********************on navigated to got called");
            this.fillList(dic);
        }

        //Fill the list box from the data from the data file
        private void fillList(Dictionary<String, Route> dic)
        {
            foreach (String s in dic.Keys)
            {
                String detail = s + " | " + dic[s].getPath();
                ListRoutes.Items.Add(detail);
            }
            Debug.WriteLine("List filled");
        }

       
        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void TxtBlckHelp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Help));
        }

        private void TxtBlckMap_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Map));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
    }
}
