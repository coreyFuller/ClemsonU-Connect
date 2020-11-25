using System;
using CUConnect.Models;
using System.Collections.Generic;

namespace CUConnect
{
    public class CUConnect
    {
        public List<Student> AllStudents { get; set; }
        public Student MatchStudent { get; set; }

        public CUConnect(List<Student> students, Student student)
        {
            AllStudents = students;
            MatchStudent = student;
        }

        public double CalculateDistance(Student A, Student B)
        {
            double totalDistance = 0;



            return totalDistance;
        }

        public void MatchStudents()
        {

        }

        public void Display()
        {

        }
    }
}
