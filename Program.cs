using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Navch
{
    class Program
    {
        static void Main(string[] args)
        {
            Group PMI = new Group();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            PMI.Add(new Student("Вермій", "Володимир", "Чоловіча", "8/7/1999"));
            PMI.Add(new Student("Корняк", "Ірина", "Жіноча", "8/7/1999"));
            PMI.Add(new Student("Химера", "Богдан", "Чоловіча", "1/5/1999"));
            PMI.Add(new Student("Ярема", "Юліан", "Чоловіча", "2/1/1999"));
            PMI.Add(new Student("Анчіфоров", "Ілля", "Чоловіча", "8/9/1998"));
            PMI.Add(new Student("Корпецька", "Марта", "Жіноча", "5/8/1998"));
            PMI.Add(new Student("Кугівчак", "Володимир", "Чоловіча", "9/1/1999"));
            PMI.Add(new Student("Йовбак", "Андріана", "Жіноча", "8/9/2001"));
            PMI.Add(new Student("Оліщук", "Іван", "Чоловіча", "1/5/1999"));
            PMI.Add(new Graduate("Гузій", "Володимир", "Чоловіча", "6/5/1999", "Доцент"));
            PMI.Add(new Student("Петровський", "Богдан", "Чоловіча", "9/1/1999"));
            PMI.Add(new Student("Медицький", "Олександр", "Чоловіча", "1/2/1999"));
            PMI.Add(new Student("Хорощак", "Валентин", "Чоловіча", "8/1/1999"));
            PMI.Add(new Student("Сорока", "Марія", "Жіноча", "2/3/1999"));
            PMI.Add(new Student("Сачко", "Антон", "Чоловіча", " 3/9/1999"));
            PMI.Add(new Student("Кріль", "Остап", "Чоловіча", "4/8/1999"));
            PMI.Add(new Student("Дель-Соль", "Арсен", "Чоловіча", "3/1/1998"));
            PMI.Add(new Student("Дмитрик", "Оля", "Жіноча", "3/8/1999"));
            PMI.Add(new Graduate("Гутій", "Таня", "Жіноча", "6/5/1999", "Бакалавр"));

            PMI.displayGroup();

            Console.WriteLine("**GIRLS:**");

            var girls = from g in PMI
                        where g.Gender == "Жіноча" && g.NumerOfYears > 16
                        orderby g.NumerOfYears
                        select g;
            foreach (var girl in girls)
            {
                Console.WriteLine(girl);
            }
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("Enter students surname:");
                string surname = Console.ReadLine();
                if(!PMI.DeleteStudet(surname))
                {
                    Console.WriteLine("cant find such student");
                }
            }
        }         
    }
}