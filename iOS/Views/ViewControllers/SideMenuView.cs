using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using SideMenuSample.iOS.Common;
using SideMenuSample.iOS.Sources;
using SideMenuSample.iOS.Views.Cells;
using SideMenuSample.iOS.Views.ViewControllers.Abstract;
using SideMenuSample.ViewModels;
using UIKit;

namespace SideMenuSample.iOS.Views.ViewControllers
{
    [MvxSidebarPresentation(MvxPanelEnum.Right, MvxPanelHintType.PushPanel, false)]
    public partial class SideMenuView : BaseMenuViewController<SideMenuViewModel>
    {
        private MenuTableViewSource source;

        public SideMenuView() : base("SideMenuView", null)
        {
        }

        public override UIImage MenuButtonImage => UIImage.FromBundle(Images.HamburgerBlack).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupTableView();
            SetStyles();
            DoBind();
        }

        private void SetStyles()
        {
            MenuTableView.SeparatorColor = UIColor.FromRGBA(187, 187, 187, 0.1f);
        }

        private void SetupTableView()
        {
            var tableView = MenuTableView;
            source = new MenuTableViewSource(tableView);
            tableView.Source = source;
            source.NavigateOtherViewModel = ViewModel.NavigateOtherViewModel;
            tableView.RowHeight = UITableView.AutomaticDimension;
            tableView.TableFooterView = new UIView(CGRect.Empty);
            tableView.AlwaysBounceVertical = false;

            tableView.RegisterNibForCellReuse(MenuCell.Nib, MenuCell.Key);
        }

        protected void DoBind()
        {
            var bindingSet = this.CreateBindingSet<SideMenuView, SideMenuViewModel>();

            bindingSet.Bind(source).For(v => v.ItemsSource).To(vm => vm.ItemsCollection);

            bindingSet.Apply();
        }
    }
}