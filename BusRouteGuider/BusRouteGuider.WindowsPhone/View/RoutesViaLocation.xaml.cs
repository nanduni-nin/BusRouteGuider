﻿using System;
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
using System.Diagnostics;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.UI.Popups;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusRouteGuider
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RoutesViaLocation : Page
    {
        Dictionary<String, Location> dic;
        BusRouteGuider.ViewModel.Algorithm process;

        public RoutesViaLocation()
        {
            //Navigation achieved
            Debug.WriteLine("Buses at a location reached");
            //Create the GUI
            this.InitializeComponent();
            //Set functionality for the phone's back buttons
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            //Create an object from Algorithm Class
            process = new ViewModel.Algorithm();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Dictionary<String, Location> dic = e.Parameter as Dictionary<String, Location>;
            Debug.WriteLine("**********************on navigated to got called");
            this.dic = dic;
            this.fillCombo(dic);
        }

        //Fill the combo boxes for location
        private void fillCombo(Dictionary<String, Location> dic)
        {
            //Clear items of the combo lists for clearing any buffers
            textLoc.Items.Clear();
           
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
                textLoc.Items.Add(key);
            }
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

        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            //return to main page
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Validating empty text box
            if (textLoc.Text == null)
            {
                MessageDialog msgbox = new MessageDialog("Please fill the fields.","Error");
                await msgbox.ShowAsync();
                return;
            }
           
             Boolean txt = false;

             //Validating if destination user input town is available in the data file
             foreach (String key in dic.Keys)
             {
                 //Check if start location user input is correct
                 if (key.Equals(textLoc.Text))
                 {
                   txt = true;
                   break;
                 }
             }
            //Warn the user
             if (txt == false)
             {
                 MessageDialog msgbox = new MessageDialog("Sorry this location is not available.", "ERROR");
                 await msgbox.ShowAsync();
                 return;
            
            }
            else{
                process.getBusNumbers(textLoc.Text.ToString(), dic);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //return to main page
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Help_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(Help));
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                // Set a threshold when to start looking for suggestions
                if (sender.Text.Length >= 1)
                {
                    sender.ItemsSource = getSuggestions(sender.Text);
                }
                else
                {
                    sender.ItemsSource = new List<String> { };
                }
            }
        }

        private object getSuggestions(string p)
        {
            //The list of suggestions to display on text box
            List<String> suggestions = new List<string>();

            //The list of the combo box should appear in alphabetical order
            SortedSet<string> keySet = new SortedSet<string>();

            //Add elements from dictionary into the sorted set which conains elements in alphebetical order
            foreach (String key in dic.Keys)
            {
                keySet.Add(key);
            }

            //Add elements from dictionary into the sorted set which conains elements in alphebetical order
            foreach (String key in keySet)
            {
                //Both user entered string and string to be suggested are converted to lowecase for comparison
                String entered = p.ToLower();
                String suggested = key.ToLower();

                //check if user entered text is availble in the suggestions List
                if (suggested.StartsWith(entered))
                {
                    suggestions.Add(key);
                }
            }

            return suggestions;
        }

        private void Map_ItemClick(object sender, ItemClickEventArgs e)
        {
            //return to main page
            this.Frame.Navigate(typeof(Map));
        }

    }
}
