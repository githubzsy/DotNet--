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
using WinformDemo.BLL;

namespace WinformDemo
{
    public partial class frmAnimal : Form
    {
        public frmAnimal()
        {
            InitializeComponent();
        }
        static SortableBindingList<AnimalDto> sortableAnimals;
        private async void frmAnimal_Load(object sender, EventArgs e)
        {
            AnimalService animalService = new AnimalService();
            var animals = await animalService.GetAnimals();

            sortableAnimals = new SortableBindingList<AnimalDto>(animals);
            dgvAnimal.DataSource = sortableAnimals;
        }
    }
}
