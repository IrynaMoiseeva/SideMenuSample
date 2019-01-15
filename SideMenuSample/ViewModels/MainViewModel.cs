using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace SideMenuSample.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public void ShowMenu()
        {
            navigationService.Navigate<SideMenuViewModel>();
        }
    }
}