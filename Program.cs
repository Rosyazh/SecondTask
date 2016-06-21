using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Practice: Customize Student class using various types of statements and parameters.
*/

namespace SecondTask
{
    public class Student
    {
        public string name;
        public string surname;
        public int age;
        public Mark[] marks;
        //Show average of all marks.
        public double GetAvgMark()
        {
            int amount = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                amount += marks[i].subjectMark;
            }
            return amount / (double)marks.Length;
        }
        //Reset all marks.
        public void ResetAllMarks(int reset = 0)
        {
            for (int i = 0; i < marks.Length; i++)
            {
                marks[i].subjectMark = reset;
            }
        }
        //Replacement the selected subject to another subject (Math|10).
        public void Replace(int num, string name, int mark)
        {
                marks[num - 1].subjectName = name;
                marks[num - 1].subjectMark = mark;
        }
        //Exchange of names between the first and last subjects.
        public void Exchange(ref string firstMark, ref string lastMark)
        {
            string str = firstMark;
            firstMark = lastMark;
            lastMark = str;
        }
        //The maximum and minimum marks.
        public void MinAndMaxMarks(out int _min, out int _max)
        {
            _min = marks[0].subjectMark;
            _max = marks[0].subjectMark;
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i].subjectMark < _min)
                    _min = marks[i].subjectMark;
                if (marks[i].subjectMark > _max)
                    _max = marks[i].subjectMark;
            }
        }
        //Replacement of marks of the first two subjects (1 and 2).
        public void ChangeMarks(params int[] _marks)
        {
            for (int i = 0; i < _marks.Length; i++)
            {
                marks[i].subjectMark = _marks[i];
            }
        }
        //Student's data input.
        public void ScanStudentData()
        {
            Console.WriteLine("Enter the name of the student: ");
            name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter the surname of the student: ");
            surname = Convert.ToString(Console.ReadLine());
            vvodage:
            Console.WriteLine("Enter the age of the student: ");
            age = Convert.ToInt32(Console.ReadLine());
            if (age < 16)
            {
                Console.WriteLine("You are too young for the student.");
                goto vvodage;
            }
            else if (age > 100)
            {
                Console.WriteLine("Maybe, you made a mistake, when you specify the age.");
                goto vvodage;
            }
            else
            {
                Console.WriteLine("The age is correct.");
            }
        }
        //Student's marks input.
        public void ScanMarksData()
        {
            int number;
            Console.WriteLine("Enter the number of subjects: ");
            number = Convert.ToInt32(Console.ReadLine());

            marks = new Mark[number];
            for (int i = 0; i < number; i++)
            {
                marks[i] = new Mark();
                Console.WriteLine("Enter the name of the subject: ");
                marks[i].subjectName = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter the mark of the subject: ");
                marks[i].subjectMark = Convert.ToInt32(Console.ReadLine());
            }
        }
        //Show data.
        public void PrintData()
        {
            Console.WriteLine("The student's name: " + name);
            Console.WriteLine("The student's surname: " + surname);
            Console.WriteLine("The student's age: " + age);
            if (marks == null)
                throw new ArgumentNullException("marks");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("The name of the subject: " + marks[i].subjectName);
                Console.WriteLine("The mark of the subject: " + marks[i].subjectMark);
            }
        }
    }

    public class Mark
    {
        public string subjectName;
        public int subjectMark;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            Student firstStudent = new Student();
            while (choice != 10)
            {
                Console.WriteLine("Menu: \n1.Student's data input. \n2.Student's marks input. \n3.Show data. \n4.Show average of all marks. \n5.Reset all marks. \n6. Exchange of names between the first and last subjects. \n7.The maximum and minimum marks. \n8.Replacement the selected subject to another subject (Math|10). \n9.Replacement of marks of the first two subjects (1 and 2). \n10.Exit.");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        firstStudent.ScanStudentData();
                        break;
                    case 2:
                        firstStudent.ScanMarksData();
                        break;
                    case 3:
                        try
                        {
                            firstStudent.PrintData();
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine("Marks haven't been added.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("The average of all marks: " + firstStudent.GetAvgMark());
                        break;
                    case 5:
                        firstStudent.ResetAllMarks();
                        break;
                    case 6:
                        string x = firstStudent.marks[0].subjectName;
                        string y = firstStudent.marks[firstStudent.marks.Length - 1].subjectName;
                        firstStudent.Exchange(ref x, ref y);
                        firstStudent.marks[0].subjectName = x;
                        firstStudent.marks[firstStudent.marks.Length - 1].subjectName = y;
                        break;
                    case 7:
                        int min, max;
                        firstStudent.MinAndMaxMarks(out min, out max);
                        Console.WriteLine("The minimum mark: " + min);
                        Console.WriteLine("The maximum mark: " + max);
                        break;
                    case 8:
                        int repnum;
                        Console.WriteLine("Enter the number of mark, that you wanna replace.");
                        repnum = Convert.ToInt32(Console.ReadLine());
                        firstStudent.Replace(repnum, name: "Math", mark: 10);
                        break;
                    case 9:
                        firstStudent.ChangeMarks(1, 2);
                        break;
                    default:
                        Console.WriteLine("The menu doesn't have this item");
                        break;
                }
            }
        }
    }
}
