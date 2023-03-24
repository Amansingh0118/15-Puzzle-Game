using System;
namespace FifteenPuzzle
{
    class program
    {
        static void Main (string[] args)
        {
            Player newPlayer = new Player();
            Game.CreateGameBoard(newPlayer.gameBoard);
            newPlayer.displayGameBoard();
            

        }

        public static class Game
        {
            public static void CreateGameBoard(int[,] playerGameBoard)
            {
                int[] usedNumbers = new int[15];
                //Creates a random number and places it in usedNumbers array. Needs to be moved to the playerGameBoard 2d array.
                for (int i=0; i<15; i++)
                {
                    Random random = new Random();
                    int x = random.Next(1,16);
                    bool test = true;
                        //tests if the number has already ben used
                        for (int k=0;k<i;k++)
                        {
                            if (x==usedNumbers[k])
                            {
                                test = false;
                                break;
                            }
                        }
                    if (test == true)
                    {
                        usedNumbers[i] = x;
                    } else 
                    {
                        i--;
                    }                    
                }
               //Move numbers from usedNumbers array to gameBoard 2d array. playerGameBoard[3,3] will always be 0 since there are 15 numbers and 16 squares.
               int row =0;
               int column = 0;
               for (int k=0;k<15;k++)
               {
                playerGameBoard[row,column] = usedNumbers[k];
                column++;
               if (column == 4)
               {
                row++;
                column=0;
               }
               } 
               
            }
            public static void PieceMovement()
            {
                
            }
        }
        public class Player
        {
            public int[,] gameBoard = new int[4,4];

            public void displayGameBoard()
            {
                /*Console.WriteLine("| " + gameBoard[0,0]+ " | " + gameBoard[0,1]+ " | "+ gameBoard[0,2] + " | " + gameBoard[0,3] + " |");
                Console.WriteLine("| " + gameBoard[1,0]+ " | " + gameBoard[1,1]+ " | "+ gameBoard[1,2] + " | " + gameBoard[1,3] + " |");
                Console.WriteLine("| " + gameBoard[2,0]+ " | " + gameBoard[2,1]+ " | "+ gameBoard[2,2] + " | " + gameBoard[2,3] + " |");
                Console.WriteLine("| " + gameBoard[3,0]+ " | " + gameBoard[3,1]+ " | "+ gameBoard[3,2] + " | " + gameBoard[3,3] + " |");*/

                Console.WriteLine($"| {gameBoard[0,0], 3} | {gameBoard[0,1], 2} | {gameBoard[0,2], 2} | {gameBoard[0,3], 3} |");
                Console.WriteLine($"| {gameBoard[1,0], 3} | {gameBoard[1,1], 2} | {gameBoard[1,2], 2} | {gameBoard[1,3], 3} |");
                Console.WriteLine($"| {gameBoard[2,0], 3} | {gameBoard[2,1], 2} | {gameBoard[2,2], 2} | {gameBoard[2,3], 3} |");
                Console.WriteLine($"| {gameBoard[3,0], 3} | {gameBoard[3,1], 2} | {gameBoard[3,2], 2} | {gameBoard[3,3], 3} |");
            }
        }
    }
}