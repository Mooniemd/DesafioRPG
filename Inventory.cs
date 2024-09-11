using System;

namespace RPG{
    public class Inventory{
        private string?[,] items = new string?[2,2];
        public void AddItem(string item, int row, int col){
            if(row < 2 && col < 2 && items[row,col] == null){
                items[row,col] = item;
                Console.WriteLine($"Item {item} foi adicionado ao inventário na posição [{row},{col}].");
            } else {
                Console.WriteLine("Posição inválida ou já ocupada.");
            }
        }

public void UseItem(int row, int col, ref int vidaPlayer, ref int danoPlayer, string nomePlayer, ref int agilidadePlayer){
    if(row < 2 && col < 2 && items[row,col] != null){
        string? item = items[row,col];

        if (item != null){
            Console.WriteLine($"Você usou {item}!");

            switch(item.ToLower()){
                case "poção de cura":
                    vidaPlayer += 20;
                    Console.WriteLine($"{nomePlayer} recuperou 20 de vida! Agora tem {vidaPlayer} de vida.");
                    break;
                case "elixir de força":
                    danoPlayer += 5;
                    Console.WriteLine($"{nomePlayer} ganhou +5 de dano temporariamente! Agora tem {danoPlayer} de dano.");
                    break;
                case "poção de agilidade":
                    agilidadePlayer += 5;
                    Console.WriteLine($"{nomePlayer} ganhou +5 de agilidade temporariamente! Agora tem {agilidadePlayer} de agilidade.");
                    break;
                default:
                    Console.WriteLine("Este item não tem efeito.");
                    break;
            }

            items[row,col] = null;
        }
    } else {
        Console.WriteLine("Nenhum item encontrado nesta posição.");
    }
}

        public void ShowInventory(){
            Console.WriteLine("Seu inventário:");
            for(int i = 0; i < 2; i++){
                for(int j = 0; j < 2; j++){
                    Console.Write(items[i,j] != null ? items[i,j] : "vazio");
                    if (j < 1) Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
    }
}