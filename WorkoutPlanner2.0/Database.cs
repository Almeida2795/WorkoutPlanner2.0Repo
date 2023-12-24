using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;

namespace WorkoutPlanner2._0
{
    internal class Database
    {
        #region Variables
        // Sets the path of the stored database as a string called 'simplyRugbyDBConnectionString'.
        private const string workoutPlannerDBConnectionString = @"Data Source=workoutDB2.db;Version=3;";
        #endregion

        #region AddRecord Methods
        // Method which takes in 8 values and adds a new record to the push table
        public void AddRecordPush(SQLiteConnection sqliteConnection, string date, string ex1, string ex2, string ex3, string ex4, string ex5)
        {
            try
            {
                // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                sqliteConnection.Open();

                // A string set up to store a database command.
                string command = "INSERT INTO Push (Date, Ex1, Ex2, Ex3, Ex4, Ex5) VALUES('" + date + "', '" + ex1 + "', '" + ex2 + "', '" + ex3 + "', '" + ex4 + "', '" + ex5 + "')";

                // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                sqliteCommand.ExecuteNonQuery();

                // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                sqliteConnection.Close();
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // Method which takes in 8 values and adds a new record to the pull table
        public void AddRecordPull(SQLiteConnection sqliteConnection, string date, string ex1, string ex2, string ex3, string ex4, string ex5)
        {
            try
            {
                // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                sqliteConnection.Open();

                // A string set up to store a database command.
                string command = "INSERT INTO Pull (Date, Ex1, Ex2, Ex3, Ex4, Ex5) VALUES('" + date + "', '" + ex1 + "', '" + ex2 + "', '" + ex3 + "', '" + ex4 + "', '" + ex5 + "')";

                // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                sqliteCommand.ExecuteNonQuery();

                // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                sqliteConnection.Close();
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // Method which takes in 8 values and adds a new record to the legs table
        public void AddRecordLegs(SQLiteConnection sqliteConnection, string date, string ex1, string ex2, string ex3, string ex4, string ex5)
        {
            try
            {
                // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                sqliteConnection.Open();

                // A string set up to store a database command.
                string command = "INSERT INTO Legs (Date, Ex1, Ex2, Ex3, Ex4, Ex5) VALUES('" + date + "', '" + ex1 + "', '" + ex2 + "', '" + ex3 + "', '" + ex4 + "', '" + ex5 + "')";

                // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                sqliteCommand.ExecuteNonQuery();

                // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                sqliteConnection.Close();
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        #endregion

        #region EditRecord Methods

        // Method which takes in 7 values and updates an existing record in the Pull table
        public void UpdateRecordPull(SQLiteConnection sqliteConnection, string date, string ex1, string ex2, string ex3, string ex4, string ex5)
        {
            try
            {
                // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                sqliteConnection.Open();

                // A string set up to store a database command.
                string command = "UPDATE Pull SET Ex1='" + ex1 + "', Ex2='" + ex2 + "', Ex3='" + ex3 + "', Ex4='" + ex4 + "', Ex5='" + ex5 + "' WHERE Date='" + date + "' ";

                // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                sqliteCommand.ExecuteNonQuery();

                // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                sqliteConnection.Close();
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Method which takes in 7 values and updates an existing record in the Push table
        public void UpdateRecordPush(SQLiteConnection sqliteConnection, string date, string ex1, string ex2, string ex3, string ex4, string ex5)
        {
            try
            {
                // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                sqliteConnection.Open();

                // A string set up to store a database command.
                string command = "UPDATE Push SET Ex1='" + ex1 + "', Ex2='" + ex2 + "', Ex3='" + ex3 + "', Ex4='" + ex4 + "', Ex5='" + ex5 + "' WHERE Date='" + date + "' ";

                // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                sqliteCommand.ExecuteNonQuery();

                // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                sqliteConnection.Close();
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Method which takes in 7 values and updates an existing record in the Legs table
        public void UpdateRecordLegs(SQLiteConnection sqliteConnection, string date, string ex1, string ex2, string ex3, string ex4, string ex5)
        {
            try
            {
                // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                sqliteConnection.Open();

                // A string set up to store a database command.
                string command = "UPDATE Legs SET Ex1='" + ex1 + "', Ex2='" + ex2 + "', Ex3='" + ex3 + "', Ex4='" + ex4 + "', Ex5='" + ex5 + "' WHERE Date='" + date + "' ";

                // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                sqliteCommand.ExecuteNonQuery();

                // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                sqliteConnection.Close();
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        #endregion

        #region AddEx Methods

        //Method that takes 3 arguments and adds a new exercise to the PullExercises Table
        public void AddExPull(SQLiteConnection sqliteConnection, string exercise)
        {
            try
            {
                // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                sqliteConnection.Open();

                // A string set up to store a database command.
                string command = "INSERT INTO PullExercises (Exercises) VALUES('" + exercise + "')";

                // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                sqliteCommand.ExecuteNonQuery();

                // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                sqliteConnection.Close();
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        //Method that takes 3 arguments and adds a new exercise to the PushExercises Table
        public void AddExPush(SQLiteConnection sqliteConnection, string exercise)
        {
            try
            {
                // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                sqliteConnection.Open();

                // A string set up to store a database command.
                string command = "INSERT INTO PushExercises (Exercises) VALUES('" + exercise + "')";

                // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                sqliteCommand.ExecuteNonQuery();

                // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                sqliteConnection.Close();
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        //Method that takes 3 arguments and adds a new exercise to the LegsExercises Table
        public void AddExLegs(SQLiteConnection sqliteConnection, string exercise)
        {
            try
            {
                // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                sqliteConnection.Open();

                // A string set up to store a database command.
                string command = "INSERT INTO LegsExercises (Exercises) VALUES('" + exercise + "')";

                // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                sqliteCommand.ExecuteNonQuery();

                // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                sqliteConnection.Close();
            }

            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        #endregion

        #region DeleteEx and Workout Methods
        // Method which handles deleting a record from the database
        public void DeleteRecord(SQLiteConnection sqliteConnection, string condition, string type)
        {
            try
            {
                if (type == "Pull")
                {
                    // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                    sqliteConnection.Open();

                    // A string set up to store a database command.
                    string command = "DELETE FROM Pull WHERE Date = '" + condition + "' ";

                    // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                    SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                    // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                    sqliteCommand.ExecuteNonQuery();

                    // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                    sqliteConnection.Close();
                }
                else if (type == "Push")
                {
                    // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                    sqliteConnection.Open();

                    // A string set up to store a database command.
                    string command = "DELETE FROM Push WHERE Date = '" + condition + "' ";

                    // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                    SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                    // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                    sqliteCommand.ExecuteNonQuery();

                    // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                    sqliteConnection.Close();
                }
                else if (type == "Legs")
                {
                    // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                    sqliteConnection.Open();

                    // A string set up to store a database command.
                    string command = "DELETE FROM Legs WHERE Date = '" + condition + "' ";

                    // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                    SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                    // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                    sqliteCommand.ExecuteNonQuery();

                    // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                    sqliteConnection.Close();
                }
                else if (type == "pullEx")
                {
                    // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                    sqliteConnection.Open();

                    // A string set up to store a database command.
                    string command = "DELETE FROM PullExercises WHERE Exercises = '" + condition + "' ";

                    // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                    SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                    // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                    sqliteCommand.ExecuteNonQuery();

                    // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                    sqliteConnection.Close();
                }
                else if (type == "pushEx")
                {
                    // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                    sqliteConnection.Open();

                    // A string set up to store a database command.
                    string command = "DELETE FROM PushExercises WHERE Exercises = '" + condition + "' ";

                    // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                    SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                    // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                    sqliteCommand.ExecuteNonQuery();

                    // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                    sqliteConnection.Close();
                }
                else if (type == "legsEx")
                {
                    // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
                    sqliteConnection.Open();

                    // A string set up to store a database command.
                    string command = "DELETE FROM LegsExercises WHERE Exercises = '" + condition + "' ";

                    // Instantiates a new object of the SQLiteCommand class, using the string 'command' and the database connection
                    SQLiteCommand sqliteCommand = new SQLiteCommand(command, sqliteConnection);

                    // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'sqliteCommand'
                    sqliteCommand.ExecuteNonQuery();

                    // Calls the Close() method from the SQLiteConnection class to close the connection with the database
                    sqliteConnection.Close();
                }
                // The program will only enter this ELSE statement if the value for the string 'type' is not equal to either "record" or "account"
                else
                {
                    MessageBox.Show("There has been an issue with deleting that database record.\nPlease try again.");
                    return;
                }
            }
            // In the event of an error a MessageBox displays the specific SQLite error and does not allow the application crash.
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        #endregion

        #region Display Data Methods
        public SQLiteDataAdapter UpdateDatabaseView(SQLiteConnection sqliteConnection, string query)
        {
            // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
            sqliteConnection.Open();

            // Instantiates a new object of the SQLiteCommand class, using the string 'query' and the database connection
            SQLiteCommand createCommand = new SQLiteCommand(query, sqliteConnection);

            // Calls the ExecuteNonQuery() from the SQLiteCommand class to execute the command 'createCommand'
            createCommand.ExecuteNonQuery();

            // Instantiates a new object of the SQLiteDataAdapter class, passing the SQLiteCommand object 'createCommand'
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(createCommand);

            // Returns the SQLiteDataAdapter object
            return dataAdapter;
        }

        // Method takes in a database connection and a query returns a SQLiteDataReader object
        public SQLiteDataReader SetUpDataReader(SQLiteConnection sqliteConnection, string query)
        {
            // Calls the Open() method from the SQLiteConnection class to open a connection with the database.
            sqliteConnection.Open();

            // Instantiates a new object of the SQLiteCommand Class, using the string 'query' and the database connection
            SQLiteCommand sqliteCommand = new SQLiteCommand(query, sqliteConnection);

            // Calls the method ExecuteReader() from the SQLiteCommand class, to create the SQLiteDataReader object  
            SQLiteDataReader dataReader = sqliteCommand.ExecuteReader();

            // Returns the SQLiteDataReader object
            return dataReader;
        }
        #endregion
    }
}
