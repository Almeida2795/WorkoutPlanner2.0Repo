using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
using System.Windows.Shapes;

namespace WorkoutPlanner2._0
{
    /// <summary>
    /// Interaction logic for PushPage.xaml
    /// </summary>
    public partial class PushPage : Window
    {
        #region Variables
        int workoutType { get; set; } = 1;

        //Creates a new Database Object
        Database pushDB = new Database();

        //Creates a string to store the Database file location
        private const string workoutPlannerDBConnectionString = @"Data Source=workoutDB2.db;Version=3;";

        // Initialises a connection to the Database based on the path which is stored as the string 'SimplyRugbyDBConnectionString'.
        SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

        #endregion

        public PushPage()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        #region DataGrid Display
        private void UpdateDataGrid()
        {
            // Initialises a connection to the Database based on the path which is stored as the string 'SimplyRugbyDBConnectionString'.
            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            // try-catch incase there are any issues with querying the database then loading the information
            // Into a datagrid from the database
            try
            {   // A string set up to store a database query.
                string query = "SELECT Date AS 'Date', Ex1 AS 'Ex1', Ex2 AS 'Ex2', Ex3 'Ex3', Ex4 AS 'Ex4', Ex5 AS 'Ex5' FROM Push";

                // Calls the UpdateDatabaseView() method from the Database class and passes the database connection and query
                // returns a SQLiteDataAdapter value and stores it as 'dataAdapter'
                SQLiteDataAdapter dataAdapter = pushDB.UpdateDatabaseView(sqliteConnection, query);

                // Instantiates a new object of the DataTable Class and passes the name of the table to be viewed.
                DataTable dataTable = new DataTable("Push");

                // Calls the Fill() method from the SQLiteDataAdapter class and passes the object of DataTable to it.
                dataAdapter.Fill(dataTable);

                // Sets the MembersDatabaseDataGrid.ItemsSource property to the dataTable's default view
                dgPush.ItemsSource = dataTable.DefaultView;

                // Calls the Update() method from the SQLiteDataAdapter class and passes the object of DataTable to it.
                dataAdapter.Update(dataTable);
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // Calls the Close() method from the SQLiteConnection class to close the connection with the database
            sqliteConnection.Close();
        }
        #endregion

        #region Button Controls
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWorkout addPage = new AddWorkout(workoutType);
            addPage.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditWorkoutPage editPage = new EditWorkoutPage(workoutType);
            editPage.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteWorkoutPage deletePage = new DeleteWorkoutPage(workoutType);
            deletePage.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        #endregion
    }
}
