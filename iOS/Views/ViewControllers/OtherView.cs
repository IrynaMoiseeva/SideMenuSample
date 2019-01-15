using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.iOS.Views;
using SideMenuSample.ViewModels;

namespace SideMenuSample.iOS.Views.ViewControllers
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false, MvxSplitViewBehaviour.Master)]
    public partial class OtherView : MvxViewController<OtherViewModel>
    {
        public OtherView() : base("OtherView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            Title = "Some screen";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

