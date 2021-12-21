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
            this.dgvAnimal.ColumnHeaderMouseClick += DgvAnimal_ColumnHeaderMouseClick;
        }

        private void DgvAnimal_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            // Check which column is selected, otherwise set NewColumn to null.
            DataGridViewColumn newColumn = dgvAnimal.Columns[e.ColumnIndex];

            DataGridViewColumn oldColumn = dgvAnimal.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not currently sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    dgvAnimal.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // If no column has been selected, display an error dialog  box.
            if (newColumn == null)
            {
                MessageBox.Show("Select a single column and try again.",
                    "Error: Invalid Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                dgvAnimal.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
            }
        }

        static SortableBindingList<AnimalDto> animalDtos;
        private async void frmAnimal_Load(object sender, EventArgs e)
        {
            AnimalService animalService = new AnimalService();
            var animals = await animalService.GetAnimals();

            animalDtos = new SortableBindingList<AnimalDto>(animals);
            dgvAnimal.DataSource = animalDtos;
        }
    }
}
