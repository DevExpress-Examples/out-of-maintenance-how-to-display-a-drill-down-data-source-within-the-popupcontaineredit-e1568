using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Q212065 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            repositoryItemPopupContainerEdit1.PopupControl = CreatePopupControl();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.SalesPerson' table. You can move, or remove it, as needed.
            this.salesPersonTableAdapter.Fill(this.nwindDataSet.SalesPerson);
        }

        private PopupContainerControl CreatePopupControl() {
            PopupContainerControl result = new PopupContainerControl();
            DrillDownControl ddc = new DrillDownControl();
            ddc.Name = "DrillDownControl";
            ddc.Dock = DockStyle.Fill;
            result.Size = ddc.Size;
            result.Controls.Add(ddc);
            return result;
        }

        private void repositoryItemPopupContainerEdit1_QueryPopUp(object sender, CancelEventArgs e) {
            PopupContainerEdit editor = (PopupContainerEdit)sender;
            DrillDownControl ddc = 
                (DrillDownControl)editor.Properties.PopupControl.Controls["DrillDownControl"];
            ddc.DataSource = pivotGridControl1.Cells.GetFocusedCellInfo().CreateDrillDownDataSource();
        }

        private void repositoryItemPopupContainerEdit1_CloseUp(object sender, CloseUpEventArgs e) {
            PopupContainerEdit editor = (PopupContainerEdit)sender;
            DrillDownControl ddc =
                (DrillDownControl)editor.Properties.PopupControl.Controls["DrillDownControl"];
            if (ddc.DataSource != null) {
                ((IDisposable)ddc.DataSource).Dispose();
                ddc.DataSource = null;
            }
        }
    }
}