using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge moonLanding = new Challenge("What year did first land on to the moon?", 1969, 30);
            Challenge packerBowls = new Challenge("How many Super Bowls have the Green Bay Packers won?", 4, 50);
            Challenge nineSqrt = new Challenge("What is the square root of 9?", 3, 15);

            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                moonLanding,
                packerBowls,
                nineSqrt
            };

            Console.WriteLine("Greetings, adventurer! What is your name?");
            Console.Write("> ");
            string userName = Console.ReadLine();

            Robe fancyRobe = new Robe();
            fancyRobe.Length = 72;
            fancyRobe.Colors = new List<string>()
            {
                "green", "mauve", "silver", "gold", "yellow", "turquoise"
            };

            Hat dopeHat = new Hat();
            dopeHat.ShininessLevel = 8;

            Adventurer theAdventurer = new Adventurer(userName, fancyRobe, dopeHat);
            theAdventurer.ChallengesPassed = 0;

            bool playing = true;

            while (playing)
            {

                Console.WriteLine(theAdventurer.GetDescription());

                for (int i = 0; i < 5; i++)
                {
                    int challengeNumber = new Random().Next(0, challenges.Count);
                    challenges[challengeNumber].RunChallenge(theAdventurer);
                }

                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                Prize reward = new Prize("Gold coin");
                Console.WriteLine("Press any key to receive your reward...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Behold, your reward: ");
                reward.ShowPrize(theAdventurer);

                Console.WriteLine("Wanna play again? (y/n)");
                Console.Write("> ");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "y")
                {
                    theAdventurer.Awesomeness += (theAdventurer.ChallengesPassed * 10);
                    Console.Clear();
                }
                else
                {
                    playing = false;
                }
            }
        }
    }
}