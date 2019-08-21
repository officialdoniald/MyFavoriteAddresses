using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Widget;
using MyFavoriteAddresses.Adapters;
using MyFavoriteAddresses.BLL.Helpers;
using MyFavoriteAddresses.BLL.Models;

namespace MyFavoriteAddresses.Views
{
    [Activity(Label = "MyFavoriteAddresses", MainLauncher = true)]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        #region Properties

        private Button _addAddressButton;
        private ListView _favddressListView;

        private List<BLL.Models.Places> _places;

        private readonly Places _place = new Places();

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.main_activity);

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);

            _places = _place.GetItems();

            _addAddressButton = FindViewById<Button>(Resource.Id.addAddressButton);

            _addAddressButton.Click += AddAddressButton_Click;

            _favddressListView = FindViewById<ListView>(Resource.Id.favoriteAddressesListView);

            _favddressListView.Adapter = new FavoriteAddressesAdapter(_places);
            
            GlobalVariables.GoogleApiKey = MyFavoriteAddresses.BLL.Properties.Resources.GoogleApiKey;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="googleMap"></param>
        public void OnMapReady(GoogleMap googleMap)
        {
            foreach (var item in _places)
            {
                MarkerOptions markerOpt = new MarkerOptions();
                markerOpt.SetPosition(new LatLng(item.Latitude, item.Longitude));
                markerOpt.SetTitle(item.Name);

                googleMap.AddMarker(markerOpt);
            }
        }
    }
}