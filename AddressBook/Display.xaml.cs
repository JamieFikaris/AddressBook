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
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : Window
    {
        public Display(string fn, string sn, string referer)
        {
            this.refererName = referer;
            this.firstName = fn;
            this.surname = sn;
            InitializeComponent();
        }

        private string firstName, surname;
        private string refererName;
        private DisplayClass display = new DisplayClass();

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (refererName == "Add")
            {
                display.addEntry(textBox.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            }
            else if (refererName == "Update")
            {
                if (firstName != "")
                {
                    display.editEntryDupe(firstName, surname, textBox.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                }
                else
                {
                    display.editEntrySurname(surname, textBox.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            submit.Content = refererName;

            if (refererName == "Search")
                submit.IsEnabled = false;

            if (refererName == "Search" || refererName == "Update")
            {
                if (firstName != "")
                {
                    display.getInfoDupe(firstName, surname);
                    textBox.Text = display.firstName;
                    textBox1.Text = display.surname;
                    textBox2.Text = display.address1;
                    textBox3.Text = display.address2;
                    textBox4.Text = display.address3;
                    textBox5.Text = display.postcode;
                    textBox6.Text = display.telephone;
                }
                else
                {
                    display.getInfoSurname(surname);
                    textBox.Text = display.firstName;
                    textBox1.Text = display.surname;
                    textBox2.Text = display.address1;
                    textBox3.Text = display.address2;
                    textBox4.Text = display.address3;
                    textBox5.Text = display.postcode;
                    textBox6.Text = display.telephone;
                }
            }
        }
    }
}
