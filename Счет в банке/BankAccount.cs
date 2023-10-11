namespace BankApp
{
    class BankAccount
    {
        private int id; // номер счета
        private string name; // ФИО владельца счета
        private double balance; // сумма средств на счету

        public void opening() // открытие счета
        {
            Console.Clear();
            Console.WriteLine("ОТКРЫТИЕ СЧЕТА В РТК-БАНКЕ");

            Console.Write("Введите ваше ФИО: ");
            name = Console.ReadLine();

            Console.Write("Введите сумму вашего первого пополнения счета (руб.): ");
            balance = Convert.ToSingle(Console.ReadLine());

            Random rnd = new Random();
            id = rnd.Next(100000000, 999999999);
            Console.Write($"\nПриветствуем вас в качестве нового клиента РТК-Банка!\nВаш счет #{id} успешно открыт.\nСпасибо, что выбрали РТК-Банк!");
            Console.WriteLine("\nНажмите Enter, чтобы перейти в меню доступных операций над счетами");
            Console.ReadKey();
            operations();
        }

        public void operations() // операции над счетами
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в приложение РТК-Банка!");
            Console.WriteLine("Доступные операции над банковскими счетами:");
            Console.WriteLine("1. Отображение информации о счете");
            Console.WriteLine("2. Пополнение счета");
            Console.WriteLine("3. Снятие средств со счета");
            Console.WriteLine("4. Перевод средств с одного счета на другой");
            Console.WriteLine("Чтобы выйти из приложения РТК-Банка, введите 0");
            Console.Write("Введите номер желаемой операции: ");
            int userChoice = (Convert.ToInt32(Console.ReadLine()));

            if (userChoice == 0)
            {
                string shut_down = "\nЗавершение работы приложения РТК-Банка..."; // динамичное сообщение о завершении работы

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
            else if (userChoice == 1)
            {
                info_display();
            }
            else if (userChoice == 2)
            {
                topping_up();
            }
            else if (userChoice == 3)
            {
                withdrawing();
            }
            else if (userChoice == 4)
            {
                transfering();
            }
            else
            {
                Console.WriteLine("ОШИБКА: Номер операции введен некорректно. Нажмите Enter и попробуйте снова");
                Console.ReadKey();
                operations();
            }
        }

        public void info_display() // отображение информации о счете
        {
            Console.Clear();
            Console.WriteLine($"ИНФОРМАЦИЯ О СЧЕТЕ");
            Console.WriteLine($"Номер счета: {id}");
            Console.WriteLine($"ФИО владельца: {name}");
            Console.WriteLine($"Остаток средств на счету: {balance} руб.");

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню доступных операций над счетами");
            Console.ReadKey();
            operations();
        }

        public void topping_up() // пополнение счета
        {
            Console.Clear();
            Console.WriteLine("ПОПОЛНЕНИЕ СЧЕТА");
            Console.Write("Введите сумму пополнения вашего счета (руб.): ");
            double top_up = Convert.ToDouble(Console.ReadLine()); // сумма пополнения
            balance += top_up;
            Console.WriteLine($"Пополнение прошло успешно! Теперь на вашем счету {balance} руб.");

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню доступных операций над счетами");
            Console.ReadKey();
            operations();
        }

        public void withdrawing() // снятие средств со счета
        {
            Console.Clear();
            Console.WriteLine("СНЯТИЕ СРЕДСТВ СО СЧЕТА");
            Console.WriteLine("Хотите ли вы 1. Снять определенную сумму со счета или 2. Снять все средства со счета?");
            Console.Write("Введите номер желаемой операции: ");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            if (userChoice == 1)
            {
                Console.Write("Введите сумму снятия средств с вашего счета (руб.): ");
                double withdraw = Convert.ToDouble(Console.ReadLine()); // сумма снятия

                if (withdraw > balance) // проверка, достаточно ли средств на счету
                {
                    Console.WriteLine("На вашем счёте недостаточно средств для снятия данной суммы.");
                    Console.WriteLine("Нажмите Enter, чтобы вернуться в меню доступных операций над счетами");
                    Console.ReadKey();
                    operations();
                }
                else
                {
                    balance -= withdraw;
                    Console.WriteLine($"Снятие прошло успешно! Теперь на вашем счету {balance} руб.");

                    Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню доступных операций над счетами");
                    Console.ReadKey();
                    operations();
                }
            }
            else if (userChoice == 2)
            {
                complete_withdrawing();
            }
        }

        public void complete_withdrawing() // снятие всех средств со счета
        {
            Console.WriteLine("Вы выбрали снятие всех средств со счета.");
            double reset = balance; // сумма снятия, равна текущему балансу
            balance -= reset;
            Console.WriteLine($"Снятие прошло успешно! Теперь на вашем счету {balance} руб.");

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню доступных операций над счетами");
            Console.ReadKey();
            operations();
        }

        public void transfering() // перевод средств с одного счета на другой
        {
            Console.Clear();
            Console.WriteLine("ПЕРЕВОД СРЕДСТВ С ОДНОГО СЧЕТА НА ДРУГОЙ");
            Console.Write("Введите номер счета получателя: ");
            int id2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите сумму перевода (руб.): ");
            int balance2 = Convert.ToInt32(Console.ReadLine());

            if (balance2 > balance) // проверка, достаточно ли средств на счету
            {
                Console.WriteLine("На вашем счёте недостаточно средств для перевода на данную сумму.");
                Console.WriteLine("Нажмите Enter, чтобы вернуться в меню доступных операций над счетами");
                Console.ReadKey();
                operations();
            }
            else
            {
                string transfer = $"Перевод {balance2} руб. на счёт #{id2}...."; // динамичное сообщение о переводе средств

                for (int j = 0; j < 1; j++)
                {
                    for (int i = 0; i < transfer.Length; i++)
                    {
                        Console.Write(transfer[i]);
                        Thread.Sleep(200);
                    }
                    Console.Clear();

                    balance -= balance2; //Перевод

                    Console.WriteLine($"Перевод {balance2} руб. на счёт #{id2} прошел успешно!");
                    Console.WriteLine($"Теперь на вашем счету {balance} руб.");

                    Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню доступных операций над счетами");
                    Console.ReadKey();
                    operations();
                }
            }
        }
    }
}