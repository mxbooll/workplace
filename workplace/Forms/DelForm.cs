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
    public partial class DelForm : Form
    {
        public DelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = "";

            if (textBox1.Text != "")
            {
                number = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Введите табельный номер!");
            }

            //Вносим изменения в таблицу сотрудников
            string command = $"DELETE FROM loginfo WHERE id = '{number}';";
            DbHelper.ExecuteNonQuery(command);

            this.Close();
        }
    }
}
