/*
 * Hoang Pham
 * 4/2/2014
 * window phone controlled quad
 * 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices.Sensors;

using Microsoft.Xna.Framework;
using equilibrium.Resources;

using Windows.System.Threading;
using Windows.Devices.Geolocation;


using kuntakinte;


namespace equilibrium
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        flightbox mflightbox;
        btConManager mConManager;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //new bluetooth manager
            mConManager = new btConManager();
     
            mflightbox = new flightbox(); // initialize a new flightbox


            mflightbox.inclineEvent += fb_inclineEvent;
            
        }
        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        

     
        private async void AppToDevice()
        {
            //configure peerfinder to search for all paired devices
            
        }

        void fb_inclineEvent(float[] data)
        {

            Dispatcher.BeginInvoke(() =>
            {
                rollTextBlock.Text = data[0].ToString();
                pitchTextBlock.Text = data[1].ToString();
                yawTextBlock.Text=data[2].ToString();

            });
            
        }
    }
}