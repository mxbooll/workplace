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
    public partial class OutputForm : Form
    {
        public OutputForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
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

            //Вносим данные в журнал входа-выхода
            string command = $"UPDATE loginfo SET timeEnter = datetime(), timeOut = 'ОТСУТСТВУЕТ' " +
                             $"WHERE id = '{number}';";
            DbHelper.ExecuteNonQuery(command);

            this.Close();
        }
    }
}
