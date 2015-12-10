﻿using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace $safeprojectname$
{
    /// <summary>
    /// A page with a container visual having a solid color background.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Compositor compositor;
        private ContainerVisual root;
        private SpriteVisual background;
        private SpriteVisual target;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void UpdateSize()
        {
            if (this.background != null && this.Host != null) {
                this.background.Size = new Vector2((float)this.Host.ActualWidth, (float)this.Host.ActualHeight);
            }
        }

        private void Host_Loaded(object sender, RoutedEventArgs e)
        {
            var visual = ElementCompositionPreview.GetElementVisual(this.Host);
            this.compositor = visual.Compositor;

            // create root container
            this.root = this.compositor.CreateContainerVisual();
            ElementCompositionPreview.SetElementChildVisual(this.Host, this.root);

            // create background
            this.background = this.compositor.CreateSpriteVisual();
            this.background.Brush = this.compositor.CreateColorBrush(Colors.LightGreen);
            this.root.Children.InsertAtBottom(this.background);

            // create green square
            var colorVisual = this.compositor.CreateSpriteVisual();
            colorVisual.Brush = this.compositor.CreateColorBrush(Colors.Green);
            colorVisual.Size = new Vector2(150.0f, 150.0f);
            colorVisual.Offset = new Vector3(250.0f, 250.0f, 0.0f);
            colorVisual.CenterPoint = new Vector3(75.0f, 75.0f, 0.0f);
            this.target = colorVisual;
            this.root.Children.InsertAtTop(this.target);

            // animate square
            Animate(this.target);

            UpdateSize();
        }

        private void Animate(Visual visual)
        {
            var easing = this.compositor.CreateCubicBezierEasingFunction(new Vector2(.5f, .1f), new Vector2(.5f, .75f));
            var animation = this.compositor.CreateScalarKeyFrameAnimation();

            animation.InsertKeyFrame(0.00f, 0.00f, easing);
            animation.InsertKeyFrame(1.00f, 360.0f, easing);

            animation.Duration = TimeSpan.FromMilliseconds(2000);
            animation.IterationBehavior = AnimationIterationBehavior.Forever;

            visual.StartAnimation("RotationAngleinDegrees", animation);
        }

        private void Host_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateSize();
        }
    }
}