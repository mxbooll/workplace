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
    public partial class GuardsForm : Form
    {
        private string nameCurrentGuard = "";
        public GuardsForm()
        {
            InitializeComponent();
            //Выбрать последнего добавленного охранника.
            string command = @"SELECT name FROM guardmen ORDER BY timeEnter DESC LIMIT 1;";
            nameCurrentGuard = DbHelper.GetString(command);
            lblName.Text = nameCurrentGuard;

            RefreshSource();
            dataGridView1.Columns[0].HeaderText = @"N";
            dataGridView1.Columns[1].HeaderText = @"Имя";
            dataGridView1.Columns[2].HeaderText = @"Фамилия";
            dataGridView1.Columns[3].HeaderText = @"Отчество";
            dataGridView1.Columns[4].HeaderText = @"Организация";
            dataGridView1.Columns[5].HeaderText = @"Должность";
            dataGridView1.Columns[6].HeaderText = @"Время входа-выхода";
            dataGridView1.Columns[7].HeaderText = @" ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new EnterForm().ShowDialog();
            RefreshSource();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new OutputForm().ShowDialog();
            RefreshSource();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Обновить информацию об охраннике, закончившем смену.
            string command = $"UPDATE guardmen SET timeOut = datetime() WHERE name = '{nameCurrentGuard}';";
            DbHelper.ExecuteNonQuery(command);
            this.Dispose();
        }

        private void GuardsForm_Load(object sender, EventArgs e)
        {
            RefreshSource();
        }

        private void RefreshSource()
        {
            dataGridView1.DataSource = DbHelper.GetDataSet(@"SELECT id, name, surname, patronymic, organization, post, timeEnter, timeOut FROM loginfo ORDER BY timeOut DESC").Tables["Table"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AddForm().ShowDialog();
            RefreshSource();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new DelForm().ShowDialog();
            RefreshSource();
        }
    }
}
