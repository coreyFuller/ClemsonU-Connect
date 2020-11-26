using System;
using System.Collections.Generic;

namespace CUConnect.Models
{
    public class DataStudent
    {
        public int id;
        public string username;
        public double totalDistance;
        public double matchAverage;
        public List<String> hobbies;
        public List<String> classes;

        public DataStudent(int _id, string _username, double _totalDistance, double _matchAverage, List<String> h, List<String> c)
        {
                id = _id;
                username = _username;
                totalDistance = _totalDistance;
                matchAverage = _matchAverage;
                hobbies = h;
                classes = c;
        }
    }
}
