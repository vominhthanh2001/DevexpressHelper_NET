using DevExpress.Office.DrawingML;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevexpressHelper.ControlHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevexpressHelper.Grid
{
    public class GridInitialize<TModel> : IGrid<TModel>
    {
        public GridInitialize()
        {
            throw new ArgumentNullException(nameof(GridControl) + "|" + nameof(GridView));
        }
        public GridInitialize(GridControl gridControl, GridView gridView)
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

            GridControl = gridControl;
            GridView = gridView;
        }
        public GridInitialize(GridControl gridControl, GridView gridView, List<TModel> models)
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

            GridControl = gridControl;
            GridView = gridView;
            Models = models;
        }

        private GridControl _gridControl;
        public GridControl GridControl { get => _gridControl; set => _gridControl = value; }

        private GridView _gridView;
        public GridView GridView { get => _gridView; set => _gridView = value; }

        private List<TModel> _models = new List<TModel>();
        public List<TModel> Models { get => _models; set => _models = value; }

        public int Count => Models.Count;

        public void Insert(TModel model, int index)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (index == -1)
            {
                throw new ArgumentNullException(nameof(index));
            }

            Models.Insert(index, model);
        }

        public void Add(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Models.Add(model);
        }

        public void Add(List<TModel> models, bool isClear = false)
        {
            if (models is null)
            {
                throw new ArgumentNullException(nameof(models));
            }

            if (isClear)
            {
                Clear();
            }

            Models.AddRange(models);
        }

        public void Clear()
        {
            Models.Clear();
        }

        public void RefreshDataSource()
        {
            ControlInvoke.Invoke(control: GridControl, action: () =>
            {
                GridControl.DataSource = Models;
                GridControl.RefreshDataSource();
            });
        }

        public void Remove(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Models.Remove(model);
        }

        public void Remove(List<TModel> models)
        {
            if (models is null)
            {
                throw new ArgumentNullException(nameof(models));
            }

            foreach (TModel model in models)
            {
                Remove(model);
            }
        }
    }
}
