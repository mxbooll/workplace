using System;
using System.Data;
using System.Windows.Forms;

namespace workplace.Forms
{
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, System.EventArgs e)
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
            //var insertQuery =
            //    $"INSERT INTO loginfo(tabel, name, surname, patronymic, organization, post) SELECT * FROM workers WHERE id = '{number}'";
            //DbHelper.ExecuteNonQuery(insertQuery);

            string command = $"UPDATE loginfo SET timeEnter = datetime(), timeOut = 'ПРИСУТСТВУЕТ' WHERE id = '{number}';";
            DbHelper.ExecuteNonQuery(command);
           
            this.Close();
        }
    }
}
