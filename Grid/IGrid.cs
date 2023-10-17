using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevexpressHelper.Grid
{
    public interface IGrid<TModel>
    {
        List<TModel> Models { get; set; }
        int Count { get; }

        void Insert(TModel model, int index);
        void Add(TModel model);
        void Add(List<TModel> models, bool isClear = false);
        void Remove(TModel model);
        void Remove(List<TModel> models);
        void Clear();
        void RefreshDataSource();
    }
}
