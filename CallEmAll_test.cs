using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaxDiffApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            try
            {
                Console.WriteLine("Please insert no. of elements in array");
                int _count;
                if (int.TryParse(Console.ReadLine(), out _count))
                {
                    // accepting only number inputs for array size
                    char[] _elements = new char[_count];
                    Console.WriteLine("Insert elements into array");
                    for (int i = 0; i < _count; i++)
                    {
                        // storing each character in array in lowercase so to avoid any mistakes in difference calculation
                        _elements[i] = Convert.ToChar(Console.ReadLine().ToLower());
                        Console.WriteLine("[{0}]", string.Join(", ", _elements));
                    }
                    Console.WriteLine("Max Difference is : " + p.MaxDiff(_elements));
                    Console.ReadKey(); 
                }
                else
                {
                    Console.WriteLine("Invalid input, Enter only number");
                    Console.ReadLine();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }


        /// <summary>
        /// To find difference between the Minimum and Maximum no of characters in array
        /// and Max character should be present before minimum in array
        /// Max character = Highest order of character in alphabetical order present in array
        /// Min character = Lowest order of character in alphabetical order present in array
        /// </summary>
        /// <param name="elements"></param>
        /// <returns>Difference between the minimum and maximum characters in array</returns>
        private int MaxDiff(char[] elements)
        {
            // Initial difference as 0 and assuming the minimum character is at 1st position
            int _diff = 0;
            int _min_element = 0;
            // Traversing the array considering the next character as max char
            for (int i = 1; i < elements.Length; i++)
            {
                if (Convert.ToInt32(elements[i]) > Convert.ToInt32(elements[_min_element]) && Convert.ToInt32(elements[i]) - Convert.ToInt32(elements[_min_element]) > _diff)
                    // If Difference between the next character and minimum character is greater than pervious, update the difference
                    _diff = Convert.ToInt32(elements[i]) - Convert.ToInt32(elements[_min_element]);
                else if (elements[_min_element] > elements[i])
                    // If the next character is smaller i.e. comes before in array as well as in alphabetical order update the minimum character
                    _min_element = i;
            }
            //returning the difference between max and min characters
            return _diff - 1;  
        }
    }
	
}
