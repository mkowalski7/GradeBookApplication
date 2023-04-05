using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var totalStudents = Students.Count;
            if (totalStudents < 5)
                throw new InvalidOperationException();
            
            var grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            var gradeIndex = grades.IndexOf(averageGrade);

            if (gradeIndex < totalStudents * 0.2)
                return 'A';
            else if (gradeIndex < totalStudents * 0.4)
                return 'B';
            else if (gradeIndex < totalStudents * 0.6)
                return 'C';
            else if (gradeIndex < totalStudents * 0.8)
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");

            base.CalculateStudentStatistics(name);
        }
    }
}