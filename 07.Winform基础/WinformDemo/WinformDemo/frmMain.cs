using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            BindEvent();
            BindList();
            
        }

        private void BindEvent()
        {
            menuNew.Click += MenuNew_Click;
            this.FormClosing += FrmMain_FormClosing;
        }


        private void FrmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //是否取消close操作
                e.Cancel = true;
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void MenuNew_Click(object? sender, EventArgs e)
        {
            frmNew.Instance.Show();
        }

        internal static BindingList<ClientInfo> Clients = new BindingList<ClientInfo>
            {
                new ClientInfo {Name="localhost:1111",Text="1111"},
                new ClientInfo {Name ="localhost:2222",Text="2222"}
            };
        private void BindList()
        {
            listBoxItems.DataSource = Clients;
            listBoxItems.ValueMember = "Name";
            listBoxItems.DisplayMember = "Name";
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lb = (ListBox)sender;
            var client = (ClientInfo)lb.SelectedItem;
            txtClientInfo.Text = client?.Text;
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem != null)
            {
                var client = (ClientInfo)listBoxItems.SelectedItem;
                new frmNewOrEdit(client).Show();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //双击控件事件，就显示窗体到任务栏，让窗体的尺寸成普通模式，使窗体获得焦点。 
            this.Show();
            this.Activate();
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            if (string.IsNullOrWhiteSpace(ofd.FileName))
            {
                return;
            }

            string str =  File.ReadAllText(ofd.FileName);
            Clients.Clear();
            foreach(var client in JsonSerializer.Deserialize<BindingList<ClientInfo>>(str))
            {
                Clients.Add(client);
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            if (string.IsNullOrWhiteSpace(sfd.FileName))
            {
                return;
            }
            var str = JsonSerializer.Serialize(Clients);
            File.WriteAllText(sfd.FileName, str);
            MessageBox.Show("保存成功");
        }

        private void menuAnimal_Click(object sender, EventArgs e)
        {
            new frmAnimal().Show();
        }
    }
}
