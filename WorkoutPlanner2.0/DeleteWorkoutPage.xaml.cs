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
    /// Interaction logic for DeleteWorkoutPage.xaml
    /// </summary>
    public partial class DeleteWorkoutPage : Window
    {
        #region Variables
        //Creates a string to store the Database file location
        private const string workoutPlannerDBConnectionString = @"Data Source=workoutDB2.db;Version=3;";

        // Initialises a connection to the Database based on the path which is stored as the string 'SimplyRugbyDBConnectionString'.
        SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

        //workout type used later to populate correct list of exercises
        public int workoutType;
        public string workoutName;

        string dateToDelete;

        //Creates a new Database object
        Database deleteWorkoutDB = new Database();

        #endregion
        public DeleteWorkoutPage(int workoutType)
        {
            InitializeComponent();

            this.workoutType = workoutType;

            PopulateComboBoxes();
        }

        #region Populate Combo Boxes

        private void PopulateComboBoxes()
        {
            //First of all clear combo box to avoid duplicates
            cbDates.Items.Clear();

            //switch to populate the combo box with the correct list of workout dates according to the workout type
            switch (this.workoutType)
            {
                case 0:
                    workoutName = "Pull";
                    populatePullDates();
                    break;
                case 1:
                    workoutName = "Push";
                    populatePushDates();
                    break;
                case 2:
                    workoutName = "Legs";
                    populateLegsDates();
                    break;
            }
        }


        private void populatePullDates()
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            // A string set up to store a database query.
            string query = "SELECT * FROM Pull ORDER BY Date ASC";

            // try-catch incase there are any issues with retrieving values from the database
            // And then adding the values to the combobox 'MembershipNoComboBox'
            try
            {
                // Calls the method SetUpDataReader() sends the database connection and the string 'query'
                // Returns with the values from the query and stores these values as a SQLiteDataReader called dataReader
                SQLiteDataReader dataReader = deleteWorkoutDB.SetUpDataReader(sqliteConnection, query);

                // A while loop, which loops while there are values in the dataReader to be read
                while (dataReader.Read())
                {
                    // Adds each value for 'Username' that is read, to the combobox called 'AccountComboBox'
                    cbDates.Items.Add(dataReader["Date"]);
                }

                // Calls the Close method from the SQLiteDataReader class to finish reading.
                dataReader.Close();
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

        private void populatePushDates()
        {

            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            // A string set up to store a database query.
            string query = "SELECT * FROM Push ORDER BY Date ASC";

            // try-catch incase there are any issues with retrieving values from the database
            // And then adding the values to the combobox 'MembershipNoComboBox'
            try
            {
                // Calls the method SetUpDataReader() sends the database connection and the string 'query'
                // Returns with the values from the query and stores these values as a SQLiteDataReader called dataReader
                SQLiteDataReader dataReader = deleteWorkoutDB.SetUpDataReader(sqliteConnection, query);

                // A while loop, which loops while there are values in the dataReader to be read
                while (dataReader.Read())
                {
                    // Adds each value for 'Username' that is read, to the combobox called 'AccountComboBox'
                    cbDates.Items.Add(dataReader["Date"]);
                }

                // Calls the Close method from the SQLiteDataReader class to finish reading.
                dataReader.Close();
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
        private void populateLegsDates()
        {

            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            // A string set up to store a database query.
            string query = "SELECT * FROM Legs ORDER BY Date ASC";

            // try-catch incase there are any issues with retrieving values from the database
            // And then adding the values to the combobox 'MembershipNoComboBox'
            try
            {
                // Calls the method SetUpDataReader() sends the database connection and the string 'query'
                // Returns with the values from the query and stores these values as a SQLiteDataReader called dataReader
                SQLiteDataReader dataReader = deleteWorkoutDB.SetUpDataReader(sqliteConnection, query);

                // A while loop, which loops while there are values in the dataReader to be read
                while (dataReader.Read())
                {
                    // Adds each value for 'Username' that is read, to the combobox called 'AccountComboBox'
                    cbDates.Items.Add(dataReader["Date"]);
                }

                // Calls the Close method from the SQLiteDataReader class to finish reading.
                dataReader.Close();
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

        #region Populate Grid

        //Methods to update datagrid View
        private void UpdateDataGrid(string selectedDate)
        {
            switch (workoutType)
            {
                case 0:

                    // try-catch incase there are any issues with querying the database then loading the information
                    // Into a datagrid from the database
                    try
                    {   // A string set up to store a database query.
                        string query = "SELECT Date AS 'Date', Ex1 AS 'Ex1', Ex2 AS 'Ex2', Ex3 AS 'Ex3', Ex4 AS 'Ex4', Ex5 AS 'Ex5' FROM Pull WHERE Date = '" + selectedDate + "' ";

                        // Calls the UpdateDatabaseView() method from the Database class and passes the database connection and query
                        // returns a SQLiteDataAdapter value and stores it as 'dataAdapter'
                        SQLiteDataAdapter dataAdapter = deleteWorkoutDB.UpdateDatabaseView(sqliteConnection, query);

                        // Instantiates a new object of the DataTable Class and passes the name of the table to be viewed.
                        DataTable dataTable = new DataTable("Pull");

                        // Calls the Fill() method from the SQLiteDataAdapter class and passes the object of DataTable to it.
                        dataAdapter.Fill(dataTable);

                        // Sets the MembersDatabaseDataGrid.ItemsSource property to the dataTable's default view
                        dgSelected.ItemsSource = dataTable.DefaultView;

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
                    break;
            }

        }

        #endregion


        #region Button Controls
        private void cbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //method to store the date selected and display the selected workout in the data grid.
            if (cbDates.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the date of the workout you want to delete");
            }
            else
            {
                dateToDelete = cbDates.SelectedItem.ToString();
                UpdateDataGrid(dateToDelete);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //runs delete record method with 3 arguments
            try
            {
                deleteWorkoutDB.DeleteRecord(sqliteConnection, dateToDelete, workoutName);
                MessageBox.Show("Record Successfuly deleted");
                cbDates.SelectedIndex = -1;
                dgSelected.ItemsSource = null;
                PopulateComboBoxes();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            switch (workoutType)
            {
                case 0:
                    PullPage pullPage = new PullPage();
                    pullPage.Show();
                    this.Close();
                    break;
                case 1:
                    PushPage pushPage = new PushPage();
                    pushPage.Show();
                    this.Close();
                    break;
                case 2:
                    LegsPage legsPage = new LegsPage();
                    legsPage.Show();
                    this.Close();
                    break;
            }
        }
        #endregion


    }
}
