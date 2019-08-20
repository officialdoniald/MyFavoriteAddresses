using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyFavoriteAddresses.Views
{
    [Activity(Label = "MyFavoriteAddresses", MainLauncher = true)]
    public class MainActivity : Activity
    {
        #region Properties

        private Button _addAddressButton;

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.main_activity);

            _addAddressButton = FindViewById<Button>(Resource.Id.addAddressButton);

            _addAddressButton.Click += AddAddressButton_Click;
        }

        /// <summary>
        /// Navigate to the AddAddressActivity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAddressButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(AddAddressActivity)));
        }
    }
}