using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using NUnit.Framework;

namespace test {
    public class ConfigureWardrobeShould {
        [Test]
        public void return_better_boxes_for_the_wall() {
            var configureWardrobe = new ConfigureWardrobe();

            var actualListBox = configureWardrobe.GiveBetterBoxForWall();

            var expectBox = new List<Valor>();
            expectBox.Add(new Valor { Cajas = "50-100-100", Suma = 250, Coste = 239 });
            expectBox.Add(new Valor { Cajas = "75-75-100", Suma = 250, Coste = 214 });
            expectBox.Add(new Valor { Cajas = "75-100-75", Suma = 250, Coste = 214 });
            expectBox.Add(new Valor { Cajas = "100-50-100", Suma = 250, Coste = 239 });
            expectBox.Add(new Valor { Cajas = "100-75-75", Suma = 250, Coste = 214 });
            expectBox.Add(new Valor { Cajas = "100-100-50", Suma = 250, Coste = 239 });
            expectBox.Add(new Valor { Cajas = "50-50-50-100", Suma = 250, Coste = 267 });
            expectBox.Add(new Valor { Cajas = "50-50-75-75", Suma = 250, Coste = 242 });
            expectBox.Add(new Valor { Cajas = "50-50-100-50", Suma = 250, Coste = 267 });
            expectBox.Add(new Valor { Cajas = "50-75-50-75", Suma = 250, Coste = 242 });
            expectBox.Add(new Valor { Cajas = "50-75-75-50", Suma = 250, Coste = 242 });
            expectBox.Add(new Valor { Cajas = "50-100-50-50", Suma = 250, Coste = 267 });
            expectBox.Add(new Valor { Cajas = "75-50-50-75", Suma = 250, Coste = 242 });
            expectBox.Add(new Valor { Cajas = "75-50-75-50", Suma = 250, Coste = 242 });
            expectBox.Add(new Valor { Cajas = "75-75-50-50", Suma = 250, Coste = 242 });
            expectBox.Add(new Valor { Cajas = "100-50-50-50", Suma = 250, Coste = 267 });
            expectBox.Add(new Valor { Cajas = "50-50-50-50-50", Suma = 250, Coste = 295 });
            actualListBox.Should().BeEquivalentTo(expectBox);
        }

        [Test]
        public void return_better_boxes_and_cheap_for_the_wall() {
            var configureWardrobe = new ConfigureWardrobe();

            var actualListBox = configureWardrobe.GiveBetterBoxAndCheapForWall();

            var expectBox = new List<Valor>();
            expectBox.Add(new Valor { Cajas = "75-75-100", Suma = 250, Coste = 214 });
            expectBox.Add(new Valor { Cajas = "75-100-75", Suma = 250, Coste = 214 });
            expectBox.Add(new Valor { Cajas = "100-75-75", Suma = 250, Coste = 214 });
            actualListBox.Should().BeEquivalentTo(expectBox);
        }

        [Test]
        public void PermutacionRepeticion(){
            var suma = 250;
            var maximasRepeticiones = suma / 50;
            var set = new List<int> {50, 75, 100, 120 };
            if (set.Count < maximasRepeticiones){
                for (int i = set.Count; i < maximasRepeticiones; i++){
                    set.Insert(0,0);
                }
            }
            else{
                maximasRepeticiones = set.Count;
            }
            var combinations = GenerateCombinations(set, maximasRepeticiones);
            var listaDefinitiva = new List<string>();
            foreach(var combination in combinations) {
                string combinationStr = string.Join(" ", combination);
                if(combination.Sum() == suma) {
                    listaDefinitiva.Add(combinationStr);
                }
            }

            foreach (var resultado in listaDefinitiva.Distinct()) {
                Console.WriteLine(resultado);
            }
        }

        private List<List<int>> GenerateCombinations(List<int> combinationList, int k) {
            {
                var combinations = new List<List<int>>();

                if(k == 0) {
                    var emptyCombination = new List<int>();
                    combinations.Add(emptyCombination);

                    return combinations;
                }

                if(combinationList.Count == 0) {
                    return combinations;
                }

                int head = combinationList[0];
                var copiedCombinationList = new List<int>(combinationList);

                List<List<int>> subcombinations = GenerateCombinations(copiedCombinationList, k - 1);

                foreach(var subcombination in subcombinations) {
                    subcombination.Insert(0, head);
                    combinations.Add(subcombination);
                }

                combinationList.RemoveAt(0);
                combinations.AddRange(GenerateCombinations(combinationList, k));

                return combinations;
            }
        }
    }
}

