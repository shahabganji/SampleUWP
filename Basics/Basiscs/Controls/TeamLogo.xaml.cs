﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing.OptionDetails;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace App1.Controls
{
    public sealed partial class TeamLogo : UserControl
    {
        public TeamLogo()
        {
            this.InitializeComponent();
        }

        public ImageSource Logo
        {
            get => (ImageSource) GetValue(LogoProperty);
            set => SetValue(LogoProperty, value);
        }

        public static readonly DependencyProperty LogoProperty = DependencyProperty.Register(
            nameof(Logo), typeof(ImageSource), typeof(TeamLogo), new PropertyMetadata(null) );

    }
}
