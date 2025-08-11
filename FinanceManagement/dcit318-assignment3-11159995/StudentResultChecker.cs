using System;
using System.Collections.Generic;
using System.IO;
using GradingSystem.Exceptions;
using GradingSystem.Models;

namespace GradingSystem
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using var reader = new StreamReader(inputFilePath);
            int lineNumber = 0;

            while (!reader.EndOfStream)
            {
                lineNumber++;
                string? line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                try
                {
                    string[] fields = line.Split(',');
                    if (fields.Length != 3)
                        throw new Exceptions.MissingFieldException($"Line {lineNumber}: Expected 3 fields, got {fields.Length}"); //added Exception to fix error

                    if (!int.TryParse(fields[0], out int id))
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format");

                    if (!int.TryParse(fields[2], out int score))
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid score format");

                    students.Add(new Student(id, fields[1].Trim(), score));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Skipping line {lineNumber}: {ex.Message}");
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using var writer = new StreamWriter(outputFilePath);
            foreach (var student in students)
            {
                writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
            }
        }
    }
}