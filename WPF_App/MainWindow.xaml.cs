using System.Windows;
using WPF_App.EPages;
using WPF_App.Pages;
using WPF_App.Repositories;

namespace WPF_App;

public partial class MainWindow : Window
{
    public static MainWindow Instance;
    public QuestionRepository QuestionRepository;
    public TicketRepository TicketRepository;
    public int CorrectCount;
    public MainWindow()
    {
        InitializeComponent();
        Instance = this;
        QuestionRepository = new QuestionRepository();
        TicketRepository = new TicketRepository();
        MainWindowFrame.Navigate(new MainMenuPage()); 
    }

    public void DisplayPage(EPage epage) //main menu
    {
        switch (epage)//main menu
        {
            case EPage.MainMenu: MainWindowFrame.Navigate(new MainMenuPage());break;
            case EPage.Ticket: MainWindowFrame.Navigate(new TicketPage()); break;
            case EPage.Examination: MainWindowFrame.Navigate(new ExaminationPage()); break; 
        }
    }

    private void Exit(object sender, System.ComponentModel.CancelEventArgs e)
    {
        TicketRepository.WriteToJson();
    }
}
