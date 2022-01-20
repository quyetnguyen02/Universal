using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoginForm.demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplitViewDemo : Page
    {
        public SplitViewDemo()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(demo.Page01));
        }

        private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            split.IsPaneOpen = !split.IsPaneOpen;

            
        }
    }
}
