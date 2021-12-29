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
            // �����ļ����е�����
        }

        /// <summary>
        /// �رմ���ʱִ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void FrmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // ����ǵ�X�رգ���ȡ������
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
            // ���������� Text
            lbAnimal.DisplayMember = "Name";
            // ѡ��ʱ���ֵ
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
        /// ��JSON�ļ���ȡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                // �����ļ���WebApi
                animalService.PostFile(openFileDialog.FileName);
                string str =  File.ReadAllText(openFileDialog.FileName);
                lbAnimal.DataSource = null;
                lbAnimal.DataSource =  new BindingList<AnimalDto>(JsonSerializer.Deserialize<List<AnimalDto>>(str));
                // ���������� Text
                lbAnimal.DisplayMember = "Name";
                // ѡ��ʱ���ֵ
                lbAnimal.ValueMember = "Id";
            }
        }

        /// <summary>
        /// �������ݵ�JSON�ļ�
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
            // ��frm
             frm.Show();
            // ���ڶ��㣬���ҵײ�Ĳ��ɲ���
            // frm.ShowDialog();
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            // TODO ѡ����ʱ�����Ҽ��˵�

            if (lbAnimal.SelectedValue != null)
            {
                var animals = (BindingList<AnimalDto>)lbAnimal.DataSource;
                animals.Remove((AnimalDto)lbAnimal.SelectedItem);
            }
        }

        /// <summary>
        /// �˳�
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
                animal.Name = "С��";
            }
        }

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDate().Show();
        }
    }
}