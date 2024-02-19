namespace Exercise_6
{
    class Game
    {
        private static void Introduction()
        {
            Console.WriteLine("Приветствую теневой маг! Помоги нам одолеть босса и принеси в наш мир покой!");
            Console.WriteLine("В вашем ассортименте есть несколько заклинаний:" + Environment.NewLine);

            Console.WriteLine("1 - Рашамон – призывает теневого духа для нанесения атаки ()" +
                "\r\n\t Наносит 100 - 400 урона" +
                "\r\n\t Отнимает 100 хп игроку" + Environment.NewLine);

            Console.WriteLine("2 - Хуганзакура - (Может быть выполнен только после призыва теневого духа)" +
                "\r\n\t Наносит по 50 - 300 урона в течении 2 ходов" + Environment.NewLine);

            Console.WriteLine("3 - Песнь Архангела – Исполнив оду, получаете благословление Архангела. Урон босса по вам не проходит" +
                "\r\n\t Восстанавливает всё здоровье" +
                "\r\n\t Можно использовать один раз за бой" + Environment.NewLine);

            Console.WriteLine("4 - Арена шипов - создает арены, окутанную шипами, мешающие врагу" +
                "\r\n\t Возвращает 60% от нанесенного врагом урона (действует 3 хода)" + Environment.NewLine);

            Console.WriteLine("5 - Подчинение шипов - (находясь на Арене шипов) подчините плющ для атаки по врагу" +
                "\r\n\t Шанс 90% нанести 500 урона врагу" +
                "\r\n\t Шанс 10% мгновенной умереть" + Environment.NewLine);
        }

        private static void ChooseSpell()
        {
            Console.WriteLine("Выберите заклинание из ассортимента:" + Environment.NewLine +
                "\t1 - Рашамон" + Environment.NewLine +
                "\t2 - Хуганзакура" + Environment.NewLine +
                "\t3 - Межпространственный разлом" + Environment.NewLine +
                "\t4 - Арена шипов" + Environment.NewLine +
                "\t5 - Укус судьбы");

            Console.Write("Выбор: ");
        }

        private static bool IsSomeoneDead(string instruction, int hpPlayer, int hpEnemy)
        {
            if (hpPlayer <= 0 && hpEnemy <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("Пожертвовав собой вы одолели врага. Люди будут оплакивать и вспоминать великого героя спавшего их! " + Environment.NewLine +
                    "\tСпасибо, Герой!" + Environment.NewLine +
                    "\tВы победили, отдав за это свою жизнь");
                return true;
            }
            else if (hpPlayer <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine($"Ваша жизнь неожиданно оборвалась. {instruction} " + Environment.NewLine +
                    "Надеюсь следующие герои смогут спасти это мир" + Environment.NewLine +
                    "\tВы проиграли эту битву");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                return true;
            }
            else if (hpEnemy <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("Враг повержен, люди могут спать спокойно, а твой подвиг запомнят на века! " + Environment.NewLine +
                    "\tСпасибо, Герой!" + Environment.NewLine +
                    "\tВы победили");
                return true;
            }

            return false;

        }

        private static bool IsSomeoneDead(int hpPlayer, int hpEnemy)
        {
            return IsSomeoneDead("Вы умерли от удара чудовища, так и не убив его.", hpPlayer, hpEnemy);
        }

        private static bool IsEnemyStart()
        {
            int flag = new Random().Next(2);
            return flag == 1;
        }

        private static void StartGame()
        {
            Random random = new();
            int hpPlayer = random.Next(500, 2001);
            int maxHpPlayer = hpPlayer;

            int hpEnemy = random.Next(hpPlayer, (int)(hpPlayer * 1.5));

            Console.WriteLine($"Здоровье босса - {hpEnemy} хп");
            Console.WriteLine($"Ваше здоровье - {hpPlayer} хп");
            Console.WriteLine();

            bool isFadeSpiritExist = false;
            bool isImmortal = false;
            int durationHukanzacura = 0;
            int durationThornArena = 0;
            int numberHealingCast = 1;

            const int MinEnemyDamage = 200;
            const int MaxEnemyDamage = 700;


            if (IsEnemyStart())
            {
                hpPlayer -= random.Next(MinEnemyDamage / 2, MaxEnemyDamage / 2);
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Ваш враг очень быстр, вы не успеваете среагировать как он первый наносит удар");
                Console.WriteLine($"Вы получили {maxHpPlayer - hpPlayer}");
                Console.WriteLine($"Ваше здоровье - {hpPlayer} хп");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine();
            }

            while (true)
            {
                ChooseSpell();

                int receivedDamage = 0;
                int dealtDamage = 0;

                switch (Console.ReadLine())
                {
                    case "1":
                        isFadeSpiritExist = true;

                        dealtDamage += random.Next(100, 401);
                        receivedDamage += random.Next(MinEnemyDamage, MaxEnemyDamage) + 100;
                        break;

                    case "2":
                        if (isFadeSpiritExist)
                        {
                            durationHukanzacura += 2;
                            isFadeSpiritExist = false;
                            receivedDamage += random.Next(MinEnemyDamage, MaxEnemyDamage);
                        }
                        else
                        {
                            Console.WriteLine("У вас нет призванных теневых духов" + Environment.NewLine);
                            continue;
                        }
                        break;

                    case "3":
                        if (numberHealingCast >= 1)
                        {
                            hpPlayer = maxHpPlayer;
                            isImmortal = true;
                            Console.WriteLine($"Вы чувствуете прилив сил");
                            numberHealingCast--;
                        }
                        else
                        {
                            Console.WriteLine("Вы больше не можете лечиться, попробуйте что-то другое" + Environment.NewLine);
                            continue;
                        }
                        break;

                    case "4":
                        durationThornArena += 3;
                        receivedDamage += random.Next(MinEnemyDamage, MaxEnemyDamage);
                        break;

                    case "5":
                        if (durationThornArena != 0)
                        {
                            receivedDamage += random.Next(MinEnemyDamage, MaxEnemyDamage);
                            switch (random.Next(1, 11))
                            {
                                case int n when n >= 1 && n <= 9:
                                    dealtDamage += 500;
                                    break;
                                case 10:
                                    hpPlayer = 0;
                                    IsSomeoneDead("Подчинение не сработало и плющ пророс в ваше тело, отчего вы мгновенно умерли", hpPlayer, hpEnemy);
                                    return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы не находитесь на арене шипов" + Environment.NewLine);
                            continue;
                        }
                        break;

                    default:
                        Console.WriteLine("Вы не знаете такого заклинания, попробуйте еще раз");
                        Console.WriteLine();
                        continue;
                }

                if (durationHukanzacura != 0)
                {
                    durationHukanzacura--;
                    dealtDamage += random.Next(50, 301);
                    Console.WriteLine($"Хуганзакура: осталось {durationHukanzacura} хода");
                }

                if (durationThornArena != 0)
                {
                    durationThornArena--;
                    dealtDamage += (int)(receivedDamage * 0.6);
                    Console.WriteLine($"Арена шипов: осталось {durationThornArena} хода");
                }

                if (isImmortal)
                {
                    receivedDamage = 0;
                    isImmortal = false;
                }
                else
                {
                    hpPlayer -= receivedDamage;
                }
                hpEnemy -= dealtDamage;

                if (IsSomeoneDead(hpPlayer, hpEnemy))
                {
                    return;
                }

                Console.WriteLine();
                Console.WriteLine($"Нанесено {dealtDamage} урона");
                Console.WriteLine($"Получено {receivedDamage} урона");

                Console.WriteLine();
                Console.WriteLine($"Здоровье босса - {hpEnemy} хп");
                Console.WriteLine($"Ваше здоровье - {hpPlayer} хп");
                Console.WriteLine();
            }
        }

        private static void Main()
        {
            Introduction();

            StartGame();
        }
    }
}
