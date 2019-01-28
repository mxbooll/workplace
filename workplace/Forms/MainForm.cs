using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using workplace.Forms;

namespace workplace
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            //Подключаемся к БД.
            DbHelper.Connect();

            //Создаем таблицу охранников
            string command = "CREATE TABLE IF NOT EXISTS guardmen(" +
                             "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                             "name VARCHAR (10) NOT NULL," +
                             "timeEnter DATETIME," +
                             "timeOut DATETIME);";
            DbHelper.ExecuteNonQuery(command);

            //Создаем таблицу журнала входа-выхода
            command = "CREATE TABLE IF NOT EXISTS loginfo(" +
                             "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                             "name VARCHAR (255) NOT NULL," +
                             "surname VARCHAR (255) NOT NULL," +
                             "patronymic VARCHAR (255) NOT NULL," +
                             "organization VARCHAR (255) NOT NULL," +
                             "post VARCHAR (255) NOT NULL," +
                             "timeEnter DATETIME," +
                             "timeOut VARCHAR (10));";
            DbHelper.ExecuteNonQuery(command);

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Разрывам содинние с БД.
            DbHelper.Disconnect();
        }

        private void AboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (txtBxNameGuardman.Text != "")
            {
                //Вносим данные об охраннике, который приступил к смене
                var insertQuery =
                    $"INSERT INTO guardmen(name, timeEnter) VALUES('{txtBxNameGuardman.Text}', datetime())";
                DbHelper.ExecuteNonQuery(insertQuery);
                new GuardsForm().ShowDialog();

            }
            else
            {
                MessageBox.Show("Введите имя");
            }
        }
    }
}
