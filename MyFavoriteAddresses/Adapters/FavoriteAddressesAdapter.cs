using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using MyFavoriteAddresses.BLL.Models;

namespace MyFavoriteAddresses.Adapters
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView Name { get; set; }
    }

    public class FavoriteAddressesAdapter : BaseAdapter<Places>
    {
        private readonly List<Places> _addresses;

        public override int Count => _addresses.Count;

        public override Places this[int position] => _addresses[position];

        public FavoriteAddressesAdapter(List<Places> addresses)
        {
            _addresses = addresses;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.favoriteaddresses_datatemplate, parent, false);

                var name = view.FindViewById<TextView>(Resource.Id.favoriteAddressTextView);

                view.Tag = new ViewHolder() { Name = name };
            }

            var holder = (ViewHolder)view.Tag;

            holder.Name.Text = _addresses[position].Name;

            return view;
        }
    }
}