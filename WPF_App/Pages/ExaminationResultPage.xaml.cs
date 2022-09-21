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
using WPF_App.Models;

namespace WPF_App.Pages
{
    public partial class ExaminationResultPage : Page
    {
        public ExaminationResultPage(Ticket ticket)
        {
            InitializeComponent();
            CorrectAnswerCount.Text = ticket.CorrectAnswerCount.ToString();
            QuestionsCount.Text = ticket.QuestionsCount.ToString();
        }

        private void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DisplayPage(EPages.EPage.MainMenu);
        }
    }
}
