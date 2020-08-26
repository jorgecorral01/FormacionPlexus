using System.Collections.Generic;
using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using NUnit.Framework;

namespace test {
    public class ConfigureWardrobeShould {
        [Test]
        public void return_better_boxes_for_the_wall(){
            var configureWardrobe = new ConfigureWardrobe();

            var actualListBox =   configureWardrobe.GiveBetterBoxForWall();

            var expectBox = new List<Valor>();
            expectBox.Add(new Valor{Cajas = "50-100-100", Suma = 250});
            expectBox.Add(new Valor { Cajas = "75-75-100", Suma = 250 });
            expectBox.Add(new Valor { Cajas = "75-100-75", Suma = 250 });
            expectBox.Add(new Valor { Cajas = "100-50-100", Suma = 250 }); 
            expectBox.Add(new Valor { Cajas = "100-75-75", Suma = 250 }); 
            expectBox.Add(new Valor { Cajas = "100-100-50", Suma = 250 });
            expectBox.Add(new Valor { Cajas = "50-50-50-50-50", Suma = 250 });
            actualListBox.Should().BeEquivalentTo(expectBox);
        }

        [Test]
        public void return_better_boxes_and_cheap_for_the_wall(){
            var configureWardrobe = new ConfigureWardrobe();

            var actualListBox = configureWardrobe.GiveBetterBoxAndCheapForWall();

            var expectBox = new List<Valor>();
            expectBox.Add(new Valor { Cajas = "75-75-100", Suma = 250, Coste = 214 });
            expectBox.Add(new Valor { Cajas = "75-100-75", Suma = 250, Coste = 214 }); 
            expectBox.Add(new Valor { Cajas = "100-75-75", Suma = 250, Coste = 214 });
            actualListBox.Should().BeEquivalentTo(expectBox);
        }
    }
}
