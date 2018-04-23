using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Q212065 {
    public partial class DrillDownControl : UserControl {
        public DrillDownControl() {
            InitializeComponent();
        }

        public object DataSource {
            get { return gridControl1.DataSource; }
            set { gridControl1.DataSource = value; }
        }
    }
}
