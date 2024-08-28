using System;
namespace RPG{
    class Program{
        static void Main(){

Console.WriteLine("Diga-me seu nome, jovem herói!");
string? nome = Console.ReadLine()!;
Console.WriteLine("E qual arma será de sua escolha?");
var armas = new List<Tuple<string, int>>{
  Tuple.Create("Machado", 3),
  Tuple.Create("Espada", 2),
  Tuple.Create("Adaga", 1)
};
foreach (var opt in armas){
  Console.WriteLine($"{opt.Item1} - STR: {opt.Item2}");
}
string? arma = Console.ReadLine()!.ToLower();
Console.WriteLine("Perfeito, agora qual será sua classe?");
var classes = new List<Tuple<string, int>>{
  Tuple.Create("Barbaro", 30),
  Tuple.Create("Guerreiro", 20),
  Tuple.Create("Assassino", 10)
};
foreach (var opt in classes){
  Console.WriteLine($"{opt.Item1} - BHP: {opt.Item2}");
}
string? classe = Console.ReadLine()!.ToLower();
bool armaExiste = false;
bool classeExiste = false;
int vidaPlayer = 0;
int danoArma = 0;
foreach(var opt in armas){
  if (opt.Item1.ToLower().Equals(arma)){
    armaExiste = true;
    danoArma = opt.Item2;
    break;
  }
}
foreach(var opt in classes){
  if (opt.Item1.ToLower().Equals(classe)){
    classeExiste = true;
    vidaPlayer = opt.Item2 + 100;
    break;
  }
}
if (armaExiste && classeExiste){
  Console.WriteLine($"Ótimo, {nome}, sua arma é: {arma} e sua classe é: {classe}.");
  Console.WriteLine("Agora você deve enfrentar Gerald, o Impiedoso, para salvar nossa vila. Boa sorte jovem herói!");
  string? nomeNPC = "Gerald";
  string? armaNPC = "Espada";
  int vidaNPC = 120;
  int danoArmaNPC = 2;
  Random random = new Random();
  while(vidaPlayer > 0 && vidaNPC > 0){
    int danoPlayer = danoArma + random.Next(0, 30);
    vidaNPC -= danoPlayer;
    Console.WriteLine($"{nome} atinge {nomeNPC} com seu/sua {arma} e deu {danoPlayer} de dano. {nomeNPC} ficou {vidaNPC} de vida!");
    if(vidaNPC <= 0) break;
    int danoNPC = danoArmaNPC + random.Next(0, 30);
    vidaPlayer -= danoNPC;
    Console.WriteLine($"{nomeNPC} atinge {nome} com seu/sua {armaNPC} e deu {danoNPC} de dano. {nome} ficou {vidaPlayer} de vida!");
  }
  if (vidaPlayer > 0 ){
    Console.WriteLine($"{nome} venceu a batalha! Parabéns jovem herói.");
  } else{
    Console.WriteLine($"{nomeNPC} venceu a batalha... Fujam todos, vamos todos morrer!");
  }
} else{
  Console.WriteLine("A classe e/ou a arma que você inseriu não existem!");
}
        }
    }
}