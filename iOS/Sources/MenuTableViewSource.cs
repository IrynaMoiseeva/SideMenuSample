using Foundation;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using SideMenuSample.iOS.Views.Cells;
using SideMenuSample.ViewModels;
using UIKit;

namespace SideMenuSample.iOS.Sources
{
    public class MenuTableViewSource : MvxTableViewSource
    {
        public MvxCommand<string> NavigateOtherViewModel;

        public MenuTableViewSource(UITableView tableView)
                    : base(tableView)
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
                return tableView.DequeueReusableCell(MenuCell.Key, indexPath) as MenuCell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var item = (MenuFeedtemViewModel)ItemsSource.ElementAt(indexPath.Row);

            NavigateOtherViewModel.Execute(item.Id);
        }
    }
}