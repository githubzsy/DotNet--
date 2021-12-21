using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformDemo
{
    public partial class frmNew : Form
    {
        private static frmNew instance;

        public static frmNew Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new frmNew();
                }
                return instance;
            }
        }

        private frmNew()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                frmMain.Clients.Add(new ClientInfo
                {
                    Name = txtName.Text,
                    Text = txtInfo.Text,
                });
            }
        }
    }
}
