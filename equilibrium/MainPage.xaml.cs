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

using Windows.Networking.Sockets;
using Windows.Networking.Proximity;



using Microsoft.Xna.Framework;
using equilibrium.Resources;

using Windows.System.Threading;
using Windows.Devices.Geolocation;

using BluetoothConnectionManager;
using kuntakinte;


namespace equilibrium
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        flightbox mflightbox;
        btConManager mConManager;

        float roll;
        float pitch;
        float yaw;

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
            PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";
            var pairedDevices = await PeerFinder.FindAllPeersAsync();

            if (pairedDevices.Count == 0)
            {

            }
            else
            {
                foreach (var pairedDevice in pairedDevices)
                {
                    if (pairedDevice.DisplayName == DeviceName.Text)
                    {
                        mConManager.Connect(pairedDevice.HostName);
                        ConnectAppToDeviceButton.Content = "Connected";
                        DeviceName.IsReadOnly = true;
                        ConnectAppToDeviceButton.IsEnabled = false;
                        continue;

                    }
                }
            }
        }

        void fb_inclineEvent(float[] data)
        {

            Dispatcher.BeginInvoke(() =>
            {
                roll = data[0];
                pitch = data[1];
                yaw = data[2];
                rollTextBlock.Text = roll.ToString();
                pitchTextBlock.Text = pitch.ToString();
                yawTextBlock.Text=yaw.ToString();

                

            });

            updateMotorDrive(roll);
            
        }


        private async void updateMotorDrive(float cmd)
        {
            await mConManager.SendCommand(cmd.ToString());
        }

        private void ConnectAppToDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            AppToDevice();
        }
    }
}