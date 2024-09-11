using System;

namespace RPG{
    public static class Combat{
        public static void IniciarCombate(string? nomePlayer, int vidaPlayer, int danoPlayer, Npc npc, Inventory inventory){
            Console.WriteLine($"Ótimo, {nomePlayer}, sua arma é: {Player.arma} e sua classe é: {Player.classe}.");
            Console.WriteLine($"Agora você deve enfrentar {npc.nome}, o Impiedoso, para salvar nossa vila. Boa sorte jovem herói!");

            Random random = new Random();
            while (vidaPlayer > 0 && npc.vida > 0){
                int danoInfligidoPlayer = danoPlayer + random.Next(0, 30);  
                npc.vida -= danoInfligidoPlayer;
                Console.WriteLine($"{nomePlayer} atinge {npc.nome} com seu/sua {Player.arma} e deu {danoInfligidoPlayer} de dano. {npc.nome} ficou com {npc.vida} de vida!");

                if (npc.vida <= 0) break;

                int valorDefesa = random.Next(1, 20) + Player.agilidade;
                int danoInfligidoNpc = npc.danoArma + random.Next(0, 30);

                if (valorDefesa > 21) {
                    Console.WriteLine($"{nomePlayer} esquivou completamente do ataque de {npc.nome}!");
                } else if (valorDefesa > 18){
                    danoInfligidoNpc /= 2;
                    Console.WriteLine($"{nomePlayer} conseguiu uma defesa parcial contra {npc.nome}, reduzindo o dano pela metade!");
                    vidaPlayer -= danoInfligidoNpc;
                    Console.WriteLine($"{npc.nome} atinge {nomePlayer} com seu/sua {npc.arma} e deu {danoInfligidoNpc} de dano. {nomePlayer} agora tem {vidaPlayer} de vida!");
                } else{
                    vidaPlayer -= danoInfligidoNpc;
                    Console.WriteLine($"{npc.nome} atinge {nomePlayer} com seu/sua {npc.arma} e deu {danoInfligidoNpc} de dano. {nomePlayer} agora tem {vidaPlayer} de vida!");
                }

                Console.WriteLine("Você gostaria de usar um item? (s/n)");
                string resposta = Console.ReadLine()!;
                if (resposta.ToLower() == "s") {
                    Console.WriteLine("Escolha a linha e a coluna do item que deseja usar:");
                    int linha = int.Parse(Console.ReadLine()!);
                    int coluna = int.Parse(Console.ReadLine()!);

                    if (!string.IsNullOrEmpty(nomePlayer)){
                        inventory.UseItem(linha, coluna, ref vidaPlayer, ref danoPlayer, nomePlayer, ref Player.agilidade);
                    }
                    else{
                        Console.WriteLine("Erro: O nome do jogador não foi definido corretamente.");
                    }
                }

                inventory.ShowInventory();
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