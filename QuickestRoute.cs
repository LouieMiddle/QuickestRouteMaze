using System;
using System.Collections;

namespace Engineering_Student_Placement_Test_2021 {
    public class QuickestRoute {
        //A 2D char array to store the maze 
        private Char[,] maze;
        //An int array to store the start coordinate
        private int[] start;
        //A string to store the quickest route out of the maze
        private String quickestRoute = null;
        //Row and column directions for calculating shortest path
        private int[] dRow = new int[] {-1,1,0,0};
        private int[] dCol = new int[] {0,0,1,-1};

        //Constructor method
        public QuickestRoute(Maze m) {
            //Get values from given maze
            maze = m.getMaze();
            start = m.getStart();
            //Calculate the shortest path
            shortestPath();
        }

        //Getter method for the quickest route
        public String getQuickestRoute() {
            return quickestRoute;
        }

        /*Finds the shortest path between A and B for a given maze.
          Implements a breadth first search algorithm for a grid. */
        private void shortestPath() {
            //Handling invalid mazes or input
            if (maze == null) {
                Console.WriteLine("File does not exist. Please try again and check for typos.");
                return;
            }
            else if (start == null) {
                Console.WriteLine("There is no start point.");
                return;
            }
            
            //Create a new queue and add the start coordinate to it
            Queue q = new Queue();
            q.Enqueue(start);

            //The number of rows and columns in the maze
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            //A 2D boolean array to store which coordinates have been visited
            bool[,] visited = new bool[rows, cols]; 
            visited[start[0], start[1]] = true;

            //A 2D char array to store the direction travelled to reach a coordinate
            char[,] prev = new char[rows, cols];
            
            while (q.Count != 0) {
                int[] cur = q.Dequeue() as int[];

                //For all surrounding coordinates
                for (int i = 0; i < 4; i++) {
                    //The row and column
                    int r = cur[0] + dRow[i];
                    int c = cur[1] + dCol[i];
                    
                    //If the surrounding coordinate takes you out of bounds continue
                    if ((r < 0) || (c < 0 )) {
                        continue;
                    }
                    else if ((r >= rows) || (c >= cols)) {
                        continue;
                    }
                    //Otherwise process it
                    else  {
                        //If coordinated has not been visited
                        if (visited[r,c] != true) {
                            //It is a wall so visit it, but don't add to queue
                            if (maze[r,c] == 'x') {
                                visited[r,c] = true;
                            }
                            //If it is the end break and reconstruct the path
                            else if (maze[r,c] == 'B') {
                                prev[r,c] = getDirection(cur, r, c);  
                                reconstructPath(prev, r, c);
                                //Return so you don't reach the end of the function
                                return; 
                            }
                            //Otherwise add to the queue
                            else {
                                int[] n = new int[2] {r,c};
                                q.Enqueue(n);
                                visited[r,c] = true;
                                prev[r,c] = getDirection(cur, r, c); 
                            }
                        }
                    }
                }
            }
            //If the function reaches here a B was not found, there is no way out of the maze
            quickestRoute = "There is no route from A to B, or there simply is no end point.";
        }

        //Gets the direction travelled given the cur coordinated and the one currently being processed
        private char getDirection(int[] cur, int r, int c) {
            if (r - cur[0] == 1) {
                return 'S';
            }
            else if (r - cur[0] == -1) {
                return 'N';
            }
            else if (c - cur[1] == 1) {
                return 'E';
            }
            else if (c - cur[1] == -1) {
                return 'W';
            }
            else {
                return '\0';
            }
        } 

        //Reconstructs the path taken from A to B
        private void reconstructPath(char[,] prev, int r, int c) {
            //Keep going until prev is equal to '\0' as the start coordinate will have no direction stored
            while (prev[r,c].Equals('\0') != true) {
                //Add direction to the quickest route
                quickestRoute += prev[r,c]; 
                //Figures out which coordinate we got to the coordinate (r,c) from
                if (prev[r,c] == 'S') {
                    r--;
                }
                else if (prev[r,c] == 'N') {
                    r++;
                }
                else if (prev[r,c] == 'E') {
                    c--;
                }
                else if (prev[r,c] == 'W') {
                    c++;
                }
            }
            //Reverse the string as it is back to front
            char[] qr = quickestRoute.ToCharArray();
            Array.Reverse(qr);
            quickestRoute = String.Concat(qr);
        }
    }
}