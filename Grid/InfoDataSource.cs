using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevexpressHelper_NET.Grid
{
    public class InfoDataSource<TModel> : GridEventHandler<TModel>
    {
        public InfoDataSource()
        {
            throw new ArgumentNullException(nameof(GridControl) + "|" + nameof(GridView));
        }
        public InfoDataSource(GridControl gridControl, GridView gridView)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            if (gridControl is null)
            {
                throw new ArgumentNullException(nameof(gridControl));
            }

            if (gridView is null)
            {
                throw new ArgumentNullException(nameof(gridView));
            }

            _gridControl = gridControl;
            _gridView = gridView;
        }

        public InfoDataSource(GridControl gridControl, GridView gridView, List<TModel> models)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            if (gridControl is null)
            {
                throw new ArgumentNullException(nameof(gridControl));
            }

            if (gridView is null)
            {
                throw new ArgumentNullException(nameof(gridView));
            }

            if (models is null)
            {
                throw new ArgumentNullException(nameof(models));
            }

            _gridControl = gridControl;
            _gridView = gridView;
            _models = models;
        }

        private GridControl _gridControl;
        public GridControl GridControl { get => _gridControl; set => _gridControl = value; }

        private GridView _gridView;
        public GridView GridView { get => _gridView; set => _gridView = value; }

        private List<TModel> _models = new List<TModel>();
        public List<TModel> Models { get => _models; set => _models = value; }
        public int Count => Models.Count;
    }
}
