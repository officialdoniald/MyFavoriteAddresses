﻿using System;
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
    [Activity(Label = "AddAddressActivity")]
    public class AddAddressActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.addaddress_activity);

        }
        //GoogleApiKey AIzaSyBbw1oWrCKjTnoM2vKt2qiDtp9N8GpqFDI
        private void SerachForAddress()
        {
            //var settings = GoogleApiSettings.Builder
            //                                .WithApiKey("api_key")
            //                                .WithLanguage("nl")
            //                                .WithType(PlaceTypes.Address)
            //                                .WithLogger(new ConsoleLogger())
            //                                .AddCountry("nl")
            //                                .Build();
        }
    }
}