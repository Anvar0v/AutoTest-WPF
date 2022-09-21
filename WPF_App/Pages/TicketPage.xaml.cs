using System.Windows;
using System.Windows.Controls;
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
        int ticketsCount = questionsRepository.GetTicketsCount();
        for (int i = 1; i < ticketsCount; i++)
        {
            var button = new Button();
            button.Height = 45;
            button.Width = 300;
            button.Content = $"Ticket {i}";
            button.FontSize = 18;
            button.Tag = i;
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
