# AlcolizerAssignment

Assignment | File-based Unit Conversion
An alcohol breath test reading can be displayed in one of several units of measure. The task is to implement a program using the language of your choice to convert between these units of measure.
1. The program reads input data from a file and writes data to a (different) output file.
2. Each line in the input file is composed of three pieces of information separated by a single space: the value and the current unit of measure and the intended unit of measure. For example, “1 g/L ug/100mL”. The program converts the value from the current unit of measure to the intended unit of measure.
3. Foreachlineintheinputfiletheprogrammustwriteacorrespondinglinetotheoutput file containing the converted value and the unit of measure. For example, “100000.000000 ug/100mL”.
4. If a line in the program input contains extra information, is missing the value or unit of measure, or has an unknown unit of measure, the program must output the string
“error” for that particular conversion.
5. An invalid line should not cause the program to abort, all other valid lines must be correctly converted.
6. The input and output files are passed to the application as the first and second parameters respectively.
7. The application name can be anything.
8. Assuming “g/L” to be the “normalised” unit, the following are valid units of measure, including the scale factor to convert from that unit to g/L:
• “ug/100mL”, 100000
• “mg/L”, 1000.0
• “g/210L”, 210.0
• “g/230L”, 230.0
• “g/dL”, 0.1
• “ug/L”, 1000000.0
 
 690355703f57c6c018ad • “g/L”, 1.0
For example, 1 g/L is 100000 ug/100mL.
9. Output value is always printed to 6 decimal places.
10. The program should be able to convert between any two units of measure.
11. Unit tests will be used to assess the application, program output must match exactly the the expected output of the test or the test fails.
2 Examples
The following examples illustrate typical usage:
  Input File
                 1 g/L ug/100mL
                 1 mg/L g/L
                 1 g/230L g/L
Input File
                 1 g/L ug/100mL
                 1 mg/L h/L
                 1 g/230L g/L
3 Submitting
Output File
100000.000000 ug/100mL
0.001000 g/L
0.004348 g/L
Output File
100000.000000 ug/100mL
error
0.004348 g/L
     1. Don’t spend any more than 90 minutes on this task. It is satisfactory to submit an incomplete solution.
2. Submit your code and build instructions (in a single zip file) via email to to ben.davies@alcolizer.com.
3. If an aspect of the program has not been specified, please ask for clarification.
