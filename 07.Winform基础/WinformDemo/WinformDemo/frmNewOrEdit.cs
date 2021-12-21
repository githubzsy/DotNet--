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
    public partial class frmNewOrEdit : Form
    {
        private ClientInfo client;

        public frmNewOrEdit(ClientInfo client = null)
        {
            this.client = client;
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            if (client != null)
            {
                txtName.Text = client.Name;
                txtInfo.Text = client.Text;
                btnSave.Text = "修改";
            }
            else btnSave.Text = "新增";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                frmMain.Clients.Add(new ClientInfo
                {
                    Name = txtName.Text,
                    Text = txtInfo.Text
                });
            }
            else
            {
                client.Text = txtInfo.Text;
                client.Name = txtName.Text;
            }
        }
    }
}
