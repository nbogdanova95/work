using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace homework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        //ObservableCollection<Department> departments = new ObservableCollection<Department>();
        //Random rnd = new Random();
       
        public MainWindow()
        {
            InitializeComponent();
            //Empl_list();
            //Dep_list();

            var connectionString = ConfigurationManager.ConnectionStrings["Data_connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT ID, Name, SurName, DepId FROM Employee", connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataGrid.DataContext = dataTable.DefaultView;
            command = new SqlCommand("DELETE FROM Employee WHERE ID = @ID", connection);
            var updcomand = new SqlCommand("UPDATE Employee", connection);
            command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            adapter.DeleteCommand = command;
            adapter.UpdateCommand = updcomand;

            Delete_temp.Click += (sender, args) =>
            {
                DataRowView rowView = (DataRowView)DataGrid.SelectedItem;
                rowView.Row.Delete();
                adapter.Update(dataTable);
            };

            Save_temp.Click += (sender, args) =>
            {
                command = new SqlCommand(@"UPDATE Employee SET Name = @Name,
                                           SurName = @SurName, Department = @DepId 
                                               WHERE ID = @ID", connection);

                command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
                command.Parameters.Add("@SurName", SqlDbType.NVarChar, -1, "SurName");
                command.Parameters.Add("@DepId", SqlDbType.Int, -1, "DepId");
                

                SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

                param.SourceVersion = DataRowVersion.Original;

                adapter.UpdateCommand = command;
                adapter.Update(dataTable);
                MessageBox.Show("Изменения сохранены в БД");

            };
        }

    

    //public void Dep_list()
    //    {
    //        departments.Add(new Department(1,"Google"));
    //        departments.Add(new Department(2, "Apple"));
    //        departments.Add(new Department(3,"Microsoft"));
    //        lstview_dep.ItemsSource = departments;
    //    }

    //    public void Empl_list()
    //    {
    //        employees.Add(new Employee(1,"Vasya","Mishin", 1));
    //        employees.Add(new Employee(2, "Petya","Orlov",1));
    //        employees.Add(new Employee(3, "Igor","Popov",3));
    //        lstview.ItemsSource = employees;

    //    }

    //    private void But_name_dep_Click(object sender, RoutedEventArgs e)
    //    {
    //        departments.Add(new Department(rnd.Next(0, 20), txt_dep_name.Text));
    //    }

    //    private void But_name_emp_Click(object sender, RoutedEventArgs e)
    //    {
    //        employees.Add(new Employee(rnd.Next(0, 20), txt_name.Text, txt_surname.Text, int.Parse(txt_dep.Text)));
    //    }
    }
}
