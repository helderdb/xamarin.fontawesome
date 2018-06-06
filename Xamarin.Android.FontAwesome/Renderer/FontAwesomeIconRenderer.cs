using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Android.FontAwesome.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.FontAwesome.Controls;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Icon), typeof(FontAwesomeIconRenderer))]

namespace Xamarin.Android.FontAwesome.Renderer
{
    public class FontAwesomeIconRenderer : LabelRenderer
    {
        private readonly Typeface _brandsRegular;
        private readonly Typeface _freeRegular;
        private readonly Typeface _freeSolid;

        public FontAwesomeIconRenderer(Context ctx) : base(ctx)
        {
            _brandsRegular = Typeface.CreateFromAsset(ctx.Assets, "FABrandsRegular.otf");
            _freeRegular = Typeface.CreateFromAsset(ctx.Assets, "FAFreeRegular.otf");
            _freeSolid = Typeface.CreateFromAsset(ctx.Assets, "FAFreeSolid.otf");
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var icon = e.NewElement as Icon;
                if (icon != null && icon.FaStyle != FaStyles.None)
                {
                    switch (icon.FaStyle)
                    {
                        case FaStyles.Solid:
                            Control.Typeface = _freeSolid;
                            break;
                        case FaStyles.Regular:
                            Control.Typeface = _freeRegular;
                            break;
                        case FaStyles.Brands:
                            Control.Typeface = _brandsRegular;
                            break;
                    }
                }
            }
        }
    }
}