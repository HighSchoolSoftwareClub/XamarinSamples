using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using RadialProgressExample.Droid.Renderers;
using RadialProgressExample.Controls;
using Xamarin.Forms.Platform.Android;
using RadialProgress;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(RadialProgressControl), typeof(RadialProgressControlRenderer))]
namespace RadialProgressExample.Droid.Renderers
{
    public class RadialProgressControlRenderer : ViewRenderer<RadialProgressControl, RadialProgressView>
    {
        RadialProgressView progressView;
        public RadialProgressControlRenderer()
        {
            progressView = new RadialProgressView(Forms.Context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<RadialProgressControl> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= Element_PropertyChanged;

            if (this.Element != null)
                this.Element.PropertyChanged += Element_PropertyChanged;

            var element = (RadialProgressControl)Element;

            progressView.Value = element.Value;
            progressView.MaxValue = element.Maximum;
            progressView.MinValue = element.Minimum;
            progressView.LabelHidden = element.LabelHidden;
            progressView.ProgressColor = element.ProgressColor.ToAndroid();

            SetNativeControl(progressView);
        }

        private void Element_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == RadialProgressControl.MaximumProperty.PropertyName)
            {
                progressView.MaxValue = Element.Maximum;
            }
            else if (e.PropertyName == RadialProgressControl.MinimumProperty.PropertyName)
            {
                progressView.MinValue = Element.Minimum;
            }
            else if (e.PropertyName == RadialProgressControl.ValueProperty.PropertyName)
            {
                progressView.Value = Element.Value;
            }
            else if (e.PropertyName == RadialProgressControl.LabelHiddenProperty.PropertyName)
            {
                progressView.LabelHidden = Element.LabelHidden;
            }
            else if (e.PropertyName == RadialProgressControl.ProgressColorProperty.PropertyName)
            {
                progressView.ProgressColor = Element.ProgressColor.ToAndroid();
            }
        }
    }
}