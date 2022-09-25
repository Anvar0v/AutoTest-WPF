using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF_App.EPages;

namespace WPF_App.Pages;

public partial class TicketPage : Page
{
    public TicketPage()
    {
        InitializeComponent();
        GenerateTicketButtons();
    }

    private void GenerateTicketButtons()
    {
        var questionsRepository = MainWindow.Instance.QuestionRepository;
        var ticketRepository = MainWindow.Instance.TicketRepository;
        int ticketsCount = questionsRepository.GetTicketsCount();
        for (int i = 0; i < ticketsCount; i++)
        {
            var button = new Button();
            if(ticketRepository.UserTickets.Any(ticket => ticket.Index == i))
            {
                var ticket = ticketRepository.UserTickets.First(ticket => ticket.Index == i);
                button.Content = ticket.TicketCompleted
                    ? $"Ticket {i + 1}\t✅" 
                    : $"Ticket {i + 1} \t{ticket.CorrectAnswerCount}/{ticket.QuestionsCount}";
            }
            else
            {
                button.Content = $"Ticket {i + 1}";
            }

            button.Height = 45;
            button.Width = 300;
            button.FontSize = 18;
            button.Tag = i;
            button.BorderBrush = new SolidColorBrush(Colors.Teal);
            button.Click += TicketButtonClick;
            button.Margin = new Thickness(5);
            TicketButtonPanel.Children.Add(button);
        }
    }

    private void TicketButtonClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var ticketIndex = (int)button.Tag; //ticket index
        MainWindow.Instance.MainWindowFrame.Navigate(new ExaminationPage(ticketIndex));
    }
    private void MainMenu(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.DisplayPage(EPage.MainMenu);
    }

}
