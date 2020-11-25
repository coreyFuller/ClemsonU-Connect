using System;
using CUConnect.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace CUConnect
{
    public class CUConnect
    {
        public List<Student> AllStudents { get; set; }
        public Student MatchStudent { get; set; }
        public Dictionary<string, int> classes;
        public Dictionary<string, int> hobbies;

        public CUConnect(List<Student> students, Student student)
        {
            StreamReader r = new StreamReader(@"C:\Users\corey\Desktop\CUConnect\CUConnect\Data\classes.json");
            string json = r.ReadToEnd();
            classes = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            r = new StreamReader(@"C:\Users\corey\Desktop\CUConnect\CUConnect\Data\hobbies.json");
            json = r.ReadToEnd();
            hobbies = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            AllStudents = students;
            MatchStudent = student;
        }

        public double CalculateDistance(Student A, Student B)
        {
            double totalDistance = 0;
            double hobbyDistance = 0;
            double classDistance = 0;



            return totalDistance;
        }

        public void MatchStudents()
        {
            foreach (Student student in AllStudents){
                CalculateDistance(MatchStudent, student);
            }
        }

        public void Display()
        {

        }
    }
}
