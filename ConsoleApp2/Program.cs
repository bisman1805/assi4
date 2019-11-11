using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class A4
    {
        /*<This method calculates the average of the list provided as the parameter>
        ,<Parameters: <List<double> numbers>,bool flag>
        ,<This method returns the average in double return type>*/
        public static double CalculateAverage(List<double> numbers, bool flag)
        {
            double sum = CalculateSum(numbers, flag);   //calculates the sum of all the numbers
            int count = 0;  //use counter for checking the number of elements in the list
            for (int i = 0; i < numbers.Count; i++) //iterating through the list
            {
                if (flag || numbers[i] >= 0)
                {
                    count++;    //if number is greater then 0 then increment counter
                }
            }
            if (count == 0)     //if no elements exist in list
            {
                throw new ArgumentException("no values are > 0");
            }
            return sum / count;     //returns the average in double return type
        }
        /*<This method calculates the sum of all the numbers in the list provided as the parameter>
        ,<Parameters: <List<double> numbers>,bool flag>
        ,<This method returns the sum in double return type>*/
        public static double CalculateSum(List<double> numbers, bool flag)
        {
            if (numbers.Count < 0)      //if no elements exist in the list
            {
                throw new ArgumentException("x cannot be empty");   //throw exception
            }

            double sum = 0.0;   //initialize sum to 0
            foreach (double val in numbers)     //iterate through the whole list
            {
                if (flag || val >= 0)
                {
                    sum += val;     //if the value is not 0 then add flag is true then keep adding the sum
                }
            }
            return sum;     //returns the sum in double return type
        }
        /*<This method calculates the median of all the numbers in the list provided as the parameter>
        ,<Parameters: <List<double> numbers>>
        ,<This method returns the median in double return type>*/
        public static double CalculateMedian(List<double> numbers)
        {
            if (numbers.Count == 0) //if no elements exist in the list
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }

            numbers.Sort();     //sort the numbers for calculating the median

            double median = numbers[numbers.Count / 2];     //initialize median to the center element of the list
            if (numbers.Count % 2 == 0)             //in case the total number of elements is evem
                median = (numbers[numbers.Count / 2] + numbers[numbers.Count / 2 - 1]) / 2;

            return median;
        }
        /*<This method calculates the median of all the numbers in the list provided as the parameter>
        ,<Parameters: <List<double> numbers>>
        ,<This method returns the Standard Deviation in double return type>*/
        public static double StandardDeviation(List<double> numbers)
        {
            if (numbers.Count <= 1)     //check if the size of array is less than or equal to 1
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int size = numbers.Count;       //take the size of the list to iterate
            double variance = 0;
            double mean = CalculateAverage(numbers, true);  //calculating the mean/average of the list of numbers

            for (int i = 0; i < size; i++)      //iterating through the whole list
            {
                double value = numbers[i];      //take a temp variable and assign the value of numbers[i] to it
                variance += Math.Pow(value - mean, 2);  //take variance using its formula
            }
            double standarddev = Math.Sqrt(variance / (size - 1));       //calculating standard deviation using its formula
            return standarddev;   //return standard deviation
        }


        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {


            List<Double> testDataD = new List<Double> { 4, 7, 6.2, 117.5, 320.2, 1.1 };

            Console.WriteLine("The sum of the array = {0}", CalculateSum(testDataD, true));

            Console.WriteLine("The average of the array = {0}", CalculateAverage(testDataD, true));

            Console.WriteLine("The median value of the Double data set = {0}", CalculateMedian(testDataD));

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", StandardDeviation(testDataD));
        }
    }
}
