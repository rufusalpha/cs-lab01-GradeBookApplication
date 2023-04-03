using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade( double averageGrade )
        {
            if ( Students.Count < 5 )
            {
                throw new InvalidOperationException("There are min. 5 students req.");
            }

            int thresholdGrade = (int)Math.Ceiling(Students.Count * 0.2);
            var gradesList = Students.OrderByDescending(student => student.AverageGrade).Select(student => student.AverageGrade).ToList();

            if (gradesList[thresholdGrade - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (gradesList[(2 * thresholdGrade) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (gradesList[(3 * thresholdGrade) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (gradesList[(4 * thresholdGrade) - 1] <= averageGrade)
            {
                return 'D';
            }
            else 
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if( Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }
    }
}
