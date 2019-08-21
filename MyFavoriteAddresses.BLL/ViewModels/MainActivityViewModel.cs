using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyFavoriteAddresses.BLL.Models;
using System.Threading.Tasks;

namespace MyFavoriteAddresses.BLL.ViewModels
{
    public class MainActivityViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MvxObservableCollection<Places> Places = new MvxObservableCollection<Places>();

        public MainActivityViewModel(IMvxNavigationService mvxNavigationService)
        {
            _navigationService = mvxNavigationService;

            Places = new MvxObservableCollection<Places>(new Places().GetItems());
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        public IMvxCommand AddAddressCommand => new MvxAsyncCommand(() => _navigationService.Navigate<AddAddressActivityViewModel>());
    }
}