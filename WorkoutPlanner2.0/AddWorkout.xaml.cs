using Microsoft.VisualBasic;
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
    /// Interaction logic for AddWorkout.xaml
    /// </summary>
    public partial class AddWorkout : Window
    {
        #region Variables

        //Creates a string to store the Database file location
        private const string workoutPlannerDBConnectionString = @"Data Source=workoutDB2.db;Version=3;";

        int workoutType;

        //Creates a new Database Object
        Database addDB = new Database();

        //Creates a new Workout Object
        Workout workout = new Workout();

        #endregion
        public AddWorkout(int workoutType)
        {
            InitializeComponent();

            this.workoutType = workoutType;

            //Populates combo boxes
            PopulateComboBoxes();

        }

        #region Populate Combo Boxes
        private void PopulateComboBoxes()
        {
            //First of all clear all combo boxes to avoid duplicated data
            cbEx1.Items.Clear();
            cbEx2.Items.Clear();
            cbEx3.Items.Clear();
            cbEx4.Items.Clear();
            cbEx5.Items.Clear();
            cbDay.Items.Clear();
            cbMonth.Items.Clear();

            PopulateDayAndMonth();
            PopulateExerciseBoxes();
        }

        //Method to populate Day and Month combo box
        private void PopulateDayAndMonth()
        {
            for (int x = 1; x < 31; x++)
            {
                cbDay.Items.Add(x);
            }
            for (int y = 1; y < 12; y++)
            {
                cbMonth.Items.Add(y);
            }
        }

        private void PopulateExerciseBoxes()
        {
            //Clears all combo boxes first of all
            cbEx1.Items.Clear();
            cbEx2.Items.Clear();
            cbEx3.Items.Clear();
            cbEx4.Items.Clear();
            cbEx5.Items.Clear();
            // Initialises a connection to the Database based on the path which is stored as the string 'SimplyRugbyDBConnectionString'.
            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            switch (workoutType)
            {
                case 0:
                    // A string set up to store a database query.
                    string queryPull = "SELECT * FROM PullExercises ORDER BY Exercises ASC";

                    // try-catch incase there are any issues with retrieving values from the database
                    // And then adding the values to the combobox 'MembershipNoComboBox'
                    try
                    {
                        // Calls the method SetUpDataReader() sends the database connection and the string 'query'
                        // Returns with the values from the query and stores these values as a SQLiteDataReader called dataReader
                        SQLiteDataReader dataReader = addDB.SetUpDataReader(sqliteConnection, queryPull);

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
                    catch(SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    break;
                case 1:
                    // A string set up to store a database query.
                    string queryPush = "SELECT * FROM PushExercises ORDER BY Exercises ASC";

                    // try-catch incase there are any issues with retrieving values from the database
                    // And then adding the values to the combobox 'MembershipNoComboBox'
                    try
                    {
                        // Calls the method SetUpDataReader() sends the database connection and the string 'query'
                        // Returns with the values from the query and stores these values as a SQLiteDataReader called dataReader
                        SQLiteDataReader dataReader = addDB.SetUpDataReader(sqliteConnection, queryPush);

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
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    break;
                case 2:
                    // A string set up to store a database query.
                    string queryLegs = "SELECT * FROM LegsExercises ORDER BY Exercises ASC";

                    // try-catch incase there are any issues with retrieving values from the database
                    // And then adding the values to the combobox 'MembershipNoComboBox'
                    try
                    {
                        // Calls the method SetUpDataReader() sends the database connection and the string 'query'
                        // Returns with the values from the query and stores these values as a SQLiteDataReader called dataReader
                        SQLiteDataReader dataReader = addDB.SetUpDataReader(sqliteConnection, queryLegs);

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
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    break;
            }
        }
        #endregion

        #region Add Ex Method
        private void AddEx()
        {
            // Initialises a connection to the Database based on the path which is stored as the string 'SimplyRugbyDBConnectionString'.
            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            switch (workoutType)
            {
                case 0:
                    string exercisePull = Interaction.InputBox("Type the name of the exercise you wish to add", "Exercise Add");
                    addDB.AddExPull(sqliteConnection, exercisePull);

                    //Update combo boxes
                    PopulateComboBoxes();
                    break;

                case 1:
                    string exercisePush = Interaction.InputBox("Type the name of the exercise you wish to add", "Exercise Add");
                    addDB.AddExPush(sqliteConnection, exercisePush);

                    //Update combo boxes
                    PopulateComboBoxes();
                    break;

                case 2:
                    string exerciseLegs = Interaction.InputBox("Type the name of the exercise you wish to add", "Exercise Add");
                    addDB.AddExLegs(sqliteConnection, exerciseLegs);

                    //Update combo boxes
                    PopulateComboBoxes();
                    break;
            }
        }
        #endregion

        #region Add Workout Method
        private void AddWorkoutMethod()
        {
            // Initialises a connection to the Database based on the path which is stored as the string 'SimplyRugbyDBConnectionString'.
            SQLiteConnection sqliteConnection = new SQLiteConnection(workoutPlannerDBConnectionString);

            //Checks if date and month has been selected
            if (cbDay.SelectedItem == null | cbMonth.SelectedItem == null)
            {
                MessageBox.Show("Please select the day and month first");
                return;
            }

            workout.date = cbDay.SelectedItem.ToString() + " / " + cbMonth.SelectedItem.ToString();
            workout.ex1 = cbEx1.SelectedItem + " " + txtP1S1.Text + " " + txtP1S2.Text + " " + txtP1S3.Text + " " + txtP1S4.Text;
            workout.ex2 = cbEx2.SelectedItem + " " + txtP2S1.Text + " " + txtP2S2.Text + " " + txtP2S3.Text + " " + txtP2S4.Text;
            workout.ex3 = cbEx3.SelectedItem + " " + txtP3S1.Text + " " + txtP3S2.Text + " " + txtP3S3.Text + " " + txtP3S4.Text;
            workout.ex4 = cbEx4.SelectedItem + " " + txtP4S1.Text + " " + txtP4S2.Text + " " + txtP4S3.Text + " " + txtP4S4.Text;
            workout.ex5 = cbEx5.SelectedItem + " " + txtP5S1.Text + " " + txtP5S2.Text + " " + txtP5S3.Text + " " + txtP5S4.Text;

            switch (workoutType)
            {
                case 0:
                    try
                    {
                        addDB.AddRecordPull(sqliteConnection, workout.date, workout.ex1, workout.ex2, workout.ex3, workout.ex4, workout.ex5);

                        MessageBox.Show("Workout Successfully Added");

                        ClearAll();
                    }
                    //In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 1:
                    try
                    {
                        addDB.AddRecordPush(sqliteConnection, workout.date, workout.ex1, workout.ex2, workout.ex3, workout.ex4, workout.ex5);

                        MessageBox.Show("Workout Successfully Added");

                        ClearAll();
                    }
                    //In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        addDB.AddRecordLegs(sqliteConnection, workout.date, workout.ex1, workout.ex2, workout.ex3, workout.ex4, workout.ex5);

                        MessageBox.Show("Workout Successfully Added");

                        ClearAll();
                    }
                    //In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }
        #endregion

        #region Clear All Method

    //Method to clear text boxes and create a new workout object
        private void ClearAll()
        {
            txtP1S1.Text = ""; txtP1S2.Text = ""; txtP1S3.Text = ""; txtP1S4.Text = "";
            txtP2S1.Text = ""; txtP2S2.Text = ""; txtP2S3.Text = ""; txtP2S4.Text = "";
            txtP3S1.Text = ""; txtP3S2.Text = ""; txtP3S3.Text = ""; txtP3S4.Text = "";
            txtP4S1.Text = ""; txtP4S2.Text = ""; txtP4S3.Text = ""; txtP4S4.Text = "";
            txtP5S1.Text = ""; txtP5S2.Text = ""; txtP5S3.Text = ""; txtP5S4.Text = "";
            cbEx1.SelectedIndex = -1; cbEx2.SelectedIndex = -1; cbEx3.SelectedIndex = -1; cbEx4.SelectedIndex = -1; cbEx5.SelectedIndex = -1;
            cbDay.SelectedIndex = -1; cbMonth.SelectedIndex = -1;
            Workout workout = new Workout();
        }
        
        #endregion

        #region Button Controls
        //Method that will show an input box for the user to input the name of the exercise and save it to the Exercises table
        private void btnAddEx_Click(object sender, RoutedEventArgs e)
        {
            AddEx();
        }

        private void btnDeleteEx_Click(object sender, RoutedEventArgs e)
        {
            //Creates a new DeleteExerciseFromListPage and passes workoutType which will later define which list to load (pull push or legs) in the delete ex page
            DeleteExercisePage delPage = new DeleteExercisePage(workoutType);
            delPage.Show();
            this.Close();
        }

        private void btnAddWorkout_Click(object sender, RoutedEventArgs e)
        {
            AddWorkoutMethod();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
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
