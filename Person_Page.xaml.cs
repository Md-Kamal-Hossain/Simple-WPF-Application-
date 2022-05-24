using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;


namespace Person_WPF
{
    /// <summary>
    /// Interaction logic for Person_Page.xaml
    /// </summary>
    public partial class Person_Page : Page
    {
        public Person_Page()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kamal\\OneDrive\\Dokumente\\New_PersonDB.mdf;Integrated Security=True;Connect Timeout= 30");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //InsertData();
            //SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kamal\\OneDrive\\Dokumente\\New_PersonDB.mdf;Integrated Security=True;Connect Timeout= 30");

            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand(@"Insert Into  [Table] values ( @Name, @Surname,@StreetName,@HouseNo,@PostCode,@City,@Contact)", conn);
                cmd.Parameters.AddWithValue("@Name", txt_name.Text);
                cmd.Parameters.AddWithValue("@Surname", txt_surname.Text);
                cmd.Parameters.AddWithValue("@StreetName", txt_streetname.Text);
                cmd.Parameters.AddWithValue("@HouseNo", txt_houseno.Text);
                cmd.Parameters.AddWithValue("@PostCode", txt_postcode.Text);
                cmd.Parameters.AddWithValue("@City", txt_city.Text);
                cmd.Parameters.AddWithValue("@Contact", txt_contact.Text);
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
                ClearTxtbox();
                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("Enter a name");
            }
            ReadData();
            ClearTxtbox();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            
        }

        private bool IsValid()
        {
           if(txt_name.Name == String.Empty)
            {
                MessageBox.Show("Please enter a name", "Select?", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
           return true;
        }

        private void ClearTxtbox()
        {
            txt_city.Clear();
            txt_contact.Clear();
            txt_houseno.Clear();
            txt_name.Clear();
            txt_postcode.Clear();
            txt_streetname.Clear();
            txt_surname.Clear();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
     
           //Show




            ReadData();



        }
        private void ReadData()
        {

            SqlCommand cmd = new SqlCommand(@"Select * from [Table]", conn);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable table = new DataTable();
            conn.Open();
            adapter.Fill(table);
            dg.ItemsSource = table.DefaultView;
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Delete 

            
            SqlCommand cmd = new SqlCommand("Delete  from [Table] where Name=@Name", conn);

            cmd.Parameters.AddWithValue("@Name", txt_name.Text);
            cmd.Parameters.AddWithValue("@Surname", txt_surname.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Edit
            
          try
            {
                //SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kamal\\OneDrive\\Dokumente\\New_PersonDB.mdf;Integrated Security=True;Connect Timeout= 30");
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                adapter.Update(table);

             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"error",MessageBoxButton.OK,MessageBoxImage.Information);
            }


        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }
    }
}
