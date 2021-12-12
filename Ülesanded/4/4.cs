using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;

namespace DrinkMachineApp
{
    public class DrinkMachineProgram
    {
        public static int choice = 0;
        public static int choiceSugar = 0;
        public static int choiceStick = 0;
        public static int count = 0;
        public static List<Option> drinks;
        static void Main(string[] args)
        {
            drinks = new List<Option>
            {
                new Option("Tee 1EUR", () => MoneyDeposit(100, count)),
                new Option("Must kohv 1.20EUR", () =>  MoneyDeposit(120, count)),
                new Option("Piimaga kohv 1.50EUR", () =>  MoneyDeposit(150, count)),
                new Option("Kakao 1.30EUR", () =>  MoneyDeposit(130, count)),
                new Option("Puljong 1EUR", () =>  MoneyDeposit(100, count)),
            };
            int index = 0;
            WriteMenu(drinks, drinks[index], count);
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < drinks.Count)
                    {
                        index++;
                        WriteMenu(drinks, drinks[index], count);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(drinks, drinks[index], count);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    if (count == 0)
                    {
                        DrinkMachineProgram.choice = index;
                    }
                    drinks[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }

        static void MoneyDeposit(int price, int count)
        {
            DrinkMachineProgram.count = 1;
            Console.Clear();
            
            int index = 0;
            drinks = new List<Option>
            {
                new Option("10 senti", () => Calculator(10, price, count)),
                new Option("20 senti", () => Calculator(20, price, count)),
                new Option("50 senti", () => Calculator(50, price, count)),
                new Option("1 euro", () => Calculator(100, price, count)),
                new Option("2 eurot", () => Calculator(200, price, count)),
            };
            if ((float)price > 0)
            {
                WriteMenu(drinks, drinks[index], count);
                Console.WriteLine("Palun sisesta " + (float)price/100 + " EUR.");
            }
            if ((float)price == 0)
            {
                Console.Write("Töötlen makset.");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.WriteLine(".");
                Thread.Sleep(1000);
                DrinkMachineProgram.count = 2;
                Thread.Sleep(1000);
                WhatElse(count);
            }
            if ((float)price < 0)
            {
                Console.WriteLine("Tagastatakse " + (float)price/100*-1 + " EUR.");
                price = 0;
                Console.Write("Töötlen makset.");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.WriteLine(".");
                Thread.Sleep(1000);
                DrinkMachineProgram.count = 2;
                WhatElse(count);
            }
        }

        static void WhatElse(int count)
        {
            int index = 0;
            /* Console.WriteLine(DrinkMachineProgram.choice); */
            if (DrinkMachineProgram.choice <= 2)
            {
                drinks = new List<Option>
                {
                    new Option("Jah", () => SugarYes()),
                    new Option("Ei", () =>  SugarNo()),
                };
                Thread.Sleep(1000);
                WriteMenu(drinks, drinks[index], count);
            }
            if (DrinkMachineProgram.choice > 2)
            {
                DrinkMachineProgram.count = 3;
                StickNeeded(count);
            }
        }

        static void StickNeeded(int count)
        {
            int index = 0;
            drinks = new List<Option>
            {
                new Option("Jah", () => StickYes()),
                new Option("Ei", () =>  StickNo()),
            };
            WriteMenu(drinks, drinks[index], count);
        }

        static void Calculator(int deposited, int price, int count)
        {
            int newPrice = (price - deposited);
            MoneyDeposit(newPrice, count);
        }

        static void SugarYes()
        {
            Console.Clear();
            Console.WriteLine("Suhkur lisatakse!");
            Thread.Sleep(1000);
            DrinkMachineProgram.count = 3;
            DrinkMachineProgram.choiceSugar = 1;
            StickNeeded(count);
        }
        static void SugarNo()
        {
            Console.Clear();
            Console.WriteLine("Suhkrut ei lisata!");
            Thread.Sleep(1000);
            DrinkMachineProgram.count = 3;
            StickNeeded(count);
        }

        static void StickYes()
        {
            Console.Clear();
            Console.WriteLine("Pulk lisatakse!");
            Thread.Sleep(1000);
            Console.WriteLine(DrinkMachineProgram.choice);
            Console.WriteLine("Alustan joogi valmistamisega");
            Thread.Sleep(2000);
            Console.WriteLine("Väljastan topsi!");
            Thread.Sleep(2000);
            Console.WriteLine("Lisan vett!");
            Thread.Sleep(2000);
            if(DrinkMachineProgram.choice <= 2 && DrinkMachineProgram.choice > 0)
            {
                Console.WriteLine("Lisan kohvi!");
                Thread.Sleep(2000);
                if(DrinkMachineProgram.choice == 2)
                {
                    Console.WriteLine("Lisan piima!");
                    Thread.Sleep(2000);
                }
            }
            if(DrinkMachineProgram.choice == 0)
            {
                Console.WriteLine("Lisan tee!");
                Thread.Sleep(2000);
            }
            if(DrinkMachineProgram.choice == 3)
            {
                Console.WriteLine("Lisan kakao!");
                Thread.Sleep(2000);
            }
            if(DrinkMachineProgram.choice == 4)
            {
                Console.WriteLine("Lisan puljongi!");
                Thread.Sleep(2000);
            }
            Console.Write("Segamine.");
            Thread.Sleep(2000);
            Console.Write(".");
            Thread.Sleep(2000);
            Console.Write(". ");
            Thread.Sleep(1000);
            Console.WriteLine("Lisan pulga!");
            Thread.Sleep(1000);
            Console.WriteLine("Jook valmis!");
        }

        static void StickNo()
        {
            Console.Clear();
            Console.WriteLine("Pulka ei lisata!");
            Thread.Sleep(1000);
            Console.WriteLine("Alustan joogi valmistamisega");
            Thread.Sleep(2000);
            Console.WriteLine("Väljastan topsi!");
            Thread.Sleep(2000);
            Console.WriteLine("Lisan vett!");
            Thread.Sleep(2000);
            if(DrinkMachineProgram.choice <= 2 && DrinkMachineProgram.choice > 0)
            {
                Console.WriteLine("Lisan kohvi!");
                Thread.Sleep(2000);
                if(DrinkMachineProgram.choice == 2)
                {
                    Console.WriteLine("Lisan piima!");
                    Thread.Sleep(2000);
                }
            }
            if(DrinkMachineProgram.choice == 0)
            {
                Console.WriteLine("Lisan tee!");
                Thread.Sleep(2000);
            }
            if(DrinkMachineProgram.choiceSugar == 1)
            {
                Console.WriteLine("Lisan suhkru!");
                Thread.Sleep(2000);
            }
            if(DrinkMachineProgram.choice == 3)
            {
                Console.WriteLine("Lisan kakao!");
                Thread.Sleep(2000);
            }
            if(DrinkMachineProgram.choice == 4)
            {
                Console.WriteLine("Lisan puljongi!");
                Thread.Sleep(2000);
            }
            Console.Write("Segamine.");
            Thread.Sleep(2000);
            Console.Write(".");
            Thread.Sleep(2000);
            Console.Write(". ");
            Thread.Sleep(1000);
            Console.WriteLine("Jook valmis!");;
        }

        static void WriteMenu(List<Option> drinks, Option selectedOption, int count)
        {
            Console.Clear();
            if (DrinkMachineProgram.count == 0)
            {
                Console.WriteLine("Vali jook:");
            }
            if (DrinkMachineProgram.count == 1)
            {
                Console.WriteLine("Palun sisesta raha");
            }
            if (DrinkMachineProgram.count == 2)
            {
                Console.WriteLine("Kas soovid suhkrut?");
            }
            if (DrinkMachineProgram.count == 3)
            {
                Console.WriteLine("Kas segamispulka soovid?");
            }
            foreach (Option option in drinks)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }

    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }

}