using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MiniClient
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();

        }

        private void memoEdit1_Paint(object sender, PaintEventArgs e)
        {
            MemoEdit txt = sender as MemoEdit;

            txt.Size = new Size(txt.Size.Width, txt.Lines.Length * 25);
        }
    }
}