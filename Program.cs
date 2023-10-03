using Memory_strg;
using Price_list;

Price_list.Price_list pr1 = new Price_list.Price_list();
Price_list.Price_list pr2 = new Price_list.Price_list();
Memory_storages hdd1 = new HDD("1", "11", "111", 2, 13.3, 8, 155); pr1.AddStorage(hdd1);
Memory_storages hdd2 = new HDD(); pr1.AddStorage(hdd2);
Memory_storages hdd3 = new HDD(); pr1.AddStorage(hdd3);

Memory_storages dvd1 = new DVD(); pr1.AddStorage(dvd1);
Memory_storages dvd2 = new DVD(); pr1.AddStorage(dvd2);
Memory_storages dvd3 = new DVD("2", "22", "2222", 1, 13.3, 8, 2000); pr2.AddStorage(dvd3);

Memory_storages f1 = new Flash(); pr2.AddStorage(f1);
Memory_storages f2 = new Flash(); pr2.AddStorage(f2);
Memory_storages f3 = new Flash(); pr2.AddStorage(f3);

pr1.Info();
pr2.Info();

pr1.DelStorage();
pr1.Info();
pr2.EditStorage(0);

pr2.Search();
pr1.Info();
pr2.Info();

pr1.List[0].Info();
pr1.List[1].Info();
pr1.List[0].SaveFile();
pr1.List[1].LoadFile("H.txt");
pr1.List[1].LoadFile("HDD.txt");
pr1.List[1].Info();
