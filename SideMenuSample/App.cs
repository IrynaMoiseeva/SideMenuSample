using MvvmCross.Core.ViewModels;
using SideMenuSample.ViewModels;

namespace SideMenuSample
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}