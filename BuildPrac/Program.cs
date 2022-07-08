using System;

namespace BuildPrac
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    //
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class Installer
    {
        private readonly Logger _log;
        public Installer(Logger logger)
        {
            _log = logger;
        }
        public void Install()
        {
            _log.Log("Installing");
        }
    }
    //---
    //
    public class Shipment
    {
        public double Cost { get; set; }
        public DateTime ShipmentDate { get; set; }
    }
    public class Order
    {
        public double TotalPrice { get; set; }
        public DateTime DatePlace { get; set; }
        public Shipment Shipment { get; set; }
    }
    public class ShippingCalculator
    {
 
        
        public double CalculateShipping(Order order)
        {
            double price = order.TotalPrice * .30;
            return price;
        }
    }
    public class OrderProcesor
    {
        private readonly ShippingCalculator _shippingCalculator;
        public OrderProcesor(ShippingCalculator shippingCalculator)
        {
            _shippingCalculator = shippingCalculator;
        }

        public void Process(Order order)
        {
            order.Shipment = new Shipment()
            {
                Cost = _shippingCalculator.CalculateShipping(order),
                ShipmentDate = DateTime.Today
            };
        }
    }
    //---


    public class VideoEncoder
    {
        private readonly MailService _mailService;

        private readonly IList<INotificationChannel> _notificationChannels;
        public VideoEncoder()
        {
            _mailService = new MailService();
            _notificationChannels = new List<INotificationChannel>();

        }
        public void Encode(Video video)
        {

            _mailService.Send(new Mail());

            foreach (var item in _notificationChannels)
            {
                item.Send(new Message());
            }
        }

        public void Register(INotificationChannel notif)
        {

            _notificationChannels.Add(notif);
        }
    }

    public interface INotificationChannel
    {
        public void Send(Message message);
    }
    public class MailNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("Sending Mail");
        }
    }
    public class SmsNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("Sending Sms");
        }
    }
    public class MailService
    {
        public void Send(Mail mail  )
        {
            Console.WriteLine("Sending Mail");
        }
    }
    public class Message
    {

    }

    public class Mail
    {

    }
    public class Video
    {

    }

  
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        public static int count = 0;

        public void RemoveMethod(int index)
        {
            entries.RemoveAt(index);
        }

        public int addMethod(string text)
        {
            Console.WriteLine();
            entries.Add($"{count++}. {text}");

            return count;
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
    public class Persistence
    {
        public void SaveFile(Journal journal, string path, bool isSave = false)
        {
            if (isSave || File.Exists(path) == false)
                File.WriteAllText(path, journal.ToString());
        }
    }
    // ----
    
    public enum Color { Red,Green,Blue};
    public enum Size { Small,Medium,Large };

    public class Product
    {
        public string Name;
        public Color color;
        public Size size;
        public Product(string name, Color color, Size size)
        {
            Name = name;
            this.color = color;
            this.size = size;
        }

    }

    public class FilterProduct
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products, Color color)
        {
            foreach (var item in products)
            {
                if (item.color == color)
                    yield return item; 
            }
        }
    }
   
    public interface IFilter<T>
    {
        IEnumerable<T> FilterProd(IEnumerable<T> items, ISpecification<T> spec);
    }
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> FilterProd(IEnumerable<Product> items,
            ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsValid(item))
                {
                    yield return item;
                }
            }
        }
    }
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public bool IsValid(T t)
        {
            return first.IsValid(t) && second.IsValid(t);
        }
    }
    public interface ISpecification<T>
    {
        bool IsValid(T t);
    }
    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification()
        {

        }
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsValid(Product t)
        {
            return t.color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;
   
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsValid(Product t)
        {
            return t.size == size;
        }
    }


    public class Rectangle
    {
        //public int Width { get; set; }
        //public int Height { get; set; }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        //public new int Width
        //{
        //  set { base.Width = base.Height = value; }
        //}

        //public new int Height
        //{ 
        //  set { base.Width = base.Height = value; }
        //}

        public override int Width // nasty side effects
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
    public partial class Program
    {
        public static int GetVowelCount(string str)
        {
            int vowelCount = 0;

            // Your code here
            for (int i = 0; i < str.Length; i++)
            {
                if (IsVowel(str[i]))
                    vowelCount++;
            }
            return vowelCount;
        }
        public static bool IsVowel(char let)
        {
            return let == 'a' || let == 'e' || let == 'i' || let == 'o' || let == 'u';
        }
        static public int Area(Rectangle r) => r.Width * r.Height;
        public static char getMax(string word)
        {
            int[] fre = new int[256];

            foreach (var item in word.ToCharArray())
            {
                fre[item]++;
            }

            int max = 0;
            char s = ' ';
            for (int i = 0; i < fre.Length; i++)
            {
                if(fre[i] > max)
                {
                    max = fre[i];

                    s = (char)i;
                }
            }
            return s;
        }
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            // Your brilliant solution goes here
            // It's possible to pass random tests in about a second ;)

            return a.Where(w => b.Contains(w) == false).ToArray();
        }

        public static int SumPrimes(int[] arr)
        {
            int total = 0;
            foreach (var item in arr)
            {
                if(IsPrime(item))
                {
                    total += item;
                }
            }
            return total;
        }
        // "-10 2 4 5" => "5 -10"  
        public static string HighLow(string str)
        {
            List<int> toAdd = new List<int>();
            List<string> strSplit = str.Split(' ').ToList();
            foreach (var item in strSplit)
            {
                toAdd.Add(int.Parse(item));
            }

            int min = toAdd[0];
            int max = toAdd[0];
            foreach (var item in toAdd)
            {
                if (item > max)
                    max = item;
                else if (item < min)
                    min = item;
            }
            return max.ToString() + " " + min.ToString();
        }

 
        public static long MinValue(int[] a)
        {
            long num = 0;
            var list = a.Select(w => w).Distinct().OrderBy(w=> w);

            var s = string.Concat(list);
             
            return Convert.ToInt64(s);
        }
   
        public static string Interview(int[] arr, int tot)
        {
            int[] formatTime = { 5, 5, 10, 10, 15, 15, 20, 20 };

            if(tot > 120 || arr.Length < 8)
                return "disqualified";

            if(tot <= 120 && arr.Length < 8)
            {

                for (int i = 0; i < arr.Length-1; i++)
                {
                    if (formatTime[i] < arr[i])
                    {
                        return "qualified";
                    }
                }
            }
            return "disqualified";
        }
        public static bool IsPrime(int n)
        {
            if (n == 1) return false;

            for (int i = 2; i <= n/2; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        public static int FindShort(string s)
        {
            var word = s.Split(' ');
            int max = 0;

            if (string.IsNullOrEmpty(s) == false)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    var min = word.Min(w => w.Length);
                    return min;
                }
            }
            return 0;
        }
        public static int DuplicateCount(string str)
        {
            string textLower = str = str.ToLower();
            List<char> toAdd = new List<char>();
            for (int i = 0; i < textLower.Length; i++)
            {

                char character = str[i];
                int res = i + 1;
                if(toAdd.Contains(character) == false && textLower.IndexOf(character, res) != -1)
                {
                    toAdd.Add(character);
                }
            }
            return toAdd.Count();
        }

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            var first = iterable.First();

            var uniques = new List<T>();

            uniques.Add(first);

            foreach (var item in iterable)
            {
                if (item.Equals(first))
                {
                    continue;
                }
                first = item;
                uniques.Add(item);
            }

            return uniques;
        }
        public static string[] WordSearch(string x, string[] y)
        {
            var list = y.Where(w => w.ToLower().Contains(x.ToLower())).ToArray();

            return list.Length > 0 ? list : new string[] { "Empty" };
        }
        public static IEnumerable<string> OpenOrSenior(int[][] data)
        {
            //your code here
            List<string> toAdd = new List<string>();
            foreach (int[] item in data)
            {
                if (item[0] >= 55 && item[1] > 7)
                    toAdd.Add("Senior");
                else
                    toAdd.Add("Open");
            }
            return toAdd;

        }
        public static bool Scramble(string str1, string str2)
        {
            if (str2.Length > str1.Length) return false;

            for (int i = 0; i < str2.Length; i++)
            {
                var isHave = str1.Contains(str2[i]);
                if (isHave == true)
                {
                    // remove all characters which are not in the str1  
                    str1 = str1.Remove(str1.IndexOf(str2[i]), 1);
                }
                else
                    return false;
            }
            return true;

        }
        public static int VolCo(string word)
        {
            var v = "aeiou";

            return word.ToCharArray().Where(w => v.Contains(w)).Count();
        }
        public static string ToCamelCase(string str)
        {
            string res = "";
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == '-' || str[i] == '_')
                {
                    res += str[i + 1].ToString().ToUpper();
                    i++;
                }
                else
                {
                    res += str[i].ToString();
                }
            }
            return res;
             
        }
        public static int getThirdMax(int[] arr)
        {
            var first = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i] > first)
                {
                    first = arr[i];
                }
            }
            int second = -int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > second && arr[i]< first)
                {
                    second = arr[i];
                }
            }
            int third = -int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > third && arr[i] < second)
                {
                    third = arr[i];
                }
            }
            return third;
        }
       
        public static int getSecond(int[] arr)
        {
            var first = 0;
            var second = 0;
            var third = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > first)
                {
                    second = first;
                    first = arr[i];
                }else if(arr[i] > second)
                {
                    third = second;
                    second = arr[i];
                }else if(arr[i] > third)
                {
                    third = arr[i];
                }
            }
            return third;

        }

        public static string SortChars(string input)
        {
            return new string(input.OrderBy(c => c).ToArray());
        }
        public static int getMaxNum(int[] arr)
        {
            var first = arr.First();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > first)
                    first = arr[i];
            }
            return first;
        }
        public static List<string> Anagrams(string word, List<string> words)
        {
            string orderedWord = new string(word.ToCharArray().OrderBy(c => c).ToArray());

            var sample = SortChars(word);
            var ans = words.Where(w => sample.Equals(SortChars(w))).ToList();
            return ans;
        }

        public static char getMaxChar(string arr)
        {
            int[] fre = new int[256];
            foreach (var item in arr)
            {
                fre[item]++;
            }
            char res = ' ';
            var first = 0;
            for (int i = 0; i < fre.Length; i++)
            {
                if(fre[i]> first)
                {
                    first = fre[i];
                    res = (char)i;
                }
            }
            return res;
        }
        public static string FindFirstNonRepeatingCharacter(string s)
        {
            var charCounter = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var ch in s)
            {
                charCounter[ch.ToString()] =
                    charCounter.ContainsKey(ch.ToString())
                    ? charCounter[ch.ToString()] + 1
                    : 1;
            }

            foreach (var ch in s)
            {
                if (charCounter[ch.ToString()] == 1)
                {
                    return ch.ToString();
                }
            }

            return null;
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            var complement = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
               complement = target - numbers[i];

                var index = 0;

                if (complement > 0 && dict.TryGetValue(complement, out index))
                {
                    var indexRef = index;
                    var iRef = i;

                    return new int[] { index, i };

                }

                if (dict.ContainsKey(numbers[i]) == false)
                {
                    dict.Add(numbers[i], i);
                }
            }

            return null;


        }
        public static bool Anagram(string word)
        {
            int first = word[0];
            int last = word.Length-1;

            while(last > first)
            {
                if (word[first++] != word[last--])
                    return false;
            }
        
            return true;
        }
        public static string letterCapitalization(string word)
        {
            string[] words = word.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0, 1).ToUpper()
                    + words[i].Substring(1).ToLower();
            }
            return string.Join(" ", words);
        }
 
        public static int duplicateCount(string word)
        {
            int count = 0;

            var dup = new List<char>();
            var unique = new List<char>();

            for (int i = 0; i < word.Length; i++)
            {
                if (unique.Contains(word[i]) == false)
                {
                    unique.Add(word[i]);
                }
                else
                {
                    dup.Add(word[i]);
                }
            }

            return dup.Count();
        }
        static (int, int) cons(string words)
        {

            var vowels =  words.Where(w => "AaEeIiOoUu".Contains(w)).Count();
            var conso =  words.Where(w => "bcdfghjklmnpqrstvwxyz".Contains(w)).Count();

            return (vowels, conso);
        }
        static string firstNonRepeatedChar(string words)
        {
            return words.GroupBy(w=> char.ToLower(w))
                
                .Where(e=> e.Count() == 1)
                .Select(q=> q.Key.ToString())
                .DefaultIfEmpty("")
                .First();
                        
        }
        public static string MakeString(string s)
        {
            var split = s.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < split.Length; i++)
            {
               sb.Append(split[i].ToString().First());
            }
            return sb.ToString();
        }
        public static int GetHighestAndItsCount(int[] str)
        {
            var first = str.First();
            int count = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] > first)
                {
                    first = str[i];
                    count = 1;
                }
                else if (str[i] == first)
                {
                    count++;
                }
            }
            return count;
            /*      int count = 0;
                  var max = str.Max();
                  for (int i = 0; i < str.Length; i++)
                  {
                      if (str[i] == max)
                          count++;
                  }
                  return count;*/
        }
        public static char getMaxOccurence(string word)
        {
            char maxOccurence = ' ';
            int[] frequencies = new int[256];

            foreach (var item in word)
            {
                frequencies[item]++;
            }
            int max = 0;
            for (int i = 0; i < frequencies.Length; i++)
            {
                if(frequencies[i] > 0)
                {
                    max = frequencies[i];
                    maxOccurence = (char) i;
                }
            }

            return maxOccurence;
        }
        public static char firstRepeating(string str)
        {
            var firstchar = new HashSet<char>();
            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (firstchar.Contains(c) == true)
                {
                    return c;
                }
                else
                {
                    firstchar.Add(c);
                }
            }
            return '\0';
        }

        public static char firstNonRepeated(string word)
        {
            HashSet<char> toAdd = new HashSet<char>();

            for (int i = 0; i < word.Length; i++)
            {
                if (toAdd.Contains(word[i])==false)
                {
                    return word[i];
                }
                else
                    toAdd.Add(word[i]);
            }
            return ' ';
        }
        public static int fare(int[] first, int[] second, int target)
        {
            int sum = -1;

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    int val = first[i] + second[j];
                    if (target >= val)
                    {
                        sum = val;
                    }
                }
            }

            return sum;
        }
        public static string Likes(string[] name)
        {
            string output = "";
            
            if(name.Length == 0)
            {
                return "no one likes this";
            }else if(name.Length == 1)
            {
                return $"{name[0]} likes this";

            }
            else if(name.Length == 2)
            {
                return $"{name[0]} and {name[1]} like this";

            }
            else if (name.Length == 3)
            {
                return $"{name[0]}, {name[1]} and {name[2]} like this";

            }
            else if(name.Length > 3)
            {
                return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            }

            return output;
        }

        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if(arr[j] < arr[j - 1])
                    {
                       var temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j-1] = temp;
                    }
                }
            }
        }
        public static string ToUnderscore(string str)
        {
            string res = "";

            foreach (var item in str)
            {

                if (char.IsUpper(item))
                {
                    res += "_";
                    res += item.ToString().ToLower();
                }
                else
                {
                    res += item.ToString();
                }
            }
            return res.TrimStart('_');


        }
        public static string ToUnderscore(int str)
        {
            return str.ToString();
        }
        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }
        }

        public class StudentComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                if (x.StudentID == y.StudentID && x.StudentName.ToLower() == y.StudentName.ToLower())
                    return true;

                return false;
            }

            public int GetHashCode(Student obj)
            {
                return obj.StudentID.GetHashCode();
            }
        }
        public static bool ValidParentheses(string input)
        {
            int result = 0;

            if (string.IsNullOrEmpty(input) == false)
            {
                foreach (var item in input)
                {
                    if (result == -1) return false;
                    if (item == '(')
                    {
                        result++;

                    }
                    if (item == ')')
                    {
                        result--;
                    }
                }
            }
           

            return result == 0;
        }
        // *
        public static int Sum(int[] numbers)
        {
            if (numbers == null || numbers.Length < 3) return 0;
            Array.Sort(numbers);
            int sum = 0;
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
        public static string sumStrings(string a, string b)
        {
            if (string.IsNullOrEmpty(a) == true || string.IsNullOrEmpty(b) == true) return "";

            int sum = 0;
            var first = int.Parse(a);
            var sec = int.Parse(b);
            sum = first + sec;

            return Convert.ToString(sum);
        }
        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            var toAdd = new List<int>();
            if(listOfItems != null)
            {
                var notString = listOfItems.Where(w => (w is string) == false);

                var res = notString.Cast<int>();
                foreach (var item in res)
                {
                    toAdd.Add(item);
                }
            }

            return toAdd;
        }

        public static int[] MoveZeroes(int[] arr)
        {
            var first =new List<int>();
            var seco =new List<int>();
            if(arr != null)
            {
                foreach (var item in arr)
                {
                    if (item > 0)
                    {
                        first.Add(item);
                    }
                    else
                    {
                        seco.Add(item);

                    }
                }
                var result = first.ToArray().Concat(seco.ToArray()).ToArray();

                return result;
            }
            return new int[] { };
         }

        public static void Main()
        {
            var obj = new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 };
            var asd = MoveZeroes(obj);
            foreach (var item in asd)
            {
                Console.WriteLine(item);
            }
    
             
            Console.ReadLine();
        }
     
    }
    public static class EM
    {
        public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T val)
        {
            return values.Select((b, i) => Equals(b, val) ? i : -1).Where(i => i != -1).ToArray();
        }
    }
    public static class ListExtener
    {
        public static List<int> FindAllIndexes<T>(this List<T> source, T value)
        {
            return source.Select((item, index) => new { Item = item, Index = index })
                            .Where(v => v.Item.Equals(value))
                            .Select(v => v.Index)
                            .ToList();
        }
    }
    public class StudentTwo
    {
        public int Id { get; set; }
        public string MiddleName { get; set; }
        public string Hobby { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class MyGeneric<T>
    {
        public T genericVariable;

        public MyGeneric(T genericVariable)
        {
            this.genericVariable = genericVariable;
        }

        public T genericMethod(T genericParameter)
        {
            Console.WriteLine($"Parameter Type {typeof(T).ToString()}, value: {genericParameter}");
            Console.WriteLine($"Parameter Type {typeof(T).ToString()}, value: {genericVariable}");


            return genericVariable;
        }
    }
    public class CLsCalculator
    {
        public static bool isEqual<T>(T v1, T v2)
        {
            return v1.Equals(v2);
        }
    }
 

}
