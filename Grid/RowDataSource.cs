using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevExpress.Office.Import.OpenXml;

namespace DevexpressHelper_NET.Grid
{
    public class RowDataSource<TModel> : InfoDataSource<TModel>
    {
        public RowDataSource() : base()
        {

        }

        public RowDataSource(GridControl gridControl, GridView gridView) : base(gridControl, gridView)
        {
            gridView.RowCellStyle += GridView_RowCellStyle;
        }

        public RowDataSource(GridControl gridControl, GridView gridView, List<TModel> models) : base(gridControl, gridView, models)
        {
            gridView.RowCellStyle += GridView_RowCellStyle;
        }

        private object _lockSetColor = new object();
        private Color _color = default(Color);
        private int _index = -1;
        private bool _foreColor = false;
        private bool _backColor = false;

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

        public void SetForeColorCell()
        {
            GridView.Columns[""].AppearanceCell.ForeColor = Color.White;
        }

        public void SetForeColorRow(TModel model, Color color)
        {
            int index = Models.IndexOf(model);

            if (index == -1)
                return;

            _index = index;
            _color = color;
            _foreColor = true;
        }

        public void SetBackColorRow(TModel model, Color color)
        {
            int index = Models.IndexOf(model);

            if (index == -1)
                return;

            _index = index;
            _color = color;
            _backColor = true;
        }

        private void GridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            lock (_lockSetColor)
            {
                int index = e.RowHandle;

                if (index == -1)
                    return;

                if (_index == -1 && _color == default(Color))
                    return;

                if (_index == index && _color != default(Color) && _foreColor)
                {
                    e.Appearance.ForeColor = _color;
                }
                else if (_index == index && _color != default(Color) && _backColor)
                {
                    e.Appearance.BackColor = _color;
                }

                _index = -1;
                _color = default(Color);
                _foreColor = false;
                _backColor = false;
            }
        }
    }
}
