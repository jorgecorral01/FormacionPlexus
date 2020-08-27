using System.Collections.Generic;
using System.Linq;
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
            var caja50 = new Caja50();
            var caja75 = new Caja75();
            var caja100 = new Caja100();
            var caja120 = new Caja120();
            var cajas = new List<Caja>{caja50, caja75, caja100, caja120};
            var posibilidadesUnaCaja = cajas.Select(caja1 => new Valor{Cajas = caja1.Width.ToString(), Suma = caja1.Width, Coste = caja1.Coste}).ToList();
            var posibilidadesDosCajas = cajas.SelectMany(caja1 => cajas.Select(caja2 => new Valor
                    {Cajas = caja1.Width.ToString() + "-" + caja2.Width.ToString(), Suma = caja1.Width + caja2.Width, Coste = caja1.Coste + caja2.Coste}))
                .ToList();
            var posibilidadesTresCajas = cajas.SelectMany(caja1 => cajas.SelectMany(caja2 => cajas.Select(caja3 => new Valor {
                Cajas = caja1.Width.ToString() + "-" + caja2.Width.ToString() + "-" + caja3.Width.ToString(), Suma = caja1.Width + caja2.Width + caja3.Width,
                Coste = caja1.Coste + caja2.Coste + caja3.Coste
            }))).ToList();
            var posibilidadesCuatroCajas = cajas.SelectMany(caja1 => cajas.SelectMany(caja2 => cajas.SelectMany(caja3 =>
                cajas.Select(caja4 => new Valor {
                    Cajas = caja1.Width.ToString() + "-" + caja2.Width.ToString() + "-" + caja3.Width.ToString() + "-" + caja4.Width.ToString(),
                    Suma = caja1.Width + caja2.Width + caja3.Width + caja4.Width, Coste = caja1.Coste + caja2.Coste + caja3.Coste + caja4.Coste
                })))).ToList();
            var posibilidadesCincoCajas = cajas.SelectMany(caja1 => cajas.SelectMany(caja2 => cajas.SelectMany(caja3 => cajas.SelectMany(caja4 =>
                cajas.Select(caja5 => new Valor {
                    Cajas = caja1.Width.ToString() + "-" + caja2.Width.ToString() + "-" + caja3.Width.ToString() + "-" + caja4.Width.ToString() + "-" +
                            caja5.Width.ToString(),
                    Suma = caja1.Width + caja2.Width + caja3.Width + caja4.Width + caja5.Width,
                    Coste = caja1.Coste + caja2.Coste + caja3.Coste + caja4.Coste + caja5.Coste
                }))))).ToList();

            posibilidadesUnaCaja.AddRange(posibilidadesDosCajas);
            posibilidadesUnaCaja.AddRange(posibilidadesTresCajas);
            posibilidadesUnaCaja.AddRange(posibilidadesCuatroCajas);
            posibilidadesUnaCaja.AddRange(posibilidadesCincoCajas);
            return posibilidadesUnaCaja;
        }
    }

    public class Caja120 : Caja{
        public Caja120() {
            Width = 120;
            Coste = 111;
        }
    }

    public class Caja100 : Caja{
        public Caja100(){
            Width = 100;
            Coste = 90;
        }
    }

    public class Caja75 : Caja {
        public Caja75(){
            Width = 75;
            Coste = 62;
        }
    }

    public class Caja50 : Caja {
        public Caja50() {
            Width = 50;
            Coste = 59;
        }

    }

    public  abstract class Caja{
        public int Width;

        public int Coste{ get; set; }
    }

}