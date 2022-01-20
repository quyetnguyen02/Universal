using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NavigationViewDemo.demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class demoFilePicker : Page
    {
        private Windows.Storage.StorageFile fileName;
        public demoFilePicker()
        {
            this.InitializeComponent();
        }

        private async void HandleOpenFile()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".txt");

            
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            fileName = file;
           
            if (file != null)
            {
               var stringContent = await FileIO.ReadTextAsync(file);
                Editor.Text = stringContent;
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Action fails!";
                contentDialog.Content = "Please chosse a file to save!";
                contentDialog.CloseButtonText = "OK";
                contentDialog.ShowAsync();
            }
            
        }

        private async void HandleSaveFile()
        {
            ContentDialog contentDialog = new ContentDialog();
            if (fileName != null)
            {
                await FileIO.WriteTextAsync(fileName, Editor.Text);
                contentDialog.Title = "Action success!";
                contentDialog.Content = "Save file success!";
            }
            else
            {
                var savePicker = new Windows.Storage.Pickers.FileSavePicker();
                savePicker.SuggestedStartLocation =
                    Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                // Dropdown of file types the user can save the file as
                savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
                // Default file name if the user does not type one in or select a file to replace
                savePicker.SuggestedFileName = "New Document";
                Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
                
                if (file != null)
                {

                    await FileIO.WriteTextAsync(file, Editor.Text);

                    contentDialog.Title = "Action success!";
                    contentDialog.Content = "Save file success!";


                }
                else
                {
                    contentDialog.Title = "Action fails!";
                    contentDialog.Content = "Please chosse a file to save!";
                }
               
            }
            contentDialog.CloseButtonText = "OK";
            contentDialog.ShowAsync();

        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
           var menuItem= sender as MenuFlyoutItem;
            switch (menuItem.Tag)
            {
                case "Open":
                    HandleOpenFile();
                    break;
                case "Save":
                    HandleSaveFile();
                    break;
                case "New":
                    break;
            }

        }
    }
}
