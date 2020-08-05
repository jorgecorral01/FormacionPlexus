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
        private ClsStudentRepository clsStudentRepository;

        [SetUp]
        public void Setup(){
            student = GivenAStudent("Peter", "House");
            newStudent = GivenAStudent("Peter", "Grey");
            clsStudentRepository = new ClsStudentRepository();
        }

        [Test]
        public void when_we_save_a_student_we_have_it(){

            clsStudentRepository.Save(student);

            clsStudentRepository.ListStudents.Should().HaveCount(1);
            //Forma mala
            clsStudentRepository.ListStudents[0].Name.Should().Be(student.Name);
            clsStudentRepository.ListStudents[0].Surname.Should().Be(student.Surname);
            //Forma mejor
            clsStudentRepository.ListStudents[0].Should().BeEquivalentTo(student);
        }
        
        [Test]
        public void when_we_ask_for_a_student_we_can_recover_it() {
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
            GivenAStudenRepositoryMock();
            GivenDataForStudentRepositoryMock(student);

            clsStudentRepository.Save(student);

            clsStudentRepository.ListStudents.Should().HaveCount(1);
            clsStudentRepository.ListStudents[0].Name.Should().Be(student.Name);
            clsStudentRepository.ListStudents[0].Surname.Should().Be(student.Surname);
        }

        [Test]
        public void when_try_save_exist_name_return_student_exist_with_mocks(){
            GivenAStudenRepositoryMock();
            GivenDataForStudentRepositoryMock(student);
            GivenStudentAlreadyExistForstudent();

            clsStudentRepository.Save(student);

            var actualStudent = clsStudentRepository.Save(newStudent);

            actualStudent.Should().BeOfType<StudentAlreadyExist>();
            clsStudentRepository.Received(2).Save(Arg.Any<Student>());

        }

        private void GivenStudentAlreadyExistForstudent(){
            clsStudentRepository.Save(newStudent).Returns(new StudentAlreadyExist());
        }

        private void GivenDataForStudentRepositoryMock(Student _student) {
            clsStudentRepository.Save(_student).Returns(_student);
            clsStudentRepository.ListStudents.Add(_student); // TODO no se si esto estaria bien.
        }

        private void GivenAStudenRepositoryMock() {
            clsStudentRepository = Substitute.For<ClsStudentRepository>();
        }

        private static Student GivenAStudent(string name, string surname) {
            return new Student {
                Name = name,
                Surname = surname
            };
        }
    }
}
