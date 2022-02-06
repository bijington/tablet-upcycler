using System;
using System.Collections.Generic;
using System.Diagnostics;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace dashy.Widgets
{
    public partial class DraggableOverlayView : ContentView
    {
        private SKPoint mouseDown;

        public DraggableOverlayView()
        {
            InitializeComponent();
        }

        void SKCanvasView_Touch(object sender, SKTouchEventArgs e)
        {
            Debug.WriteLine($"Touch = {e.ActionType}");
            switch (e.ActionType)
            {
                case SKTouchAction.Entered:
                    this.HandleMovement(e.Location);
                    break;
                case SKTouchAction.Pressed:
                    this.HandlePress(e.Location);
                    break;
                case SKTouchAction.Moved:
                    this.HandleMovement(e.Location);
                    break;
                case SKTouchAction.Released:
                    //this.HandleRelease(e.Location);
                    break;
                case SKTouchAction.Cancelled:
                    //this.HandleRelease(e.Location);
                    break;
                case SKTouchAction.Exited:
                    break;
                case SKTouchAction.WheelChanged:
                    break;
            }

            e.Handled = true;
        }

        private void HandlePress(SKPoint location)
        {
            this.mouseDown = location;
        }

        private void HandleMovement(SKPoint location)
        {
            var density = DeviceDisplay.MainDisplayInfo.Density;

            ((VisualElement)this.Parent).TranslationX += (location.X - this.mouseDown.X) / density;
            ((VisualElement)this.Parent).TranslationY += (location.Y - this.mouseDown.Y) / density;
        }
    }
}
