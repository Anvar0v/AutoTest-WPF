using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Models;

namespace WPF_App.Repositories;

public class QuestionRepository
{
    public List<QuestionEntity> Questions {get ;set;}
    public int TicketQuestionsCount = 10;

    public QuestionRepository()
    {
        LoadQuestionsFromJsonFile();
    }

    public void LoadQuestionsFromJsonFile()
    {
        string path = "JsonData/uzlotin.json";
        string jsonString = File.ReadAllText(path);
        Questions = JsonConvert.DeserializeObject<List<QuestionEntity>>(jsonString);
    }

    //we have to get the of the questions
    public int GetTicketsCount()
    {
        return Questions.Count / TicketQuestionsCount;
    }

    public List<QuestionEntity> GetQuestuionsRange(int from,int count)
    {
        return Questions.Skip(from).Take(count).ToList();
    }
}

/*public List<QuestionEntity> Questions { get; set; }

public QuestionRepository()
{
    LoadQuestionsFromJsonFile();
}

public void LoadQuestionsFromJsonFile()
{
    string path = "JsonData/uzlotin.json";
    string jsonString = File.ReadAllText(path);
    Questions = JsonConvert.DeserializeObject<List<QuestionEntity>>(jsonString);
}*/
