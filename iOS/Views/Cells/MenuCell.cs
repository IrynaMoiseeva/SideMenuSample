using System;
using UIKit;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using SideMenuSample.ViewModels;

namespace SideMenuSample.iOS.Views.Cells
{
    public partial class MenuCell : MvxTableViewCell
    {
        public const string NibName = "MenuCell";

        public static readonly NSString Key = new NSString(NibName);
        public static readonly UINib Nib;

        static MenuCell()
        {
            Nib = UINib.FromName(NibName, NSBundle.MainBundle);
        }

        protected MenuCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public static MenuCell Create()
        {
            return (MenuCell)Nib.Instantiate(null, null)[0];
        }

        public UILabel MenuTitleLabel => TitleLabel;

        public UIImageView MenuImageView => MenuIcon;

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            DoBind();
            SetStyles();
        }

        protected void DoBind()
        {
            var bindingSet = this.CreateBindingSet<MenuCell, MenuFeedtemViewModel>();
            bindingSet.Bind(TitleLabel).To(vm => vm.Title);
            bindingSet.Apply();
        }

        protected void SetStyles()
        {
            this.SelectionStyle = UITableViewCellSelectionStyle.Default;
        }
    }
}