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
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
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

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

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
            dopeHat.ShininessLevel = 1;

            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(userName, fancyRobe, dopeHat);

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                moonLanding,
                packerBowls
            };

            Console.WriteLine(theAdventurer.GetDescription());

            // Loop through all the challenges and subject the Adventurer to them
            // foreach (Challenge challenge in challenges)
            // {
            //     challenge.RunChallenge(theAdventurer);
            // }
            for (int i = 0; i < 5; i++)
            {
                int challengeNumber = new Random().Next(0, challenges.Count);
                challenges[challengeNumber].RunChallenge(theAdventurer);
            }

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
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
                Console.Clear();
                Main(args);
            }
        }
    }
}