using GradingSystem;
using System;


// Main entry point for the Grading System application.
try
{
    // Initializing the processor for student results
    var processor = new StudentResultProcessor();

    // these file names can be changed as needed
    string inputFile = "students.txt";
    string outputFile = "report.txt";

    // Processing of data
    var students = processor.ReadStudentsFromFile(inputFile);
    processor.WriteReportToFile(students, outputFile);

    Console.WriteLine($"Successfully processed {students.Count} students. Report saved to {outputFile}");
}
// Catching specific exceptions for better error handling
catch (FormatException ex)
{
    Console.WriteLine($"Error: Invalid data format - {ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Error: Access denied - {ex.Message}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Error: Input file not found - {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}