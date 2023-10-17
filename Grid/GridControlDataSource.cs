using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevexpressHelper.Grid
{
    public class GridControlDataSource<TModel> : GridInitialize<TModel>
    {
        public GridControlDataSource(GridControl gridControl, GridView gridView) : base(gridControl, gridView)
        {
            RefreshDataSource();
        }

        public GridControlDataSource(GridControl gridControl, GridView gridView, List<TModel> models) : base(gridControl, gridView, models)
        {
            RefreshDataSource();
        }
    }
}
