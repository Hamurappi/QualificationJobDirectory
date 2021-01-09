using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace QualificationJobDirectory
{
    public partial class QJD : Form
    {
        private SqlConnection sqlConnection = null;

        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;
        public QJD()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "directoryDBDataSet.Workers". При необходимости она может быть перемещена или удалена.
            this.workersTableAdapter.Fill(this.directoryDBDataSet.Workers);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["QJDDB"].ConnectionString);

            sqlConnection.Open();
            searchDate("");

            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение к базе установленно успешно!");
            }
        }

        public void searchDate(string valueToSearch)
        {
            string query = "SELECT * FROM Workers WHERE CONCAT ('FullName', 'Position', 'Phone') like N'%" + valueToSearch + "%'";
            command = new SqlCommand(query, sqlConnection);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void To_add_Click(object sender, EventArgs e)
        {
            Hide();
            ToAddList toAddList = new ToAddList();
            toAddList.ShowDialog();
            Close();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            DataView dv = table.DefaultView;
            dv.RowFilter = string.Format("fullname like '%{0}%'", SearchBox.Text);
            dataGridView1.DataSource = dv.ToTable();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentCell.Value.ToString();
            try
            {
                sqlConnection.Open();
                string command_model_kar = "DELETE FROM workers WHERE (ID=" + Convert.ToInt32(s) + ");";
                SqlCommand command_model_kar_add = new SqlCommand(command_model_kar, sqlConnection);
                command_model_kar_add.ExecuteNonQuery();
                MessageBox.Show("Удаление выполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Удаление не выполнено\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
/* private SqlConnection sqlConnection = null;
  
   sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["QJDDB"].ConnectionString);     Подключение
                                                                                                              Таблицы
            sqlConnection.Open();

    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Workers WHERE FullName LIKE N'%texbox%',     Конструктор
                                                                                                                Запроса
            sqlConnection);                                                Строка подключения                
            
    DataSet dataSet = new DataSet();
    dataAdapter.Fill(dataSet);
    dataGridView1.DataSource = dataSet.Tables[0];                        Представление выборки в таблицу
    */
// SELECT * FROM Workers WHERE FullName LIKE N'%texbox%'
