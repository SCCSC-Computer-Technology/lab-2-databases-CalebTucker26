/*Caleb Tucker
 * Lab 2
 * City Database
 * CPT-206-A80H*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace C_Tucker_Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City);

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            SortMethod();
        }

        private void btnPopulationStats_Click(object sender, EventArgs e)
        {
            PopulationsStats();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Methods

        //Sorting Method using an if statement to chose the correct sorting method.
        public void SortMethod()
        {
            if (cBoxSortOptions.SelectedIndex == 0)
            {
                this.cityTableAdapter.sortPopulationASC(this.cityDBDataSet.City);
            }
            else if (cBoxSortOptions.SelectedIndex == 1)
            {
                this.cityTableAdapter.sortPopulationDSC(this.cityDBDataSet.City);
            }
            else if(cBoxSortOptions.SelectedIndex == 2)
            {
                this.cityTableAdapter.sortCityName(this.cityDBDataSet.City);
            }
            else
            {
                MessageBox.Show("Please select a sorting option.");
            }
        }

        //Population Display Method
        public void PopulationsStats()
        {
            MessageBox.Show("The total populations is: " + this.cityTableAdapter.populationSumQuery() + "\n" + "The average population is: " + this.cityTableAdapter.avgPopulationQuery() + "\n" + "The highest Population is: " + this.cityTableAdapter.highestPopulationQuery() + "\n" + "The lowest population is: " + this.cityTableAdapter.lowestPopulationQuery());
        }
    }
}

