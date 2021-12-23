using DtoModels;
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

            lbAnimal.SelectedValueChanged += LbAnimal_SelectedValueChanged;
            BindAnimal();
        }

        private async void BindAnimal()
        {
            lbAnimal.DataSource = await animalService.GetAll();
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

        private void menuOpen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你好傻");
        }

        private void menuSave_Click(object sender, EventArgs e)
        {

        }
    }
}