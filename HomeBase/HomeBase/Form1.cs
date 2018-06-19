using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeBase
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\Administrator\\Desktop\\New folder\\HomeBase\\HomeBase\\agileassignment3.mdf;Integrated Security = True");
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'agileassignment3DataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.agileassignment3DataSet.Table);

        }

        private void clear_Click(object sender, EventArgs e)
        {
            descriptionbox.Clear();
            datebox.Refresh();
            locationbox.Clear();
            timebox.Clear();
            prioritybox.Refresh();
        }
        public void diaplay_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [job]";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (descriptionbox.Text != "" & locationbox.Text != "" & timebox.Text != "")
            {
                con.Open();
                string query = "Insert into job (Description,Location,Date,Time,Priority) Values('" + descriptionbox.Text + "','" + locationbox.Text + "','" + datebox.Text + "','" + timebox.Text + "','" + prioritybox.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data is successful saved");
                descriptionbox.Clear();
                datebox.Refresh();
                locationbox.Clear();
                timebox.Clear();
                prioritybox.ResetText();
                diaplay_data();
            } 
        }
    }
}
