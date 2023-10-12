namespace Individuellt_projekt_Oskar_Johansson
{
    class ATM
    {
        private string[] UserName = { "Oskar", "Emilia", "Vilgot", "Fia", "Felix" };
        private string[] Pins = { "2233", "1122", "1234", "0000", "1111" };
        private string[] AccountNames = { "Primärtkonto", "Sparkonto" };
        private double[][] AccountsBalances = new double[5][];

        public ATM()
        {
            for (int i = 0; i < UserName.Length; i++)
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
                }
            }
            
            while (LogInAttempts < 3);

            Console.WriteLine("Du har inga försök kvar. Programmet kommer nu att avslutas.");
            Environment.Exit(0);
            return null;

        }
        private bool SuccessfulLogIn(string username, string pin)
        {
            for(int i = 0;i < UserName.Length;i++)
            {
                if (UserName[i] == username && Pins[i] == pin)
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
                Console.WriteLine("\nHuvudmeny:");
                Console.WriteLine("1. Se konton och saldo");
                Console.WriteLine("2. Överföring mellan konton");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");

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
                        return;
                    default:
                        Console.WriteLine("Ogiltligt val välj mellan 1-4");
                        break;
                }
            }
        }

        public void ViewAccounts(string username)
        {
            Console.Clear();
            Console.WriteLine("Hej");
        }

        public void TransferMoney(string username)
        {
            Console.Clear();
            Console.WriteLine("Hej");
        }
        public void WithdrawMoney(string username)
        {
            Console.Clear();
            Console.WriteLine("Hej");
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