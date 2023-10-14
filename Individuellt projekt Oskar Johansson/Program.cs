using System;


namespace Individuellt_projekt_Oskar_Johansson
{
    class ATM
    {
        static string[] UserNames = { "Oskar", "Emilia", "Vilgot", "Fia", "Felix" };
        static string[] Pins = { "2233", "1122", "1234", "0000", "1111" };
        static string[][] AccountNames = {
       new string[] { "Lönekonto", "Sparkonto", "Privatkonto", "Huskonto", "Semesterkonto" },
       new string[] { "Lönekonto", "Sparkonto", "Hundkonto", "Gårdkonto" },
       new string[] { "Lönekonto", "Sparkonto", "Leksakerkonto" },
       new string[] { "Lönekonto", "Hundgodiskonto" },
       new string[] { "Lönekonto" }
        };
        static decimal[][] AccountsBalances = {
       new decimal[] { 500.0m, 30000.0m, 5900.0m, 20000.0m, 10000.0m },
       new decimal[] { 300.0m, 200000.0m, 150000.0m, 60000.0m },
       new decimal[] { 25000.0m, 46000.0m, 450000.0m },
       new decimal[] { 100.0m, 100000.0m },
       new decimal[] { 90000.0m}
        };



        public void Welcome()
        {
            Console.WriteLine("Välkommen till din bank");
        }

        public string LogIn()
        {
            int LogInAttempts = 0;
            string username, pin;

            do
            {
                Console.Clear();
                Welcome();
                Console.WriteLine("Ange ditt användarnamn: ");
                username = Console.ReadLine();
                Console.WriteLine("Ange din pinkod: ");
                pin = Console.ReadLine();
                if (SuccessfulLogIn(username, pin))
                {
                    return username;
                }
                else
                {
                    LogInAttempts++;
                    Console.WriteLine($"Fel användarnamn eller pin. Försök igen.");
                    Console.WriteLine($"Dina försök är: {LogInAttempts} av 3 möjliga försök.");
                    Thread.Sleep(2500);
                    Console.Clear();
                }
            }

            while (LogInAttempts < 3);

            Console.WriteLine("Du har inga försök kvar. Programmet kommer nu att avslutas.");
            Environment.Exit(0);
            return null;

        }
        public bool SuccessfulLogIn(string username, string pin)
        {
            int index = Array.IndexOf(UserNames, username);
            if (index != -1 && Pins[index] == pin)
            {
                return true;
            }
            return false;
        }

        public void MainMenu(string username)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Du är inloggad på: {username}");
                Console.WriteLine("\nHuvudmeny:");
                Console.WriteLine("[1] Se konton och saldo");
                Console.WriteLine("[2] Överföring mellan konton");
                Console.WriteLine("[3] Ta ut pengar");
                Console.WriteLine("[4] Logga ut");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewAccounts(username);
                        break;
                    case "2":
                        TransferMoney(username);
                        break;
                    case "3":
                        WithdrawMoney(username);
                        break;
                    case "4":
                        username = LogIn();
                        MainMenu(username);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltligt val välj mellan 1-4");
                        break;
                }

                Console.WriteLine("");
                Console.WriteLine("Tryck enter för att återgå till menyn.");
                Console.ReadLine();
                Console.Clear();

            }

        }

        public void ViewAccounts(string username)
        {
            Console.Clear();
            Console.WriteLine($"Konton och saldo för {username}:");

            int userIndex = Array.IndexOf(UserNames, username);
            if (userIndex != -1)
            {
                for (int i = 0; i < AccountNames[userIndex].Length; i++)
                {
                    Console.WriteLine($"{AccountNames[userIndex][i]}: {AccountsBalances[userIndex][i]} kr");
                }
            }
            else
            {
                Console.WriteLine("Användarnamn hittades inte.");
            }
        }


        public void TransferMoney(string username)
        {
            Console.Clear();
            Console.WriteLine("Överföring mellan konton:");
            ViewAccounts(username);

            int userIndex = Array.IndexOf(UserNames, username);

            Console.WriteLine("Välj konto att ta pengar från: ");
            string fromAccount = Console.ReadLine();

            Console.WriteLine("Välj konto att överföra till: ");
            string toAccount = Console.ReadLine();

            Console.WriteLine("Ange summan att överföra: ");
            decimal amount;
            if (decimal.TryParse(Console.ReadLine(), out amount))
            {
                int fromAccountIndex = Array.IndexOf(AccountNames[userIndex], fromAccount);
                int toAccountIndex = Array.IndexOf(AccountNames[userIndex], toAccount);

                if (fromAccountIndex != -1 && toAccountIndex != -1 &&
                    AccountsBalances[userIndex][fromAccountIndex] >= amount)
                {
                    AccountsBalances[userIndex][fromAccountIndex] -= amount;
                    AccountsBalances[userIndex][toAccountIndex] += amount;
                    Console.WriteLine($"{amount} kr överförd från {fromAccount} till {toAccount}.");
                    Console.WriteLine("Nya saldon:");
                    ViewAccounts(username);
                }
                else
                {
                    Console.WriteLine("Ogiltig överföring.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp.");
            }
        }
        public void WithdrawMoney(string username)
        {
            Console.Clear();
            Console.WriteLine("Ta ut pengar");
            ViewAccounts(username);
            int userIndex = Array.IndexOf(UserNames, username);

            Console.WriteLine("Välj konto att ta ut pengar från: ");
            string account = Console.ReadLine();

            int accountIndex = Array.IndexOf(AccountNames[userIndex], account);
            if (accountIndex != -1)
            {
                Console.WriteLine("Ange summan att ta ut: ");
                decimal amount;
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Ange din pinkod för att ta ut pengar: ");
                    string pin = Console.ReadLine();
                    if (SuccessfulLogIn(username, pin))
                    {
                        if (AccountsBalances[userIndex][accountIndex] >= amount)
                        {
                            AccountsBalances[userIndex][accountIndex] -= amount;
                            Console.WriteLine($"{amount} kr har tagits ut från {account}.");
                            Console.WriteLine($"Nya saldo {account}: {AccountsBalances[userIndex][accountIndex]} kr");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Otillräckligt saldo.");
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Fel pinkod.");
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltigt belopp.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ogiltigt kontoval.");
            }
            

        }
        internal class Program
        {
            static void Main(string[] args)
            {
                ATM Bank = new ATM();
                Bank.Welcome();
                string username = Bank.LogIn();
                Bank.MainMenu(username);
            }

        }
    }
}