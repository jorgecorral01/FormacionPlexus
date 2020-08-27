using System.Collections.Generic;
using System.Linq;
using Kata1.Boxes;
using Kata1.Boxes.Abstract;
using Kata1.Dtos;

namespace Kata1{
    public class ConfigureWardrobe{
        public List<Valor> GiveBetterBoxForWall(){
            var posibilidadesUnaCaja = FindBettersBoxes();
            return posibilidadesUnaCaja.Where(item => item.Suma == 250).ToList();
        }

        public List<Valor> GiveBetterBoxAndCheapForWall() {
            var posibilidadesUnaCaja = FindBettersBoxes();
            var min = posibilidadesUnaCaja.Where(item => item.Suma == 250).Min(item => item.Coste);
            return posibilidadesUnaCaja.Where(item => item.Suma == 250 && item.Coste == min).ToList();
        }

        private static List<Valor> FindBettersBoxes(){
            var caja50 = new Box50();
            var caja75 = new Box75();
            var caja100 = new Box100();
            var caja120 = new Box120();
            var cajas = new List<Box>{caja50, caja75, caja100, caja120};
            var posibilidadesUnaCaja = cajas.Select(caja1 => new Valor{Cajas = caja1.Width.ToString(), Suma = caja1.Width, Coste = caja1.Cost}).ToList();
            var posibilidadesDosCajas = cajas.SelectMany(caja1 => cajas.Select(caja2 => new Valor
                    {Cajas = caja1.Width.ToString() + "-" + caja2.Width.ToString(), Suma = caja1.Width + caja2.Width, Coste = caja1.Cost + caja2.Cost}))
                .ToList();
            var posibilidadesTresCajas = cajas.SelectMany(caja1 => cajas.SelectMany(caja2 => cajas.Select(caja3 => new Valor {
                Cajas = caja1.Width.ToString() + "-" + caja2.Width.ToString() + "-" + caja3.Width.ToString(), Suma = caja1.Width + caja2.Width + caja3.Width,
                Coste = caja1.Cost + caja2.Cost + caja3.Cost
            }))).ToList();
            var posibilidadesCuatroCajas = cajas.SelectMany(caja1 => cajas.SelectMany(caja2 => cajas.SelectMany(caja3 =>
                cajas.Select(caja4 => new Valor {
                    Cajas = caja1.Width.ToString() + "-" + caja2.Width.ToString() + "-" + caja3.Width.ToString() + "-" + caja4.Width.ToString(),
                    Suma = caja1.Width + caja2.Width + caja3.Width + caja4.Width, Coste = caja1.Cost + caja2.Cost + caja3.Cost + caja4.Cost
                })))).ToList();
            var posibilidadesCincoCajas = cajas.SelectMany(caja1 => cajas.SelectMany(caja2 => cajas.SelectMany(caja3 => cajas.SelectMany(caja4 =>
                cajas.Select(caja5 => new Valor {
                    Cajas = caja1.Width.ToString() + "-" + caja2.Width.ToString() + "-" + caja3.Width.ToString() + "-" + caja4.Width.ToString() + "-" +
                            caja5.Width.ToString(),
                    Suma = caja1.Width + caja2.Width + caja3.Width + caja4.Width + caja5.Width,
                    Coste = caja1.Cost + caja2.Cost + caja3.Cost + caja4.Cost + caja5.Cost
                }))))).ToList();

            posibilidadesUnaCaja.AddRange(posibilidadesDosCajas);
            posibilidadesUnaCaja.AddRange(posibilidadesTresCajas);
            posibilidadesUnaCaja.AddRange(posibilidadesCuatroCajas);
            posibilidadesUnaCaja.AddRange(posibilidadesCincoCajas);
            return posibilidadesUnaCaja;
        }
    }
}