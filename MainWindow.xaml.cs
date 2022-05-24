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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kamal\\OneDrive\\Dokumente\\Buhl_DataDB.mdf;Integrated Security=True;Connect Timeout=30");
        public void ShowData()
        {
            SqlCommand cmd = new SqlCommand(@"Select * from [Table] ", conn );
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataGrid dg = new DataGrid();
            dg.ItemsSource = ds.Tables;
            
            conn.Close();
        }
        public void InsertData()
        {
            

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //InsertData();
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kamal\\OneDrive\\Dokumente\\New_PersonDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"Insert Into  [Table] values (@Name, @Surnmae", conn);
            cmd.Parameters.AddWithValue("@Name", txt_name.Text);
            cmd.Parameters.AddWithValue("@Surname", txt_surname.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("success");
        }
        public void ClearData()
        {
            txt_name.Clear();
            txt_surname.Clear();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"Select * from [Table] ", conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataGrid dg = new DataGrid();
            dg.ItemsSource = ds.Tables;

            conn.Close();
        }
    }
}
