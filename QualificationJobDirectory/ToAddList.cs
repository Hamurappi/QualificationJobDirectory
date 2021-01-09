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
using System.IO;

namespace QualificationJobDirectory
{
    public partial class ToAddList : Form
    {
        private SqlConnection sqlConnection = null;

        string imgLoc = ""; 
        public ToAddList()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ToAddList_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["QJDDB"].ConnectionString);

            sqlConnection.Open();
        }
        // Вставка фото через кнопку из файла
        private void OpenPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPD Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                dlg.Title = "Select Workers Picture";
                if (dlg.ShowDialog()==DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    PhotoBox.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Сохранение работника в базу
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                SqlCommand command = new SqlCommand(
                    $"INSERT INTO [Workers]( FullName, Position, Phone, Photo) VALUES ( @FullName, @Position, @Phone, @Photo)",
                    sqlConnection);
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

               // command.Parameters.AddWithValue("ID", IDBox.Text);
                command.Parameters.AddWithValue("FullName", SurnameBox.Text+ " " + NameBox.Text + " " + PatrBox.Text);
                command.Parameters.AddWithValue("Position", PostBox.Text);
                command.Parameters.AddWithValue("Phone", PhoneBox.Text);
               
                command.Parameters.Add(new SqlParameter("@Photo", img));
                int x = command.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show(x.ToString() + " record(s) saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            Hide();
            QJD qjd = new QJD();
            qjd.ShowDialog();
            Close();
        }
    }
}
