using MvvmCross;
using MvvmCross.ViewModels;
using MyFavoriteAddresses.BLL.ViewModels;

namespace MyFavoriteAddresses.BLL
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //Mvx.IoCProvider.RegisterType<ICalculationService, CalculationService>();

            RegisterAppStart<MainActivityViewModel>();
        }
    }
}