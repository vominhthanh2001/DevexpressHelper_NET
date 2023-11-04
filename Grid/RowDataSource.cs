using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevexpressHelper_NET.Grid
{
    public class RowDataSource<TModel>
    {
        public RowDataSource()
        {
            throw new ArgumentNullException(nameof(GridControl) + "|" + nameof(GridView));
        }
        public RowDataSource(GridControl gridControl, GridView gridView, List<TModel> models)
        {
            _gridControl = gridControl ?? throw new ArgumentNullException(nameof(gridControl));
            _gridView = gridView ?? throw new ArgumentNullException(nameof(gridView));
            _models = models ?? throw new ArgumentNullException(nameof(models));
        }

        private GridControl _gridControl;

        private GridView _gridView;
        private List<TModel> _models;

        private int[] IndexsRowSelected()
        {
            return _gridView.GetSelectedRows().ToArray();
        }

        public TModel RowSelect()
        {
            int[] indexs = IndexsRowSelected();

            if (indexs == null)
                return default(TModel);

            if (indexs.Length == 0)
                return default(TModel);

            var rows = indexs.Select(x => _models[x]).Cast<TModel>().ToList();

            return rows.FirstOrDefault();
        }

        public List<TModel> RowsSelect()
        {
            int[] indexs = IndexsRowSelected();

            if (indexs == null)
                return default(List<TModel>);

            if (indexs.Length == 0)
                return default(List<TModel>);

            var rows = indexs.Select(x => _models[x]).Cast<TModel>().ToList();

            return rows;
        }
    }
}
