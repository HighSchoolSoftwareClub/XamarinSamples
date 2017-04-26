using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using RadialProgressExample.Controls;
using RadialProgressExample.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using RadialProgress;

[assembly: ExportRenderer(typeof(RadialProgressControl),typeof(RadialProgressControlRenderer))]
namespace RadialProgressExample.iOS.Renderers
{
    public class RadialProgressControlRenderer : ViewRenderer<RadialProgressControl,RadialProgressView>
    {
        RadialProgressView progressView;
        public RadialProgressControlRenderer()
        {
            progressView = new RadialProgressView();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<RadialProgressControl> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= Element_PropertyChanged;

            if (this.Element != null)
                this.Element.PropertyChanged += Element_PropertyChanged; ;

            var element = (RadialProgressControl)Element;

            progressView.Value = element.Value;
            progressView.MaxValue = element.Maximum;
            progressView.MinValue = element.Minimum;
            progressView.LabelHidden = element.LabelHidden;
            progressView.ProgressColor = element.ProgressColor.ToUIColor();

            SetNativeControl(progressView);
        }

        private void Element_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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