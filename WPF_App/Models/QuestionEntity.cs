using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Models;
public  class QuestionEntity
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<Choice> Choices { get; set; }
    public Media Media { get; set; }
    public string Description { get; set; }
    public bool isCompleted { get; set; }

}
