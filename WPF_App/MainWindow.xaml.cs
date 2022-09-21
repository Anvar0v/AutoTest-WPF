using System.Windows;
using WPF_App.EPages;
using WPF_App.Pages;
using WPF_App.Repositories;

namespace WPF_App;

public partial class MainWindow : Window
{
    public static MainWindow Instance;
    public QuestionRepository QuestionRepository;
    public MainWindow()
    {
        InitializeComponent();
        Instance = this;
        QuestionRepository = new QuestionRepository();
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

   
}
