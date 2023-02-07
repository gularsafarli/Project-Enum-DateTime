using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];

            string option;
            do
            {
                Console.WriteLine("1.Yeni qrup yarat");
                Console.WriteLine("2.Qruplara bax");
                Console.WriteLine("3.Type deyerine gore qruplara bax");
                Console.WriteLine("4.Bugunədək baslamıs qruplara bax");
                Console.WriteLine("5.son 2 ayda baslamıs qruplara bax");
                Console.WriteLine("6.bu ayin sonunadek yeni başlayacaq olan qruplara bax");
                Console.WriteLine("7.Verilmiş 2 tarix aralığnda başlamış olan qruplara bax");
                Console.WriteLine("0.Menudan cix");

                Console.WriteLine("Secim et:");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("No daxil edin:");
                        string no = Console.ReadLine();
                        Console.WriteLine("Type daxil edin:");
                        foreach (var item in Enum.GetValues(typeof(GroupTypes)))
                        {
                            Console.WriteLine($" {(byte)item}- {item}");
                        }
                        string typeStr = Console.ReadLine();
                        byte typebyte = Convert.ToByte(typeStr);
                        do
                        {
                            typeStr = Console.ReadLine();
                            typebyte = Convert.ToByte(typeStr);
                        } while (!Enum.IsDefined(typeof(GroupTypes), typebyte));

                        GroupTypes type = (GroupTypes)typebyte;

                        Console.WriteLine("Date elave edin:");
                        string date = Console.ReadLine();
                        DateTime startdate = Convert.ToDateTime(date);
                        Group gr = new Group
                        {
                            No = no,
                            Type = type,
                            StartDate = startdate
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = gr;
                        break;
                    case "2":
                        foreach (var item in groups)
                        {
                            Console.WriteLine($"No:{item.No}- Type:{item.Type}-StartDate:{item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Axtardiginiz type daxil edin:");
                        typeStr = Console.ReadLine();
                        typebyte = Convert.ToByte(typeStr);
                        type = (GroupTypes)typebyte;
                        foreach (var item in groups)
                        {
                            if (item.Type == type)
                            {
                                Console.WriteLine($"No:{item.No}- Type:{item.Type}-StartDate:{item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("Bugunedek baslamis qruplara bax");
                        foreach (var item in groups)
                        {
                            if (item.StartDate < DateTime.Now)
                            {
                                Console.WriteLine($"No:{item.No}- Type:{item.Type}-StartDate:{item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }
                        break;
                    case "5":
                        Console.WriteLine("son 2 ayda baslamıs qruplara bax");
                        foreach (var item in groups)
                        {
                            if (item.StartDate > DateTime.Now.AddMonths(-2))
                            {
                                Console.WriteLine($"No:{item.No}- Type:{item.Type}-StartDate:{item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }
                        break;
                    case "6":
                        Console.WriteLine("Bu ayın sonunadək yeni başlayacaq olan qruplara bax");
                        foreach (var item in groups)
                        {
                            if (item.StartDate.Day >= DateTime.Now.Day && item.StartDate.Month == DateTime.Now.Month && item.StartDate.Year == DateTime.Now.Year)
                            {
                                Console.WriteLine($"No:{item.No}- Type:{item.Type}-StartDate:{item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }
                        break;
                    case "7":
                        Console.WriteLine("Verilmis 2 tarix aralığnda baslamıs olan qruplara bax");
                        Console.WriteLine("Ilk grupu daxil edin:");
                        string firstgroup = Console.ReadLine();
                        DateTime group1 = Convert.ToDateTime(firstgroup);

                        string secondgroup = Console.ReadLine();
                        DateTime group2 = Convert.ToDateTime(secondgroup);
                        foreach (var item in groups)
                        {
                            if (item.StartDate >= group1 && item.StartDate <= group2)
                            {
                                Console.WriteLine($"No:{item.No}- Type:{item.Type}-StartDate:{item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }

                        }
                        break;
                    case "0":
                        Console.WriteLine("Program bitdi!");
                        break;
                    default:
                        Console.WriteLine("Yanlis secim etdiniz");
                        break;
                }


            } while (option != "0");
        }
    }
}
