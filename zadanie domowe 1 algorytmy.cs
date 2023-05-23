using System;

namespace dryNOVO
{
    public class Program
    {
        public static string ProsteWstawianie(string text)
        {
            char[] keys = text.ToCharArray();

            for (int i = 1; i < keys.Length; i++)
            {
                char key = keys[i];
                int j = i - 1;

                while (j >= 0 && keys[j] > key)
                {
                    keys[j + 1] = keys[j];
                    j--;
                }

                keys[j + 1] = key;
            }

            return new string(keys);
        }

        public static string WstawianiePolowkowe(string text)
        {
            char[] keys = text.ToCharArray();

            for (int i = 1; i < keys.Length; i++)
            {
                char key = keys[i];
                int lewo = 0;
                int prawo = i-1;

                while (lewo <= prawo)
                {
                    int srednia = (lewo + prawo) / 2;

                    if (keys[srednia] > key) {
                        prawo = srednia - 1;
                    } else {
                        lewo = srednia + 1;
					}
                }

                for (int j = i-1; j >= lewo; j--)
                    keys[j+1] = keys[j];

                keys[lewo] = key;
            }

            return new string(keys);
        }

        public static string ProsteWybieranie(string text)
        {
            char[] keys = text.ToCharArray();

            for (int i = 0; i < keys.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < keys.Length; j++)
                {
                    if (keys[j] < keys[minIndex])
                        minIndex = j;
                }

                (keys[minIndex], keys[i]) = (keys[i], keys[minIndex]);
            }

            return new string(keys);
        }

        public static string SortowanieBabelkowe(string text)
        {
            char[] keys = text.ToCharArray();
            bool zamienione;

            for (int i = 0; i < keys.Length - 1; i++)
            {
                zamienione = false;

                for (int j = 0; j < keys.Length - i - 1; j++)
                {
                    if (keys[j] > keys[j + 1])
                    {
                        (keys[j + 1], keys[j]) = (keys[j], keys[j + 1]);
                        zamienione = true;
                    }
                }

                if (!zamienione)
                    break;
            }

            return new string(keys);
        }

        public static string SortowanieKoktailowe(string text)
        {
            char[] keys = text.ToCharArray();
            bool zamienione;

            int start = 0;
            int end = keys.Length - 1;

            while (start < end)
            {
                zamienione = false;

                for (int i = start; i < end; i++)
                {
                    if (keys[i] > keys[i + 1])
                    {
                        (keys[i + 1], keys[i]) = (keys[i], keys[i + 1]);
                        zamienione = true;
                    }
                }

                if (!zamienione)
                    break;

                end--;

                for (int i = end - 1; i >= start; i--)
                {
                    if (keys[i] > keys[i + 1])
                    {
                        (keys[i + 1], keys[i]) = (keys[i], keys[i + 1]);
                        zamienione = true;
                    }
                }

                if (!zamienione)
                    break;

                start++;
            }

            return new string(keys);
        }

        public static string SzybkieSortowanie(string text)
        {
            char[] keys = text.ToCharArray();
            SzybieSortowanieR(keys, 0, keys.Length - 1);
            return new string(keys);
        }

        public static void SzybieSortowanieR(char[] keys, int left, int right)
        {
            if (left < right)
            {
                int index = SzybkieSortowanieM(keys, left, right);
                SzybieSortowanieR(keys, left, index - 1);
                SzybieSortowanieR(keys, index + 1, right);
            }
        }

        public static int SzybkieSortowanieM(char[] keys, int left, int right)
        {
            char temp = keys[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (keys[j] <= temp)
                {
                    i++;
                (keys[j], keys[i]) = (keys[i], keys[j]);
            }
        }

            (keys[right], keys[i + 1]) = (keys[i + 1], keys[right]);
            return i + 1;
        }

        public static string StogoweSortowanie(string text)
        {
            char[] keys = text.ToCharArray();
            int n = keys.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Stog(keys, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                (keys[i], keys[0]) = (keys[0], keys[i]);
                Stog(keys, i, 0);
            }

            return new string(keys);
        }

        public static void Stog(char[] keys, int n, int i)
        {
            int najwiekszy = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && keys[left] > keys[najwiekszy])
                najwiekszy = left;

            if (right < n && keys[right] > keys[najwiekszy])
                najwiekszy = right;

            if (najwiekszy != i)
            {
                (keys[najwiekszy], keys[i]) = (keys[i], keys[najwiekszy]);
                Stog(keys, n, najwiekszy);
            }
        }

		public static void Main()
        {
            string text = "";

			Console.WriteLine("wprowadz tekst: ");
			text = Console.ReadLine();

            Console.WriteLine("sortowanie przez proste wstawianie:");
            Console.WriteLine(ProsteWstawianie(text));

            Console.WriteLine("Sortowanie przez wstawianie połówkowe:");
            Console.WriteLine(WstawianiePolowkowe(text));

            Console.WriteLine("Sortowanie przez proste wybieranie:");
            Console.WriteLine(ProsteWybieranie(text));

            Console.WriteLine("Sortowanie bąbelkowe:");
            Console.WriteLine(SortowanieBabelkowe(text));

            Console.WriteLine("Sortowanie koktajlowe:");
            Console.WriteLine(SortowanieKoktailowe(text));

            Console.WriteLine("Sortowanie szybkie:");
            Console.WriteLine(SzybkieSortowanie(text));

            Console.WriteLine("Sortowanie stogowe:");
            Console.WriteLine(StogoweSortowanie(text));

            Console.ReadKey();
        }
    }
}
