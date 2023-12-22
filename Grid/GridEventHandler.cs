using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevexpressHelper_NET.Grid
{
    public class GridEventHandler<TModel>
    {
        public event EventHandler<TModel> OnModelChanged;
        public event EventHandler<TModel> OnAdded;
        public event EventHandler<TModel> OnRemoved;
    }
}
