using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workplace.Forms
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = "";
            string surname = "";
            string patronymic = "";
            string organizaion = "";
            string post = "";


            if (
                textBox1.Text != "" &&
                textBox2.Text != "" &&
                textBox3.Text != "" &&
                textBox4.Text != "" &&
                textBox5.Text != "")
            {
                name = textBox1.Text;
                surname = textBox2.Text;
                patronymic = textBox3.Text;
                organizaion = textBox4.Text;
                post = textBox5.Text;
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }

            //Вносим данные в таблицу сотрудников
            var insertQuery =
                $"INSERT INTO loginfo(name, surname, patronymic, organization, post) VALUES(" +
                $"'{name}', '{surname}','{patronymic}','{organizaion}','{post}')";
            DbHelper.ExecuteNonQuery(insertQuery);

            this.Close();
        }
    }
}
