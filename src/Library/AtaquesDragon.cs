namespace RoleplayGame
{
    public class AtaquesDragon
    {
        public string Nombre{get; set;}
        public int Ataque {get; set;}
        
        public AtaquesDragon(string nombre, int ataque)
        {
            this.Nombre = nombre;
            this.Ataque = ataque;
        }
    }
}