using DtoModels;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Unicode;
using WebApiDemo2.BLL;

namespace WinformDemo2
{
    public partial class frmMain : Form
    {
        AnimalService animalService=new AnimalService();


        public frmMain()
        {
            InitializeComponent();
            this.FormClosing += FrmMain_FormClosing;

            lbAnimal.SelectedValueChanged += LbAnimal_SelectedValueChanged;
            BindAnimal();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            //System.Threading.Timer timer = new System.Threading.Timer((obj) => {
            //    MessageBox.Show("1");
            //    timer.Change(new TimeSpan(0),
            //    intervalTime + intervalTime);
            //},null,0,5000);
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());
            // 监视文件夹中的内容
        }

        /// <summary>
        /// 关闭窗体时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void FrmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // 如果是点X关闭，则取消动作
            if(e.CloseReason == System.Windows.Forms.CloseReason.UserClosing)
            {
                e.Cancel = true; 
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private async void BindAnimal()
        {
            lbAnimal.DataSource = new BindingList<AnimalDto>(await animalService.GetAll());
            // 看到的文字 Text
            lbAnimal.DisplayMember = "Name";
            // 选中时候的值
            lbAnimal.ValueMember = "Id";
        }

        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        private void LbAnimal_SelectedValueChanged(object? sender, EventArgs e)
        {
            var lb =  (ListBox)sender;
            var animal = (AnimalDto)lb.SelectedItem;
            var json = JsonSerializer.Serialize(animal,options);
            txtAnimal.Text = json;
        }

        /// <summary>
        /// 从JSON文件读取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                // 传输文件到WebApi
                animalService.PostFile(openFileDialog.FileName);
                string str =  File.ReadAllText(openFileDialog.FileName);
                lbAnimal.DataSource = null;
                lbAnimal.DataSource =  new BindingList<AnimalDto>(JsonSerializer.Deserialize<List<AnimalDto>>(str));
                // 看到的文字 Text
                lbAnimal.DisplayMember = "Name";
                // 选中时候的值
                lbAnimal.ValueMember = "Id";
            }
        }

        /// <summary>
        /// 保存数据到JSON文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var str = JsonSerializer.Serialize(lbAnimal.DataSource);
                File.WriteAllText(saveFileDialog.FileName, str);
            }
        }

        private void menuAnimal_Click(object sender, EventArgs e)
        {
            var frm = new frmDataGridView();
            // 打开frm
             frm.Show();
            // 置于顶层，而且底层的不可操作
            // frm.ShowDialog();
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            // TODO 选中行时出现右键菜单

            if (lbAnimal.SelectedValue != null)
            {
                var animals = (BindingList<AnimalDto>)lbAnimal.DataSource;
                animals.Remove((AnimalDto)lbAnimal.SelectedItem);
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void menuChangeName_Click(object sender, EventArgs e)
        {
            var animals = (BindingList<AnimalDto>)lbAnimal.DataSource;
            foreach (var animal in animals)
            {
                animal.Name = "小黑";
            }
        }

        private void 打开日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDate().Show();
        }
    }
}