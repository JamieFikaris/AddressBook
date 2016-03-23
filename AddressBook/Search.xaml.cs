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
using System.Windows.Shapes;

namespace AddressBook
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search(string referer)
        {
            this.refererName = referer;
            InitializeComponent();
        }

        private string selectedFirstName;
        private string refererName;
        SearchClass a = new SearchClass();

        private void searchbutton_Click(object sender, RoutedEventArgs e)
        {
            if (a.getSurname(textBox.Text))
            {
                //doesn't disable button so user can still use it if they dont want to delete entry
                if (a.surnameEntries == 1) //if there are two of the same surnames
                {
                    searchbutton.IsEnabled = false;
                    comboBox.IsEnabled = true;
                    foreach (string text in a.firstNames)
                    {
                        comboBox.Items.Add(text); //adds first names to combobox so user can select which one
                    }
                }
                else
                {
                    if (refererName =="Delete")
                    {
                        MessageBoxResult result = MessageBox.Show("", "Are you sure you want to delete this entry from the database?", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            a.deleteEntrySurname(textBox.Text);
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        Display s = new Display("", textBox.Text, refererName);
                        this.Hide();
                        s.ShowDialog(); //open search form
                        this.Close();
                    }
                }

            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedFirstName = comboBox.SelectedItem.ToString();
            continuebutton.IsEnabled = true;
        }

        private void continuebutton_Click(object sender, RoutedEventArgs e)
        {
            if (refererName == "Delete")
            {
                MessageBoxResult result = MessageBox.Show("", "Are you sure you want to delete this entry from the database?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    a.deleteEntryDupe(selectedFirstName, textBox.Text);
                }
            }
            else
            {
                Display s = new Display(selectedFirstName, textBox.Text, refererName);
                this.Hide();
                s.ShowDialog(); //open search form
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (refererName == "Delete")
            {
                continuebutton.Content = "Delete";
                searchbutton.Content = "Delete";
            }
        }
    }
}
