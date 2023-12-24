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
    /// Interaction logic for EditWorkoutPage.xaml
    /// </summary>
    public partial class EditWorkoutPage : Window
    {
        #region Variables
        //Creates a string to store the Database file location
        private const string workoutPlannerDBConnectionString = @"Data Source=workoutDB2.db;Version=3;";

        // Initialises a connection to the Database based on the path which is stored as the string 'SimplyRugbyDBConnectionString'.
        SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

        //workout type used later to populate correct list of exercises
        public int workoutType;
        public string workoutName;

        string dateToEdit;

        //Creates a new Database object
        Database editWorkoutDB = new Database();

        //Creates a new workout object
        Workout workout = new Workout();

        #endregion

        public EditWorkoutPage(int workoutType)
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
                    PopulatePullExList();
                    break;
                case 1:
                    workoutName = "Push";
                    populatePushDates();
                    PopulatePushExList();
                    break;
                case 2:
                    workoutName = "Legs";
                    populateLegsDates();
                    PopulateLegsExList();
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
                SQLiteDataReader dataReader = editWorkoutDB.SetUpDataReader(sqliteConnection, query);

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
                SQLiteDataReader dataReader = editWorkoutDB.SetUpDataReader(sqliteConnection, query);

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
                SQLiteDataReader dataReader = editWorkoutDB.SetUpDataReader(sqliteConnection, query);

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

        private void PopulatePullExList()
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            // A string set up to store a database query.
            string query = "SELECT * FROM PullExercises ORDER BY Exercises ASC";

            // try-catch incase there are any issues with retrieving values from the database
            // And then adding the values to the combobox 'MembershipNoComboBox'
            try
            {
                // Calls the method SetUpDataReader() sends the database connection and the string 'query'
                // Returns with the values from the query and stores these values as a SQLiteDataReader called dataReader
                SQLiteDataReader dataReader = editWorkoutDB.SetUpDataReader(sqliteConnection, query);

                // A while loop, which loops while there are values in the dataReader to be read
                while (dataReader.Read())
                {
                    // Adds each value for 'Username' that is read, to the combobox called 'AccountComboBox'
                    cbEx1.Items.Add(dataReader["Exercises"]);
                    cbEx2.Items.Add(dataReader["Exercises"]);
                    cbEx3.Items.Add(dataReader["Exercises"]);
                    cbEx4.Items.Add(dataReader["Exercises"]);
                    cbEx5.Items.Add(dataReader["Exercises"]);
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
        private void PopulatePushExList()
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            // A string set up to store a database query.
            string query = "SELECT * FROM PushExercises ORDER BY Exercises ASC";

            // try-catch incase there are any issues with retrieving values from the database
            // And then adding the values to the combobox 'MembershipNoComboBox'
            try
            {
                // Calls the method SetUpDataReader() sends the database connection and the string 'query'
                // Returns with the values from the query and stores these values as a SQLiteDataReader called dataReader
                SQLiteDataReader dataReader = editWorkoutDB.SetUpDataReader(sqliteConnection, query);

                // A while loop, which loops while there are values in the dataReader to be read
                while (dataReader.Read())
                {
                    // Adds each value for 'Username' that is read, to the combobox called 'AccountComboBox'
                    cbEx1.Items.Add(dataReader["Exercises"]);
                    cbEx2.Items.Add(dataReader["Exercises"]);
                    cbEx3.Items.Add(dataReader["Exercises"]);
                    cbEx4.Items.Add(dataReader["Exercises"]);
                    cbEx5.Items.Add(dataReader["Exercises"]);
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
        private void PopulateLegsExList()
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            // A string set up to store a database query.
            string query = "SELECT * FROM LegsExercises ORDER BY Exercises ASC";

            // try-catch incase there are any issues with retrieving values from the database
            // And then adding the values to the combobox 'MembershipNoComboBox'
            try
            {
                // Calls the method SetUpDataReader() sends the database connection and the string 'query'
                // Returns with the values from the query and stores these values as a SQLiteDataReader called dataReader
                SQLiteDataReader dataReader = editWorkoutDB.SetUpDataReader(sqliteConnection, query);

                // A while loop, which loops while there are values in the dataReader to be read
                while (dataReader.Read())
                {
                    // Adds each value for 'Username' that is read, to the combobox called 'AccountComboBox'
                    cbEx1.Items.Add(dataReader["Exercises"]);
                    cbEx2.Items.Add(dataReader["Exercises"]);
                    cbEx3.Items.Add(dataReader["Exercises"]);
                    cbEx4.Items.Add(dataReader["Exercises"]);
                    cbEx5.Items.Add(dataReader["Exercises"]);
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

        #region Populate Data Grid

        private void UpdateDataGrid(string dateToEdit)
        {
            //Checks workoutType to select which populate method to use
            switch(workoutType)
            {
                case 0:
                    PopulatePullEx(dateToEdit);
                    break;
                case 1:
                    PopulatePushEx(dateToEdit);
                    break;
                case 2:
                    PopulateLegsEx(dateToEdit);
                    break;
            }    
        }

        private void PopulatePullEx(string dateToEdit)
        {
            // try-catch incase there are any issues with querying the database then loading the information
            // Into a datagrid from the database
            try
            {   // A string set up to store a database query.
                string query = "SELECT Date AS 'Date', Ex1 AS 'Ex1', Ex2 AS 'Ex2', Ex3 AS 'Ex3', Ex4 AS 'Ex4', Ex5 AS 'Ex5' FROM Pull WHERE Date = '" + dateToEdit + "' ";

                // Calls the UpdateDatabaseView() method from the Database class and passes the database connection and query
                // returns a SQLiteDataAdapter value and stores it as 'dataAdapter'
                SQLiteDataAdapter dataAdapter = editWorkoutDB.UpdateDatabaseView(sqliteConnection, query);

                // Instantiates a new object of the DataTable Class and passes the name of the table to be viewed.
                DataTable dataTable = new DataTable("Pull");

                // Calls the Fill() method from the SQLiteDataAdapter class and passes the object of DataTable to it.
                dataAdapter.Fill(dataTable);

                // Sets the MembersDatabaseDataGrid.ItemsSource property to the dataTable's default view
                dgEdit.ItemsSource = dataTable.DefaultView;

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

        private void PopulatePushEx(string dateToEdit)
        {
            // try-catch incase there are any issues with querying the database then loading the information
            // Into a datagrid from the database
            try
            {   // A string set up to store a database query.
                string query = "SELECT Date AS 'Date', Ex1 AS 'Ex1', Ex2 AS 'Ex2', Ex3 AS 'Ex3', Ex4 AS 'Ex4', Ex5 AS 'Ex5' FROM Push WHERE Date = '" + dateToEdit + "' ";

                // Calls the UpdateDatabaseView() method from the Database class and passes the database connection and query
                // returns a SQLiteDataAdapter value and stores it as 'dataAdapter'
                SQLiteDataAdapter dataAdapter = editWorkoutDB.UpdateDatabaseView(sqliteConnection, query);

                // Instantiates a new object of the DataTable Class and passes the name of the table to be viewed.
                DataTable dataTable = new DataTable("Push");

                // Calls the Fill() method from the SQLiteDataAdapter class and passes the object of DataTable to it.
                dataAdapter.Fill(dataTable);

                // Sets the MembersDatabaseDataGrid.ItemsSource property to the dataTable's default view
                dgEdit.ItemsSource = dataTable.DefaultView;

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

        private void PopulateLegsEx(string dateToEdit)
        {
            // try-catch incase there are any issues with querying the database then loading the information
            // Into a datagrid from the database
            try
            {   // A string set up to store a database query.
                string query = "SELECT Date AS 'Date', Ex1 AS 'Ex1', Ex2 AS 'Ex2', Ex3 AS 'Ex3', Ex4 AS 'Ex4', Ex5 AS 'Ex5' FROM Legs WHERE Date = '" + dateToEdit + "' ";

                // Calls the UpdateDatabaseView() method from the Database class and passes the database connection and query
                // returns a SQLiteDataAdapter value and stores it as 'dataAdapter'
                SQLiteDataAdapter dataAdapter = editWorkoutDB.UpdateDatabaseView(sqliteConnection, query);

                // Instantiates a new object of the DataTable Class and passes the name of the table to be viewed.
                DataTable dataTable = new DataTable("Legs");

                // Calls the Fill() method from the SQLiteDataAdapter class and passes the object of DataTable to it.
                dataAdapter.Fill(dataTable);

                // Sets the MembersDatabaseDataGrid.ItemsSource property to the dataTable's default view
                dgEdit.ItemsSource = dataTable.DefaultView;

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

        #region Clear Inputs

        private void ClearAll()
        {
            //Clears all the input areas
            txtP1S1.Text = ""; txtP1S2.Text = ""; txtP1S3.Text = ""; txtP1S4.Text = "";
            txtP2S1.Text = ""; txtP2S2.Text = ""; txtP2S3.Text = ""; txtP2S4.Text = "";
            txtP3S1.Text = ""; txtP3S2.Text = ""; txtP3S3.Text = ""; txtP3S4.Text = "";
            txtP4S1.Text = ""; txtP4S2.Text = ""; txtP4S3.Text = ""; txtP4S4.Text = "";
            txtP5S1.Text = ""; txtP5S2.Text = ""; txtP5S3.Text = ""; txtP5S4.Text = "";
            cbEx1.SelectedIndex = -1; cbEx2.SelectedIndex = -1; cbEx3.SelectedIndex = -1; cbEx4.SelectedIndex = -1; cbEx5.SelectedIndex = -1;
        }

        #endregion

        #region Edit Methods

        private void EditWorkout()
        {
            //Add the first exercise to the ex1 of the workout object
            workout.ex1 = cbEx1.SelectedItem + " " + txtP1S1.Text + " " + txtP1S2.Text + " " + txtP1S3.Text + " " + txtP1S4.Text;

            //Add the second exercise to the ex2 of the workout object
            workout.ex2 = cbEx2.SelectedItem + " " + txtP2S1.Text + " " + txtP2S2.Text + " " + txtP2S3.Text + " " + txtP2S4.Text;

            //Add the third exercise to the ex3 of the workout object
            workout.ex3 = cbEx3.SelectedItem + " " + txtP3S1.Text + " " + txtP3S2.Text + " " + txtP3S3.Text + " " + txtP3S4.Text;

            //Add the fourth exercise to the ex4 of the workout object
            workout.ex4 = cbEx4.SelectedItem + " " + txtP4S1.Text + " " + txtP4S2.Text + " " + txtP4S3.Text + " " + txtP4S4.Text;

            //Add the fifth exercise to the ex5 of the workout object
            workout.ex5 = cbEx5.SelectedItem + " " + txtP5S1.Text + " " + txtP5S2.Text + " " + txtP5S3.Text + " " + txtP5S4.Text;

            switch (workoutType)
            {
                case 0:
                    EditPullWorkout();
                    break;
                case 1:
                    EditPushWorkout();
                    break;
                case 2:
                    EditLegsWorkout();
                    break;
            }
        }

        private void EditPullWorkout()
        {
            editWorkoutDB.UpdateRecordPull(sqliteConnection, dateToEdit, workout.ex1, workout.ex2, workout.ex3, workout.ex4, workout.ex5);
        }

        private void EditPushWorkout()
        {
            editWorkoutDB.UpdateRecordPull(sqliteConnection, dateToEdit, workout.ex1, workout.ex2, workout.ex3, workout.ex4, workout.ex5);
        }

        private void EditLegsWorkout()
        {
            editWorkoutDB.UpdateRecordPull(sqliteConnection, dateToEdit, workout.ex1, workout.ex2, workout.ex3, workout.ex4, workout.ex5);
        }

        #endregion

        #region Button Controls
        private void cbDates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //method to store the date selected and display the selected workout in the data grid.
            if (cbDates.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the date of the workout you want to delete");
            }
            else
            {
                dateToEdit = cbDates.SelectedItem.ToString();
                UpdateDataGrid(dateToEdit);

                MessageBox.Show("Workout successfuly edited. Please click back if you are done Editing");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            switch(workoutType)
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditWorkout();
            ClearAll();
            UpdateDataGrid(dateToEdit);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }
        #endregion
    }
}
