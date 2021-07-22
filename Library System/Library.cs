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

namespace Library_System
{
    public partial class Library : Form
    {
        SqlDataReader sqlDataReader;
        public Library()
        {
            InitializeComponent();
            customizeDesign();
            CombosubjectFill();
            ComboclassFill();
        }

        SqlConnection con = new SqlConnection("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=shule;Integrated Security=True;");
        public void CombosubjectFill()
        {
            // sqlConnection = new SqlConnection(connStr);
            string cmdStr = " SELECT *  FROM Subject";
            SqlCommand sqlCommand = new SqlCommand(cmdStr, con);
            try
            {

                con.Open();

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    string sName = sqlDataReader["SubjectDescription"].ToString();

                    txtlibrarySubjects.Items.Add(sName);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        public void ComboclassFill()
        {


            string cmdStr = " SELECT *  FROM Classes";
            SqlCommand sqlCommand = new SqlCommand(cmdStr, con);
            try
            {

                con.Open();

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    string sName = sqlDataReader["ClassName"].ToString();

                    guna2ComboBox2.Items.Add(sName);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }


        private void customizeDesign()
        {
            panelDropdownShelves.Visible = false;
            panelDropdownBooks.Visible = false;
            panelDropdownMagazines.Visible = false;


        }

        private void hideSubMenu()
        {
            if (panelDropdownShelves.Visible == true)
                panelDropdownShelves.Visible = false;
            if (panelDropdownBooks.Visible == true)
                panelDropdownBooks.Visible = false;
            if (panelDropdownMagazines.Visible == true)
                panelDropdownMagazines.Visible = false;





            //panelDropDown.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }







        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void MainDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Library_Load(object sender, EventArgs e)
        {
            guna2ComboBox2.Items.Insert(0, "..Select Class..");
            guna2ComboBox2.SelectedIndex = 0;

            txtlibrarySubjects.Items.Insert(0, "..Select Subject..");
            txtlibrarySubjects.SelectedIndex = 0;

            comboboxselectyear.Items.Insert(0, "..Select Year..");
            comboboxselectyear.SelectedIndex = 0;

            comboboxfilteritems.Items.Insert(0, "..Select Item..");
            comboboxfilteritems.SelectedIndex = 0;
            // panel5books.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            Shelves.Visible = false;
            main.Visible = true;
            Books.Visible = false;
            Users.Visible = false;
            magazines.Visible = false;
            RemoveShelves.Visible = false;
            BorrowMagazines.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Shelves.Visible = true;
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = false;
            magazines.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Shelves.Visible = false;
            main.Visible = false;
            Books.Visible = true;
            Users.Visible = false;
            magazines.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Shelves.Visible = false;
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = true;
            magazines.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Shelves.Visible = true;
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = false;
            magazines.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Shelves.Visible = false;
            main.Visible = false;
            Books.Visible = true;
            Users.Visible = false;
            magazines.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Shelves.Visible = false;
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = true;
            magazines.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }


        private void guna2Button7_Click(object sender, EventArgs e)
        {

            if (guna2TextBox6.Text != "")
            {
                // Calculate what day of the week is 14 days from Today.
                System.DateTime today = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(14, 0, 0, 0);
                System.DateTime answer = today.Add(duration);
                guna2DateTimePicker1.Value = answer;
                guna2DateTimePicker2.Value = DateTime.Now;
                try
                {
                    con.Open();
                    String selectQuery = "SELECT Book_ISBN,Tittle,Class From Books where Book_ISBN='" + guna2TextBox6.Text + "' AND Status ='Available'";
                    SqlCommand cmd = new SqlCommand(selectQuery, con);
                    SqlDataReader mdr = cmd.ExecuteReader();

                    if (mdr.Read())
                    {
                        guna2TextBox4.Text = mdr.GetValue(0).ToString();
                        guna2TextBox3.Text = mdr.GetValue(1).ToString();
                        guna2TextBox19.Text = mdr.GetValue(2).ToString();
                    }
                    else
                    {
                        MessageBox.Show("No such Book in Library");
                    }
                }
                catch (Exception emm)
                {
                    MessageBox.Show(emm.Message);
                }
                con.Close();
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && guna2TextBox4.Text != "" && guna2TextBox3.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("insert into Borrow_Books(AdmNo,Class,Reason,Book_ISBN,Tittle,Date_Borrow,Due_Date,Charges) values (@AdmNo,@Class,@Reason,@Book_ISBN,@Tittle,@Date_Borrow,@Due_Date,@Charges)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@AdmNo", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Class", guna2TextBox19.Text);
                    cmd.Parameters.AddWithValue("@Reason", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Book_ISBN", guna2TextBox4.Text);
                    cmd.Parameters.AddWithValue("@Tittle", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Date_Borrow", guna2DateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@Due_Date", guna2DateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Charges", guna2TextBox7.Text);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("UPDATE Books SET Status='Borrowed' Where Book_ISBN='" + guna2TextBox4.Text + "'", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Successfully Borrowed", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2TextBox1.Text = "";
                    guna2TextBox4.Text = "";
                    guna2TextBox3.Text = "";
                    guna2DateTimePicker2.Value = DateTime.Now;
                    guna2DateTimePicker1.Value = DateTime.Now;
                    guna2TextBox6.Text = "";
                }
                else
                {
                    MessageBox.Show("Kindly Check Student Details !!");
                }
            }
            catch (Exception ee2)
            {
                MessageBox.Show(ee2.Message);
            }
            con.Close();
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            System.DateTime today = guna2DateTimePicker2.Value;
            System.TimeSpan duration = new System.TimeSpan(14, 0, 0, 0);
            System.DateTime answer = today.Add(duration);
            guna2DateTimePicker1.Value = answer;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM Borrow_Books Where Reason='Borrow'";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView2.DataSource = t;
            con.Close();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox12.Text != "")
                {
                    con.Open();
                    String selectQuery = "SELECT AdmNo,Book_ISBN,Tittle,Date_Borrow,Due_Date From Borrow_Books where Book_ISBN='" + guna2TextBox12.Text + "'AND Reason='Borrow'";
                    SqlCommand cmd = new SqlCommand(selectQuery, con);
                    SqlDataReader mdr = cmd.ExecuteReader();

                    if (mdr.Read())
                    {
                        guna2TextBox11.Text = mdr.GetValue(0).ToString();
                        guna2TextBox9.Text = mdr.GetValue(1).ToString();
                        guna2TextBox10.Text = mdr.GetValue(2).ToString();
                        guna2DateTimePicker3.Text = mdr.GetValue(3).ToString();
                        guna2DateTimePicker4.Text = mdr.GetValue(4).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Book has not Been Borrowed Yet !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    con.Close();

                    if (guna2DateTimePicker4.Value > DateTime.Now)
                    {
                        guna2TextBox8.Text = 0.00.ToString();
                    }
                    else
                    {
                        //var time = guna2DateTimePicker4.Value - DateTime.Now.To();
                        DateTime StartTime = guna2DateTimePicker4.Value;
                        DateTime datenow = DateTime.Now;
                        TimeSpan span = datenow.Subtract(StartTime);
                        int totaldays;
                        totaldays = span.Days;
                        guna2TextBox8.Text = (5 * totaldays).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Enter Book ISBNto Search.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox11.Text != "" && guna2TextBox9.Text != "" && guna2TextBox10.Text != "" && guna2TextBox13.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Borrow_Books Set Reason ='" + guna2TextBox5.Text + "',Charges =('" + guna2TextBox13.Text + "'- Charges) where Book_ISBN = '" + guna2TextBox9.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Books SET Status='Available' Where Book_ISBN='" + guna2TextBox9.Text + "'", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Returned Successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2TextBox12.Text = "";
                    guna2TextBox11.Text = "";
                    guna2TextBox9.Text = "";
                    guna2TextBox10.Text = "";
                    guna2TextBox8.Text = 0.00.ToString();
                    guna2TextBox13.Text = "";
                }
                else
                {
                    MessageBox.Show("Search For a Book and Provide all Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ee1)
            {
                MessageBox.Show(ee1.Message);
                con.Close();
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM Borrow_Books Where Reason='Return'";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView2.DataSource = t;
            con.Close();
        }

        private void New_Books_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex != 0 && txtlibrarySubjects.SelectedIndex != 0 && guna2TextBox16.Text != "" && guna2TextBox17.Text != "" && guna2TextBox20.Text != "" && guna2TextBox15.Text != "" && guna2DateTimePicker11.Text != "")
            {
                String status = "Available";
                SqlCommand cmd = new SqlCommand("insert into Books(Class,Subject,Tittle,Author,Edition,Publication_Year,Publisher,Date_Received,Shelf_No,Status) values (@Class,@Subject,@Tittle,@Author,@Edition,@Publication_Year,@Publisher,@Date_Received,@Shelf_No,@Status)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Class", guna2ComboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@Subject", txtlibrarySubjects.Text);
                cmd.Parameters.AddWithValue("@Tittle", guna2TextBox16.Text);
                cmd.Parameters.AddWithValue("@Author", guna2TextBox17.Text);
                cmd.Parameters.AddWithValue("@Edition", guna2TextBox15.Text);
                cmd.Parameters.AddWithValue("@Publication_Year", guna2DateTimePicker11.Text);
                cmd.Parameters.AddWithValue("@Publisher", guna2TextBox21.Text);
                cmd.Parameters.AddWithValue("@Date_Received", guna2DateTimePicker5.Value);
                cmd.Parameters.AddWithValue("@Shelf_No", guna2TextBox20.Text);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.ExecuteNonQuery();

                MessageBox.Show("New Book Added to Shelf Successfully.");
                con.Close();
            }
            else
            {
                MessageBox.Show("Kindly check Books details.");
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM Books";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView2.DataSource = t;
            con.Close();
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {
            //con.Open();

            //SqlCommand cmd2 = new SqlCommand("IF Exists (Select Book_ISBN From Borrow_Books Where Book_ISBN ='" + guna2TextBox9.Text+ "' AND Reason = 'Borrow' )",con);
            //cmd2.ExecuteNonQuery();
            //MessageBox.Show("Book has not Been Returned");
            //con.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNShelfName.Text != "" && richTextBoxNshelfDescription.Text != "" && txtNShelfLocation.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("insert into Shelf(Shelf_Name,Shelf_Description,Shelf_Location) values (@Shelf_Name,@Shelf_Description,@Shelf_Location)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Shelf_Name", txtNShelfName.Text);
                    cmd.Parameters.AddWithValue("@Shelf_Description", richTextBoxNshelfDescription.Text);
                    cmd.Parameters.AddWithValue("@Shelf_Location", txtNShelfLocation.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("New Shelf Added  Successfully.");
                    txtNShelfName.Text = "";
                    richTextBoxNshelfDescription.Text = "";
                    txtNShelfLocation.Text = "";


                    con.Close();
                }
                else
                {
                    MessageBox.Show("Kindly check Shelf details.");
                }
            }
            catch (Exception ee3)
            {
                MessageBox.Show(ee3.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM Shelf";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            GridShelfs.DataSource = t;
            con.Close();
        }

        private void ReturnBooks_Click(object sender, EventArgs e)
        {

        }



        private void guna2Button3_Click(object sender, EventArgs e)
        {
            txtNShelfName.Text = "";
            richTextBoxNshelfDescription.Text = "";
            txtNShelfLocation.Text = "";
        }

        private void Books_Paint(object sender, PaintEventArgs e)
        {

        }

        private void assignTeachers_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {

            if (guna2TextBox25.Text != "")
            {
                // Calculate what day of the week is 14 days from Today.
                System.DateTime today = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(60, 0, 0, 0);
                System.DateTime answer = today.Add(duration);
                guna2DateTimePicker7.Value = answer;
                guna2DateTimePicker6.Value = DateTime.Now;
                try
                {
                    con.Open();
                    String selectQuery = "SELECT Book_ISBN,Tittle,Class From Books where Book_ISBN='" + guna2TextBox25.Text + "' and Status = 'Available'";
                    SqlCommand cmd = new SqlCommand(selectQuery, con);
                    SqlDataReader mdr = cmd.ExecuteReader();

                    if (mdr.Read())
                    {
                        guna2TextBox26.Text = mdr.GetValue(0).ToString();
                        guna2TextBox27.Text = mdr.GetValue(1).ToString();
                        guna2TextBox29.Text = mdr.GetValue(2).ToString();
                    }
                    else
                    {
                        MessageBox.Show("No such Book in Library");
                    }
                }
                catch (Exception emm)
                {
                    MessageBox.Show(emm.Message);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter Book Number To search.");
            }
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox28.Text != "" && guna2TextBox22.Text != "" && guna2TextBox29.Text != "" && guna2TextBox26.Text != "" && guna2TextBox27.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("insert into Assign_Books(Teacher_No,Teacher_Name,Class,Book_ISBN,Tittle,Reason,Date_Assign,Due_Date) values (@Teacher_No,@Teacher_Name,@Class,@Book_ISBN,@Tittle,@Reason,@Date_Assign,@Due_Date)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Teacher_No", guna2TextBox28.Text);
                    cmd.Parameters.AddWithValue("@Teacher_Name", guna2TextBox22.Text);
                    cmd.Parameters.AddWithValue("@Class", guna2TextBox29.Text);
                    cmd.Parameters.AddWithValue("@Book_ISBN", guna2TextBox26.Text);
                    cmd.Parameters.AddWithValue("@Tittle", guna2TextBox27.Text);
                    cmd.Parameters.AddWithValue("@Reason", guna2TextBox23.Text);
                    cmd.Parameters.AddWithValue("@Date_Assign", guna2DateTimePicker6.Value);
                    cmd.Parameters.AddWithValue("@Due_Date", guna2DateTimePicker7.Value);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Books SET Status='Available' Where Book_ISBN='" + guna2TextBox26.Text + "'", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Assign Successfully.");
                    guna2TextBox28.Text = "";
                    guna2TextBox22.Text = "";
                    guna2TextBox29.Text = "";
                    guna2TextBox26.Text = "";
                    guna2TextBox27.Text = "";

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Kindly check All details.");
                }
            }
            catch (Exception ee3)
            {
                MessageBox.Show(ee3.Message);
            }
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM Assign_Books";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView2.DataSource = t;
            con.Close();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            guna2TextBox28.Text = "";
            guna2TextBox22.Text = "";
            guna2TextBox29.Text = "";
            guna2TextBox26.Text = "";
            guna2TextBox27.Text = "";
            guna2TextBox25.Text = "";
        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
            Shelves.Visible = false;
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = false;
            magazines.Visible = true;
            BorrowMagazines.Visible = false;
        }

        private void label41_Click(object sender, EventArgs e)
        {
            Shelves.Visible = false;
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = false;
            magazines.Visible = true;
            BorrowMagazines.Visible = false;
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }





        private void guna2Button22_Click(object sender, EventArgs e)
        {

            if (guna2TextBox31.Text != "")
            {
                // Calculate what day of the week is 14 days from Today.
                System.DateTime today = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(5, 0, 0);
                System.DateTime answer = today.Add(duration);
                guna2DateTimePicker10.Value = answer;
                guna2DateTimePicker9.Value = DateTime.Now;
                try
                {
                    con.Open();
                    String selectQuery = "SELECT Magazinne_NO,Magazinne_Name From Magazinne where Magazinne_NO='" + guna2TextBox31.Text + "' ";
                    SqlCommand cmd = new SqlCommand(selectQuery, con);
                    SqlDataReader mdr = cmd.ExecuteReader();

                    if (mdr.Read())
                    {
                        guna2TextBox32.Text = mdr.GetValue(0).ToString();
                        guna2TextBox33.Text = mdr.GetValue(1).ToString();
                    }
                    else
                    {
                        MessageBox.Show("No such Magazinne in Library");
                    }
                }
                catch (Exception emm)
                {
                    MessageBox.Show(emm.Message);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter Magazinne Number in Library");
            }
        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox33.Text != "" && guna2TextBox32.Text != "")
                {
                    string status = "Borrowed";
                    SqlCommand cmd = new SqlCommand("insert into Magazinne_Borrow(Magazinne_Name,Magazinne_No,Date_Borrow,Due_Date,Status) values (@Magazinne_Name,@Magazinne_No,@Date_Borrow,@Due_Date,@Status)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Magazinne_Name", guna2TextBox33.Text);
                    cmd.Parameters.AddWithValue("@Magazinne_NO", guna2TextBox32.Text);
                    cmd.Parameters.AddWithValue("@Date_Borrow", guna2DateTimePicker9.Value);
                    cmd.Parameters.AddWithValue("@Due_Date", guna2DateTimePicker10.Value);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Magazinne Borrowed Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2TextBox31.Text = "";
                    guna2TextBox33.Text = "";
                    guna2TextBox32.Text = "";
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Provide all Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception em3)
            {
                MessageBox.Show(em3.Message);
            }
        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            guna2TextBox31.Text = "";
            guna2TextBox33.Text = "";
            guna2TextBox32.Text = "";
        }

        private void guna2Button27_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM Magazinne_Borrow Where Status='Borrowed'";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView3.DataSource = t;
            con.Close();
        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM Magazinne";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView3.DataSource = t;
            con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            string query = "SELECT * FROM Borrow_Books Where Reason = 'Borrow'";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView4.DataSource = t;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            con.Open();
            string query = "SELECT * FROM Books where Status='Available' ";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView4.DataSource = t;
            con.Close();

        }



        private void button7_Click(object sender, EventArgs e)
        {

            con.Open();
            string query = "SELECT * FROM Shelf ";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView4.DataSource = t;
            con.Close();
        }

        private void button1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {

            showSubMenu(panelDropdownShelves);
            //Shelves.Visible = true;
            //Shelves.BringToFront();
            //main.Visible = false;
            //Books.Visible = false;
            //Users.Visible = false;
            //magazines.Visible = false;
            //RemoveShelves.Visible = false;
            //BorrowMagazines.Visible = false;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button31_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDropdownBooks);

            Shelves.Visible = false;
            main.Visible = false;
            Books.Visible = true;
            Users.Visible = false;
            magazines.Visible = false;
            RemoveShelves.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void btnMagazines_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDropdownMagazines);

            //Shelves.Visible = false;
            //main.Visible = false;
            //Books.Visible = false;
            //Users.Visible = false;
            //magazines.Visible = true;
            //RemoveShelves.Visible = false;
            //BorrowMagazines.Visible = false;
        }

        private void btnLusers_Click(object sender, EventArgs e)
        {
            Shelves.Visible = false;
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = true;
            magazines.Visible = false;
            RemoveShelves.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //panel5books.Visible = false;
            // this.WindowState = FormWindowState.Maximized;
            Shelves.Visible = false;
            main.Visible = true;
            Books.Visible = false;
            Users.Visible = false;
            magazines.Visible = false;
            RemoveShelves.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void btnAvailableShelves_Click(object sender, EventArgs e)
        {
            // panel5shelf.Visible = false;
            con.Open();
            string query = "SELECT * FROM Shelf ";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView4.DataSource = t;
            con.Close();
        }

        private void btnUnreturnedBooks_Click(object sender, EventArgs e)
        {
            // panel5books.Visible = false;
            con.Open();
            string query = "SELECT * FROM Borrow_Books Where Reason = 'Borrow'";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView4.DataSource = t;
            con.Close();
        }

        private void btnAvailableBooks_Click(object sender, EventArgs e)
        {
            // panel5books.Visible = false;
            con.Open();
            string query = "SELECT * FROM Books where Status='Available' ";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView4.DataSource = t;
            con.Close();

        }

        private void headerside_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {
            // showSubMenu(panelDropdownShelves);
            Shelves.Visible = true;
            Shelves.BringToFront();
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = false;
            magazines.Visible = false;
            RemoveShelves.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void btnRemoveShelves_Click(object sender, EventArgs e)
        {
            RemoveShelves.Visible = true;
            RemoveShelves.BringToFront();
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = false;
            magazines.Visible = false;
            Shelves.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void RemoveShelves_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShelfRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtShelfSearch.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Shelf WHERE Shelf_NO='" + txtShelfNumber.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Shelf Removed Successfully !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShelfSearch.Text = "";
                    txtShelfNumber.Text = "";
                    txtShelfName.Text = "";
                    txtShelfDescription.Text = "";
                    txtShelfLocation.Text = "";
                }
                else
                {
                    MessageBox.Show("Please Provide Shelf Number!");
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
            con.Close();
        }


        private void guna2TextBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchShelf_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtShelfSearch.Text != "")
                {
                    con.Open();
                    String selectQuery = "SELECT Shelf_No,Shelf_Name,Shelf_Description,Shelf_Location From Shelf where Shelf_NO='" + txtShelfSearch.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectQuery, con);
                    SqlDataReader mdr = cmd.ExecuteReader();

                    if (mdr.Read())
                    {
                        txtShelfNumber.Text = mdr.GetValue(0).ToString();
                        txtShelfName.Text = mdr.GetValue(1).ToString();
                        txtShelfDescription.Text = mdr.GetValue(2).ToString();
                        txtShelfLocation.Text = mdr.GetValue(3).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Shelf does not Exists !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Enter Shelf Number to Search.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ee4)
            {
                MessageBox.Show(ee4.Message);
            }
        }

        private void btnShelfReset_Click(object sender, EventArgs e)
        {
            txtShelfNumber.Text = "";
            txtShelfName.Text = "";
            txtShelfDescription.Text = "";
            txtShelfLocation.Text = "";
            txtShelfSearch.Text = "";
        }

        private void guna2TextBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtlibrarySubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string querry = "Select * FROM Shelf where Shelf_Name='" + txtlibrarySubjects.SelectedItem + "'";

                SqlCommand cmd = new SqlCommand(querry, con);
                con.Open();
                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    guna2TextBox20.Text = sqlDataReader["Shelf_No"].ToString();

                }

            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);

            }
            con.Close();
        }

        private void btnMagazineSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMagazine.Text != "" && txtMagazineDescription.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("insert into Magazinne(Magazinne_Name,Magazinne_Description,Date_Received) values (@Magazinne_Name,@Magazinne_Description,@Date_Received)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Magazinne_Name", txtMagazine.Text);
                    cmd.Parameters.AddWithValue("@Magazinne_Description", txtMagazineDescription.Text);
                    cmd.Parameters.AddWithValue("@Date_Received", guna2DateTimePicker12.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Magazinne Received Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Provide all Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception em3)
            {
                MessageBox.Show(em3.Message);
            }
        }

        private void btnMagazineReset_Click(object sender, EventArgs e)
        {
            txtMagazine.Text = "";
            txtMagazineDescription.Text = "";
        }

        private void guna2TextBox31_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {

        }

        private void BorrowMagazines_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnViewMagazines_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM Magazinne";
            SqlDataAdapter d = new SqlDataAdapter(query, con);
            DataTable t = new DataTable();
            d.Fill(t);
            dataGridView3.DataSource = t;
            con.Close();
        }

        private void guna2Button35_Click(object sender, EventArgs e)
        {
            BorrowMagazines.Visible = true;
            BorrowMagazines.BringToFront();
        }

        private void guna2Button34_Click(object sender, EventArgs e)
        {
            Shelves.Visible = false;
            main.Visible = false;
            Books.Visible = false;
            Users.Visible = false;
            magazines.Visible = true;
            RemoveShelves.Visible = false;
            BorrowMagazines.Visible = false;
        }

        private void magazines_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

