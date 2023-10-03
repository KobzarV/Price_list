namespace Memory_strg
{
    public abstract class Memory_storages
    {
        private string name;
        private string maker;
        private string model;
        private int count;
        private double price;
        
        //Властивості
        public string Name 
        { 
            get { return name; }
            set {
                if (!string.IsNullOrEmpty(value)) { name = value; }
                else
                {
                    Random r = new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        name += ((char)r.Next(65, 122)).ToString();
                    }
                }
            }
        }
        public string Maker 
        {
            get { return maker; }
            set
            {
                if (!string.IsNullOrEmpty(value)) { maker = value; }
                else
                {
                    Random r = new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        maker += ((char)r.Next(65, 122)).ToString();
                    }
                }
            }
        }
        public string Model
        {
            get { return model; }
            set
            {
                if (!string.IsNullOrEmpty(value)) { model = value; }
                else
                {
                    Random r = new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        model += ((char)r.Next(65, 122)).ToString();
                    }
                }
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                if (count > 0) { count = value; }
                else
                {
                    Random r = new Random();
                    count = r.Next(1, 100);
                }
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (price > 0) { price = value; }
                else
                {
                    Random r = new Random();
                    price = r.Next(1, 2000)/0.3;
                }
            }
        }
        //Конструктори
        public Memory_storages(string name, string maker, string model, int count, double price)
        {
            Name = name;
            Maker = maker;
            Model = model;
            Count = count;
            Price = price;
        }

        public Memory_storages()
        {
            Name = "";
            Maker = "";
            Model = "";
            Count = 0;
            Price = 0;
        }

        public Memory_storages(Memory_storages other)
        {
            Name = other.Name;
            Maker = other.Maker;
            Model = other.Model;
            Count = other.Count;
            Price = other.Price;
        }

        public void Edit()
        {
            Console.WriteLine("Введіть нову назву:");
            Name = Console.ReadLine();
            Console.WriteLine("Введіть нового виробника:");
            Maker = Console.ReadLine();
            Console.WriteLine("Введіть нову модель:");
            Model = Console.ReadLine();
            Console.WriteLine("Введіть нову кількість:");
            Count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть нову ціну:");
            Price = Convert.ToDouble(Console.ReadLine());
        }

        // Віртуальний метод для виводу на екран
        public virtual void Info() { }
        public virtual void SaveFile(string fileName = "") { }
        public virtual void LoadFile(string fileName) { }
    }

    public class DVD : Memory_storages
    {
        public double memorySize;
        public double usbSpeed;

        public double MemorySize 
        {
            get { return memorySize; }
            set 
            {
                if(memorySize > 0) { memorySize = value; }
                else 
                {
                    Random r = new Random();
                    usbSpeed = r.Next(1, 100);
                }
            }
        }
        public double UsbSpeed
        {
            get { return usbSpeed; }
            set 
            {
                if (usbSpeed > 0) { usbSpeed = value; }
                else 
                {
                    Random r = new Random();
                    usbSpeed = r.Next(100, 10000);
                }
            }
        }

        public DVD(string name, string maker, string model, int count, double price,
            int memorySizeGB, int usbSpeed) : base(name, maker, model, count, price)
        {
            MemorySize = memorySizeGB;
            UsbSpeed = usbSpeed;
        }

        public DVD() : base() 
        {
            Random r = new Random();
            MemorySize = r.Next(1, 100);
            UsbSpeed = r.Next(100, 10000);
        }

        // Перевизначення методу для печаті інформації про Flash-пам'ять
        public override void Info()
        {
            Console.WriteLine("\tDVD");
            Console.WriteLine($"Найменування: {Name}");
            Console.WriteLine($"Виробник: {Maker}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Кількість: {Count}");
            Console.WriteLine($"Ціна: {Price}");
            Console.WriteLine($"Об'єм пам'яті: {MemorySize} ГБ");
            Console.WriteLine($"Швидкість USB: {UsbSpeed} Мбіт/с");
            Console.WriteLine("--------------------------------------------");
        }

        public override void SaveFile(string fileName = "")
        {
            if (fileName == "") { fileName = "DVD.txt"; }
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Записуємо властивості об'єкта в файл
                    writer.WriteLine("Name - " + Name);
                    writer.WriteLine("Maker - " + Maker);
                    writer.WriteLine("Model - " + Model);
                    writer.WriteLine("Count - " + Count);
                    writer.WriteLine("Price - " + Price);
                    writer.WriteLine("Memory size - " + MemorySize);
                    writer.WriteLine("USB speed - " + UsbSpeed);
                }

                Console.WriteLine("Дані успішно збережені в файл: " + fileName);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Помилка збереження у файл: " + ex.Message);
            }
        }

        public override void LoadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не знайдено!!");
                return;
            }
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('-');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();
                            switch (key)
                            {
                                case "Name":
                                    Name = value;
                                    break;
                                case "Maker":
                                    Maker = value;
                                    break;
                                case "Model":
                                    Model = value;
                                    break;
                                case "Count":
                                    if (int.TryParse(value, out int count))
                                    {
                                        Count = count;
                                    }
                                    break;
                                case "Price":
                                    if (double.TryParse(value, out double price))
                                    {
                                        Price = price;
                                    }
                                    break;
                                case "Memory size":
                                    if (double.TryParse(value, out double memorySize))
                                    {
                                        MemorySize = memorySize;
                                    }
                                    break;
                                case "WriteSpeed":
                                    if (double.TryParse(value, out double usbSpeed))
                                    {
                                        UsbSpeed = usbSpeed;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Помилка зчитування з файлу: " + ex.Message);
            }
        }
    }

    public class HDD : Memory_storages
    {
        public double diskSize;
        public double usbSpeed;

        public double DiskSize
        {
            get { return diskSize; }
            set
            {
                if (diskSize > 0) { diskSize = value; }
                else 
                {
                    Random r = new Random();
                    diskSize = r.Next(1, 100);
                }
            }
        }
        public double UsbSpeed
        {
            get { return usbSpeed; }
            set
            {
                if (usbSpeed > 0) { usbSpeed = value; }
                else
                {
                    Random r = new Random();
                    usbSpeed = r.Next(100, 10000);
                }
            }
        }

        public HDD(string name, string maker, string model, int count, double price,
            double diskSize, double usbSpeed) : base(name, maker, model, count, price)
        {
            DiskSize = diskSize;
            UsbSpeed = usbSpeed;
        }

        public HDD() : base()
        {
            Random r = new Random();
            diskSize = r.Next(1, 100);
            UsbSpeed = r.Next(100, 10000);
        }

        // Перевизначення методу для печаті інформації про Flash-пам'ять
        public override void Info()
        {
            Console.WriteLine("\tHDD");
            Console.WriteLine($"Найменування: {Name}");
            Console.WriteLine($"Виробник: {Maker}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Кількість: {Count}");
            Console.WriteLine($"Ціна: {Price}");
            Console.WriteLine($"Розмір диску: {diskSize} ГБ");
            Console.WriteLine($"Швидкість USB: {UsbSpeed} Мбіт/с");
            Console.WriteLine("--------------------------------------------");
        }
        public override void SaveFile(string fileName = "") 
        {
            if (fileName == "") { fileName = "HDD.txt"; }
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Записуємо властивості об'єкта в файл
                    writer.WriteLine("Name - " + Name);
                    writer.WriteLine("Maker - " + Maker);
                    writer.WriteLine("Model - " + Model);
                    writer.WriteLine("Count - " + Count);
                    writer.WriteLine("Price - " + Price);
                    writer.WriteLine("Disk size - " + DiskSize);
                    writer.WriteLine("USB speed - " + UsbSpeed);
                }

                Console.WriteLine("Дані успішно збережені в файл: " + fileName);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Помилка збереження у файл: " + ex.Message);
            }
        }

        public override void LoadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не знайдено!!");
                return;
            }
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('-');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();
                            switch (key)
                            {
                                case "Name":
                                    Name = value;
                                    break;
                                case "Maker":
                                    Maker = value;
                                    break;
                                case "Model":
                                    Model = value;
                                    break;
                                case "Count":
                                    if (int.TryParse(value, out int count))
                                    {
                                        Count = count;
                                    }
                                    break;
                                case "Price":
                                    if (double.TryParse(value, out double price))
                                    {
                                        Price = price;
                                    }
                                    break;
                                case "Disk size":
                                    if (double.TryParse(value, out double diskSize))
                                    {
                                        DiskSize = diskSize;
                                    }
                                    break;
                                case "Usb speed":
                                    if (double.TryParse(value, out double usbSpeed))
                                    {
                                        UsbSpeed = usbSpeed;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Помилка зчитування з файлу: " + ex.Message);
            }
        }
    }

    public class Flash : Memory_storages
    {
        public double readSpeed;
        public double writeSpeed;

        public double ReadSpeed
        {
            get { return readSpeed; }
            set
            {
                if (readSpeed > 0) { readSpeed = value; }
                else
                {
                    Random r = new Random();
                    readSpeed = r.Next(100, 10000);
                }
            }
        }
        public double WriteSpeed
        {
            get { return writeSpeed; }
            set
            {
                if (writeSpeed > 0) { writeSpeed = value; }
                else
                {
                    Random r = new Random();
                    writeSpeed = r.Next(100, 10000);
                }
            }
        }

        public Flash(string name, string maker, string model, int count, double price,
            double readSpeed, double writeSpeed) : base(name, maker, model, count, price)
        {
            ReadSpeed = readSpeed;
            WriteSpeed = writeSpeed;
        }

        public Flash() : base()
        {
            Random r = new Random();
            ReadSpeed = r.Next(100, 10000);
            WriteSpeed = r.Next(100, 10000);
        }

        // Перевизначення методу для печаті інформації про Flash-пам'ять
        public override void Info()
        {
            Console.WriteLine("\tFlash");
            Console.WriteLine($"Найменування: {Name}");
            Console.WriteLine($"Виробник: {Maker}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Кількість: {Count}");
            Console.WriteLine($"Ціна: {Price}");
            Console.WriteLine($"Швидкість зчитування: {ReadSpeed} Мбіт/с");
            Console.WriteLine($"Швидкість запису: {WriteSpeed} Мбіт/с");
            Console.WriteLine("--------------------------------------------");
        }

        public override void SaveFile(string fileName = "")
        {
            if(fileName == "") { fileName = "Flash.txt"; }
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Записуємо властивості об'єкта в файл
                    writer.WriteLine("Name - " + Name);
                    writer.WriteLine("Maker - " + Maker);
                    writer.WriteLine("Model - " + Model);
                    writer.WriteLine("Count - " + Count);
                    writer.WriteLine("Price - " + Price);
                    writer.WriteLine("ReadSpeed - " + ReadSpeed);
                    writer.WriteLine("WriteSpeed - " + WriteSpeed);
                }

                Console.WriteLine("Дані успішно збережені в файл: " + fileName);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Помилка збереження у файл: " + ex.Message);
            }
        }
        public override void LoadFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                Console.WriteLine("Файл не знайдено!!");
                return;
            }    
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('-');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();
                            switch (key)
                            {
                                case "Name":
                                    Name = value;
                                    break;
                                case "Maker":
                                    Maker = value;
                                    break;
                                case "Model":
                                    Model = value;
                                    break;
                                case "Count":
                                    if (int.TryParse(value, out int count))
                                    {
                                        Count = count;
                                    }
                                    break;
                                case "Price":
                                    if (double.TryParse(value, out double price))
                                    {
                                        Price = price;
                                    }
                                    break;
                                case "ReadSpeed":
                                    if (double.TryParse(value, out double readSpeed))
                                    {
                                        ReadSpeed = readSpeed;
                                    }
                                    break;
                                case "WriteSpeed":
                                    if (double.TryParse(value, out double writeSpeed))
                                    {
                                        WriteSpeed = writeSpeed;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Помилка зчитування з файлу: " + ex.Message);
            }
        }
    }
}
