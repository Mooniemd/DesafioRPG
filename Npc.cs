namespace RPG{
    public class Npc{
        public string? nome;
        public string? arma;
        public int vida;
        public int danoArma;

        public Npc(string nome, string arma, int vida, int danoArma){
            this.nome = nome;
            this.arma = arma;
            this.vida = vida;
            this.danoArma = danoArma;
        }
    }
}   