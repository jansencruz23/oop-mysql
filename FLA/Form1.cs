using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FLA
{
    public partial class Form1 : Form
    {
        private const string CONNECTION_STRING = "server=localhost;user id = root; password=; database=dbsis;";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var query = "INSERT INTO Students(FirstName,LastName,MiddleInitial,Course,YearLevel,Picture) " +
                "VALUES('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtMiddle.Text
                + "','" + txtCourse.Text + "','" + txtYear.Text + "','" + txtPath.Text + "')";
            var conn = new MySqlConnection(CONNECTION_STRING);
            var cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr;
            conn.Open();
            rdr = cmd.ExecuteReader();
            MessageBox.Show("The record has been inserted");
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var sqlquery = "UPDATE Students SET FirstName='" + txtFirstName.Text + "', LastName ='"
                + txtLastName.Text + "', MiddleInitial = '" + txtMiddle.Text + "', Course = '" + txtCourse.Text + "'," +
                "YearLevel = '" + txtYear.Text + "', Picture = '" + txtPath.Text + "'  WHERE StudentID = '"+ txtStudentId.Text+"' ";
            var conn = new MySqlConnection(CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand(sqlquery, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("The record has been updated successfully!");
            conn.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var query = "SELECT * FROM Students";
            var conn = new MySqlConnection(CONNECTION_STRING);
            var cmd = new MySqlCommand(query, conn);
            var da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var sqlquery = "DELETE FROM Students WHERE StudentID='" + this.txtStudentId.Text + "'";
            var conn = new MySqlConnection(CONNECTION_STRING);
            var cmd = new MySqlCommand(sqlquery, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("The record has been deleted successfully");
            conn.Close();
        }

        private void btnBSCS_Click(object sender, EventArgs e)
        {
            var query = "SELECT * FROM Students WHERE Course = 'BSCS';";
            var conn = new MySqlConnection(CONNECTION_STRING);
            var cmd = new MySqlCommand(query, conn);
            var da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = "SELECT * FROM Students;";
            var conn = new MySqlConnection(CONNECTION_STRING);
            var cmd = new MySqlCommand(query, conn);
            var da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("LastName LIKE '%{0}%'", txtSearch.Text);
            dgvStudents.DataSource = dv;
        }

        private void imgPic_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico|All Files|*.*";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = file.FileName.Replace("\\", "\\\\");
                imgPic.Image = Image.FromFile(file.FileName);
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = dgvStudents.Rows[e.RowIndex];

                    txtStudentId.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                    txtFirstName.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                    txtMiddle.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                    txtLastName.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                    txtCourse.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
                    txtYear.Text = selectedRow.Cells[5].Value?.ToString() ?? "";
                    txtPath.Text = selectedRow.Cells[6].Value?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(txtPath.Text))
                    {
                        imgPic.Image = Image.FromFile(txtPath.Text);
                    }
                    else
                    {
                        imgPic.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}