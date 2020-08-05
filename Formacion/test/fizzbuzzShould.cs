using NUnit.Framework;
using FluentAssertions;
using Kata1;

namespace test {
    
    public class fizzbuzzShould {
        private ClsFizzBuzz clsEjemplo1;

        [SetUp]
        public void Setup() {
            clsEjemplo1 = new ClsFizzBuzz();
            
        }

        [Test]
        public void for_numbers_not_reconized_multiples_return_same_number() {
            var number = 1;
            clsEjemplo1 = new ClsFizzBuzz();

            var resultado = clsEjemplo1.EsDivisiblePor(number);

            resultado.Should().Be("1");

        }

        [Test]
        public void for_numbers_multiples_of_three_return_fizz(){
            var number = 3;
            clsEjemplo1 = new ClsFizzBuzz();

            var resultado = clsEjemplo1.EsDivisiblePor(number);

            resultado.Should().Be("fizz");
            
        }

        [Test]
        public void for_numbers_multiples_of_five_return_buzz() {
            var number = 5;
            clsEjemplo1 = new ClsFizzBuzz();

            var resultado = clsEjemplo1.EsDivisiblePor(number);

            resultado.Should().Be("buzz");

        }
        [Test]
        public void for_numbers_multiples_of_three_or_five_return_fizzbuzz() {
            var number = 15;
            clsEjemplo1 = new ClsFizzBuzz();

            var resultado = clsEjemplo1.EsDivisiblePor(number);

            resultado.Should().Be("fizzbuzz");

        }
    }
}
