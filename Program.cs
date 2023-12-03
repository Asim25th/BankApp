namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int id;
            int number; // номер счета
            string name; // ФИО владельца счета
            double balance; // сумма средств на счету

            Console.WriteLine("Добро пожаловать в приложение РТК-Банка!");
            Console.Write("Введите количество будущих клиентов банка: ");
            int userCount = (Convert.ToInt32(Console.ReadLine()));

            Random rnd = new Random();
            BankAccount[] account = new BankAccount[userCount]; // создание и объявление объекта "счет в банке"
            BankAccount bank = new BankAccount();

            for (int i = 0; i < account.Length; i++)
            {
                Console.Clear();
                Console.WriteLine($"Клиент {i + 1}");
                account[i] = new BankAccount();
                id = i + 1; // обновление id
                Console.Write("Введите ваше ФИО: ");
                name = Console.ReadLine();
                number = rnd.Next(100000000, 999999999);
                Console.Write("Введите сумму вашего первого пополнения счета (руб.): ");
                balance = Convert.ToDouble(Console.ReadLine());
                account[i].UserInfo(id, number, name, balance); // отправка полученных значений в класс BankAccount
                Console.WriteLine("\nИнформация о счете: ");
                account[i].AccountInfo(); // вывод информации об открытом счете
                Console.ReadKey();               
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Доступные для использования счета:");
                bank.AccountToChoose(account, account.Length); // закидываем длину массива, чтобы не сработало условие if
                Console.WriteLine("\nЧтобы выйти из приложения РТК-Банка, введите 0");
                Console.Write("\nВведите номер счета, на который хотите зайти: ");
                int userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice == 0)
                {
                    break;
                }
                else
                {
                    int accountIndex = userChoice - 1; // представление номера счета в виде индекса массива
                    while (userChoice > account.Length || accountIndex < 0)
                    {
                        Console.Write("ОШИБКА: Некорректный выбор. Попробуйте ввести другое значение: ");
                        userChoice = Convert.ToInt32(Console.ReadLine());
                        accountIndex = userChoice - 1; // представление номера счета в виде индекса массива
                    }
                    Console.Clear();
                    account[accountIndex].AccountInfo(); // вывод информации о выбранном аккаунте
                    Console.WriteLine("\nДоступные операции над банковскими счетами:");
                    Console.WriteLine("1. Пополнение счета");
                    Console.WriteLine("2. Снятие средств со счета");
                    Console.WriteLine("3. Снятие всех средств со счета");
                    Console.WriteLine("4. Перевод средств с одного счета на другой");
                    Console.WriteLine("Чтобы выйти из приложения РТК-Банка, введите 0");
                    Console.Write("Введите номер желаемой операции: ");
                    int operationChoice = Convert.ToInt32(Console.ReadLine());
                    account[accountIndex].Operations(account, operationChoice, accountIndex, userChoice);
                }
            }
        }
    } 
}