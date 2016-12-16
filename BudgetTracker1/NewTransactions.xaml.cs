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
using Logic.Entity;
using Logic;
using System.Text.RegularExpressions;

namespace BudgetTracker1
{
    /// <summary>
    /// Логика взаимодействия для NewTransactions.xaml
    /// </summary>
    public partial class NewTransactions : Window
    {
        private List<Budget> _list;
        User _user;
        Repository repository;
        public NewTransactions(object user, List<Budget> list, Repository repo)
        {
            InitializeComponent();
            Fill_ComboBoxTypeOfTransaction();         
            _user = user as User;
            _list = list;
            LabelUserName.Content = _user.Name;
            repository = repo;
        }

       

        private void ComboBoxTypeOfTransaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTypeOfTransaction.SelectedIndex == 0)
                Fill_ComboBoxNameTransaction_Income();
            else if (ComboBoxTypeOfTransaction.SelectedIndex == 1)
                Fill_ComboBoxTransaction_Costs();
        }
        void Fill_ComboBoxTypeOfTransaction()
        {
            ComboBoxTypeOfTransaction.Items.Add("Income");
            ComboBoxTypeOfTransaction.Items.Add("Costs");
        }

        private void ComboBoxTransactionName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void Fill_ComboBoxNameTransaction_Income()
        {
            ComboBoxTransactionName.Items.Clear();
            ComboBoxTransactionName.SelectedIndex = 0;
            ComboBoxTransactionName.Items.Add("Salary");
            ComboBoxTransactionName.Items.Add("Business");
            ComboBoxTransactionName.Items.Add("Dividends");
            ComboBoxTransactionName.Items.Add("Gifts");
            ComboBoxTransactionName.Items.Add("Extra income");

        }
        void Fill_ComboBoxTransaction_Costs()
        {
            ComboBoxTransactionName.Items.Clear();
            ComboBoxTransactionName.SelectedIndex = 0;
            ComboBoxTransactionName.Items.Add("Food");
            ComboBoxTransactionName.Items.Add("Restaraunts");
            ComboBoxTransactionName.Items.Add("Clothes");
            ComboBoxTransactionName.Items.Add("Fitness");
            ComboBoxTransactionName.Items.Add("Petrol");
            ComboBoxTransactionName.Items.Add("Car service");
            ComboBoxTransactionName.Items.Add("Household products");
            ComboBoxTransactionName.Items.Add("Leisure/Rest");
            ComboBoxTransactionName.Items.Add("Internet");
            ComboBoxTransactionName.Items.Add("Smartphone");
        }

        private void ButtomAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                repository.AddTransaction(LabelUserName.Content.ToString(), ComboBoxTransactionName.SelectedItem.ToString(), ComboBoxTypeOfTransaction.SelectedIndex == 0, decimal.Parse(TextBoxMoney.Text), DescriptionName.Text);
            }
            catch(FormatException)
            {
               
                MessageBox.Show("Please, provide correct value!", "Error occured", MessageBoxButton.YesNo, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBoxButton mb = new MessageBoxButton();
                
                MessageBox.Show(ex.Message, "Error occured", MessageBoxButton.YesNo, MessageBoxImage.Error);
            }
        }

        private void TextBoxMoney_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxMoney.Text = new Regex(@"[^\d +( \. +\d)]").Replace(TextBoxMoney.Text, "");
        }
    }
}
