using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DevexpressHelper.ControlHelper
{
    public class ControlInvoke
    {
        public static void Invoke(Control control, Action action)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public static TModel Invoke<TModel>(Control control, Func<TModel> func) where TModel : new()
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            TModel model = new TModel();

            if (control.InvokeRequired)
            {
                model = (TModel)control.Invoke(func);
            }
            else
            {
                model = (TModel)control.Invoke(func);
            }

            return model;
        }
    }
}
