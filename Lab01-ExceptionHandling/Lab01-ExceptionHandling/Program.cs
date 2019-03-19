using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Lab01_ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //run program
                StartSequence();
               
            }
            //general catch
            catch (Exception e)
            {
                Console.WriteLine("oops, your broke the program!", e.Message);
            }
            //run no matter what
            finally
            {
                Console.WriteLine("The Program is complete");
            }
        }
        static void StartSequence()
        {
            try
            {
                int product;
                int chosenNumber;
                //request user input
                Console.WriteLine("Please enter a number greater than 0, this will be the size of your array");
                //store inout to chosenNumber
                chosenNumber = Convert.ToInt32(Console.ReadLine());
                //make new array and the size the user input
                int[] arrayInstance = new int[chosenNumber];
                //call the populate method
                Console.WriteLine(Populate(arrayInstance));
                //get sum
                Console.WriteLine(Sum(arrayInstance));
                //getProduct
                product = (GetProduct(arrayInstance, Sum(arrayInstance)));
                //stores product func result to pass as argument
                Console.WriteLine(product);


                //get Quotient
                Console.WriteLine(GetQuotient(product));
            }
            //if incorrect format tell user
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);

            }
            //if overflow catch and tell user
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
        static int[] Populate(int[] array)
        {

            //for each index in array
            for (int i = 1; i <=array.Length -1; i++)
            {
                //request input i want to make the "/6" display the actual selected number but no global variables?
                Console.WriteLine($"please enter a number {i}/6");
                //store raw input (string)
                string input = Console.ReadLine();
                //store int in index position
                array[i] = Convert.ToInt32(input);
            }
            //return inputed array
            Console.WriteLine($"The array you've created looks like :");
            //got idea from stackoverflow
            foreach  (int val in array)
            {
                Console.WriteLine(val.ToString());
            }
            return array;
        }
        static int Sum (int[] array)
        {
            int sum;
            //calc sum
            sum = array.Sum();
            //return sum
            return sum;
            
        }
        static int GetProduct(int[] array, int sum)
        {
            try
            {
                int product;
                //ask for input
                Console.WriteLine("please enter a random number between 1 and the chosen length of your array to calculate your product");
                //save raw input
                string input = Console.ReadLine();
                //convert raw input to int
                int randomInt = Convert.ToInt32(input);
                //calc and return
                product = randomInt * sum;
                return product;
            }
            //xatch index exception
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;

            }
        }
        static decimal GetQuotient(int product)
        {
            try
            {
                decimal solution;
                Console.WriteLine($"pick a number to divide by your product:{product}");
                //save input
                string ans = Console.ReadLine();
                //convert input
                decimal input = Convert.ToDecimal(ans);
                //return input
                solution = decimal.Divide(product, input);
                return solution;
            }
            //catch exception
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        

        
    }
}
