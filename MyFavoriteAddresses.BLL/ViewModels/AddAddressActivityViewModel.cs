using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace MyFavoriteAddresses.BLL.ViewModels
{
    public class AddAddressActivityViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public AddAddressActivityViewModel(IMvxNavigationService mvxNavigationService)
        {
            _navigationService = mvxNavigationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        /// <summary>
        /// If the address already selected, go back to MainActivity.
        /// </summary>
        public void Ready()
        {
            _navigationService.Navigate<MainActivityViewModel>();
        }
    }
}