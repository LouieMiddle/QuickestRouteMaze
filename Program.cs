using System;

namespace Engineering_Student_Placement_Test_2021 {
    class Program {
        static void Main(string[] args) {
            String input;
            Maze maze = null;
            QuickestRoute quickestRoute = null;

            //Get name of maze file
            Console.WriteLine("Enter the name of a maze file. Please include file extension '.txt'. Enter 'Quit' to quit.");
            Console.Write("Enter here: ");
            input = Console.ReadLine();

            //While not equal to quit
            while (input.Equals("Quit") != true) {
                //Create a maze object storing the maze
                maze = new Maze(input);
                //Calculate the quickest route out of the maze
                quickestRoute = new QuickestRoute(maze);
                //Print the result to the console if the result is not null
                if (!(string.IsNullOrEmpty(quickestRoute.getQuickestRoute()))) { 
                    Console.WriteLine(quickestRoute.getQuickestRoute());
                }
                //Take user input again unless they quit
                Console.WriteLine("Enter the name of a maze file. Enter 'Quit' to quit.");
                Console.Write("Enter here: ");
                input = Console.ReadLine();
            }
        }
    }
}
