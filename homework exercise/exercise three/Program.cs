using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_three
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] player = new Player[] { };
            #region Questions
            string[] answers = new string[] { "1. Which of the variable types is not a C# variable type?", "a) int", " b) var", "c) let", "d) string" };
            string[] answersTwo = new string[] { "2. If we declare an int variable in C# without initialization what efault value will it get?", "a) undefined", "b) 0", "c) null", "d) cant declare variable without initialization " };
            string[] answersThree = new string[] { "3. If we declare an var variable in C# without initialization what value will it get?", "a) undefined", "b) 0", "c) null", "d) cant declare var without initialization" };
            Question question = new Question(answers);
            Question questionTwo = new Question(answersTwo);
            Question questionThree = new Question(answersThree);
            TheAnswer[,] users = new TheAnswer[3, 5] {
                {
            new TheAnswer(question.Answer[0], false),
            new TheAnswer(question.Answer[1], false),
            new TheAnswer(question.Answer[2], false),
            new TheAnswer(question.Answer[3], true),
            new TheAnswer(question.Answer[4],false)
                },
                {
            new TheAnswer(questionTwo.Answer[0],false),
            new TheAnswer(questionTwo.Answer[1], false),
            new TheAnswer(questionTwo.Answer[2], true),
            new TheAnswer(questionTwo.Answer[3], false),
            new TheAnswer(questionTwo.Answer[4],false)
                },
                {
            new TheAnswer(questionThree.Answer[0],false),
            new TheAnswer(questionThree.Answer[1], false),
            new TheAnswer(questionThree.Answer[2], false),
            new TheAnswer(questionThree.Answer[3], false),
            new TheAnswer(questionThree.Answer[4],true)
                }
            };
            #endregion
            Quiz(users, player);
            Console.ReadLine();
        }
        public static int TrueAnswer(TheAnswer question, TheAnswer firstAnswer, TheAnswer secondAnswer, TheAnswer thirdAnswer, TheAnswer fourthAnswer)
        {
            string input = "a";
            do
            {
                Console.WriteLine("Your answer");
                input = Console.ReadLine();
                if ((firstAnswer.TrueOrFalse == true && input.ToLower() == "a") || (secondAnswer.TrueOrFalse == true && input.ToLower() == "b") || (thirdAnswer.TrueOrFalse == true && input.ToLower() == "c") || (fourthAnswer.TrueOrFalse == true && input.ToLower() == "d"))
                {
                    Console.WriteLine("\n Correct \n");
                    return 1;
                }
                else if ((firstAnswer.TrueOrFalse == false && input.ToLower() == "a") || (secondAnswer.TrueOrFalse == false && input.ToLower() == "b") || (thirdAnswer.TrueOrFalse == false && input.ToLower() == "c") || (fourthAnswer.TrueOrFalse == false && input.ToLower() == "d"))
                {
                    Console.WriteLine("\n Inccorect \n");
                    return 0;
                }
                else
                {
                    Console.WriteLine("\n Wrong input \n");
                }

            } while (input.ToLower() != "a" || input.ToLower() != "b" || input.ToLower() != "c" || input.ToLower() != "d");
            return 0;
        }
        public static void Quiz(TheAnswer[,] users, Player[] player)
        {
            string input;
            do
            {
                Console.WriteLine("Start quiz:\n Y for start \n N for exit ");
                input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    Console.WriteLine("enter name");
                    string userName = Console.ReadLine();
                    int score = 0;
                    for (int q = 0; q < 3; q++)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            Console.WriteLine($"{users[q, i].Answer}\n{users[q, i + 1].Answer} \n {users[q, i + 2].Answer} \n {users[q, i + 3].Answer}\n{users[q, i + 4].Answer}");
                            score += TrueAnswer(users[q, i], users[q, i + 1], users[q, i + 2], users[q, i + 3], users[q, i + 4]);
                        }
                    }
                    Player newPlayer = new Player(userName, score);
                    Array.Resize(ref player, player.Length + 1);
                    player[player.Length - 1] = newPlayer;
                    Console.WriteLine("User name: Score:");
                    foreach (Player allPlayers in player)
                    {
                        Console.WriteLine($"{allPlayers.UserName}          {allPlayers.Score}");
                    }
                }
                else if (input.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            } while (input.ToLower() == "y" || input != "n");
        }
    }
}
