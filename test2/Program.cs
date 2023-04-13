using System.IO;
using System.Text;
using System.Linq;

StreamReader file_input = new StreamReader("C://Users/gilma/OneDrive/Рабочий стол/file_input.txt");
List <string> strings_ = new List<string>();
string line;
line = file_input.ReadLine();

while (line != null)
{
    string[] stri = line.Split(' ', '.', ',', '?', ';', ':', '!', '"', ')', '(');
    foreach (string st in stri)
    { 
        if (String.IsNullOrWhiteSpace(st) != true && st.Equals("-") != true)
        { 
            strings_.Add(st.ToLower()); 
        }
    }
    line = file_input.ReadLine();
}
file_input.Close();

var dict = new Dictionary<string, int>();

foreach (var i in strings_)
{
    bool d = dict.TryAdd(i, 1);
    if (d == false)
    {
        dict[i] += 1;
    }
}

dict = dict.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
StreamWriter file_output = new StreamWriter("C://Users/gilma/OneDrive/Рабочий стол/file_output.txt");

foreach (var item in dict)
{
    file_output.Write(item.Key + " " + item.Value);
    file_output.Write("\n");
}
file_output.Close();
Console.WriteLine(3);
Console.ReadKey();