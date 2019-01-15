// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;

namespace SideMenuSample.iOS.Views.Cells
{
    [Register ("MenuCell")]
    partial class MenuCell
    {
        [Outlet]
        UIKit.UIImageView MenuIcon { get; set; }


        [Outlet]
        UIKit.UILabel TitleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MenuIcon != null) {
                MenuIcon.Dispose ();
                MenuIcon = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }
        }
    }
}