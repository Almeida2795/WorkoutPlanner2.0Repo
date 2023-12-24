using System;
using System.Collections.Generic;
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
    /// Interaction logic for DeleteExercisePage.xaml
    /// </summary>
    public partial class DeleteExercisePage : Window
    {

        #region Variables
        //Creates a string to store the Database file location
        private const string workoutPlannerDBConnectionString = @"Data Source=workoutDB2.db;Version=3;";

        //Creates a new SQLiteConnection object that takes the Connection String
        SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

        //workout type used later to populate correct list of exercises
        public int workoutType;

        //workout name used for the delete record method
        public string workoutName;

        //creates a bew database object
        Database deleteExDB = new Database();
        #endregion
        public DeleteExercisePage(int workoutType)
        {
            InitializeComponent();
            this.workoutType = workoutType;
            PopulateComboBoxes();
        }

        #region Populate Combo Boxes

        private void PopulateComboBoxes()
        {
            //First of all clear combo box to avoid duplicates
            cbExs.Items.Clear();

            //Loads the method for the correct workoutType and defines workoutName which will then be used for the delete method
            switch (this.workoutType)
            {
                case 0:
                    workoutName = "pullEx";
                    populatePullExercises();
                    break;
                case 1:
                    workoutName = "pushEx";
                    populatePushExercises();
                    break;
                case 2:
                    workoutName = "legsEx";
                    populateLegsExercises();
                    break;
            }
        }
        private void populatePullExercises()
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
                SQLiteDataReader dataReader = deleteExDB.SetUpDataReader(sqliteConnection, query);

                // A while loop, which loops while there are values in the dataReader to be read
                while (dataReader.Read())
                {
                    // Adds each value for 'Username' that is read, to the combobox called 'AccountComboBox'
                    cbExs.Items.Add(dataReader["Exercises"]);
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

        private void populatePushExercises()
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
                SQLiteDataReader dataReader = deleteExDB.SetUpDataReader(sqliteConnection, query);

                // A while loop, which loops while there are values in the dataReader to be read
                while (dataReader.Read())
                {
                    // Adds each value for 'Username' that is read, to the combobox called 'AccountComboBox'
                    cbExs.Items.Add(dataReader["Exercises"]);
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

        private void populateLegsExercises()
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
                SQLiteDataReader dataReader = deleteExDB.SetUpDataReader(sqliteConnection, query);

                // A while loop, which loops while there are values in the dataReader to be read
                while (dataReader.Read())
                {
                    // Adds each value for 'Username' that is read, to the combobox called 'AccountComboBox'
                    cbExs.Items.Add(dataReader["Exercises"]);
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

        #region Delete Method

        private void DeleteExercise()
        {
            if (cbExs.SelectedItem == null)
            {
                MessageBox.Show("Please select an exercise first");
            }
            else
            {
                //stores the selected item from the drop down to the string exercise
                string exercise = cbExs.SelectedItem.ToString();

                //calls the delete record method with 3 arguments
                deleteExDB.DeleteRecord(sqliteConnection, exercise, workoutName);

                MessageBox.Show(exercise + " was successfuly deleted! Close this window when you are done");
            }
            //Update combo boxes
            PopulateComboBoxes();
        }

        #endregion

        #region Button Controls
        private void btnDeleteEx_Click(object sender, RoutedEventArgs e)
        {
            DeleteExercise();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AddWorkout addWorkoutPage = new AddWorkout(workoutType);
            addWorkoutPage.Show();
            this.Close();
            
        }
        #endregion
    }
}
