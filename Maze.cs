using System;

namespace Engineering_Student_Placement_Test_2021 {
    public class Maze { 
        //A 2D char array to store the maze 
        private Char[,] maze; 
        //An int array to store the start coordinate
        private int[] start = null;

        //Constructor method
        public Maze(String mazename) {
            //Read the maze from the text file
            maze = readMaze(mazename);
        }

        //Getter method for the maze
        public Char[,] getMaze() {
            return maze;
        }

        //Getter method for the start coordinate
        public int[] getStart() {
            return start;
        }

        //A debugging method that prints the maze
        public void printMaze() {
            if (maze != null) {
                int rowLength = maze.GetLength(0);
                int colLength = maze.GetLength(1);

                //Loop through the maze and print each character
                for (int c = 0; c < rowLength; c++) {
                    for (int r = 0; r < colLength; r++) {
                        Console.Write(string.Format("{0}", maze[c, r]));
                    }
                    Console.Write(Environment.NewLine);
                }
                Console.ReadLine();
            }
        }

        //A method to read the maze
        private Char[,] readMaze(String filename) {
            if (!(System.IO.File.Exists(filename))) {
                return null;
            }

            string[] lines = System.IO.File.ReadAllLines(filename);
            int rows = lines.Length;
            int cols = lines[0].Length;
            Char[,] tempMaze = new char[rows, cols];

            int c = 0;
            int r = 0;

            //Loop through every line in the text file
            foreach (string line in lines) {
                //Loop through every char in the line
                foreach (Char ch in line) {
                    //Add char to the maze array
                    tempMaze[r,c] = ch;
                    //If start coordinate store in start variable
                    if (ch == 'A') {
                        start = new int[2];
                        start[0] = r;
                        start[1] = c;
                    }
                    c += 1;
                }
                r += 1;
                c = 0;
            }
            return tempMaze;
        }
    }
}