using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.DataGrid;
using Syncfusion.UI.Xaml.DataGrid.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Style_Sample
{
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
}
