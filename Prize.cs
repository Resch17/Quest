using System;

namespace Quest
{
    public class Prize
    {
        private string _text;

        public void ShowPrize(Adventurer person)
        {
            if (person.Awesomeness > 0)
            {
                for (int i = 0; i < person.Awesomeness; i++)
                {
                    Console.WriteLine(_text);
                }
            }
            else 
            {
                Console.WriteLine("Man, really not your day, huh?");
            }
        }

        public Prize(string text)
        {
            _text = text;
        }
    }
}