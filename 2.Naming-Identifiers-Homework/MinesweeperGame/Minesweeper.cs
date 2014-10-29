using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Minesweeper
    {
        public class Ranking
        {
            private string playerName;
            private int playerScore;

            public Ranking(string playerName, int playerScore)
            {
                this.PlayerName = playerName;
                this.PlayerScore = playerScore;
            }

            public string PlayerName { get; set; }

            public int PlayerScore { get; set; }
        }

        private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] playingField = CreatePlayingField();
            char[,] bombs = PutBombs();
            int countPoints = 0;
            bool isExplosion = false;
            List<Ranking> champions = new List<Ranking>(6);
            int row = 0;
            int coll = 0;
            bool isNewGame = true;
            const int maxBoardValue = 35;
            bool isWin = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine(
                        "Let's play on the Minesweeper. Try to find the fields without minesweeper.\n"
                        + "To see the ranking enter 'top'\nTo start a new game enter 'restart'\nTo get out of the game enter 'exit'");
                    PrintBoard(playingField);
                    isNewGame = false;
                }

                Console.Write("Enter the row and column separate by space:");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out coll)
                        && row <= playingField.GetLength(0) && coll <= playingField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRanking(champions);
                        break;
                    case "restart":
                        playingField = CreatePlayingField();
                        bombs = PutBombs();
                        PrintBoard(playingField);
                        isExplosion = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye, Bye!");
                        break;
                    case "turn":
                        if (bombs[row, coll] != '*')
                        {
                            if (bombs[row, coll] == '-')
                            {
                                MakeMove(playingField, bombs, row, coll);
                                countPoints++;
                            }

                            if (maxBoardValue == countPoints)
                            {
                                isWin = true;
                            }
                            else
                            {
                                PrintBoard(playingField);
                            }
                        }
                        else
                        {
                            isExplosion = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (isExplosion)
                {
                    PrintBoard(bombs);
                    Console.Write("\nUupppsss! You died heroically with {0} points. " + "Enter nickname: ", countPoints);
                    string playerNickname = Console.ReadLine();
                    Ranking gameRank = new Ranking(playerNickname, countPoints);
                    if (champions.Count < 5)
                    {
                        champions.Add(gameRank);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].PlayerScore < gameRank.PlayerScore)
                            {
                                champions.Insert(i, gameRank);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Ranking previousRankCollection, Ranking newRankCollection) => newRankCollection.PlayerName.CompareTo(previousRankCollection.PlayerName));
                    champions.Sort((Ranking previousRankCollection, Ranking newRankCollection) => newRankCollection.PlayerScore.CompareTo(previousRankCollection.PlayerScore));
                    PrintRanking(champions);

                    playingField = CreatePlayingField();
                    bombs = PutBombs();
                    countPoints = 0;
                    isExplosion = false;
                    isNewGame = true;
                }

                if (isWin)
                {
                    Console.WriteLine("\nGood for you! You open 35 cells without a drop of blood");
                    PrintBoard(bombs);
                    Console.WriteLine("Enter your name: ");
                    string playerName = Console.ReadLine();
                    Ranking rankPoints = new Ranking(playerName, countPoints);
                    champions.Add(rankPoints);
                    PrintRanking(champions);
                    playingField = CreatePlayingField();
                    bombs = PutBombs();
                    countPoints = 0;
                    isWin = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("Nice isn't it?!");
            Console.Read();
        }

        private static void PrintRanking(List<Ranking> gamePoints)
        {

            if (gamePoints.Count > 0)
            {
                Console.WriteLine("\nPoints:");
                for (int i = 0; i < gamePoints.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, gamePoints[i].PlayerName, gamePoints[i].PlayerScore);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty rank!\n");
            }
        }

        private static void MakeMove(char[,] field, char[,] bombs, int row, int coll)
        {
            char bombsCollection = CountBombs(bombs, row, coll);
            bombs[row, coll] = bombsCollection;
            field[row, coll] = bombsCollection;
        }

        private static void PrintBoard(char[,] board)
        {
            int boardRow = board.GetLength(0);
            int boardColl = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRow; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardColl; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PutBombs()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] playingField = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    playingField[i, j] = '-';
                }
            }

            List<int> bombsPosition = new List<int>();
            const int defaultWhileCounterValue = 15;
            const int maxRandomCounterValue = 50;
            while (bombsPosition.Count < defaultWhileCounterValue)
            {
                Random randomizingBombs = new Random();
                int nextRandomValue = randomizingBombs.Next(maxRandomCounterValue);
                if (!bombsPosition.Contains(nextRandomValue))
                {
                    bombsPosition.Add(nextRandomValue);
                }
            }

            foreach (int position in bombsPosition)
            {
                int boardRow = position / boardColumns;
                int boardColl = position % boardColumns;
                if (boardColl == 0 && position != 0)
                {
                    boardRow--;
                    boardColl = boardColumns;
                }
                else
                {
                    boardColl++;
                }

                playingField[boardRow, boardColl - 1] = '*';
            }

            return playingField;
        }

        private static void CalculateNumberOfBombs(char[,] board)
        {
            int boardColl = board.GetLength(0);
            int boardRow = board.GetLength(1);

            for (int i = 0; i < boardColl; i++)
            {
                for (int j = 0; j < boardRow; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char numbersOfBombs = CountBombs(board, i, j);
                        board[i, j] = numbersOfBombs;
                    }
                }
            }
        }

        private static char CountBombs(char[,] board, int row, int coll)
        {
            int numbersofBombs = 0;
            int boardRow = board.GetLength(0);
            int boardColl = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, coll] == '*')
                {
                    numbersofBombs++;
                }
            }

            if (row + 1 < boardRow)
            {
                if (board[row + 1, coll] == '*')
                {
                    numbersofBombs++;
                }
            }

            if (coll - 1 >= 0)
            {
                if (board[row, coll - 1] == '*')
                {
                    numbersofBombs++;
                }
            }

            if (coll + 1 < boardColl)
            {
                if (board[row, coll + 1] == '*')
                {
                    numbersofBombs++;
                }
            }

            if ((row - 1 >= 0) && (coll - 1 >= 0))
            {
                if (board[row - 1, coll - 1] == '*')
                {
                    numbersofBombs++;
                }
            }

            if ((row - 1 >= 0) && (coll + 1 < boardColl))
            {
                if (board[row - 1, coll + 1] == '*')
                {
                    numbersofBombs++;
                }
            }

            if ((row + 1 < boardRow) && (coll - 1 >= 0))
            {
                if (board[row + 1, coll - 1] == '*')
                {
                    numbersofBombs++;
                }
            }

            if ((row + 1 < boardRow) && (coll + 1 < boardColl))
            {
                if (board[row + 1, coll + 1] == '*')
                {
                    numbersofBombs++;
                }
            }

            return char.Parse(numbersofBombs.ToString());
        }
    }
}