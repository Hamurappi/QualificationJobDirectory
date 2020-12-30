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

        public QJD()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["QJDDB"].ConnectionString);

            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение к базе установленно успешно!");
            }
               
        }

        private void To_add_Click(object sender, EventArgs e)
        {
            Hide();
            ToAddList toAddList = new ToAddList();
            toAddList.ShowDialog();
            Close();
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
