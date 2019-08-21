using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Google.Places;
using Java.Lang;
using MvvmCross.Platforms.Android.Views;
using MyFavoriteAddresses.BLL.Helpers;
using MyFavoriteAddresses.BLL.Models;
using MyFavoriteAddresses.BLL.ViewModels;

namespace MyFavoriteAddresses.Views
{
    [Activity(Label = "AddAddressActivity")]
    public class AddAddressActivity : MvxActivity<AddAddressActivityViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.addaddress_activity);

            if (!PlacesApi.IsInitialized)
            {
                PlacesApi.Initialize(this, GlobalVariables.GoogleApiKey);
            }

            List<Place.Field> fields = new List<Place.Field>
            {
                Place.Field.Id,
                Place.Field.Name,
                Place.Field.LatLng,
                Place.Field.Address
            };

            Intent intent = new Autocomplete.IntentBuilder(AutocompleteActivityMode.Overlay, fields)
                .SetCountry("US")
                .SetCountry("UK")
                .Build(this);

            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            try
            {
                var place = Autocomplete.GetPlaceFromIntent(data);

                Places places = new Places();

                places.StorePlace(
                    place.Name,
                    place.LatLng.Longitude,
                    place.LatLng.Latitude);
            }
            catch (IllegalArgumentException)
            {
                //TODO Log
            }

            ViewModel.Ready();
        }
    }
}