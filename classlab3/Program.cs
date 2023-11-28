using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classlab3
{
    class Program
    {
        //        Написать класс – одномерный массив целых чисел.Учитывая следующие
        //рекомендации:
        //- создайте метод конструктор (), внутри которого будут определен один параметр: размер
        //массива. Начальные значения свойства берутся из входных параметров метода.
        //-создайте метод InputData позволяющий задать данные массива пользователем         +
        //            -
        //создайте метод InputDataRandom заполняющий массив с помощью датчика           +
        //случайных чисел
        //-
        //создайте метод print() – вывод на экран содержимого массив из указанного      +
        //диапазона индексов
        //-
        //создайте метод FindValue - который возвращает список индексов для искомого        +
        //элемента
        //-
        //создайте метод DelValue - который удаляет из массива (искомый элемент в           +
        //массиве может встречаться несколько раз) искомый элемент.
        //-
        //создайте метод FindMax- который возвращает максимальное значение из массива.      +
        //-
        //создайте метод Add который выполняет сложение двух массивов одинаковой        +
        //длины поэлементно
        //- создайте метод Sort который выполняет сортировку элементов массива по возрастанию.          +
        //Замечание – использование класса Array - запрещено
        //Замечание - при реализации методов класса необходимо использовать модификаторы ref,
        //in, out


        public class IntArray
        {
            int[] data { get; set; }
            public int Length { get;set; }

            public IntArray( in int num)
            {
                this.Length = num;

                data = new int[num];
            }

            public void InputData(in int[] arr)
            {

                for (int i = 0; i < this.Length; i++)
                {
                    data[i] = arr[i];
                }

            }

            public void InputDataRandom()
            {

                Random rnd = new Random();

                for (int i = 0; i < this.Length; i++)
                {
                    data[i] = rnd.Next(0,100);
                }

            }

            public void Print(in int ind1, in int ind2)
            {

                Console.WriteLine();

                for (int i = ind1-1; i < ind2; i++)
                {
                    Console.Write("{0} ", data[i]);
                }

            }

            public int[] FindValue(in int value)
            {

                List<int> nums = new List<int>();

                for (int i = 0; i < this.Length; i++)
                {
                    if (data[i] == value) nums.Add(i);
                }

                return nums.ToArray();

            }


            void arr_copy(in int[] source, out int[] destin)
            {

                destin = new int[source.Length];

                for (int j = 0; j < destin.Length; j++) { destin[j] = source[j]; }

            }

            void data_copy(in int[] source)
            {

                data = new int[source.Length];

                for (int j = 0; j < data.Length; j++) { data[j] = source[j]; }

            }


            public void DelValue( int value)
            {

                int[] nums=new int[0]; arr_copy(data, out nums); int[] buf;

                int diff=0;


                    arr_copy(nums, out buf);

                while (FindInarr(buf, value,buf.Length-diff)) 
                {
                    for (int j = 0; j < buf.Length-diff; j++)
                    {
                        if (buf[j] == value)
                        {

                            for (int k = j + 1; k < buf.Length-diff; k++) { buf[k - 1] = buf[k]; }
                            diff++;

                        }
                    }

                }

                nums = new int[nums.Length - diff];
                for (int j = 0; j < nums.Length; j++) { nums[j] = buf[j]; }

                data_copy(nums);
                Length -= diff;

            }

            bool FindInarr(in int[] values, int value, int eofdiapason) 
            {

                for(int k =0;k<eofdiapason;k++) { if (values[k] == value) return true; }
                return false;
            }

            public int FindMax()
            {
                int max = int.MinValue;
                foreach (int el in data) { if (el > max) max = el; }

                return max;
            }

            public void Add(in int[] data2)
            {
                int[] resdata = new int[Length];

                for (int i = 0; i < Length; i++)
                {
                    resdata[i] = data[i] + data2[i];
                }
                data = resdata;
            }

            public int[] Sort()
            {
                int[] nums; arr_copy(data, out nums);

                for (int i = 0; i < nums.Length; i++)
                {

                    for (int j = i+1; j < nums.Length; j++)
                    {

                        if (nums[j] < nums[i]) { int buf = nums[i]; nums[i] = nums[j]; nums[j] = buf; }

                    }

                }

                return nums;
            }


        }

        static void Main(string[] args)
        {
            visual_menu();

            IntArray arr=null;
            string buf; bool run = true;
            int buf2;

            while (run)
            {
                Console.WriteLine();
                buf = Console.ReadLine();
                Console.WriteLine();

                switch (int.Parse(buf))
                {
                    case 1:
                        
                        Console.WriteLine("Введите размер массива:  ");
                        buf2 = int.Parse(Console.ReadLine());

                        arr = new IntArray(buf2);

                        break;

                    case 2:
                        int[] bufarr;

                        Console.WriteLine("Введите массив:  ");
                        bufarr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                        arr.InputData(bufarr);

                        break;

                    case 3:

                        arr.InputDataRandom();

                        break;

                    case 4:
                         int[] indexes;

                        Console.WriteLine("Введите элемент для поиска:  ");
                        buf2 = int.Parse(Console.ReadLine());

                        indexes = arr.FindValue(buf2);

                        Console.WriteLine("Номера вхождения выбранного элемента в массив:  ");
                        foreach (int el in indexes) { Console.WriteLine("{0} ", el+1); }

                        break;

                    case 5:
                        
                        Console.WriteLine("Введите элемент для удаления:  ");
                        buf2 = int.Parse(Console.ReadLine());

                        arr.DelValue(buf2);

                        break;

                    case 6:

                        buf2 = arr.FindMax();

                        Console.WriteLine("Максимальный элемент в массиве :  {0}", buf2);

                        break;

                    case 7:

                        int[] secondarr;

                        Console.WriteLine("Введите второй массив:  ");
                        secondarr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                        if (secondarr.Length != arr.Length) Console.WriteLine("Длины массивов не совпадают!  ");

                        else arr.Add(secondarr);

                        break;

                    case 8:

                        int[] sortedarr;

                        sortedarr = arr.Sort();

                        Console.WriteLine("Сортированный массив:  ");
                        foreach (int el in sortedarr) { Console.Write("{0} ", el); }

                        break;

                    case 9:

                        int[] inds;

                        Console.WriteLine("Введите начальный и конечный номера для печати в массиве:  ");
                        inds = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                        Console.WriteLine("Выбранный сегмент массива:  ");
                        arr.Print(inds[0],inds[1]);

                        break;

                    case 0:
                        run = false;
                        break;
                }



            }



        }

        static public void visual_menu()
        {
            Console.WriteLine("Функции работы с одномерным массивом:\n 1.Создать массив\n 2.Ввести данные\n 3.Сгенерировать случайные данные\n 4.Вывести индексы элемента в массиве\n 5.Удалить все вхождения элемента в массив \n 6.Найти максимальный элемент в массиве\n 7.Сложить 2 массива\n 8.Сортировать массив по возрастанию\n 9.Печать сегмента массива\n 0.Выход\n");
        }

    }
}
