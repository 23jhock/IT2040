namespace DictionaryExample;

class Program
{
    static void Main(string[] args)
    {
        //Declare a dictionary of student names and scores. Name is a string and score is a float
        Dictionary<string, float> studentScores = new Dictionary<string, float>(){
            {"Brian", 94},
            {"Cydni", 97.1f},
            {"Truman", 87.7f}
        };

        //add an entry to the dictionary
        studentScores.Add("Jaime", 89);

        //print values from the dictionary
        Console.WriteLine("Get Values from Dictionary\n----------------");
        Console.WriteLine(studentScores["Brian"]);
        Console.WriteLine(studentScores["Cydni"]);

        //loop through the dictionary
        Console.WriteLine("\nGet Key & Values from Dictionary\n----------------");
        foreach(KeyValuePair<string, float> student in studentScores){
            Console.WriteLine($"{student.Key}: {student.Value}");
        }

        //loop through the dictionary keys
        Console.WriteLine("\nGet Values from Dictionary Using the key\n----------------");
        foreach(string key in studentScores.Keys){
            Console.WriteLine($"{key}: {studentScores[key]}");
        }

        //reference a key that is not in the dictionary
        //Console.WriteLine(studentScores["Tyler"]);

        //check if key exists in the dictionary
        Console.WriteLine("\nSearch Dictionary for Valid Key\n----------------");
        string searchKey = "Truman";

        if(studentScores.ContainsKey(searchKey)){
            Console.WriteLine($"{searchKey}: {studentScores[searchKey]}");
        }else{
            Console.WriteLine($"{searchKey} not found in the Dictionary");
        }



    }
}
