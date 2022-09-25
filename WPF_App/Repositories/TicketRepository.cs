using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WPF_App.Models;

namespace WPF_App.Repositories;
public class TicketRepository
{
    public List<Ticket> UserTickets = new List<Ticket>();

    private const string Folder = "UserData";
    private const string FileName = "usertickets.json";

    public TicketRepository()
    {
        ReadJsonData();
    }

    public void WriteToJson()
    {
        List<Ticket> ticketData = UserTickets
            .Select(t => new Ticket(t.Index, t.CorrectAnswerCount, t.QuestionsCount)).ToList();

        var jsonData = JsonConvert.SerializeObject(ticketData);
        
        if (!Directory.Exists(Folder))
        {
            //if there is no such folder in the directory that the user in, it then opens a new folder
            Directory.CreateDirectory(Folder);
        }
        
        File.WriteAllText(Path.Combine(Folder, FileName), jsonData);
        

    }

    public void ReadJsonData()
    {
        //if there is no such file it breaks the fucn of if statement ⬇️⬇️⬇️
        if (!File.Exists(Path.Combine(Folder, FileName))) return;

        var jsonData = File.ReadAllText(Path.Combine(Folder, FileName));
        UserTickets = JsonConvert.DeserializeObject<List<Ticket>>(jsonData);
    }
}
