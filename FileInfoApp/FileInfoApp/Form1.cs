using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileInfoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = file.GetFile();
        }

        File file = new File();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            file.Id = numericUpDown1.Text;
            file.Title = textBox2.Text;
            file.Name = textBox3.Text;
            file.Time = dateTimePicker1.Text;
            file.Creator = textBox5.Text;
            var success = file.Add(file);
            dataGridView1.DataSource = file.GetFile();
            if (success)
            {
                MessageBox.Show("File has been added successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            file.Id = numericUpDown1.Text;
            file.Title = textBox2.Text;
            file.Name = textBox3.Text;
            file.Time = dateTimePicker1.Text;
            file.Creator = textBox5.Text;
            var success = file.Update(file);
            dataGridView1.DataSource = file.GetFile();
            if (success)
            {
                MessageBox.Show("File has been updated successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            file.Id = numericUpDown1.Text;
            var success = file.Delete(file);
            //dataGridView1.DataSource = file.GetFile();
            if (success)
            {
                ClearControls();
                MessageBox.Show("File has been delete successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            numericUpDown1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = "";
            textBox5.Text = "";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            numericUpDown1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
