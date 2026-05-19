# How to serialize template column content in WinUI DataGrid?

This example describes how to serialize template column content in **WinUI DataGrid**.

By default, you cannot serialize the template content in [WinUI DataGrid](https://www.syncfusion.com/winui-controls/datagrid) (SfDataGrid). This is the default behavior during Serialization and Deserialization operation.

### XAML

``` xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <XamlControlsResources xmlns="using:Microsoft.UI.Xaml.Controls" />
            <!-- Other merged dictionaries here -->
        </ResourceDictionary.MergedDictionaries>
        <!-- Other app resources here -->
        <DataTemplate x:Key="cellTemplate">
            <Button Width="110" Content="{Binding Value}" />
        </DataTemplate>
    </ResourceDictionary>
</Application.Resources>


<dataGrid:SfDataGrid x:Name="dataGrid"
                    AutoGenerateColumns="False"
                    ItemsSource="{Binding Orders}">
    <dataGrid:SfDataGrid.Columns>
        <dataGrid:GridTemplateColumn CellTemplate="{StaticResource cellTemplate}"
                                HeaderText="Order ID"
                                MappingName="OrderID"
                                SetCellBoundValue="True" />        
    </dataGrid:SfDataGrid.Columns>
</dataGrid:SfDataGrid>
```

If you want to serialize and deserialize the template content, you have to reconstruct the same template during deserialization in [RestoreColumnProperties](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.Serialization.SerializationController.html#Syncfusion_UI_Xaml_DataGrid_Serialization_SerializationController_RestoreColumnProperties_Syncfusion_UI_Xaml_DataGrid_Serialization_SerializableGridColumn_Syncfusion_UI_Xaml_DataGrid_GridColumn_) method.

### C#

``` csharp
this.dataGrid.SerializationController = new SerializationControllerExt(this.dataGrid);

public class SerializationControllerExt : SerializationController
{
    public SerializationControllerExt(SfDataGrid grid)
    : base(grid)
    {

    }

    protected override void RestoreColumnProperties(SerializableGridColumn serializableColumn, GridColumn column)
    {
        base.RestoreColumnProperties(serializableColumn, column);
        if (column is GridTemplateColumn)
        {
            if (column.MappingName == "OrderID")
            {
                column.CellTemplate = Application.Current.Resources["cellTemplate"] as DataTemplate;
            }
        }
    }
}
```