using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Models;
public class Ticket
{
    public int Index;
    public int CorrectAnswerCount;
    public int QuestionsCount;

    public List<QuestionEntity> Questions;
    public List<TicketData> SelectedQuestionIndex;

    public bool isQuestionCompleted(int questionIndex)
    {
        return SelectedQuestionIndex.Any(td => td.QuestionIndex == questionIndex);
    }

    public bool isChoiceCompleted(int questionIndex, int choiceIndex)
    {
        return SelectedQuestionIndex.Any(td => td.QuestionIndex == questionIndex
        && td.SelectedChoiceIndex == choiceIndex);
    }

    public bool TicketCompleted
    {
        get
        {
           return CorrectAnswerCount == QuestionsCount;
        }
    }

    public Ticket(int index, List<QuestionEntity> questions)
    {
        Index = index;
        Questions = questions;
        SelectedQuestionIndex = new List<TicketData>();
        QuestionsCount = questions.Count;
    }

    public Ticket(int index, int correctAnswerCount, int questionsCount)
    {
        Index =index;
        CorrectAnswerCount = correctAnswerCount;
        QuestionsCount = questionsCount;
    }

    public Ticket()
    {

    }
}

public class TicketData
{
    public int QuestionIndex;
    public int SelectedChoiceIndex;

    public TicketData(int questionIndex, int selectedChoiceIndex)
    {
        QuestionIndex = questionIndex;
        SelectedChoiceIndex = selectedChoiceIndex;
    }
}
