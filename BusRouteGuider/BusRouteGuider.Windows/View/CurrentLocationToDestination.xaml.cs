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
using System.Diagnostics;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BusRouteGuider
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrentLocationToDestination : Page
    {
        Dictionary<String, Location> dic;
        BusRouteGuider.ViewModel.Algorithm process;

        public CurrentLocationToDestination()
        {
            //Navigation achieved
            Debug.WriteLine("Start to destination reached");
            //Create the GUI
            this.InitializeComponent();
            //Create an object from Algorithm Class
            process = new ViewModel.Algorithm();
        }

        //Fill the combo boxes for start location and destination
        private void fillCombo(Dictionary<String, Location> dic)
        {
            //Clear items of the combo lists for clearing any buffers
            comboStart.Items.Clear();
           

            //The list of the combo box should appear in alphabetical order
            SortedSet<string> keySet = new SortedSet<string>();

            //Add elements from dictionary into the sorted set which conains elements in alphebetical order
            foreach (String key in dic.Keys)
            {
                keySet.Add(key);
            }

            //Fill the combo boxes
            foreach (String key in keySet)
            {
                comboStart.Items.Add(key);
            }
            Debug.WriteLine("Combo filled");

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Dictionary<String, Location> dic = e.Parameter as Dictionary<String, Location>;
            Debug.WriteLine("**********************on navigated to got called");
            this.dic = dic;
            this.fillCombo(dic);
        }
       
        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void TxtBlckMap_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Map));
        }

        private void TxtBlckHelp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Help));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (comboStart.SelectedItem.ToString() == null)
            {
                MessageDialog msgbox = new MessageDialog("Please add the destination.", "ERROR");
                await msgbox.ShowAsync();
                return;
            }
            else
            {
                process.getRoutes("Moratuwa Campus", comboStart.SelectedItem.ToString(), dic, false);
            }
        }

    }
}
