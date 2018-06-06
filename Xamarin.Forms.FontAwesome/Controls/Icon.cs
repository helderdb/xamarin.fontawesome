namespace Xamarin.Forms.FontAwesome.Controls
{
    public class Icon : Label
    {
        public static readonly BindableProperty FaStyleProperty = BindableProperty.Create(
            "FaStyle", typeof(FaStyles), typeof(Icon), FaStyles.None, propertyChanged: updateIcon);

        public FaStyles FaStyle
        {
            get { return (FaStyles)base.GetValue(FaStyleProperty); }
            set { base.SetValue(FaStyleProperty, value); }
        }

        public static readonly BindableProperty FaNameProperty = BindableProperty.Create(
            "FaName", typeof(string), typeof(Icon), null, propertyChanged: updateIcon);

        public string FaName
        {
            get { return (string)base.GetValue(FaNameProperty); }
            set { base.SetValue(FaNameProperty, value); }
        }

        private static void updateIcon(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (Icon)bindable;

            ctrl.Text = null;

            if (string.IsNullOrWhiteSpace(ctrl.FaName))
                return;

            var style = ctrl.FaStyle;

            if (style == FaStyles.None)
            {
                if (FaLookup.Regular.ContainsKey(ctrl.FaName))
                    style = FaStyles.Regular;
                else if (FaLookup.Solid.ContainsKey(ctrl.FaName))
                    style = FaStyles.Solid;
                else if (FaLookup.Brands.ContainsKey(ctrl.FaName))
                    style = FaStyles.Brands;
            }

            if (style != ctrl.FaStyle)
            {
                ctrl.FaStyle = style;
                return;
            }

            if (style == FaStyles.Solid)
            {
                if (FaLookup.Solid.ContainsKey(ctrl.FaName))
                    ctrl.Text = FaLookup.Solid[ctrl.FaName].ToString();
            }
            else if (style == FaStyles.Regular)
            {
                if (FaLookup.Regular.ContainsKey(ctrl.FaName))
                    ctrl.Text = FaLookup.Regular[ctrl.FaName].ToString();
            }
            else if (style == FaStyles.Brands)
            {
                if (FaLookup.Brands.ContainsKey(ctrl.FaName))
                    ctrl.Text = FaLookup.Brands[ctrl.FaName].ToString();
            }
        }
    }
}
