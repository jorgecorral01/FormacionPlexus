using System.Collections.Generic;

namespace Kata1{
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
}