using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.DataGrid;
using Microsoft.UI.Xaml.Media.Animation;
using Syncfusion.UI.Xaml.Data;
using Windows.Storage;
using Syncfusion.UI.Xaml.DataGrid.Serialization;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Style_Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.dataGrid.SerializationController = new SerializationControllerExt(this.dataGrid);
        }

        private async void Serialize_Click(object sender, RoutedEventArgs e)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var storageFile = await folder.CreateFileAsync("DataGrid.xml", CreationCollisionOption.ReplaceExisting);
            SerializationOptions options = new SerializationOptions();
            options.SerializeUnboundRows = false;
            this.dataGrid.Serialize(storageFile, options);
        }

        private async void Deserialize_Click(object sender, RoutedEventArgs e)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var storageFile = await folder.GetFileAsync("DataGrid.xml");
            DeserializationOptions options = new DeserializationOptions();
            options.DeserializeUnboundRows = false;
            this.dataGrid.Deserialize(storageFile, options);
        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var folder = ApplicationData.Current.LocalFolder;
        //    var storageFile = await folder.CreateFileAsync("DataGrid.xml", CreationCollisionOption.ReplaceExisting);
        //    SerializationOptions options = new SerializationOptions();
        //    options.SerializeUnboundRows = false;
        //    this.datagrid.Serialize(storageFile, options);
        //    //FileStream stream = new FileStream("DataGrid", FileMode.Create);
        //    //this.datagrid.Serialize(stream);
        //}

        //private async void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    var folder = ApplicationData.Current.LocalFolder;
        //    var storageFile = await folder.GetFileAsync("DataGrid.xml");
        //    DeserializationOptions options = new DeserializationOptions();
        //    options.DeserializeUnboundRows = false;
        //    this.datagrid.Deserialize(storageFile, options);
        //}
    }
}
