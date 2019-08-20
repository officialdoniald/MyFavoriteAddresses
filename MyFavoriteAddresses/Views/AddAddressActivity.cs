using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Google.Places;

namespace MyFavoriteAddresses.Views
{
    [Activity(Label = "AddAddressActivity")]
    public class AddAddressActivity : Activity
    {
        private DatabaseConnection _databaseConnection;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.addaddress_activity);

            _databaseConnection = new DatabaseConnection();

            if (!PlacesApi.IsInitialized)
            {
                PlacesApi.Initialize(this, "AIzaSyBbw1oWrCKjTnoM2vKt2qiDtp9N8GpqFDI");
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
                .Build(this);

            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            _databaseConnection.StoreAddress(Autocomplete.GetPlaceFromIntent(data));

            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }
}