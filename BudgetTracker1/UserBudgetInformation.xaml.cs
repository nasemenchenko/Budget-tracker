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
using System.Windows.Forms.DataVisualization.Charting;
using Logic;

namespace BudgetTracker1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class UserBudgetInformation : Window
    {
         List<Budget> _budget;
        public UserBudgetInformation(User user)
        {

            InitializeComponent();
            using (Context c = new Context())
            {
                _budget = c.User.Single(u => u.Name == user.Name).Budgets;

                UserLabel.Content = user.Name;
                DataGridBudgetInfo.ItemsSource = from b in _budget
                    select new
                    {
                        Name = user.Name,
                        Location = user.Location,
                        TransactionName = b.Description?.TransactionName,
                        Comment = b.Description?.TransactionComment,
                        DateOfTransaction = b.Description?.Date.ToShortDateString(),
                        TimeOfTransaction = b.Description?.Date.ToShortTimeString(),
                        Type = b.TransactionType ? "Income" : "Outcome",
                        Sum = b.Description?.TransactionSum

                    };
                decimal sum = 0;
                CreateChart();
                _budget.ForEach(item => sum += (item.Description.TransactionSum)*((item.TransactionType) ? 1 : -1));

                LabelSum.Content = sum.ToString();
            }
        }
        private void CreateChart()
        {
            ChartBudgetView.ChartAreas.Add(new ChartArea("BudgetChartArea"));
            ChartBudgetView.Series.Add(new Series("BudgetChart"));
            ChartBudgetView.Series["BudgetChart"].ChartArea = "BudgetChartArea";
            ChartBudgetView.Series["BudgetChart"].ChartType = SeriesChartType.Pie;


        }
        private void FillCostsChart(List<Budget> budgets ,bool transactionType)
        {

           

            var listCostsData = budgets.FindAll(transaction => transaction.TransactionType == transactionType);
            var list3 = (from item in listCostsData
                         group item by item.Description.TransactionName into l
                         select l).ToList();
            List<decimal> list1 = new List<decimal>();
            List<string> list2 = new List<string>();

            list3.ForEach(
                item =>
                {
                    list2.Add(item.Key);
                    list1.Add(item.Sum(i => i.Description.TransactionSum));
                });
            ChartBudgetView.Series["BudgetChart"].Points.DataBindXY(list2, list1);

        }
        private void buttonShowChart_Click(object sender, RoutedEventArgs e)
        {
            if (BudgetCanvas.Visibility == Visibility.Hidden)
            {
                SpChoiceTransactionType.Visibility = Visibility.Hidden;
                BudgetCanvas.Visibility = Visibility.Visible;
                DataGridBudgetInfo.Visibility = Visibility.Hidden;
                buttonShowChart.Content = "Show budget table";
                FillCostsChart(_budget, RBtransactiontype.IsChecked.Value);
            }
            else
            {
                SpChoiceTransactionType.Visibility = Visibility.Visible;
                BudgetCanvas.Visibility = Visibility.Hidden;
                DataGridBudgetInfo.Visibility = Visibility.Visible;
                buttonShowChart.Content = "Show budget chart";
            }
        }
    }
}
