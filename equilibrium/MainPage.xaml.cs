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

using kuntakinte;


namespace equilibrium
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Motion motion;
        private flightbox mflightbox;
        private btConManager mConManager;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //new bluetooth manager
            mConManager = new btConManager();
     


            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            if (!Motion.IsSupported)
            {
                MessageBox.Show("The motion API is not supported on this device.");
                return;
            }

            if (motion == null)
            {
                motion = new Motion();
                //motion.TimeBetweenUpdates = TimeSpan.FromMilliseconds(20);
                motion.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<MotionReading>>(motion_CurrentValueChanged);
            }

            try
            {
                motion.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("unable to start the Motion API.");
            }

            flightbox mflightbox = new flightbox(); // initialize a new flightbox
            
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

        void motion_CurrentValueChanged(object sender, SensorReadingEventArgs<MotionReading> e)
        {
            Dispatcher.BeginInvoke(() => CurrentValueChanged(e.SensorReading));
        }

        private void CurrentValueChanged(MotionReading e)
        {
            //check to see if motion data is valid.
            if (motion.IsDataValid)
            {
                //show numeric values for attitude
                yawTextBlock.Text = MathHelper.ToDegrees(e.Attitude.Yaw).ToString("0");
                pitchTextBlock.Text = MathHelper.ToDegrees(e.Attitude.Pitch).ToString("0");
                rollTextBlock.Text = MathHelper.ToDegrees(e.Attitude.Roll).ToString("0");
                

            }
        }

        private async void AppToDevice()
        {
            //configure peerfinder to search for all paired devices
            
        }
    }
}