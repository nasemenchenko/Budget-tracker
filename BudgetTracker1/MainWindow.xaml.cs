//using Logic;
using Logic;
using Logic.Entity;
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

namespace BudgetTracker1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository;
        public MainWindow()
        {
            InitializeComponent();

            using (Context c = new Context())
                repository = new Repository(c);

            foreach (var item in repository.Users)
                ComboBoxChooseUser.Items.Add(item);
            repository.onUserListChanged += Repository_onUserListChanged;
        }

        private void Repository_onUserListChanged()
        {
            ComboBoxChooseUser.Items.Clear();
            ComboBoxChooseUser.SelectedIndex = 0;

            foreach (var item in repository.Users)
                ComboBoxChooseUser.Items.Add(item);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                repository.AddUser(textBoxUserName.Text, textboxLocation.Text);

                textBoxUserName.Clear();
                textboxLocation.Clear();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured", MessageBoxButton.YesNo, MessageBoxImage.Error);
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            repository.ClearUsersList();

        }

        private void ButtonShowUserData_Click(object sender, RoutedEventArgs e)
        {
            var test = repository.Budget.FindAll(u => u.User.Name == (ComboBoxChooseUser.SelectedItem as User).Name);
            if (ComboBoxChooseUser.SelectedItem == null)
                MessageBox.Show("Please, add the new user");
            else
            {
                UserBudgetInformation user = new UserBudgetInformation(ComboBoxChooseUser.SelectedItem, repository.Budget.FindAll(u => u.User.Name == (ComboBoxChooseUser.SelectedItem as User).Name));
                user.ShowDialog();
            }
        }

        private void ButtonAddRecord_Click(object sender, RoutedEventArgs e)
        {
            NewTransactions transactions = new NewTransactions(ComboBoxChooseUser.SelectedItem, repository.Budget.FindAll(u => u.User == ComboBoxChooseUser.SelectedItem as User), repository);
            transactions.ShowDialog();
        }

        private void ButtonDeleteOneUser_Click(object sender, RoutedEventArgs e)
        {
          
                repository.DeleteUser((ComboBoxChooseUser.SelectedItem as User).Name);
            //}
            ////catch(Exception ex)
            //{
            //  //  MessageBox.Show(ex.Message);
            //}
        }
    }
}
