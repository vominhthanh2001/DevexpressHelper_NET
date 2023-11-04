using DevExpress.Office.DrawingML;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevexpressHelper.ControlHelper;
using DevexpressHelper_NET.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevexpressHelper.Grid
{
    public class GridInitialize<TModel> : RowDataSource<TModel>, IGrid<TModel>
    {
        public GridInitialize() : base()
        {

        }

        public GridInitialize(GridControl gridControl, GridView gridView) : base(gridControl, gridView)
        {

        }

        public GridInitialize(GridControl gridControl, GridView gridView, List<TModel> models) : base(gridControl, gridView, models)
        {

        }

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
