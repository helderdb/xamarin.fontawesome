using System;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.FontAwesome.Controls;
using Xamarin.Forms.Platform.iOS;
using Xamarin.iOS.FontAwesome.Renderer;

[assembly: ExportRenderer(typeof(Icon), typeof(FontAwesomeIconRenderer))]
namespace Xamarin.iOS.FontAwesome.Renderer
{
    public class FontAwesomeIconRenderer : LabelRenderer
    {
        private string _brandsName;
        private string _regularName;
        private string _solidName;

        private readonly UIFont _brandsRegular;
        private readonly UIFont _freeRegular;
        private readonly UIFont _freeSolid;

        public FontAwesomeIconRenderer() : base()
        {
            foreach (var familyNames in UIFont.FamilyNames.OrderBy(c => c).ToList())
            {
                foreach (var familyName in UIFont.FontNamesForFamilyName(familyNames).OrderBy(c => c).ToList())
                {
                    if (familyName.Contains("FontAwesome") && familyName.Contains("Brands"))
                        _brandsName = familyName;
                    else if (familyName.Contains("FontAwesome") && familyName.Contains("Regular"))
                        _regularName = familyName;
                    else if (familyName.Contains("FontAwesome") && familyName.Contains("Solid"))
                        _solidName = familyName;
                }
            }
            _brandsRegular = UIFont.FromName(_brandsName, 16);
            _freeRegular = UIFont.FromName(_regularName, 16);
            _freeSolid = UIFont.FromName(_solidName, 16);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var icon = e.NewElement as Icon;
                if (Math.Abs(icon.FontSize) <= 0)
                    icon.FontSize = 16;

                if (icon != null && icon.FaStyle != FaStyles.None)
                {
                    switch (icon.FaStyle)
                    {
                        case FaStyles.Solid:
                            Control.Font = _freeSolid.WithSize((nfloat)icon.FontSize);
                            break;
                        case FaStyles.Regular:
                            Control.Font = _freeRegular.WithSize((nfloat)icon.FontSize);
                            break;
                        case FaStyles.Brands:
                            Control.Font = _brandsRegular.WithSize((nfloat)icon.FontSize);
                            break;
                    }
                }
            }
        }
    }
}
