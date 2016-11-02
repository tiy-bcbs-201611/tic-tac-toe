using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Random computerSpotChooser = new Random();
            int currentMove = 0;
            bool humanWon = false;
            bool computerWon = false;
            string[] plays = new string[]
            {
                "0", "1", "2",
                "3", "4", "5",
                "6", "7", "8"
            };

            // let's play this game: just keep looping
            // until something in the game causes the
            // loop to break.
            while (true)
            {
                // Clear the console
                Console.Clear();
                
                // Draw the current state of the board
                for (int i = 0; i < 9; i = i + 1)
                {
                    Console.Write(" ");
                    Console.Write(plays[i]);
                    Console.Write(" ");
                    if (i == 2 || i == 5)
                    {
                        Console.WriteLine();
                        Console.WriteLine("---+---+---");
                    }
                    else if (i != 8)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }

                // Stop if the human won
                if (humanWon)
                {
                    Console.WriteLine("Good job, human! You won!");
                    break;
                }

                // Stop if the computer won
                if (computerWon)
                {
                    Console.WriteLine("Well, I guess I won. I'm so good.");
                    break;
                }

                // Just stop if the board is full
                if (currentMove == 9)
                {
                    Console.WriteLine("Well, looks like it's a draw.");
                    break;
                }

                // Ask the human for their move
                Console.WriteLine("Hi, human. In what spot would you like to place your X?");
                string humanInput = Console.ReadLine();
                int input = int.Parse(humanInput);
                plays[input] = "X";
                currentMove = currentMove + 1;

                // Did the human win?
                humanWon = (plays[0] == plays[1] && plays[1] == plays[2] && plays[0] == "X");
                humanWon = humanWon || (plays[3] == plays[4] && plays[4] == plays[5] && plays[3] == "X");
                humanWon = humanWon || (plays[6] == plays[7] && plays[7] == plays[8] && plays[6] == "X");
                humanWon = humanWon || (plays[0] == plays[3] && plays[3] == plays[6] && plays[0] == "X");
                humanWon = humanWon || (plays[1] == plays[4] && plays[4] == plays[7] && plays[1] == "X");
                humanWon = humanWon || (plays[2] == plays[5] && plays[5] == plays[8] && plays[2] == "X");
                humanWon = humanWon || (plays[0] == plays[4] && plays[4] == plays[8] && plays[0] == "X");
                humanWon = humanWon || (plays[2] == plays[4] && plays[4] == plays[6] && plays[2] == "X");
                
                if (humanWon)
                {
                    continue;
                }

                // Is the board full, now? It is if this is the ninth move.
                if (currentMove == 9)
                {
                    continue;
                }

                // Find a spot for the computer to move and put an "O" there.
                int nextMove = computerSpotChooser.Next(9);
                while (plays[nextMove] == "X" || plays[nextMove] == "O")
                {
                    nextMove = computerSpotChooser.Next(9);
                }
                plays[nextMove] = "O";
                currentMove = currentMove + 1;

                // Did the computer win?
                computerWon = (plays[0] == plays[1] && plays[1] == plays[2] && plays[0] == "O");
                computerWon = computerWon || (plays[3] == plays[4] && plays[4] == plays[5] && plays[3] == "O");
                computerWon = computerWon || (plays[6] == plays[7] && plays[7] == plays[8] && plays[6] == "O");
                computerWon = computerWon || (plays[0] == plays[3] && plays[3] == plays[6] && plays[0] == "O");
                computerWon = computerWon || (plays[1] == plays[4] && plays[4] == plays[7] && plays[1] == "O");
                computerWon = computerWon || (plays[2] == plays[5] && plays[5] == plays[8] && plays[2] == "O");
                computerWon = computerWon || (plays[0] == plays[4] && plays[4] == plays[8] && plays[0] == "O");
                computerWon = computerWon || (plays[2] == plays[4] && plays[4] == plays[6] && plays[2] == "O");

                if (computerWon)
                {
                    continue;
                }
            }

            Console.WriteLine("Press ENTER to close the window...");
            Console.ReadLine();
        }
    }
}
