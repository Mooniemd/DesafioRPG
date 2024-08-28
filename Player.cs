namespace RPG{
    public static class Player{
            public static string? nome;
            public static string? arma;
            public static string? classe;
        public static void dadosPlayer(){

static void nomePlayer(){
    Console.WriteLine("Diga-me seu nome, jovem herói!");
    nome = Console.ReadLine()!;
}

static void armaPlayer(){
    Console.WriteLine("E qual arma será de sua escolha?");
    var armas = new List<Tuple<string, int>>{
    Tuple.Create("Machado", 3),
    Tuple.Create("Espada", 2),
    Tuple.Create("Adaga", 1)
 };
        foreach (var opt in armas){
        Console.WriteLine($"{opt.Item1} - STR: {opt.Item2}");
}
    arma = Console.ReadLine()!.ToLower();
}

static void classePlayer(){
    Console.WriteLine("Perfeito, agora qual será sua classe?");
    var classes = new List<Tuple<string, int>>{
    Tuple.Create("Barbaro", 30),
    Tuple.Create("Guerreiro", 20),
    Tuple.Create("Assassino", 10)
  };

        foreach (var opt in classes){
        Console.WriteLine($"{opt.Item1} - BHP: {opt.Item2}");
      }
      
    classe = Console.ReadLine()!.ToLower();
}
        }
    }
}