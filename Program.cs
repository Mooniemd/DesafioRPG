using System;

namespace RPG
{
    class Program
    {
        static void Main()
        {
            Inventory inventory = new Inventory();

            Player.dadosPlayer();
            
            if (Player.VerificarAC()){

                inventory.AddItem("Poção de Cura", 0, 0);
                inventory.AddItem("Elixir de Força", 0, 1);
                inventory.AddItem("Poção de Agilidade", 1, 0);
                

                inventory.ShowInventory();

                Npc npc = new Npc("Gerald", "Espada", 120, 2);
                Combat.IniciarCombate(Player.nome, Player.vida, Player.danoArma, npc, inventory);
            }
            else{
                Console.WriteLine("A classe e/ou a arma que você inseriu não existem!");
            }
        }
    }
}