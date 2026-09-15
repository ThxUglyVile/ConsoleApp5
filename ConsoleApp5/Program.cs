
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantProgram
{
    // =========================================================
    // 1. КЛАСС RESTAURANT
    // =========================================================
    class Restaurant
    {
        // 7 характеристик
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Cuisine { get; set; }
        public int TablesCount { get; set; }
        public int EmployeesCount { get; set; }
        public double Rating { get; set; }

        // 7 методов
        public void OpenRestaurant()
        {
            Console.WriteLine("Ресторан открыт.");
        }

        public void CloseRestaurant()
        {
            Console.WriteLine("Ресторан закрыт.");
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n========== РЕСТОРАН ==========");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Адрес: {Address}");
            Console.WriteLine($"Телефон: {Phone}");
            Console.WriteLine($"Кухня: {Cuisine}");
            Console.WriteLine($"Столиков: {TablesCount}");
            Console.WriteLine($"Сотрудников: {EmployeesCount}");
            Console.WriteLine($"Рейтинг: {Rating}");
        }

        public void ChangeRating(double rating)
        {
            Rating = rating;
        }

        public void AddTable()
        {
            TablesCount++;
        }

        public void AddEmployee()
        {
            EmployeesCount++;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Ресторан работает. Рейтинг: {Rating}");
        }
    }


    // =========================================================
    // 2. КЛАСС EMPLOYEE
    // =========================================================
    class Employee
    {
        // 7 характеристик
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set; }

        // 7 методов
        public void StartWork()
        {
            Console.WriteLine($"{Name} начал работу.");
        }

        public void FinishWork()
        {
            Console.WriteLine($"{Name} закончил работу.");
        }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"ID: {Id} | {Name} | {Position} | " +
                $"Зарплата: {Salary} грн | Опыт: {Experience} лет");
        }

        public void IncreaseSalary(double amount)
        {
            Salary += amount;
        }

        public void AddExperience()
        {
            Experience++;
        }

        public void ChangePosition(string position)
        {
            Position = position;
        }

        public void ChangePhone(string phone)
        {
            Phone = phone;
        }
    }


    // =========================================================
    // 3. КЛАСС DISH
    // =========================================================
    class Dish
    {
        // 7 характеристик
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public string Ingredients { get; set; }
        public int CookingTime { get; set; }

        // 7 методов
        public void ShowInfo()
        {
            Console.WriteLine(
                $"{Id}. {Name} | {Category} | " +
                $"{Price} грн | {Weight} г | " +
                $"{CookingTime} мин.");
        }

        public void ChangePrice(double price)
        {
            Price = price;
        }

        public void AddIngredient(string ingredient)
        {
            Ingredients += ", " + ingredient;
        }

        public void StartCooking()
        {
            Console.WriteLine($"Блюдо '{Name}' готовится.");
        }

        public void FinishCooking()
        {
            Console.WriteLine($"Блюдо '{Name}' готово.");
        }

        public void ChangeCookingTime(int time)
        {
            CookingTime = time;
        }

        public bool ContainsName(string text)
        {
            return Name.ToLower().Contains(text.ToLower());
        }
    }


    // =========================================================
    // 4. КЛАСС MENU
    // =========================================================
    class Menu
    {
        // 7 характеристик
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public int DishesCount { get; set; }
        public string Season { get; set; }
        public bool IsAvailable { get; set; }

        public List<Dish> Dishes { get; set; }
            = new List<Dish>();

        // 7 методов
        public void ShowMenu()
        {
            Console.WriteLine("\n========== МЕНЮ ==========");

            foreach (Dish dish in Dishes)
            {
                Console.WriteLine(
                    $"{dish.Id}. {dish.Name} - {dish.Price} грн");
            }
        }

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
            DishesCount = Dishes.Count;
        }

        public void RemoveDish(int id)
        {
            Dish dish =
                Dishes.FirstOrDefault(d => d.Id == id);

            if (dish != null)
            {
                Dishes.Remove(dish);
                DishesCount = Dishes.Count;
                Console.WriteLine("Блюдо удалено.");
            }
            else
            {
                Console.WriteLine("Блюдо не найдено.");
            }
        }

        public Dish FindDish(string name)
        {
            return Dishes.FirstOrDefault(
                d => d.ContainsName(name));
        }

        public void SortByPrice()
        {
            Dishes = Dishes
                .OrderBy(d => d.Price)
                .ToList();

            Console.WriteLine("Блюда отсортированы по цене.");
        }

        public void ShowCategory(string category)
        {
            var result = Dishes.Where(
                d => d.Category.ToLower() ==
                     category.ToLower());

            foreach (Dish dish in result)
            {
                dish.ShowInfo();
            }
        }

        public void ChangeSeason(string season)
        {
            Season = season;
        }
    }


    // =========================================================
    // 5. КЛАСС CUSTOMER
    // =========================================================
    class Customer
    {
        // 7 характеристик
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int OrdersCount { get; set; }
        public double BonusPoints { get; set; }

        // 7 методов
        public void ShowInfo()
        {
            Console.WriteLine(
                $"ID: {Id} | {Name} | Возраст: {Age} | " +
                $"Заказов: {OrdersCount} | " +
                $"Бонусов: {BonusPoints:F0}");
        }

        public void MakeOrder()
        {
            OrdersCount++;
        }

        public void AddBonus(double points)
        {
            BonusPoints += points;
        }

        public bool UseBonus(double points)
        {
            if (points <= BonusPoints)
            {
                BonusPoints -= points;
                return true;
            }

            return false;
        }

        public double GetDiscount()
        {
            if (OrdersCount >= 10)
                return 10;

            if (OrdersCount >= 5)
                return 5;

            return 0;
        }

        public void ChangePhone(string phone)
        {
            Phone = phone;
        }

        public void SayHello()
        {
            Console.WriteLine($"Здравствуйте, {Name}!");
        }
    }


    // =========================================================
    // 6. КЛАСС ORDER
    // =========================================================
    class Order
    {
        // 7 характеристик
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string DishName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }

        public List<Dish> Dishes { get; set; }
            = new List<Dish>();

        // 7 методов
        public void CreateOrder()
        {
            Status = "Создан";
        }

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
        }

        public void RemoveDish(string name)
        {
            Dish dish = Dishes.FirstOrDefault(
                d => d.Name.ToLower() ==
                     name.ToLower());

            if (dish != null)
                Dishes.Remove(dish);
        }

        public void CalculatePrice()
        {
            TotalPrice =
                Dishes.Sum(d => d.Price) * Quantity;
        }

        public void ConfirmOrder()
        {
            Status = "Подтвержден";
        }

        public void ChangeStatus(string status)
        {
            Status = status;
        }

        public void CancelOrder()
        {
            Status = "Отменен";
        }
    }


    // =========================================================
    // 7. КЛАСС TABLE
    // =========================================================
    class Table
    {
        // 7 характеристик
        public int Number { get; set; }
        public int Seats { get; set; }
        public string Location { get; set; }
        public bool IsFree { get; set; }
        public bool IsReserved { get; set; }
        public string CustomerName { get; set; }
        public double ReservationPrice { get; set; }

        // 7 методов
        public void ShowInfo()
        {
            string status;

            if (IsReserved)
                status = "Забронирован";
            else if (IsFree)
                status = "Свободен";
            else
                status = "Занят";

            Console.WriteLine(
                $"Столик №{Number} | " +
                $"Мест: {Seats} | " +
                $"{Location} | {status}");
        }

        public void Reserve(string customer)
        {
            if (!IsFree)
            {
                Console.WriteLine("Столик занят.");
                return;
            }

            IsReserved = true;
            IsFree = false;
            CustomerName = customer;

            Console.WriteLine(
                $"Столик №{Number} забронирован.");
        }

        public void FreeTable()
        {
            IsFree = true;
            IsReserved = false;
            CustomerName = "";

            Console.WriteLine(
                $"Столик №{Number} освобожден.");
        }

        public void CleanTable()
        {
            Console.WriteLine(
                $"Столик №{Number} убран.");
        }

        public void AddSeats(int count)
        {
            Seats += count;
        }

        public void SetReservationPrice(double price)
        {
            ReservationPrice = price;
        }

        public void ChangeLocation(string location)
        {
            Location = location;
        }
    }


    // =========================================================
    // PROGRAM
    // =========================================================
    class Program
    {
        static Restaurant restaurant = new Restaurant
        {
            Name = "La Piazza",
            Address = "ул. Центральная, 15",
            Phone = "+380 67 123 45 67",
            Cuisine = "Итальянская",
            TablesCount = 10,
            EmployeesCount = 5,
            Rating = 4.8
        };

        static Menu menu = new Menu
        {
            Id = 1,
            Name = "Основное меню",
            Type = "Основное",
            Language = "Украинский",
            DishesCount = 0,
            Season = "Лето",
            IsAvailable = true
        };

        static List<Customer> customers =
            new List<Customer>();

        static List<Employee> employees =
            new List<Employee>();

        static List<Order> orders =
            new List<Order>();

        static List<Table> tables =
            new List<Table>();


        // =====================================================
        // MAIN
        // =====================================================
        static void Main(string[] args)
        {
            Console.OutputEncoding =
                System.Text.Encoding.UTF8;

            InitializeData();

            restaurant.OpenRestaurant();

            while (true)
            {
                ShowMainMenu();

                Console.Write("\nВыберите действие: ");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        restaurant.ShowInfo();
                        break;

                    case "2":
                        menu.ShowMenu();
                        break;

                    case "3":
                        AddDish();
                        break;

                    case "4":
                        RemoveDish();
                        break;

                    case "5":
                        FindDish();
                        break;

                    case "6":
                        SortDishes();
                        break;

                    case "7":
                        CreateCustomer();
                        break;

                    case "8":
                        ShowCustomers();
                        break;

                    case "9":
                        CreateOrder();
                        break;

                    case "10":
                        ShowOrders();
                        break;

                    case "11":
                        ChangeOrderStatus();
                        break;

                    case "12":
                        ReserveTable();
                        break;

                    case "13":
                        ShowFreeTables();
                        break;

                    case "14":
                        FreeTable();
                        break;

                    case "15":
                        ShowEmployees();
                        break;

                    case "16":
                        ShowStatistics();
                        break;

                    case "0":
                        restaurant.CloseRestaurant();
                        return;

                    default:
                        Console.WriteLine(
                            "Неверный пункт меню.");
                        break;
                }

                Console.WriteLine(
                    "\nНажмите Enter для продолжения...");
                Console.ReadLine();
                Console.Clear();
            }
        }


        // =====================================================
        // НАЧАЛЬНЫЕ ДАННЫЕ
        // =====================================================
        static void InitializeData()
        {
            // ПИЦЦА
            menu.AddDish(new Dish
            {
                Id = 1,
                Name = "Пицца Маргарита",
                Category = "Пицца",
                Price = 250,
                Weight = 500,
                Ingredients =
                    "сыр, помидоры, томатный соус",
                CookingTime = 20
            });

            menu.AddDish(new Dish
            {
                Id = 2,
                Name = "Пицца Пепперони",
                Category = "Пицца",
                Price = 300,
                Weight = 550,
                Ingredients =
                    "сыр, пепперони, томатный соус",
                CookingTime = 22
            });

            menu.AddDish(new Dish
            {
                Id = 3,
                Name = "Пицца Четыре сыра",
                Category = "Пицца",
                Price = 350,
                Weight = 500,
                Ingredients =
                    "моцарелла, пармезан, дорблю, чеддер",
                CookingTime = 25
            });

            // ПАСТА
            menu.AddDish(new Dish
            {
                Id = 4,
                Name = "Паста Карбонара",
                Category = "Паста",
                Price = 220,
                Weight = 350,
                Ingredients =
                    "паста, бекон, сыр, сливки",
                CookingTime = 15
            });

            menu.AddDish(new Dish
            {
                Id = 5,
                Name = "Паста Болоньезе",
                Category = "Паста",
                Price = 240,
                Weight = 400,
                Ingredients =
                    "паста, мясо, томатный соус",
                CookingTime = 18
            });

            // САЛАТЫ
            menu.AddDish(new Dish
            {
                Id = 6,
                Name = "Цезарь",
                Category = "Салат",
                Price = 180,
                Weight = 300,
                Ingredients =
                    "курица, салат, сыр, соус",
                CookingTime = 10
            });

            menu.AddDish(new Dish
            {
                Id = 7,
                Name = "Греческий салат",
                Category = "Салат",
                Price = 160,
                Weight = 300,
                Ingredients =
                    "помидоры, огурцы, сыр, маслины",
                CookingTime = 8
            });

            // СУПЫ
            menu.AddDish(new Dish
            {
                Id = 8,
                Name = "Борщ",
                Category = "Суп",
                Price = 150,
                Weight = 400,
                Ingredients =
                    "свекла, капуста, мясо",
                CookingTime = 15
            });

            menu.AddDish(new Dish
            {
                Id = 9,
                Name = "Крем-суп грибной",
                Category = "Суп",
                Price = 170,
                Weight = 350,
                Ingredients =
                    "грибы, сливки, лук",
                CookingTime = 15
            });

            // ДЕСЕРТЫ
            menu.AddDish(new Dish
            {
                Id = 10,
                Name = "Чизкейк",
                Category = "Десерт",
                Price = 170,
                Weight = 200,
                Ingredients =
                    "сыр, печенье, сливки",
                CookingTime = 5
            });

            menu.AddDish(new Dish
            {
                Id = 11,
                Name = "Тирамису",
                Category = "Десерт",
                Price = 160,
                Weight = 180,
                Ingredients =
                    "маскарпоне, кофе, печенье",
                CookingTime = 5
            });

            // НАПИТКИ
            menu.AddDish(new Dish
            {
                Id = 12,
                Name = "Кола",
                Category = "Напиток",
                Price = 60,
                Weight = 500,
                Ingredients = "газированный напиток",
                CookingTime = 1
            });

            menu.AddDish(new Dish
            {
                Id = 13,
                Name = "Кофе",
                Category = "Напиток",
                Price = 80,
                Weight = 200,
                Ingredients = "кофе, вода, молоко",
                CookingTime = 5
            });

            menu.AddDish(new Dish
            {
                Id = 14,
                Name = "Апельсиновый сок",
                Category = "Напиток",
                Price = 100,
                Weight = 300,
                Ingredients = "апельсин",
                CookingTime = 2
            });


            // СОТРУДНИКИ
            employees.Add(new Employee
            {
                Id = 1,
                Name = "Алексей",
                Age = 28,
                Position = "Повар",
                Salary = 25000,
                Phone = "+380 67 111 22 33",
                Experience = 5
            });

            employees.Add(new Employee
            {
                Id = 2,
                Name = "Анна",
                Age = 25,
                Position = "Официант",
                Salary = 18000,
                Phone = "+380 50 333 44 55",
                Experience = 3
            });


            // КЛИЕНТ
            customers.Add(new Customer
            {
                Id = 1,
                Name = "Михаил",
                Age = 21,
                Phone = "+380 50 222 33 44",
                Email = "misha@gmail.com",
                OrdersCount = 4,
                BonusPoints = 150
            });


            // СТОЛИКИ
            for (int i = 1; i <= 10; i++)
            {
                tables.Add(new Table
                {
                    Number = i,
                    Seats = i % 2 == 0 ? 4 : 2,
                    Location =
                        i <= 5 ? "Зал" : "У окна",
                    IsFree = true,
                    IsReserved = false,
                    CustomerName = "",
                    ReservationPrice = 100
                });
            }
        }


        // =====================================================
        // ГЛАВНОЕ МЕНЮ
        // =====================================================
        static void ShowMainMenu()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("          РЕСТОРАН LA PIAZZA");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Информация о ресторане");
            Console.WriteLine("2. Показать меню");
            Console.WriteLine("3. Добавить блюдо");
            Console.WriteLine("4. Удалить блюдо");
            Console.WriteLine("5. Найти блюдо");
            Console.WriteLine("6. Сортировать по цене");
            Console.WriteLine("7. Добавить клиента");
            Console.WriteLine("8. Показать клиентов");
            Console.WriteLine("9. Создать заказ");
            Console.WriteLine("10. Показать заказы");
            Console.WriteLine("11. Изменить статус заказа");
            Console.WriteLine("12. Забронировать столик");
            Console.WriteLine("13. Свободные столики");
            Console.WriteLine("14. Освободить столик");
            Console.WriteLine("15. Сотрудники");
            Console.WriteLine("16. Статистика");
            Console.WriteLine("0. Выход");
            Console.WriteLine("======================================");
        }


        // =====================================================
        // ДОБАВЛЕНИЕ БЛЮДА
        // =====================================================
        static void AddDish()
        {
            Console.WriteLine(
                "========== ДОБАВЛЕНИЕ БЛЮДА ==========");

            Console.WriteLine("\nВыберите категорию:");

            Console.WriteLine("1. Пицца");
            Console.WriteLine("2. Паста");
            Console.WriteLine("3. Салат");
            Console.WriteLine("4. Суп");
            Console.WriteLine("5. Десерт");
            Console.WriteLine("6. Напиток");

            Console.Write("\nВаш выбор: ");
            string categoryChoice =
                Console.ReadLine();

            string category;

            switch (categoryChoice)
            {
                case "1":
                    category = "Пицца";
                    break;

                case "2":
                    category = "Паста";
                    break;

                case "3":
                    category = "Салат";
                    break;

                case "4":
                    category = "Суп";
                    break;

                case "5":
                    category = "Десерт";
                    break;

                case "6":
                    category = "Напиток";
                    break;

                default:
                    Console.WriteLine("Неверная категория.");
                    return;
            }

            Console.Write("Название блюда: ");
            string name = Console.ReadLine();

            Console.Write("Цена: ");
            double price =
                double.Parse(Console.ReadLine());

            Console.Write("Вес: ");
            int weight =
                int.Parse(Console.ReadLine());

            Console.Write("Ингредиенты: ");
            string ingredients =
                Console.ReadLine();

            Console.Write("Время приготовления: ");
            int time =
                int.Parse(Console.ReadLine());

            int id = menu.Dishes.Count == 0
                ? 1
                : menu.Dishes.Max(d => d.Id) + 1;

            Dish dish = new Dish
            {
                Id = id,
                Name = name,
                Category = category,
                Price = price,
                Weight = weight,
                Ingredients = ingredients,
                CookingTime = time
            };

            menu.AddDish(dish);

            Console.WriteLine(
                "\nБлюдо успешно добавлено!");
        }


        // =====================================================
        // УДАЛЕНИЕ БЛЮДА
        // =====================================================
        static void RemoveDish()
        {
            menu.ShowMenu();

            Console.Write("\nВведите ID блюда: ");
            int id =
                int.Parse(Console.ReadLine());

            menu.RemoveDish(id);
        }


        // =====================================================
        // ПОИСК БЛЮДА
        // =====================================================
        static void FindDish()
        {
            Console.Write("Введите название блюда: ");
            string name = Console.ReadLine();

            Dish dish = menu.FindDish(name);

            if (dish != null)
                dish.ShowInfo();
            else
                Console.WriteLine("Блюдо не найдено.");
        }


        // =====================================================
        // СОРТИРОВКА
        // =====================================================
        static void SortDishes()
        {
            menu.SortByPrice();

            menu.ShowMenu();
        }


        // =====================================================
        // СОЗДАНИЕ КЛИЕНТА
        // =====================================================
        static void CreateCustomer()
        {
            Console.Write("Имя клиента: ");
            string name = Console.ReadLine();

            Console.Write("Возраст: ");
            int age =
                int.Parse(Console.ReadLine());

            Console.Write("Телефон: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            int id = customers.Count == 0
                ? 1
                : customers.Max(c => c.Id) + 1;

            Customer customer = new Customer
            {
                Id = id,
                Name = name,
                Age = age,
                Phone = phone,
                Email = email,
                OrdersCount = 0,
                BonusPoints = 0
            };

            customers.Add(customer);

            Console.WriteLine(
                $"Клиент добавлен. Его ID: {id}");
        }


        // =====================================================
        // ПОКАЗ КЛИЕНТОВ
        // =====================================================
        static void ShowCustomers()
        {
            Console.WriteLine(
                "========== КЛИЕНТЫ ==========");

            foreach (Customer customer in customers)
            {
                customer.ShowInfo();
            }
        }


        // =====================================================
        // СОЗДАНИЕ ЗАКАЗА
        // =====================================================
        static void CreateOrder()
        {
            Console.WriteLine(
                "========== СОЗДАНИЕ ЗАКАЗА ==========");

            ShowCustomers();

            Console.Write("\nВведите ID клиента: ");

            int customerId =
                int.Parse(Console.ReadLine());

            Customer customer =
                customers.FirstOrDefault(
                    c => c.Id == customerId);

            if (customer == null)
            {
                Console.WriteLine(
                    "Клиент не найден.");
                return;
            }

            Console.WriteLine(
                $"\nЗдравствуйте, {customer.Name}!");

            // =============================================
            // ПОКАЗ БЛЮД
            // =============================================
            Console.WriteLine(
                "\n========== ВЫБЕРИТЕ БЛЮДО ==========");

            foreach (Dish dish in menu.Dishes)
            {
                Console.WriteLine(
                    $"{dish.Id}. {dish.Name} - " +
                    $"{dish.Price} грн.");
            }

            Console.Write(
                "\nВведите номер блюда: ");

            int dishId =
                int.Parse(Console.ReadLine());

            Dish selectedDish =
                menu.Dishes.FirstOrDefault(
                    d => d.Id == dishId);

            if (selectedDish == null)
            {
                Console.WriteLine(
                    "Такого блюда нет.");
                return;
            }

            Console.WriteLine(
                $"\nВы выбрали: {selectedDish.Name}");

            Console.WriteLine(
                $"Цена: {selectedDish.Price} грн.");

            // =============================================
            // КОЛИЧЕСТВО
            // =============================================
            Console.Write(
                "\nВведите количество: ");

            int quantity =
                int.Parse(Console.ReadLine());

            if (quantity <= 0)
            {
                Console.WriteLine(
                    "Количество должно быть больше 0.");
                return;
            }

            // =============================================
            // РАСЧЕТ
            // =============================================
            double total =
                selectedDish.Price * quantity;

            Console.WriteLine(
                $"\n{selectedDish.Name} x {quantity}");

            Console.WriteLine(
                $"Стоимость: {total} грн.");

            // =============================================
            // СКИДКА
            // =============================================
            double discount =
                customer.GetDiscount();

            if (discount > 0)
            {
                double discountAmount =
                    total * discount / 100;

                total -= discountAmount;

                Console.WriteLine(
                    $"Ваша скидка: {discount}%");

                Console.WriteLine(
                    $"После скидки: {total:F2} грн.");
            }

            // =============================================
            // ОПЛАТА
            // =============================================
            Console.WriteLine(
                "\nВыберите способ оплаты:");

            Console.WriteLine("1. Карта");
            Console.WriteLine("2. Наличные");
            Console.WriteLine("3. Apple Pay / Google Pay");

            Console.Write("\nВаш выбор: ");

            string paymentChoice =
                Console.ReadLine();

            string paymentMethod;

            switch (paymentChoice)
            {
                case "1":
                    paymentMethod = "Карта";
                    break;

                case "2":
                    paymentMethod = "Наличные";
                    break;

                case "3":
                    paymentMethod =
                        "Apple Pay / Google Pay";
                    break;

                default:
                    paymentMethod = "Карта";
                    break;
            }

            // =============================================
            // СОЗДАНИЕ ЗАКАЗА
            // =============================================
            int orderId = orders.Count == 0
                ? 1
                : orders.Max(o => o.Id) + 1;

            Order order = new Order
            {
                Id = orderId,
                CustomerId = customer.Id,
                DishName = selectedDish.Name,
                Quantity = quantity,
                TotalPrice = total,
                PaymentMethod = paymentMethod
            };

            order.AddDish(selectedDish);
            order.CreateOrder();

            orders.Add(order);

            customer.MakeOrder();

            // 5% бонусов
            double bonus = total * 0.05;

            customer.AddBonus(bonus);

            Console.WriteLine(
                "\n================================");
            Console.WriteLine(
                $"ЗАКАЗ №{order.Id} СОЗДАН");
            Console.WriteLine(
                $"Блюдо: {selectedDish.Name}");
            Console.WriteLine(
                $"Количество: {quantity}");
            Console.WriteLine(
                $"ИТОГО: {total:F2} грн.");
            Console.WriteLine(
                $"Оплата: {paymentMethod}");
            Console.WriteLine(
                $"Начислено бонусов: {bonus:F0}");
            Console.WriteLine(
                "================================");
        }


        // =====================================================
        // ПОКАЗ ЗАКАЗОВ
        // =====================================================
        static void ShowOrders()
        {
            Console.WriteLine(
                "========== ЗАКАЗЫ ==========");

            if (orders.Count == 0)
            {
                Console.WriteLine(
                    "Заказов пока нет.");
                return;
            }

            foreach (Order order in orders)
            {
                Console.WriteLine(
                    $"№{order.Id} | " +
                    $"Клиент ID: {order.CustomerId} | " +
                    $"{order.DishName} x {order.Quantity} | " +
                    $"{order.TotalPrice:F2} грн | " +
                    $"{order.Status}");
            }
        }


        // =====================================================
        // ИЗМЕНЕНИЕ СТАТУСА
        // =====================================================
        static void ChangeOrderStatus()
        {
            ShowOrders();

            if (orders.Count == 0)
                return;

            Console.Write(
                "\nВведите номер заказа: ");

            int id =
                int.Parse(Console.ReadLine());

            Order order =
                orders.FirstOrDefault(
                    o => o.Id == id);

            if (order == null)
            {
                Console.WriteLine(
                    "Заказ не найден.");
                return;
            }

            Console.WriteLine(
                "\nВыберите статус:");

            Console.WriteLine(
                "1. Подтвержден");

            Console.WriteLine(
                "2. Готовится");

            Console.WriteLine(
                "3. Готов");

            Console.WriteLine(
                "4. Оплачен");

            Console.WriteLine(
                "5. Отменен");

            Console.Write("\nВаш выбор: ");

            string choice =
                Console.ReadLine();

            switch (choice)
            {
                case "1":
                    order.ChangeStatus(
                        "Подтвержден");
                    break;

                case "2":
                    order.ChangeStatus(
                        "Готовится");
                    break;

                case "3":
                    order.ChangeStatus(
                        "Готов");
                    break;

                case "4":
                    order.ChangeStatus(
                        "Оплачен");
                    break;

                case "5":
                    order.CancelOrder();
                    break;

                default:
                    Console.WriteLine(
                        "Неверный выбор.");
                    return;
            }

            Console.WriteLine(
                $"Новый статус: {order.Status}");
        }


        // =====================================================
        // БРОНИРОВАНИЕ
        // =====================================================
        static void ReserveTable()
        {
            ShowFreeTables();

            Console.Write(
                "\nВведите номер столика: ");

            int number =
                int.Parse(Console.ReadLine());

            Table table =
                tables.FirstOrDefault(
                    t => t.Number == number);

            if (table == null)
            {
                Console.WriteLine(
                    "Столик не найден.");
                return;
            }

            Console.Write(
                "Имя клиента: ");

            string customer =
                Console.ReadLine();

            table.Reserve(customer);
        }


        // =====================================================
        // СВОБОДНЫЕ СТОЛИКИ
        // =====================================================
        static void ShowFreeTables()
        {
            Console.WriteLine(
                "========== СВОБОДНЫЕ СТОЛИКИ ==========");

            foreach (Table table in tables)
            {
                if (table.IsFree)
                    table.ShowInfo();
            }
        }


        // =====================================================
        // ОСВОБОЖДЕНИЕ СТОЛИКА
        // =====================================================
        static void FreeTable()
        {
            Console.Write(
                "Введите номер столика: ");

            int number =
                int.Parse(Console.ReadLine());

            Table table =
                tables.FirstOrDefault(
                    t => t.Number == number);

            if (table != null)
                table.FreeTable();
            else
                Console.WriteLine(
                    "Столик не найден.");
        }


        // =====================================================
        // СОТРУДНИКИ
        // =====================================================
        static void ShowEmployees()
        {
            Console.WriteLine(
                "========== СОТРУДНИКИ ==========");

            foreach (Employee employee in employees)
            {
                employee.ShowInfo();
            }
        }


        // =====================================================
        // СТАТИСТИКА
        // =====================================================
        static void ShowStatistics()
        {
            Console.WriteLine(
                "========== СТАТИСТИКА ==========");

            double revenue =
                orders
                .Where(o => o.Status == "Оплачен")
                .Sum(o => o.TotalPrice);

            double averageCheck =
                orders.Count > 0
                ? orders.Average(o => o.TotalPrice)
                : 0;

            int freeTables =
                tables.Count(t => t.IsFree);

            int occupiedTables =
                tables.Count(t => !t.IsFree);

            Console.WriteLine(
                $"Блюд: {menu.Dishes.Count}");

            Console.WriteLine(
                $"Клиентов: {customers.Count}");

            Console.WriteLine(
                $"Заказов: {orders.Count}");

            Console.WriteLine(
                $"Оплачено заказов: " +
                $"{orders.Count(o => o.Status == "Оплачен")}");

            Console.WriteLine(
                $"Выручка: {revenue:F2} грн.");

            Console.WriteLine(
                $"Средний чек: " +
                $"{averageCheck:F2} грн.");

            Console.WriteLine(
                $"Свободных столиков: {freeTables}");

            Console.WriteLine(
                $"Занятых столиков: {occupiedTables}");

            Console.WriteLine(
                $"Сотрудников: {employees.Count}");

            if (orders.Count > 0)
            {
                var popularDish =
                    orders
                    .GroupBy(o => o.DishName)
                    .OrderByDescending(g => g.Count())
                    .First();

                Console.WriteLine(
                    $"Популярное блюдо: " +
                    $"{popularDish.Key}");
            }
        }
    }
}

