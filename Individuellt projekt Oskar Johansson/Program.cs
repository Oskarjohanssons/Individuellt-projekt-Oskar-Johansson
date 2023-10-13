using System.Runtime.CompilerServices;

namespace Individuellt_projekt_Oskar_Johansson
{
    class ATM
    {
        private string[] UserNames = { "Oskar", "Emilia", "Vilgot", "Fia", "Felix" };
        private string[] Pins = { "2233", "1122", "1234", "0000", "1111" };
        private string[] AccountNames = { "Primärtkonto", "Sparkonto" };
        private double[][] AccountsBalances = new double[5][];

        public ATM()
        {
            for (int i = 0; i < UserNames.Length; i++)
            {
                AccountsBalances[i] = new double[2];
                for (int j = 0; j < 2; j++)
                {
                    AccountsBalances[i][j] = 100.0;
                }
            }
        }

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
                    Thread.Sleep(2000);
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
            for(int i = 0;i < UserNames.Length;i++)
            {
                if (UserNames[i] == username && Pins[i] == pin)
                {
                    return true;
                }
            }
            return false;
        }

        public void MainMenu(string username)
        {
            while(true)
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
                        username=LogIn();
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
            Console.WriteLine($"\nKonton och saldo för {username}:");
            int UserIndex =  Array.IndexOf(UserNames, username);
            for (int i = 0; i < AccountNames.Length; i++)
            {
                Console.WriteLine($"{AccountNames[i]}: {AccountsBalances[UserIndex][i]} kr");
                
            }

        }

        public void TransferMoney(string username)
        {
            Console.Clear();
            Console.WriteLine("\nÖverföring mellan konton:");
            ViewAccounts(username);
            int UserIndex = Array.IndexOf(UserNames, username);

            Console.WriteLine("Välj konto att ta pengar från: ");
            string FromAccount = Console.ReadLine();

            Console.WriteLine("Välj konto att ta pengar ifrån: ");
            string ToAccount = Console.ReadLine();

            Console.WriteLine("Ange summan att överföra: ");
            double Amount = double.Parse(Console.ReadLine());

            int FromAccountIndex = Array.IndexOf(AccountNames, FromAccount);
            int ToAccountIndex = Array.IndexOf(AccountNames, ToAccount);

            if (FromAccountIndex != -1 && ToAccountIndex != -1 && AccountsBalances[UserIndex][FromAccountIndex] >= Amount)
            {
                AccountsBalances[UserIndex][FromAccountIndex] -= Amount;
                AccountsBalances[UserIndex][ToAccountIndex] += Amount;
                Console.WriteLine($"{Amount} kr överför från {FromAccount} till {ToAccount}.");
                Console.WriteLine("Nya saldon:");
                ViewAccounts(username);

            }
            else
            {
                Console.WriteLine("Ogiltlig överföring");
            }
        

        }
        public void WithdrawMoney(string username)
        {
            Console.Clear();
            Console.WriteLine("\nTa ut pengar");
            Console.WriteLine("Ange din pinkod för att ta ut pengar: ");
            string pin = Console.ReadLine();

            if(SuccessfulLogIn(username, pin))
            {
                ViewAccounts(username);
                int UserIndex = Array.IndexOf(UserNames, username);

                Console.WriteLine("Välj konto att ta ut pengar från: ");
                string Account = Console.ReadLine();

                int AccountIndex = Array.IndexOf(AccountNames, Account);
                if(AccountIndex != -1) 
                {
                    Console.WriteLine("Ange summan att ta ut: ");
                    double Amount = double.Parse(Console.ReadLine());

                    if (AccountsBalances[UserIndex][AccountIndex]>= Amount)
                    {
                        AccountsBalances[UserIndex][AccountIndex] -= Amount;
                        Console.WriteLine($"{Amount} kr har tagits ut från {Account}.");
                        Console.WriteLine($"Nya saldo {Account}: {AccountsBalances[UserIndex][AccountIndex]} kr");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltligt uttag.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltligt val.");
   
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Fel pinkod.");
            }
            
  
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