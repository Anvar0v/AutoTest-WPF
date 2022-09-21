using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPF_App.EPages;
using WPF_App.Models;
using WPF_App.Repositories;

namespace WPF_App.Pages;

public partial class ExaminationPage : Page
{
    public Ticket currentTicket;
    private int currrentQuestionIndex;
    public ExaminationPage(int? currentTicketIndex = null)
    {
        InitializeComponent();

        if (currentTicketIndex == null)
        {

            currentTicketIndex = new Random().Next(0, MainWindow.Instance.QuestionRepository.GetTicketsCount());
            Title.Content = $"{currentTicketIndex + 1}";

        }

        Title.Content = $"Ticket {currentTicketIndex + 1}";
        CreateTicket(currentTicketIndex.Value);
        ShowQuestion();
        GenerateQuestionIndexButtons();

    }

    private void CreateTicket(int ticketIndex)
    {
        var ticketQuestionsCount = MainWindow.Instance.QuestionRepository.TicketQuestionsCount;
        var from = ticketIndex * ticketQuestionsCount;
        var ticketQuestions = MainWindow.Instance.QuestionRepository.GetQuestuionsRange(from, ticketQuestionsCount);
        currentTicket = new Ticket(ticketIndex, ticketQuestions);
    }

    private void Menu(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.DisplayPage(EPage.MainMenu);
    }

    private void ShowQuestion()
    {
        var questionRepository = new QuestionRepository();
        var question = currentTicket.Questions[currrentQuestionIndex];
        QuestionText.Text = $"{currrentQuestionIndex + 1} {question.Question}";

        LoadQuestionIamge(question.Media);
        GenerateChoiceButtons(question.Choices);
    }

    private void LoadQuestionIamge(Media questionImage)
    {
        string ImagePath;
        if (questionImage.Exist)
        {
            ImagePath = Path.Combine(Environment.CurrentDirectory, "Images", $"{questionImage.Name}.png");
        }
        else
        {
            ImagePath = Path.Combine(Environment.CurrentDirectory, "Images", $"noPhoto.jpg");
        }

        QuestionImage.Source = new BitmapImage(new Uri(ImagePath));
    }

    private void GenerateChoiceButtons(List<Choice> choices)
    {
        ChoicesPanel.Children.Clear();
        for (int i = 0; i < choices.Count; i++)
        {
            var button = new Button();
            button.Height = 40;
            button.Width = 490;
            button.FontSize = 14;
            button.Margin = new Thickness(5);
            button.Content = choices[i].Text;
            button.Tag = choices[i];

            button.FontWeight = FontWeights.DemiBold;
            button.BorderBrush = new SolidColorBrush(Colors.Teal);
            button.Background = new SolidColorBrush(Colors.Snow);
            button.Click += ChoiceButtonClick;

            if (choices[i].isSelected)
            {
                if (choices[i].Answer)
                {
                    button.Background = new SolidColorBrush(Colors.LightGreen);
                }
                else
                {
                    button.Background = new SolidColorBrush(Colors.Red);
                }
            }
            var textBlock = new TextBlock();
            textBlock.Text = choices[i].Text;
            textBlock.TextWrapping = TextWrapping.Wrap;
            button.Content = textBlock;

            ChoicesPanel.Children.Add(button);
        }
    }

    private void ChoiceButtonClick(object sender, RoutedEventArgs e)
    {
        if (currentTicket.Questions[currrentQuestionIndex].isCompleted) return;
        var button = sender as Button;
        var choice = (Choice)button.Tag;
        if (choice.Answer)
        {
            button.Background = new SolidColorBrush(Colors.LightGreen);
            (QuestionIndexButtonPanel.Children[currrentQuestionIndex] as Button)!.Background = new SolidColorBrush(Colors.LightGreen);
            currentTicket.CorrectAnswerCount++;
        }
        else
        {
            button.Background = new SolidColorBrush(Colors.Red);
            (QuestionIndexButtonPanel.Children[currrentQuestionIndex] as Button)!.Background = new SolidColorBrush(Colors.Red);
        }
        choice.isSelected = true;
        currentTicket.Questions[currrentQuestionIndex].isCompleted = true;

        currentTicket.SelectedQuestionIndex.Add(currrentQuestionIndex);
        if (currentTicket.SelectedQuestionIndex.Count == currentTicket.QuestionsCount)
        {
            MainWindow.Instance.MainWindowFrame.Navigate(new ExaminationResultPage(currentTicket));
        }
    }

    public void GenerateQuestionIndexButtons()
    {
        for (int i = 0; i < currentTicket.QuestionsCount; i++)
        {
            var button = new Button();
            button.Height = 30;
            button.Width = 30;
            button.Content = i + 1;
            button.FontSize = 16;
            button.Tag = i;
            button.BorderBrush = new SolidColorBrush(Colors.Teal);
            QuestionIndexButtonPanel.Children.Add(button);
            button.Click += QuestionIndexButtonsClick;
        }
    }

    private void QuestionIndexButtonsClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        currrentQuestionIndex = (int)button.Tag;
        ShowQuestion();
    }

}
