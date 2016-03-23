using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace AddressBook
{
    class SearchClass
    {
        public int surnameEntries { get; private set; }

        private static string path = System.AppDomain.CurrentDomain.BaseDirectory; //set directory to folder app is in

        private OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "db.accdb; Persist Security Info=false;");
        private OleDbCommand command;

        private List<string> firstnames = new List<string>();
        public List<string> firstNames
        {
            get { return firstnames; }
        }

        private List<string> surnames = new List<string>();
        public List<string> surnameList
        {
            get { return surnames; }
        }

        public SearchClass()
        {
            command = connection.CreateCommand();
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            finally
            {
                connection.Close();
            }
        }

        public bool getSurname(string input)
        {
            try
            {
                command.CommandText = "SELECT * FROM Info WHERE Surname ='" + input + "'";

                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    surnames.Add(reader["Surname"].ToString());
                }

                connection.Close();

                if (surnames.Count > 1) //if there is more than 1 surname record
                {
                    surnameEntries = 1;
                    command.CommandText = "SELECT FirstName FROM Info WHERE Surname ='" + input + "'";

                    command.CommandType = CommandType.Text;
                    connection.Open();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        firstnames.Add(reader["FirstName"].ToString()); //takes first names from database
                    }
                    connection.Close();
                }

                if (surnames.Count > 0)
                    return true;
                else
                {
                    MessageBox.Show("Surname not found!");
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            finally
            {
                connection.Close();
            }
        }

        public void deleteEntryDupe(string fn, string sn)
        {
            try
            {
                command.CommandText = "DELETE FROM Info WHERE Surname ='" + sn + "' AND FirstName = '" + fn + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
                MessageBox.Show("Entry deleted!");
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            finally
            {
                connection.Close();
            }
        }

        public void deleteEntrySurname(string sn)
        {
            try
            {
                command.CommandText = "DELETE FROM Info WHERE Surname ='" + sn + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
                MessageBox.Show("Entry deleted!");
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            finally
            {
                connection.Close();
            }
        }
    }
}
