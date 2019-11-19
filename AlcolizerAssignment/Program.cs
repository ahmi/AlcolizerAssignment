using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlcolizerAssignment
{
    class AlcolizerTest
    {
        private readonly string inputFile;
        private readonly string outputFile;

        //Constructor to initialise 
        public AlcolizerTest(string inFile = "input.txt", string outFile = "output.txt")
        {
            inputFile = inFile;
            outputFile = outFile;
        }
        //Fetch data from input file,
        //store in array,
        //every index has one line
        //every line contains 3 values (i-e 1 g/L ug/100mL)
        private string[] readInputFile(string inFile)
        {
            try
            {
                StreamReader sr = File.OpenText(inFile);
                Console.WriteLine("The first line of this file is {sr.ReadLine()}");
                string[] lines = File.ReadAllLines(inFile, Encoding.UTF8);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                return lines;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file was not found: {e}: " + e);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The directory was not found: '{e}'" + e);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be opened: '{e}'" + e);
            }
            return new string[0];
        }

        //Write output to file
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
        private void writeOutPutFile(List<string> data_output)
        {
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                //Write the Out file with converted values and errors
                foreach (string line in data_output)
                    sw.Write(line + "\n");
            }
        }
        //Check if unit format is correct
        private bool acceptableFormats(string format = "")
        {
            //Only the following Input/OutPut formats are accepted
            string[] allowedFormats = { "ug/100mL","g/L", "mg/L","g/210L", "g/230L",
                                "g/dL", "ug/L" };
            return allowedFormats.Contains(format);

        }
        //Check if string contains a double/int value
        //https://docs.microsoft.com/en-us/dotnet/api/system.convert.todouble?view=netframework-4.8#System_Convert_ToDouble_System_String_
        private bool isAnInteger(string numberAsString)
        {
            double result = 0.0;
            try
            {
                result = Convert.ToDouble(numberAsString);
                Console.WriteLine("Converted '{0}' to {1}.", numberAsString, result);
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}' to a Double.", numberAsString);
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is outside the range of a Double.", numberAsString);
            }
            return false;
        }
        private string ConvertToOtherUnit(double inputQty, string inputFormat, string outputFormat)
        {

            var waitArray = new Dictionary<string, Double>();
            waitArray.Add("ug/100mL", 100000);
            waitArray.Add("g/L", 1.0);
            waitArray.Add("mg/L", 1000.0);
            waitArray.Add("g/210L", 210.0);
            waitArray.Add("g/230L", 230.0);
            waitArray.Add("g/dL", 0.1);
            waitArray.Add("ug/L", 1000000.0);

            //First Get the input unit weight
            //For Example: user gives 1 mg/L as input
            //this line will convert it to 1/1000 to unify it 
            var equivalentWeight = inputQty / waitArray[inputFormat];
            // Now multiply equivalentWeight to output format value like convert g/L to mg/L
            var outputWeight = equivalentWeight * waitArray[outputFormat];
            // Convert output value to 6 decimal places as per requirement.
            // For example: will convert 100.09 to 100.090000
            //return (inputQty.ToString("0.######"), outputWeight) + " " + outputFormat;
            return outputWeight.ToString("0.######") + " " + outputFormat;
        }

        /*
        * The method reads file
        * Convert each row from file to inputqty, inputformat, outputformat
        * Converts inputqty to given output format qty
        * Sends Error if invalid file/data
        * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
        * 
        */

        public void convert()
        {
            //Read Input File
            var inputStream = this.readInputFile(this.inputFile);
            List<string> outputArray = new List<string>();
            if (inputStream.Length > 0)
            {
                foreach (var input in inputStream)
                {
                    string[] inputUnits = input.Split(' ');
                    if (inputUnits.Length == 3)
                    {
                        var inputQty = inputUnits[0];
                        var inputFormat = inputUnits[1];
                        var outPutFormat = inputUnits[2];
                        if (inputStream.Length > 0)
                        {
                            if (this.isAnInteger(inputQty) && this.acceptableFormats(inputFormat) && this.acceptableFormats(outPutFormat))
                            {
                                double val = Convert.ToDouble(inputQty);
                                outputArray.Add(ConvertToOtherUnit(val, inputFormat, outPutFormat));
                            }    
                            else
                            {
                                outputArray.Add("Error");
                            }
                        }
                    }
                }
            }
            else {
                Console.WriteLine("Invalid/No data in input file");
            }
            Console.WriteLine(string.Join(",", outputArray));
            //passing array of formatted strings to function to write in output file
            this.writeOutPutFile(outputArray);
        }
    }
    // Main Program,. entry point
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
#warning Please copy/paste input.txt, output.txt path in variables below
            string inputFilePath = "/Users/admin/Projects/AlcolizerAssignment/AlcolizerAssignment/files/input.txt";
            string outFilePath = "/Users/admin/Projects/AlcolizerAssignment/AlcolizerAssignment/files/output.txt";
            AlcolizerTest obj = new AlcolizerTest(inputFilePath, outFilePath);
            obj.convert();
        }

    }
}