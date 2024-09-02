using System;
using System.Collections.Generic;

namespace RPG
{
    class Program
    {
        static void Main()
        {
            Player.dadosPlayer();
            
            if (Player.VerificarAC())
            {
                Npc npc = new Npc("Gerald", "Espada", 120, 2);
                Combat.IniciarCombate(Player.nome, Player.vida, Player.danoArma, npc);
            }
            else
            {
                Console.WriteLine("A classe e/ou a arma que você inseriu não existem!");
            }
        }
    }
}