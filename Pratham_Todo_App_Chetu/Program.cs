// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class Person
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string Date { get; set; }

    public string Status { get; set; }  
}

/*class Program
{
    static void Main()
    {
        string jsonFilePath = "C:\\Users\\ASUS\\source\\repos\\Pratham_Todo_App_Chetu\\Pratham_Todo_App_Chetu\\TodoList.json";

        // Check if the file exists
        if (File.Exists(jsonFilePath))
        {
            // Read the entire JSON file content
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON content into your C# class
            Person person = JsonConvert.DeserializeObject<Person>(jsonContent);

            // Now, you can access the data from the Person object
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Email: {person.Email}");

            //

        }
        else
        {
            Console.WriteLine("JSON file not found!");
        }
    }
}

*/


public class Program
{
    private const string jsonFilePath = "C:\\Users\\ASUS\\source\\repos\\Pratham_Todo_App_Chetu\\Pratham_Todo_App_Chetu\\TodoList.json";

    static void Main()
    {

        string start = "---- Task Manager ----\r\n1. Add a Task\r\n2. View Tasks\r\n3. Mark Completed\r\n4. Delete Task\r\n5. Exit";
        // Example of adding new data
        Console.WriteLine(start);
        Console.Write("Enter your choice: ");
        int choice=Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            
                case 1: Console.WriteLine("1. Add a Task");
                Console.Write("Enter Task Name: ");
                string task_name=Console.ReadLine();
                Console.Write("Enter Description: ");
                string ? desc = Console.ReadLine();
                Console.Write("Enter Due Date (yyyy-mm-dd): ");
                string due_date = Console.ReadLine();

                Person newPerson = new Person
                {
                    Name = task_name,
                    Desc = desc,
                    Date = due_date,
                    Status="Incomplete"
                };
                AddDataToJsonFile(newPerson);
                break;
                case 2: Console.WriteLine("---- View Tasks ----\r\n");
                List<Person> allPersons = ReadDataFromJsonFile();
                foreach (Person person in allPersons)
                {
                    Console.WriteLine($"Name: {person.Name}");
                    Console.WriteLine($"Age: {person.Desc}");
                    Console.WriteLine($"Email: {person.Date}");
                    Console.WriteLine();
                }
                break;
                case 3: Console.WriteLine("3. Mark Completed");
                break;
                case 4: Console.WriteLine("4. Delete Task");
                break;
                case 5: Console.WriteLine("5. Exit");
                break;
       }
        /*Person newPerson = new Person
        {
            Name = "Jane Smith",
            Age = 23,
            Email = "jane.smith@example.com"
        };*/

        

        // After adding data, read and display the updated content
       
    }

    static List<Person> ReadDataFromJsonFile()
    {
        List<Person> allPersons = new List<Person>();

        if (File.Exists(jsonFilePath))
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            allPersons = JsonConvert.DeserializeObject<List<Person>>(jsonContent);
        }

        return allPersons;
    }

    static void AddDataToJsonFile(Person newPerson)
    {
        List<Person> allPersons = ReadDataFromJsonFile();
        allPersons.Add(newPerson);

        string jsonContent = JsonConvert.SerializeObject(allPersons, Formatting.Indented);
        File.WriteAllText(jsonFilePath, jsonContent);
    }
}


