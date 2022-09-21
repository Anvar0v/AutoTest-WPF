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
    public List<QuestionEntity> Questions;
    public List<int> SelectedQuestionIndex;
    public int QuestionsCount
    {
        get
        {
            return Questions.Count;
        }
    }

    public Ticket (int index, List<QuestionEntity> questions)
    {
        Index = index;
        Questions = questions;
        SelectedQuestionIndex = new List<int>();    
    }
}
