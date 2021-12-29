using DtoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiDemo2.BLL;

namespace WinformDemo2
{
    public partial class frmDataGridView : Form
    {

        AnimalService animalService = new AnimalService();
        public SortableBindingList<AnimalDto> animals = new SortableBindingList<AnimalDto>();

        public frmDataGridView()
        {
            InitializeComponent();

            BindAnimals();
        }

        async void BindAnimals()
        {
            var lst = await animalService.GetAll();
            animals = new SortableBindingList<AnimalDto>(lst);
            dgvAnimal.DataSource = animals;

            dgvAnimal.Columns["Id"].HeaderText = "主键";
            dgvAnimal.Columns["Age"].HeaderText = "年龄";
            dgvAnimal.Columns["Name"].HeaderText = "名称";
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            animals.Add(new AnimalDto() { Name = "123", Age = 12, Id = "123" });
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            dgvAnimal.DataSource = null;
            dgvAnimal.DataSource = animals;
            // TODO 没效
            // dgvAnimal.Refresh();
        }

        private void menuSaveToApi_Click(object sender, EventArgs e)
        {
            // TODO 保存animals到WebApi

        }

        // TODO 传文件到WebApi上
    }
}
