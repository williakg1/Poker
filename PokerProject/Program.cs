using System;
using System.Collections.Generic;

namespace PokerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Players
            Console.WriteLine("Enter player 1's Name");
            string Player1 = Console.ReadLine();

            Console.WriteLine("Enter PLayer 2's Name");
            string Player2 = Console.ReadLine();

            //Set the list full of all card options 
            List<string> Deck = new List<string>();

            Deck.Add("2S"); Deck.Add("3S"); Deck.Add("4S"); Deck.Add("5S"); Deck.Add("6S"); Deck.Add("7S"); Deck.Add("8S");
            Deck.Add("9S"); Deck.Add("10S"); Deck.Add("JS"); Deck.Add("QS"); Deck.Add("KS"); Deck.Add("2D"); Deck.Add("3D");
            Deck.Add("4D"); Deck.Add("5D"); Deck.Add("6D"); Deck.Add("7D"); Deck.Add("8D"); Deck.Add("9D"); Deck.Add("10D");
            Deck.Add("JD"); Deck.Add("QD"); Deck.Add("KD"); Deck.Add("2H"); Deck.Add("3H"); Deck.Add("4H"); Deck.Add("5H");
            Deck.Add("6H"); Deck.Add("7H"); Deck.Add("8H"); Deck.Add("9H"); Deck.Add("10H"); Deck.Add("JH"); Deck.Add("QH");
            Deck.Add("KH"); Deck.Add("2C"); Deck.Add("3C"); Deck.Add("4C"); Deck.Add("5C"); Deck.Add("6C"); Deck.Add("7C");
            Deck.Add("8C"); Deck.Add("9C"); Deck.Add("10C"); Deck.Add("JC"); Deck.Add("QC"); Deck.Add("KC"); Deck.Add("AC");
            Deck.Add("AH"); Deck.Add("AD"); Deck.Add("AS");




            // Hand 1 randomly generated and displayed 
            List<string> Hand1 = new List<string>();

            for (int i = 0; i < 5; i++)
            {

                Random rand = new Random();
                int randCard = rand.Next(Deck.Count);
                var result = Deck[randCard];

                Hand1.Add(result);

                Deck.RemoveAt(randCard);

            }



            Console.WriteLine(Player1 + "'s Hand is " + Hand1[0] + " " + Hand1[1] + " " + Hand1[2] + " " + Hand1[3] + " " + Hand1[4]);

            //Hand 2 randomly Generated and displayed 
            List<string> Hand2 = new List<string>();

            for (int k = 0; k < 5; k++)
            {
                Random rand = new Random();
                int randCard = rand.Next(Deck.Count);
                var result = Deck[randCard];

                Hand2.Add(result);

                Deck.RemoveAt(randCard);

            }


            Console.WriteLine(Player2 + "'s Hand is " + Hand2[0] + " " + Hand2[1] + " " + Hand2[2] + " " + Hand2[3] + " " + Hand2[4]);



            int Score1 = getScore(Hand1, Player1);
            int Score2 = getScore(Hand2, Player2);

            int HighCard1 = getHighCard(Hand1);
            int HighCard2 = getHighCard(Hand2);

            if (Score1 == Score2)
            {
                Score1 = Score1 + HighCard1;
                Score2 = Score2 + HighCard2;
            }

            if (Score1 > Score2)
            {
                Console.WriteLine(Player1 + " Wins!");
            }
            else
            {
                Console.WriteLine(Player2 + " Wins!");
            }
        }

        public static int getScore(List<string> Hand, String Name)
        {
            int Score = 0;
            int Count2 = 0; int Count3 = 0; int Count4 = 0; int Count5 = 0; int Count6 = 0; int Count7 = 0; int Count8 = 0;
            int Count9 = 0; int Count10 = 0; int CountJ = 0; int CountQ = 0; int CountK = 0; int CountA = 0;

            //Count The Number of each Card they Have 
            for (int i = 0; i < Hand.Count; i++)
            {
                var card = Hand[i];

                if (card.StartsWith("2"))
                {
                    Count2++;
                }
                else if (card.StartsWith("3"))
                {
                    Count3++;
                }
                else if (card.StartsWith("4"))
                {
                    Count4++;
                }
                else if (card.StartsWith("5"))
                {
                    Count5++;
                }
                else if (card.StartsWith("6"))
                {
                    Count6++;
                }
                else if (card.StartsWith("7"))
                {
                    Count7++;
                }
                else if (card.StartsWith("8"))
                {
                    Count8++;
                }
                else if (card.StartsWith("9"))
                {
                    Count9++;
                }
                else if (card.StartsWith("10"))
                {
                    Count10++;
                }
                else if (card.StartsWith("J"))
                {
                    CountJ++;
                }
                else if (card.StartsWith("Q"))
                {
                    CountQ++;
                }
                else if (card.StartsWith("K"))
                {
                    CountK++;
                }
                else if (card.StartsWith("A"))
                {
                    CountA++;
                }
            }

            List<int> CardCount1 = new List<int>();
            CardCount1.Add(Count2); CardCount1.Add(Count3); CardCount1.Add(Count4); CardCount1.Add(Count5); CardCount1.Add(Count6);
            CardCount1.Add(Count7); CardCount1.Add(Count8); CardCount1.Add(Count9); CardCount1.Add(Count10); CardCount1.Add(CountJ);
            CardCount1.Add(CountQ); CardCount1.Add(CountK); CardCount1.Add(CountA);

            var HandValue = 0;
            int counter = 0;

            //check for a pair or 2 Pair
            if (CardCount1.Contains(2))
            {
                for (int i = 0; i < CardCount1.Count; i++)
                {
                    if (CardCount1[i] == 2)
                    {
                        HandValue = i + 2;
                        counter++;
                    }
                }
                if (counter == 2)
                {
                    Console.WriteLine(Name + " has a Two Pair ");
                    Score = 300;
                }
                else
                {
                    if (HandValue == 11)
                    {
                        Console.WriteLine(Name + " has a pair of Jacks");
                    }
                    else if (HandValue == 12)
                    {
                        Console.WriteLine(Name + " has a pair of Queens");
                    }
                    else if (HandValue == 13)
                    {
                        Console.WriteLine(Name + " has a pair of Kings");
                    }
                    else if (HandValue == 14)
                    {
                        Console.WriteLine(Name + " has a pair of Aces");
                    }
                    else
                    {
                        Console.WriteLine(Name + " has a pair of " + HandValue);
                    }
                    Score = 200 + HandValue;
                }
            }



            //check for 3 of a kind
            if (CardCount1.Contains(3))
            {
                for (int i = 0; i < CardCount1.Count; i++)
                {
                    if (CardCount1[i] == 3)
                    {
                        HandValue = i + 2;
                    }
                }
                Console.WriteLine(Name + " has a 3 pair of " + HandValue);
                Score = 400;
            }

            //check for Full House
            if (CardCount1.Contains(3) && CardCount1.Contains(2))
            {
                Console.WriteLine(Name + " has a full house");
                Score = 700;
            }

            //check for 4 of a Kind
            if (CardCount1.Contains(4))
            {
                for (int i = 0; i < CardCount1.Count; i++)
                {
                    if (CardCount1[i] == 4)
                    {
                        HandValue = i + 2;
                    }
                }
                Console.WriteLine(Name + " Has a 4 Pair of " + HandValue);
                Score = 800;
            }

            //check for a flush 
            if (Hand[0].EndsWith("H"))
            {
                if (Hand[1].EndsWith("H"))
                {
                    if (Hand[2].EndsWith("H"))
                    {
                        if (Hand[3].EndsWith("H"))
                        {
                            if (Hand[4].EndsWith("H"))
                            {
                                if (Hand.Contains("10H") && Hand.Contains("JH") && Hand.Contains("QH") && Hand.Contains("KH") && Hand.Contains("AH"))
                                {
                                    Console.WriteLine(Name + " has a Royal Flush of Hearts!");
                                    Score = 1000;
                                }
                                else
                                {
                                    Console.WriteLine(Name + " has a Flush of Hearts");
                                    Score = 600;
                                }
                            }
                        }
                    }
                }
            }
            else if (Hand[0].EndsWith("D"))
            {
                if (Hand[1].EndsWith("D"))
                {
                    if (Hand[2].EndsWith("D"))
                    {
                        if (Hand[3].EndsWith("D"))
                        {
                            if (Hand[4].EndsWith("D"))
                            {
                                if (Hand.Contains("10D") && Hand.Contains("JD") && Hand.Contains("QD") && Hand.Contains("KD") && Hand.Contains("AD"))
                                {
                                    Console.WriteLine(Name + " has a Royal Flush of Diamonds!");
                                    Score = 1000;
                                }
                                else
                                {
                                    Console.WriteLine(Name + " has a Flush of Diamonds");
                                    Score = 600;
                                }
                            }
                        }
                    }
                }
            }
            else if (Hand[0].EndsWith("C"))
            {
                if (Hand[1].EndsWith("C"))
                {
                    if (Hand[2].EndsWith("C"))
                    {
                        if (Hand[3].EndsWith("C"))
                        {
                            if (Hand[4].EndsWith("C"))
                            {
                                if (Hand.Contains("10C") && Hand.Contains("JC") && Hand.Contains("QC") && Hand.Contains("KC") && Hand.Contains("AC"))
                                {
                                    Console.WriteLine(Name + " has a Royal Flush of Clubs!");
                                    Score = 1000;
                                }
                                else
                                {
                                    Console.WriteLine(Name + " has a Flush of Clubs");
                                    Score = 600;
                                }
                            }
                        }
                    }
                }
            }
            else if (Hand[0].EndsWith("S"))
            {
                if (Hand[1].EndsWith("S"))
                {
                    if (Hand[2].EndsWith("S"))
                    {
                        if (Hand[3].EndsWith("S"))
                        {
                            if (Hand[4].EndsWith("S"))
                            {
                                if (Hand.Contains("10S") && Hand.Contains("JS") && Hand.Contains("QS") && Hand.Contains("KS") && Hand.Contains("AS"))
                                {
                                    Console.WriteLine(Name + " has a Royal Flush of Spades!");
                                    Score = 1000;
                                }
                                else
                                {
                                    Console.WriteLine(Name + " has a Flush of Spades");
                                    Score = 600;
                                }
                            }
                        }
                    }
                }
            }

            //check for a straight and Straight Flush
            for (int i = 0; i < 9; i++)
            {
                if (CardCount1[i] == 1)
                {
                    if (CardCount1[i + 1] == 1)
                    {
                        if (CardCount1[i + 2] == 1)
                        {
                            if (CardCount1[i + 3] == 1)
                            {
                                if (CardCount1[i + 4] == 1)
                                {
                                    //Check For a Straight flush
                                    if (Hand[0].EndsWith("H"))
                                    {
                                        if (Hand[1].EndsWith("H"))
                                        {
                                            if (Hand[2].EndsWith("H"))
                                            {
                                                if (Hand[3].EndsWith("H"))
                                                {
                                                    if (Hand[4].EndsWith("H"))
                                                    {
                                                        Console.WriteLine("Kam has a Straight Flush of Hearts");
                                                        Score = 900;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (Hand[0].EndsWith("D"))
                                    {
                                        if (Hand[1].EndsWith("D"))
                                        {
                                            if (Hand[2].EndsWith("D"))
                                            {
                                                if (Hand[3].EndsWith("D"))
                                                {
                                                    if (Hand[4].EndsWith("D"))
                                                    {
                                                        Console.WriteLine("Kam has a Straight Flush of Diamonds");
                                                        Score = 900;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (Hand[0].EndsWith("C"))
                                    {
                                        if (Hand[1].EndsWith("C"))
                                        {
                                            if (Hand[2].EndsWith("C"))
                                            {
                                                if (Hand[3].EndsWith("C"))
                                                {
                                                    if (Hand[4].EndsWith("C"))
                                                    {
                                                        Console.WriteLine("Kam has a Straight Flush of Clubs");
                                                        Score = 900;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (Hand[0].EndsWith("S"))
                                    {
                                        if (Hand[1].EndsWith("S"))
                                        {
                                            if (Hand[2].EndsWith("S"))
                                            {
                                                if (Hand[3].EndsWith("S"))
                                                {
                                                    if (Hand[4].EndsWith("S"))
                                                    {
                                                        Console.WriteLine("Kam has a Straight Flush of Spades");
                                                        Score = 900;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kam has a straight!");
                                        Score = 500;
                                    }
                                }
                            }
                        }
                    }
                }
            }


            return Score;
        }

        public static int getHighCard(List<string> Hand)
        {
            //Find Highest Card
            int HighCard = 0;
            if (Hand.Contains("AH") || Hand.Contains("AD") || Hand.Contains("AC") || Hand.Contains("AS"))
            {
                HighCard = 14;
            }
            else if (Hand.Contains("KH") || Hand.Contains("KD") || Hand.Contains("KC") || Hand.Contains("KS"))
            {
                HighCard = 13;
            }
            else if (Hand.Contains("QH") || Hand.Contains("QD") || Hand.Contains("QC") || Hand.Contains("QS"))
            {
                HighCard = 12;
            }
            else if (Hand.Contains("JH") || Hand.Contains("JD") || Hand.Contains("JC") || Hand.Contains("JS"))
            {
                HighCard = 11;
            }
            else if (Hand.Contains("10H") || Hand.Contains("10D") || Hand.Contains("10C") || Hand.Contains("10S"))
            {
                HighCard = 10;
            }
            else if (Hand.Contains("9H") || Hand.Contains("9D") || Hand.Contains("9C") || Hand.Contains("9S"))
            {
                HighCard = 9;
            }
            else if (Hand.Contains("8H") || Hand.Contains("8D") || Hand.Contains("8C") || Hand.Contains("8S"))
            {
                HighCard = 8;
            }
            else if (Hand.Contains("7H") || Hand.Contains("7D") || Hand.Contains("7C") || Hand.Contains("7S"))
            {
                HighCard = 7;
            }
            else if (Hand.Contains("6H") || Hand.Contains("6D") || Hand.Contains("6C") || Hand.Contains("6S"))
            {
                HighCard = 6;
            }
            else if (Hand.Contains("5H") || Hand.Contains("5D") || Hand.Contains("5C") || Hand.Contains("5S"))
            {
                HighCard = 5;
            }
            else if (Hand.Contains("4H") || Hand.Contains("4D") || Hand.Contains("4C") || Hand.Contains("4S"))
            {
                HighCard = 4;
            }
            else if (Hand.Contains("3H") || Hand.Contains("3D") || Hand.Contains("3C") || Hand.Contains("3S"))
            {
                HighCard = 3;
            }
            else if (Hand.Contains("2H") || Hand.Contains("2D") || Hand.Contains("2C") || Hand.Contains("2S"))
            {
                HighCard = 2;
            }

            return HighCard;
        }

    }
}
