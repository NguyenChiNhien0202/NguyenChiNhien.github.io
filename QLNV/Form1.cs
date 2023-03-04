using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Input;

namespace QLNV
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-UH7940K;Initial Catalog=QLNS;Integrated Security=True";

        SqlDataAdapter adapter= new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NHANVIEN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.ReadOnly= true;
            int i;
            i = dgv.CurrentRow.Index;
            textBox1.Text = dgv.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dgv.Rows[i].Cells[1].Value.ToString();
            textBox4.Text = dgv.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dgv.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dgv.Rows[i].Cells[4].Value.ToString();
            dateTimePicker1.Text = dgv.Rows[i].Cells[5].Value.ToString();
            textBox6.Text = dgv.Rows[i].Cells[6].Value.ToString();
            textBox7.Text = dgv.Rows[i].Cells[7].Value.ToString();
            textBox8.Text = dgv.Rows[i].Cells[8].Value.ToString();
            textBox9.Text = dgv.Rows[i].Cells[9].Value.ToString();
            textBox10.Text = dgv.Rows[i].Cells[10].Value.ToString();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            command= connection.CreateCommand();
            command.CommandText="insert into NHANVIEN values('" +textBox1.Text+ "','" +textBox2.Text+ "', '"+textBox4.Text+ "','"+textBox3.Text+ "','"+textBox5.Text+"','"+dateTimePicker1.Text+"','"+textBox6.Text+ "','"+textBox7.Text+ "','"+textBox8.Text+ "','"+textBox9.Text+ "','"+textBox10.Text+"')";
            command.ExecuteNonQuery(); 
            loadData(); 
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText ="delete from NHANVIEN where MaNV = '"+textBox1.Text+"'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update NHANVIEN set HoTen =N'" +textBox2.Text+ "' , DanToc = N'" +textBox4.Text+ "', GioiTinh = N'" +textBox3.Text+ "', QueQuan= N'" +textBox5.Text+ "', NgaySinh= '"+dateTimePicker1.Text+ "', SDT= '" +textBox6.Text+ "', MaTDHV='"+textBox7.Text+ "', MaPB='"+textBox8.Text+ "', MaCV='"+textBox9.Text+ "',MaLuong='"+textBox10.Text+"' where MaNV = '"+textBox1.Text+"'  ";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btKhoiTao_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }
    }
}
