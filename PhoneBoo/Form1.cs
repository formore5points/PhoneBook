using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PhoneBoo
{
    public partial class Form1 : Form
    {

        SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Contacts;Integrated Security=True");
        SqlDataAdapter adtr;
        DataTable tbl = new DataTable();
        List<Contact> People = new List<Contact>();
        int selected_row = -1;
        Boolean event_checker = false;
        Boolean textbox1flag = false;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Phone");
            comboBox1.Items.Add("Location");
            comboBox1.Items.Add("E-Mail");

            comboBox2.Items.Add("Phone");
            comboBox2.Items.Add("Location");
            comboBox2.Items.Add("E-Mail");
            GetList();
        }

       
        public DataTable GetList()
        {
            tbl.Clear();
            adtr = new SqlDataAdapter("Select * from Contacts",connection);
            adtr.Fill(tbl);
            dataGridView1.DataSource = tbl;
            foreach (DataRow row in tbl.Rows)
            {

                People.Add(new Contact(Int32.Parse(row["ID"].ToString()), row["Name"].ToString(), row["Surname"].ToString(), row["Company"].ToString(), new Information(row["InfoType"].ToString(), row["Info"].ToString())));
                          
            }
            return tbl;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            button2.Enabled = false;
            
            event_checker = false;

            if (e.RowIndex != -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Surname"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["Company"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["InfoType"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["Info"].Value.ToString();


                selected_row = e.RowIndex;

                if (textBox1.Text != "")
                {
                    button3.Enabled = true;
                    button1.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                    button1.Enabled = false;
                }

                event_checker = true;



            }

           

         
              
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == 0)
            {
                connection.Open();
            }

            string sql = "update Contacts set Name=@name,Surname=@surname,Company=@company,InfoType=@infotype,Info=@info where ID=@id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@name", textBox2.Text);

            cmd.Parameters.AddWithValue("@Surname", textBox3.Text);

            cmd.Parameters.AddWithValue("@company", textBox7.Text);

            cmd.Parameters.AddWithValue("@infotype", comboBox1.Text);

            cmd.Parameters.AddWithValue("@info", textBox8.Text);
      
            cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[selected_row].Cells["ID"].Value.ToString());

            cmd.ExecuteNonQuery();
        
            connection.Close();

            GetList();

            MessageBox.Show("Person succesfully edited.");

            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!event_checker | textbox1flag)
                return;
            else
            {
                if (textBox1.Text != dataGridView1.Rows[selected_row].Cells["ID"].Value.ToString())
                {
                    MessageBox.Show("You can not change the ID.");
                    textBox1.Text = dataGridView1.Rows[selected_row].Cells["ID"].Value.ToString();
                }
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!event_checker)
                return;
            else
            {
                if (textBox2.Text != dataGridView1.Rows[selected_row].Cells["Name"].Value.ToString())
                {
                    button2.Enabled = true;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!event_checker)
                return;
            else
            {
                if (textBox3.Text != dataGridView1.Rows[selected_row].Cells["Surname"].Value.ToString())
                {
                    button2.Enabled = true;
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            if (!event_checker)
                return;
            else
            {
                if (textBox8.Text != dataGridView1.Rows[selected_row].Cells["Info"].Value.ToString())
                {
                    button2.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (connection.State == 0)
            {
                connection.Open();
            }

            string sql = "delete from Contacts where ID=@id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[selected_row].Cells["ID"].Value.ToString());

            cmd.ExecuteNonQuery();

            connection.Close();

            GetList();

            MessageBox.Show("Person succesfully deleted.");

            button3.Enabled = false;

            textbox1flag = true;
            event_checker = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            textbox1flag = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (connection.State == 0)
            {
                connection.Open();
            }

            
            if(textBox5.Text!="" && textBox4.Text != "" && textBox9.Text != "" && comboBox2.Text != "")
            {
                string sql = "insert into Contacts (name,surname,company,InfoType,Info) VALUES (@val1, @val2, @val3,@val4,@val5)";

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@val1", textBox5.Text);

                cmd.Parameters.AddWithValue("@val2", textBox4.Text);

                cmd.Parameters.AddWithValue("@val3", textBox10.Text);

                cmd.Parameters.AddWithValue("@val4", comboBox2.Text);

                cmd.Parameters.AddWithValue("@val5", textBox9.Text);

                cmd.ExecuteNonQuery();

                connection.Close();

                GetList();

                MessageBox.Show("Person succesfully added.");

                textBox5.Text = "";
                textBox4.Text = "";
                comboBox2.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
            }
            else
            {
                MessageBox.Show("Please fill the all areas.");
            }

          

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!event_checker)
                return;
            else
            {
                if (comboBox1.Text != dataGridView1.Rows[selected_row].Cells["InfoType"].Value.ToString())
                {
                    button2.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Visible == true)
            {
                dataGridView1.Visible = false;
                label2.Visible = false;

                label10.Visible = true;
                textBox6.Visible = true;

                textBox6.Text = findPersonByID(Int32.Parse(dataGridView1.Rows[selected_row].Cells["ID"].Value.ToString()),People).ToString();

                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;

                button1.Text = "Back to Normal View";



            }
            else
            {
                dataGridView1.Visible = true;
                label2.Visible = true;

                label10.Visible = false;
                textBox6.Visible = false;
                textBox6.Text = "";


                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;

                button1.Text = "Get Person Report";
            }
           
        }

        public Contact findPersonByID(int ID, List<Contact> People2)
        {
            Contact p = null;
            
            for (int i = 0; i < People2.Count; i++)
            {
                if (ID == People2[i].ID)
                {
                    p = People2[i];
                    break;
                }
                    
            }
            return p;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!event_checker)
                return;
            else
            {
                if (textBox7.Text != dataGridView1.Rows[selected_row].Cells["Company"].Value.ToString())
                {
                    button2.Enabled = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report r = new Report(People);


            dataGridView1.Visible = false;
            label2.Visible = false;

            label10.Visible = true;
            textBox6.Visible = true;

            textBox6.Text = r.getReportasString();

            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            button1.Text = "Back to Normal View";
            
        }
    }
}
