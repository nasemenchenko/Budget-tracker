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
using System.Windows.Shapes;

namespace BudgetTracker1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class UserBudgetInformation : Window
    {
        User _user;
        public UserBudgetInformation(object user, List<Budget> budget)
        {

            InitializeComponent();
            _user = user as User;
            UserLabel.Content = _user.Name;
            DataGridBudgetInfo.ItemsSource = from b in budget
                                             select new
                                             {
                                                 Name = b.User.Name,
                                                 Location = b.User.Location,
                                                 TransactionName = b.Description.TransactionName,
                                                 Comment = b.Description.TransactionComment,
                                                 DateOfTransaction = b.Description.Date.ToShortDateString(),
                                                 TimeOfTransaction = b.Description.Date.ToShortTimeString(),
                                                 Type = b.TransactionType ? "Income" : "Outcome",
                                                 Sum = b.Description.TransactionSum

                                             };
            decimal sum = 0;
            budget.ForEach(item => sum += (item.Description.TransactionSum) * ((item.TransactionType) ? 1 : -1));
            LabelSum.Content = sum.ToString();
        }
    }
}
