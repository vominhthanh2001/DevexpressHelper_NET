using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevexpressHelper_NET.Grid
{
    public class RowDataSource<TModel> : InfoDataSource<TModel>
    {
        public RowDataSource() : base()
        {

        }

        public RowDataSource(GridControl gridControl, GridView gridView) : base(gridControl, gridView)
        {

        }

        public RowDataSource(GridControl gridControl, GridView gridView, List<TModel> models) : base(gridControl, gridView, models)
        {

        }

        private int[] IndexsRowSelected()
        {
            return base.GridView.GetSelectedRows().ToArray();
        }

        public TModel RowSelect()
        {
            int[] indexs = IndexsRowSelected();

            if (indexs == null)
                return default(TModel);

            if (indexs.Length == 0)
                return default(TModel);

            var rows = indexs.Select(x => base.Models[x]).Cast<TModel>().ToList();

            return rows.FirstOrDefault();
        }

        public List<TModel> RowsSelect()
        {
            int[] indexs = IndexsRowSelected();

            if (indexs == null)
                return default(List<TModel>);

            if (indexs.Length == 0)
                return default(List<TModel>);

            var rows = indexs.Select(x => base.Models[x]).Cast<TModel>().ToList();

            return rows;
        }
    }
}
