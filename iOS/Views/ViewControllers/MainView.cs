using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.iOS.Views;
using SideMenuSample.ViewModels;
using UIKit;

namespace SideMenuSample.iOS.Views.ViewControllers
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public class MainView : MvxViewController<MainViewModel>
    {
        public MainView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.View.BackgroundColor = UIColor.White;

            ViewModel.ShowMenu();
        }
    }
}
