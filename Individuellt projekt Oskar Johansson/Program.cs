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
            int LogInAttempts = 3;
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
                    LogInAttempts--;
                    Console.WriteLine($"Fel användarnamn eller pin. Försök igen. du har {LogInAttempts} kvar");
                }
            }
            
            while (LogInAttempts >= 0);

            Console.WriteLine("Du har skrivit in fel pinkod tre gånger. Programmet kommer att avslutas nu.");
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

        }

        public void ViewAccounts()
        {

        }

        public void TransferMoney()
        {

        }
        public void WithdrawMoney()
        {

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