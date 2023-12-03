namespace BankApp
{
    class BankAccount
    {
        private int id;
        private int number; // номер счета
        private string name; // ФИО владельца счета
        private double balance; // сумма средств на счету

        public void UserInfo(int id, int number, string name, double balance) // получение отправленных из класса Program значений
        {
            this.id = id;
            this.number = number;
            this.name = name;
            this.balance = balance;
        }

        public void AccountToChoose(BankAccount[] account, int j) // вывод доступных для выбора счетов
        {
            for (int i = 0; i < account.Length; i++)
            {
                if (i == j) // пропуск счета, вход в который был осуществлен
                {
                    continue;
                }
                else // вывод номеров счетов и имен клиентов
                {
                    Console.WriteLine($"{account[i].id}. {account[i].name} (#{account[i].number})");
                }
            }
        }

        public void Operations(BankAccount[] account, int operationChoice, int accountIndex, int userChoice) // операции над счетами
        {
            switch (operationChoice)
            {
                case 0:
                    System.Environment.Exit(0); // завершение работы программы
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("ПОПОЛНЕНИЕ СЧЕТА");
                    account[accountIndex].ToppingUp(account, accountIndex);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("СНЯТИЕ СРЕДСТВ СО СЧЕТА");
                    account[accountIndex].Withdrawing(account, accountIndex);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("СНЯТИЕ ВСЕХ СРЕДСТВ СО СЧЕТА");
                    account[accountIndex].CompleteWithdrawing(account, accountIndex);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("ПЕРЕВОД СРЕДСТВ С ОДНОГО СЧЕТА НА ДРУГОЙ");
                    Console.WriteLine("\nДоступные для перевода счета:");
                    AccountToChoose(account, accountIndex); // вывод всех доступных для перевода счетов
                    Console.Write("\nВведите номер счета, на который хотите осуществить перевод: ");
                    int chooseToSend = Convert.ToInt32(Console.ReadLine()); // id выбранного для перевода счета
                    int destinationIndex = chooseToSend - 1; // индекс массива
                    account[accountIndex].Transfering(account, accountIndex, destinationIndex);
                    break;
                default:        
                    Console.WriteLine("ОШИБКА: Некорректный выбор. Нажмите Enter, чтобы вернуться в меню выбора счета.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        public void AccountInfo() // отображение информации о счете
        {
            Console.WriteLine($"Номер счета: {number}");
            Console.WriteLine($"ФИО владельца: {name}");        
            Console.WriteLine($"Остаток средств на счету: {balance} руб.");
        }

        private void ToppingUp(BankAccount[] account, int accountIndex) // пополнение счета
        {
            Console.Write("Введите сумму пополнения вашего счета (руб.): ");
            double topUp = Convert.ToDouble(Console.ReadLine());

            while (topUp <= 0)
            {
                Console.Write("ОШИБКА: Некорректная сумма пополнения счета. Попробуйте ввести другое значение: ");
                topUp = Convert.ToDouble(Console.ReadLine());
            }

            account[accountIndex].balance += topUp; // увеличение баланса после пополнения
            Console.WriteLine($"Пополнение прошло успешно! Теперь на вашем счету {account[accountIndex].balance} руб.");
            Console.ReadKey();
        }

        private void Withdrawing(BankAccount[] account, int accountIndex) // снятие средств со счета
        {
            Console.Write("Введите сумму снятия средств с вашего счета (руб.): ");
            double withdraw = Convert.ToDouble(Console.ReadLine());

            while (withdraw > account[accountIndex].balance)
            {
                Console.Write("ОШИБКА: На вашем счету недостаточно средств для совершения снятия. Попробуйте ввести другое значение: ");
                withdraw = Convert.ToDouble(Console.ReadLine());
            }

            while (withdraw <= 0)
            {
                Console.Write("ОШИБКА: Некорректная сумма пополнения счета. Попробуйте ввести другое значение: ");
                withdraw = Convert.ToDouble(Console.ReadLine());
            }

            account[accountIndex].balance -= withdraw;
            Console.WriteLine($"Со счета было списано {withdraw} руб.");
            Console.WriteLine($"Текущий остаток средств на счету: {account[accountIndex].balance} руб.");
            Console.ReadKey();
        }

        private void CompleteWithdrawing(BankAccount[] account, int accountIndex) // снятие всех средств со счета
        {
            account[accountIndex].balance = 0;
            Console.WriteLine($"Снятие прошло успешно! Теперь на вашем счету {account[accountIndex].balance} руб.\n");
            Console.ReadKey();
        }

        private void Transfering(BankAccount[] account, int accountIndex, int destinationIndex) // перевод средств с одного счета на другой
        {
            Console.Write("Введите сумму перевода (руб.): ");
            double transferedMoney = Convert.ToDouble(Console.ReadLine());

            while (transferedMoney < 0 || account[accountIndex].balance < transferedMoney)
            {
                Console.Write("ОШИБКА: На вашем счету недостаточно средств для совершения перевода. Попробуйте ввести другое значение: ");
                transferedMoney = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine($"С вашего счета успешно отправлено {transferedMoney} руб.");
            Console.Write("\nНажмите Enter для вывода обновленной информации по счетам");
            Console.ReadKey();
            Console.Clear();

            account[accountIndex].balance -= transferedMoney; // уменьшение баланса отправителя
            account[destinationIndex].balance += transferedMoney; // увеличение баланса получателя

            Console.WriteLine("Информация о счете, на который переводились деньги: ");
            account[destinationIndex].AccountInfo();
            Console.ReadKey();

            Console.WriteLine("\nИнформация о счете, с которого переводились деньги: ");
            account[accountIndex].AccountInfo();
            Console.ReadKey();
        }
    }
}