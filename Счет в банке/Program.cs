namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(); // создание и объявление объекта "счет в банке"

            Console.WriteLine("Добро пожаловать в приложение РТК-Банка!");
            Console.WriteLine("Хотите ли вы открыть счет в нашем банке?");
            Console.Write("Чтобы начать процедуру открытия счета, введите 1: ");
            int userChoice = (Convert.ToInt32(Console.ReadLine()));

            if (userChoice == 1)
            {
                account.opening();
            }
            else
            {
                Console.WriteLine("\nВы выбрали не открывать счет в РТК-Банке. До свидания!");
                string shut_down = "Завершение работы приложения РТК-Банка..."; // динамичное сообщение о завершении работы

                for (int j = 0; j < 1; j++)
                {
                    for (int i = 0; i < shut_down.Length; i++)
                    {
                        Console.Write(shut_down[i]);
                        Thread.Sleep(200);
                    }

                    System.Environment.Exit(0); // завершает работу программы
                }
            }
        }
    } 
}