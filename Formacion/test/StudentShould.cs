using System;
using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace test{
    public class StudentShould{
        private Student student ;
        private Student newStudent ;

        [SetUp]
        public void Setup(){
            student = GivenAStudent("Peter", "House");
            newStudent = GivenAStudent("Peter", "Grey");
        }

        [Test]
        public void when_we_save_a_student_we_have_it(){
            var clsStudentRepository = new ClsStudentRepository();

            clsStudentRepository.Save(student);

            clsStudentRepository.ListStudents.Should().HaveCount(1);
            clsStudentRepository.ListStudents[0].Name.Should().Be(student.Name);
            clsStudentRepository.ListStudents[0].Surname.Should().Be(student.Surname);
        }

        private static Student GivenAStudent(string name, string surname){
            return new Student{
                Name = name,
                Surname = surname
            };
        }

        [Test]
        public void when_we_ask_for_a_student_we_can_recover_it() {
            var clsStudentRepository = new ClsStudentRepository();
            clsStudentRepository.Save(student);

            var actualStudent = clsStudentRepository.FindByName(student.Name);

            actualStudent.Name.Should().Be(student.Name);
            actualStudent.Surname.Should().Be(student.Surname);
            //Porque esto si es verdad?
            Assert.AreEqual(actualStudent, student);
            Assert.AreSame(actualStudent, student);
        }

        [Test]
        public void when_try_save_exist_name_return_student_exist(){
            var clsStudentRepository = new ClsStudentRepository();
            clsStudentRepository.Save(student);

            var actualStudent = clsStudentRepository.Save(newStudent);

            actualStudent.Should().BeOfType<StudentAlreadyExist>();

            // TODO 
            //Assert.That(() => {
            //    clsStudentRepository.Save(student);
            //}, Throws.TypeOf<StudentAlreadyExist>());

            //try {
            //    clsStudentRepository.Save(newStudent);
            //    clsStudentRepository.ListStudents.Should().HaveCount(1);
            //}
            //catch (Exception e){
            //    e.GetType().Should().BeOfType<StudentAlreadyExist>();
            //}


        }

        [Test]
        public void when_we_save_a_student_we_have_it_with_mock() {
            var clsStudentRepository = Substitute.For<ClsStudentRepository>();
            clsStudentRepository.Save(student).Returns(student);
            clsStudentRepository.ListStudents.Add(student);// TODO no se si esto estaria bien.

            clsStudentRepository.Save(student);

            clsStudentRepository.ListStudents.Should().HaveCount(1);
            clsStudentRepository.ListStudents[0].Name.Should().Be(student.Name);
            clsStudentRepository.ListStudents[0].Surname.Should().Be(student.Surname);
        }

        [Test]
        public void when_try_save_exist_name_return_student_exist_with_mocks() {
            var clsStudentRepository = Substitute.For<ClsStudentRepository>();
            clsStudentRepository.Save(student).Returns(student);
            clsStudentRepository.Save(newStudent).Returns(new StudentAlreadyExist());

            clsStudentRepository.Save(student);

            var actualStudent = clsStudentRepository.Save(newStudent);

            actualStudent.Should().BeOfType<StudentAlreadyExist>();
            clsStudentRepository.Received(2).Save(Arg.Any<Student>());

        }
    }
}
