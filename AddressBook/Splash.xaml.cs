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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AddressBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Search searchForm = new Search(Search.Name);
            searchForm.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Search searchForm = new Search(Delete.Name);
            searchForm.ShowDialog();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Search searchForm = new Search(Update.Name);
            searchForm.ShowDialog();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Display displayForm = new Display("", "", Add.Name);
            displayForm.ShowDialog();
        }
    }
}
