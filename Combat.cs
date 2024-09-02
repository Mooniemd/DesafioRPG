using System;

namespace RPG{
    public static class Combat{
        public static void IniciarCombate(string? nomePlayer, int vidaPlayer, int danoPlayer, Npc npc)
        {
            Console.WriteLine($"Ótimo, {nomePlayer}, sua arma é: {Player.arma} e sua classe é: {Player.classe}.");
            Console.WriteLine($"Agora você deve enfrentar {npc.nome}, o Impiedoso, para salvar nossa vila. Boa sorte jovem herói!");

            Random random = new Random();
            while (vidaPlayer > 0 && npc.vida > 0)
            {
                int danoInfligidoPlayer = danoPlayer + random.Next(0, 30);
                npc.vida -= danoInfligidoPlayer;
                Console.WriteLine($"{nomePlayer} atinge {npc.nome} com seu/sua {Player.arma} e deu {danoInfligidoPlayer} de dano. {npc.nome} ficou com {npc.vida} de vida!");

                if (npc.vida <= 0) break;

                // Esquiva do Player
                bool esquivou = random.Next(0, 60) < Player.agilidade;

                if (esquivou){
                    Console.WriteLine($"{nomePlayer} esquivou do ataque de {npc.nome}!");
                }
                else{
                    int danoInfligidoNpc = npc.danoArma + random.Next(0, 30);
                    vidaPlayer -= danoInfligidoNpc;
                    Console.WriteLine($"{npc.nome} atinge {nomePlayer} com seu/sua {npc.arma} e deu {danoInfligidoNpc} de dano. {nomePlayer} ficou com {vidaPlayer} de vida!");
                }
            }

            if (vidaPlayer > 0){
                Console.WriteLine($"{nomePlayer} venceu a batalha! Parabéns jovem herói.");
            }
            else{
                Console.WriteLine($"{npc.nome} venceu a batalha... Fujam todos, senão vamos morrer!");
            }
        }
    }
}