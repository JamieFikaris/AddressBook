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
    class DisplayClass
    {
        private static string path = System.AppDomain.CurrentDomain.BaseDirectory; //set directory to folder app is in

        private OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "db.accdb; Persist Security Info=false;");
        private OleDbCommand command;

        public string firstName { get; private set; }
        public string surname { get; private set; }
        public string address1 { get; private set; }
        public string address2 { get; private set; }
        public string address3 { get; private set; }
        public string postcode { get; private set; }
        public string telephone { get; private set; }

        public DisplayClass()
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

        public void getInfoDupe(string fn, string sn)
        {
            try
            {
                command.CommandText = "SELECT * FROM Info WHERE Surname ='" + sn + "' AND FirstName = '" + fn + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    firstName = reader["FirstName"].ToString();
                    surname = reader["Surname"].ToString();
                    address1 = reader["AddressLine1"].ToString();
                    address2 = reader["AddressLine2"].ToString();
                    address3 = reader["AddressLine3"].ToString();
                    postcode = reader["Postcode"].ToString();
                    telephone = reader["Telephone"].ToString();

                }

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

        public void getInfoSurname(string sn)
        {
            try
            {
                command.CommandText = "SELECT * FROM Info WHERE Surname ='" + sn + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    firstName = reader["FirstName"].ToString();
                    surname = reader["Surname"].ToString();
                    address1 = reader["AddressLine1"].ToString();
                    address2 = reader["AddressLine2"].ToString();
                    address3 = reader["AddressLine3"].ToString();
                    postcode = reader["Postcode"].ToString();
                    telephone = reader["Telephone"].ToString();

                }

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

        public void editEntryDupe(string fn, string sn, string firstName, string surname, string address1, string address2, string address3, string postcode, string telephone)
        {
            if (firstName == "" || surname == "" || address1 == "" || address2 == "" || address3 == "" || postcode == "") //telephone not included as per request
            {
                MessageBox.Show("Fill in all text boxes");
            }
            else
            {
                try
                {
                    command.CommandText = "UPDATE Info set FirstName ='" + firstName + "', Surname = '" + surname + "', AddressLine1 = '" + address1 + "', AddressLine2 = '" + address2 + "', AddressLine3 = '" + address3 + "', Postcode = '" + postcode + "', Telephone = '" + telephone + "' WHERE Surname ='" + sn + "' AND FirstName = '" + fn + "'";
                    command.CommandType = CommandType.Text;
                    connection.Open();


                    command.ExecuteNonQuery();
                    MessageBox.Show("Entry updated!");
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

        public void editEntrySurname(string sn, string firstName, string surname, string address1, string address2, string address3, string postcode, string telephone)
        {
            if (firstName == "" || surname == "" || address1 == "" || address2 == "" || address3 == "" || postcode == "") //telephone not included as per request
            {
                MessageBox.Show("Fill in all text boxes");
            }
            else
            {
                try
                {
                    command.CommandText = "UPDATE Info set FirstName ='" + firstName + "', Surname = '" + surname + "', AddressLine1 = '" + address1 + "', AddressLine2 = '" + address2 + "', AddressLine3 = '" + address3 + "', Postcode = '" + postcode + "', Telephone = '" + telephone + "'  WHERE Surname ='" + sn + "'";
                    command.CommandType = CommandType.Text;
                    connection.Open();


                    command.ExecuteNonQuery();
                    MessageBox.Show("Entry updated!");
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

        public void addEntry(string firstName, string surname, string address1, string address2, string address3, string postcode, string telephone)
        {
            if (firstName == "" || surname == "" || address1 == "" || address2 == "" || address3 == "" || postcode == "") //telephone not included as per request
            {
                MessageBox.Show("Fill in all text boxes");
            }
            else
            {
                try
                {
                    command.CommandText = "INSERT INTO Info (FirstName, Surname, AddressLine1, AddressLine2, AddressLine3, Postcode, Telephone) VALUES('" + firstName + "', '" + surname + "', '" + address1 + "', '" + address2 + "', '" + address3 + "', '" + postcode + "','" + telephone + "')";
                    command.CommandType = CommandType.Text;
                    connection.Open();


                    command.ExecuteNonQuery();
                    MessageBox.Show("Added to the database");
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
}
