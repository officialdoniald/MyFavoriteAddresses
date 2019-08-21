using System.Collections.Generic;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using MyFavoriteAddresses.Adapters;
using MyFavoriteAddresses.BLL.Helpers;
using MyFavoriteAddresses.BLL.Models;
using MyFavoriteAddresses.BLL.ViewModels;

namespace MyFavoriteAddresses.Views
{
    [Activity(Label = "MyFavoriteAddresses", MainLauncher = true)]
    public class MainActivity : MvxActivity<MainActivityViewModel>, IOnMapReadyCallback
    {
        #region Properties

        private Button _addAddressButton;
        private ListView _favddressListView;

        private readonly Places _place = new Places();

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.main_activity);

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);

            _addAddressButton = FindViewById<Button>(Resource.Id.addAddressButton);

            _favddressListView = FindViewById<ListView>(Resource.Id.favoriteAddressesListView);

            _favddressListView.Adapter = new FavoriteAddressesAdapter(ViewModel.Places);
            
            GlobalVariables.GoogleApiKey = MyFavoriteAddresses.BLL.Properties.Resources.GoogleApiKey;
        }
        
        /// <summary>
        /// What happen when the maps already rendered.
        /// </summary>
        /// <param name="googleMap"></param>
        public void OnMapReady(GoogleMap googleMap)
        {
            foreach (var item in ViewModel.Places)
            {
                MarkerOptions markerOpt = new MarkerOptions();
                markerOpt.SetPosition(new LatLng(item.Latitude, item.Longitude));
                markerOpt.SetTitle(item.Name);

                googleMap.AddMarker(markerOpt);
            }
        }
    }
}