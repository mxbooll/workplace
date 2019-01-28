using System.Data;
using System.Data.SQLite;

namespace workplace
{
    // Класс для работы с БД.

    internal static class DbHelper
    {
        private static SQLiteConnection connDB;

        // Имя БД.
        public static string Database { get; set; } = "EmployeesDB.db";

        // Открывает подключение к БД.
        public static void Connect()
        {
            connDB = new SQLiteConnection($"Data Source={Database}; Version=3");
            connDB.Open();
        }

        // Закрывает подключение к БД.
        public static void Disconnect()
        {
            if ((connDB != null) && (connDB.State != ConnectionState.Closed))
                connDB.Close();
        }

        public static SQLiteCommand CreateSQLiteCommand(string cmdText)
        {
            //return new SQLiteCommand(cmdText, connDB);

            return new SQLiteCommand(cmdText, connDB);
        }

        public static SQLiteDataAdapter GetData(SQLiteCommand command)
        {
            return new SQLiteDataAdapter(command);
        }

        public static SQLiteDataAdapter GetData(string cmdText)
        {
            return new SQLiteDataAdapter(cmdText, connDB);
        }

        public static DataSet GetDataSet(string cmdText)
        {
            var dataSet = new DataSet();
            GetData(cmdText).Fill(dataSet);
            return dataSet;
        }

        public static int ExecuteNonQuery(string cmdText)
        {
            return CreateSQLiteCommand(cmdText).ExecuteNonQuery();
        }
        public static string GetString(string cmdText)
        {
            SQLiteCommand command = new SQLiteCommand(cmdText, connDB);
            string amount = command.ExecuteScalar().ToString();
            return amount;
        }
    }
}
