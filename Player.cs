using System;
using System.Collections.Generic;

namespace RPG
{
    public static class Player
    {
        public static string? nome;
        public static string? arma;
        public static string? classe;
        public static int vida;
        public static int danoArma;
        public static int agilidade;

        private static List<Tuple<string, int>> armas = new List<Tuple<string, int>>{
            Tuple.Create("machado", 3),
            Tuple.Create("espada", 2),
            Tuple.Create("adaga", 1),
            Tuple.Create("grimorio", 7)
        };

        private static List<Tuple<string, int, int>> classes = new List<Tuple<string, int, int>>{
            Tuple.Create("barbaro", 30, 2),
            Tuple.Create("guerreiro", 20, 5),  
            Tuple.Create("assassino", 10, 15),
            Tuple.Create("mago", 5, 10)
        };

        public static void dadosPlayer(){
            nomePlayer();
            armaPlayer();
            classePlayer();
        }

        private static void nomePlayer(){
            Console.WriteLine("Diga-me seu nome, jovem herói!");
            nome = Console.ReadLine()!;
        }

        private static void armaPlayer(){
            Console.WriteLine("E qual arma será de sua escolha?");
            
            foreach (var opt in armas){

                if(opt.Item1 == "grimorio"){
                    Console.WriteLine($"{opt.Item1} - MAN: {opt.Item2}");
                } else{
                Console.WriteLine($"{opt.Item1} - STR: {opt.Item2}");
                }

            }

            arma = Console.ReadLine()!.ToLower();
        }

        private static void classePlayer(){
            Console.WriteLine("Perfeito, agora qual será sua classe?");
            
            foreach (var opt in classes){
                Console.WriteLine($"{opt.Item1} - BHP: {opt.Item2} - AGI: {opt.Item3}");
            }

            classe = Console.ReadLine()!.ToLower();
        }

        public static bool VerificarAC(){
            bool armaExiste = false;
            bool classeExiste = false;

            foreach (var opt in armas){
                if (opt.Item1.ToLower().Equals(arma)){
                    armaExiste = true;
                    danoArma = opt.Item2;
                    break;
                }
            }

            foreach (var opt in classes){
                if (opt.Item1.ToLower().Equals(classe)){
                    classeExiste = true;
                    vida = opt.Item2 + 100;
                    agilidade = opt.Item3;
                    break;
                }
            }

            return armaExiste && classeExiste;
        }
    }
}