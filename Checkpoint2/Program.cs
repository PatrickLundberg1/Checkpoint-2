
using Checkpoint2;

//##Level 3

// Create Product_Table and Product classes
// Product_Table class should handle the logic for storing and displaying Product objects
Product_Table PT = new Product_Table();
bool result_status;

while (true)
{
    Console.WriteLine("--------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
    Console.ResetColor();

    result_status = PT.Add_Product("Q");

    if (!result_status)
    {
        PT.Display();
        string command;

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("To enter a new product - enter: \"P\" | To quit - enter: \"Q\"");
            Console.ResetColor();
            command = (Console.ReadLine() ?? "").Trim().ToLower();

            if(command == "q")
            {
                // exit program
                return;
            }else if(command == "p")
            {
                if (!PT.Add_Product("Q"))
                {
                    return;
                }
            }
        }
    }
}