using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Kata1.Dtos;

namespace Kata1{
    public class ClsStudentRepository{
        public List<Student> ListStudents;

        public ClsStudentRepository(){
            ListStudents = new List<Student>();
        }
        public virtual Student Save(Student student){
            if (FindByName(student.Name) != null){ return new StudentAlreadyExist();}
            ListStudents.Add(student);
            return student;
        }

        public Student FindByName(string studentName){
            return ListStudents.FirstOrDefault(item => item.Name == studentName);
        }
    }
}