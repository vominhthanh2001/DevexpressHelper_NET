using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevexpressHelper_NET.ControlHelper
{
    public class ControlForm
    {
        private static XtraPanel _panel;
        private static XtraForm _form;
        private static XtraUserControl _user;

        public static void AddFormToPanel(XtraPanel panel, XtraForm form, bool isShow = true, bool isClear = true)
        {
            if (isClear)
            {
                panel.Controls.Clear();
            }

            form.Size = panel.Size;

            panel.Controls.Add(form);
            panel.SizeChanged += Panel_SizeChanged;

            if (isShow)
            {
                form.Show();
            }

            _user = null;
        }

        private static void Panel_SizeChanged(object sender, EventArgs e)
        {
            if (_panel == null)
            {
                return;
            }

            if (_form != null)
            {
                _form.Size = _panel.Size;
            }

            if (_user != null)
            {
                _user.Size = _panel.Size;
            }
        }

        public static void AddFormToPanel(XtraPanel panel, XtraUserControl user, bool isShow = true, bool isClear = true)
        {
            if (isClear)
            {
                panel.Controls.Clear();
            }

            user.Size = panel.Size;

            panel.Controls.Add(user);
            panel.SizeChanged += Panel_SizeChanged;

            if (isShow)
            {
                user.Show();
            }

            _form = null;
        }
    }
}
