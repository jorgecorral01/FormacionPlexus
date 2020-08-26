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
            expectBox.Add(new Valor{valores = "50-100-100", suma = 250});
            expectBox.Add(new Valor { valores = "75-75-100", suma = 250 });
            expectBox.Add(new Valor { valores = "75-100-75", suma = 250 });
            expectBox.Add(new Valor { valores = "100-50-100", suma = 250 }); 
            expectBox.Add(new Valor { valores = "100-75-75", suma = 250 }); 
            expectBox.Add(new Valor { valores = "100-100-50", suma = 250 });
            expectBox.Add(new Valor { valores = "50-50-50-50-50", suma = 250 });
            actualListBox.Should().BeEquivalentTo(expectBox);
        }
    }
}
