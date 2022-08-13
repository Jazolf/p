using System;

namespace StudentApi.Models
{
    public class StudentItems
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public bool IsComplete { get; set; }

        //internal static void Remove(StudentItems student)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
