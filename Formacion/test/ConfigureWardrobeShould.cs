using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kata1;
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

    public class ConfigureWardrobe{
        public List<Valor> GiveBetterBoxForWall(){
            var longitudeCaja = new List<int> { 50, 75, 100, 120 };
            var posibilidadesUnaCaja = longitudeCaja.Select(caja1 => new Valor { valores = caja1.ToString(), suma = caja1 }).ToList();
            var posibilidadesDosCajas = longitudeCaja.SelectMany(a => longitudeCaja.Select(b => new Valor { valores = a + "-" + b, suma = a + b })).ToList();
            var posibilidadesTresCajas = longitudeCaja.SelectMany(a => longitudeCaja.SelectMany(b => longitudeCaja.Select(c => new Valor { valores = a + "-" + b + "-" + c, suma = a + b + c }))).ToList();
            var posibilidadesCuatroCajas = longitudeCaja.SelectMany(a => longitudeCaja.SelectMany(b => longitudeCaja.SelectMany(c => longitudeCaja.SelectMany(d => longitudeCaja.Select(e => new Valor { valores = a + "-" + b + "-" + c + "-" + d + "-" + e, suma = a + b + c + d + e }))))).ToList();
            posibilidadesUnaCaja.AddRange(posibilidadesDosCajas);
            posibilidadesUnaCaja.AddRange(posibilidadesTresCajas);
            posibilidadesUnaCaja.AddRange(posibilidadesCuatroCajas);
            return posibilidadesUnaCaja.Where(item => item.suma == 250).ToList();
        }
    }

    public class Valor {
        public string valores { get; set; }
        public int suma { get; set; }
    }
}
