using System;
namespace FifteenPuzzle
{
    class program
    {
        static void Main (string[] args)
        {
            Player newPlayer = new Player();
            Game.CreateGameBoard(newPlayer.gameBoard);
            Console.WriteLine("The zero can switch locations with another piece next to it. You have to arrange the numbers in numerical order");
            Console.WriteLine("Use the letters 'w' 'a' 's' 'd' or keypad '8' '4' '2' '6' to represent 'up' 'left' 'down' 'right'");
            Console.WriteLine("Press any Key to Contine");
            Console.ReadLine();
            do 
            {
                newPlayer.displayGameBoard();
                Console.WriteLine("Pick a way to move");
                string userMovementInput = Console.ReadLine().ToLower();
                Game.PieceMovement(userMovementInput, newPlayer.gameBoard);
                Console.Clear();

            } while(Game.checkIfWon(newPlayer.gameBoard) == false);

            if(Game.checkIfWon(newPlayer.gameBoard) == true)
            {
                newPlayer.displayGameBoard();
                Console.WriteLine("Congratulation! You Won!");
            }

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
            //Not sure if I should reuse playerGameBoard as a requirment here (used it in above function), I'm sure it will run fine, just want know if it would be "correct"
            public static void PieceMovement(string positionInput, int[,] playerGameBoard)
            {
                // Might have been a good place to use a tuple
                int xPosition=0;
                int yPosition=0;
                int xNewPosition=0;
                int yNewPosition=0;
                int tempHolding;

                for (int i=0;i<4;i++)
                {
                    for (int k=0;k<4;k++)
                    {
                        if (playerGameBoard[i,k] == 0)
                        {
                            xPosition =i;
                            yPosition =k;
                            xNewPosition=i;
                            yNewPosition=k;
                        }
                    }
                }
                if (positionInput == "8" | positionInput == "w" | positionInput == "4" | positionInput == "a" | positionInput == "6" | positionInput == "d" | positionInput == "2" | positionInput == "s")
                {
                    if (positionInput == "8" || positionInput == "w")
                    {
                        xNewPosition -= 1;
                    }
                    if (positionInput == "4" || positionInput == "a")
                    {
                        yNewPosition -= 1;
                    }
                    if (positionInput == "6" || positionInput == "d")
                    {
                        yNewPosition += +1;
                    }
                    if (positionInput == "2" || positionInput == "s")
                    {
                        xNewPosition += 1;
                    }
                    if (xNewPosition>3 || yNewPosition>3 || xNewPosition<0 || yNewPosition<0)
                    {
                        Console.WriteLine("You can't leave the board! Please pick a valid move! Press any button to continue.");
                        Console.ReadLine();
                    } else 
                    {
                        tempHolding = playerGameBoard[xNewPosition,yNewPosition];
                        playerGameBoard[xNewPosition,yNewPosition] = 0;
                        playerGameBoard[xPosition,yPosition] = tempHolding;
                    }
                    
                } else
                {
                    Console.WriteLine("Please put in a valid movement. Press any button to continue.");
                    Console.ReadLine();
                }
            }
            public static bool checkIfWon(int[,] playerGameBoard)
            {
                bool won =false;
                int[,] completeBoard = new int [4,4]
                {
                    {1,2,3,4},
                    {5,6,7,8},
                    {9,10,11,12},
                    {13,14,15,0}
                };
                if (playerGameBoard ==completeBoard)
                {
                    won = true;
                }
                return won;
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