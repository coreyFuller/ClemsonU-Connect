using System;
using CUConnect.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace CUConnect
{
    public class CUConnect
    {
        public List<DataStudent> AllStudents { get; set;}
        public DataStudent Student_to_match { get; set; }
        public Dictionary<string, int> classes;
        public Dictionary<string, int> hobbies;
        public Dictionary<string,  Student> users;


        public CUConnect(List<DataStudent> students, DataStudent student, List<Student> original)
        {
            users = new Dictionary<string, Student>();
            StreamReader r = new StreamReader(@"..\CUConnect\Data\classes.json");
            string json = r.ReadToEnd();
            classes = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            r = new StreamReader(@"..\CUConnect\Data\hobbies.json");
            json = r.ReadToEnd();
            hobbies = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            AllStudents = students;
            Student_to_match = student;

            foreach (Student o in original)
            {
                users.Add(o.Username, o);
            }
        }

        public double CalculateDistance(DataStudent A, DataStudent B)
        {
            double hobbyDistance = 0;
            double classDistance = 0;

            for(int i = 0; i < A.hobbies.Count; i++) 
                hobbyDistance += Math.Abs(hobbies[A.hobbies[i]] - hobbies[B.hobbies[i]]);
            double hobbyMean = hobbyDistance / A.hobbies.Count;


            for (int i = 0; i < A.classes.Count; i++)
                classDistance += Math.Abs(classes[A.classes[i]] - classes[B.classes[i]]);
            double classMean = classDistance / A.classes.Count;

            double totalDistance = classMean + hobbyMean;

            return totalDistance;
        }

        public List<Student> MatchStudents()
        {
            foreach (DataStudent student in AllStudents){
                student.totalDistance += CalculateDistance(Student_to_match, student);
            }
            AllStudents.Sort((x, y) => x.totalDistance.CompareTo(y.totalDistance));
            List<DataStudent> concat = new List<DataStudent>();
            for( int i =0; i < 5; i++)
            {
                concat.Add(AllStudents[i]);
            }
            return Display(concat);

        }


        public List<Student> Display(List<DataStudent> concat)
        {
            List<Student> finalList = new List<Student>();

            foreach(DataStudent s in concat)
            {
                finalList.Add((Student)users[s.username]);
            }
            return finalList;
        }
    }
}
