using Memory_strg;

namespace Price_list
{
    internal class Price_list
    {
        // полe
        private List<Memory_storages> storages;
        
        public List<Memory_storages> List
        {
            get { return storages; }
        }

        // конструктори

        public Price_list() { storages = new List<Memory_storages>(); }
        public Price_list(List<Memory_storages> stor) 
        { 
            storages = new List<Memory_storages>();
            foreach (var storage in stor)
            {
                storages.Add(storage);
            }
        }

        // Методи
        
        public void AddStorage(Memory_storages storage) 
        {
            storages.Add(storage);
        }

        public void DelStorage()
        {
            
            Console.WriteLine("Оберіть критерій видалення:\n" +
                "1) По назвi\n2)По виробнику\n3)По моделі\n4)По ціні");
            int choise = Convert.ToInt32(Console.ReadLine());
            string text = "";
            switch(choise)
            {
                case 1:
                    Console.Write("Введіть назву для видалення - ");
                    text = Console.ReadLine();
                    foreach (Memory_storages? storage in storages)
                    {
                        if (string.Equals(storage.Name, text))
                        {
                            storages.Remove(storage);
                            break;
                        }
                    }
                    break;
                case 2:
                    Console.Write("Введіть виробника для видалення - ");
                    text = Console.ReadLine();
                    foreach (Memory_storages storage in storages)
                    {
                        if (string.Equals(storage.Maker, text))
                        {
                            storages.Remove(storage);
                            break;
                        }
                    }
                    break;
                case 3:
                    Console.Write("Введіть модель для видалення - ");
                    text = Console.ReadLine();
                    foreach (Memory_storages storage in storages)
                    {
                        if (string.Equals(storage.Model, text))
                        {
                            storages.Remove(storage);
                            break;
                        }
                    }
                    break;
                case 4:
                    Console.Write("Введіть контрольну ціну (менше цієї ціне видаляється) - ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    foreach (Memory_storages storage in storages)
                    {
                        if (storage.Price < num)
                        {
                            storages.Remove(storage);
                            break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Некоректний вибір!!");
                    break;
            }
        }

        public void EditStorage(int num)
        {
            if(storages.Count < num || num < 0)
            {
                Console.WriteLine("Немає сховища із таким номером!");
            }
            else
            {
                storages[num].Edit();
            }
        }

        public void Search()
        {
            Console.WriteLine("Оберіть критерій видалення:\n" +
                "1) По назвi\n2)По виробнику\n3)По моделі\n4)По ціні");
            int choise = Convert.ToInt32(Console.ReadLine());
            string text = "";
            switch (choise)
            {
                case 1:
                    Console.Write("Введіть назву для пошуку - ");
                    text = Console.ReadLine();
                    foreach (Memory_storages storage in storages)
                    {
                        if (string.Equals(storage.Name, text))
                        {
                            storage.Info();
                        }
                    }
                    break;
                case 2:
                    Console.Write("Введіть виробника для пошуку - ");
                    text = Console.ReadLine();
                    foreach (Memory_storages storage in storages)
                    {
                        if (string.Equals(storage.Maker, text))
                        {
                            storage.Info();
                        }
                    }
                    break;
                case 3:
                    Console.Write("Введіть модель для пошуку - ");
                    text = Console.ReadLine();
                    foreach (Memory_storages storage in storages)
                    {
                        if (string.Equals(storage.Model, text))
                        {
                            storage.Info();
                        }
                    }
                    break;
                case 4:
                    Console.Write("Введіть контрольну ціну - ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    foreach (Memory_storages storage in storages)
                    {
                        if (storage.Price == num)
                        {
                            storage.Info();
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Некоректний вибір!!");
                    break;
            }
        }

        public void Info()
        {
            Console.WriteLine("###############################");
            foreach (Memory_storages storage in storages)
            {
                storage.Info();
            }
        }
    }
}
