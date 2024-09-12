namespace RoleplayGame
{
    public class Mago
    {
        public string Nombre { get; set; }

        public int Vida { get; set; }

        public Array Hechizos
        {
            get { return this.Hechizos; }
            set { this.Hechizos = value; }
        }

        public void curar(int curar)
        {
            Vida += curar;
        }
        public int ValorAtaque (Item ataque)
        {
            int valor = 0;
            foreach (Item item in Hechizos)
            {
                valor += item.Valor;
            }
            return valor;
        }

        public void RecibirAtaque(int ataque)
        {
            Vida -= ataque;
        }
        
    }
}
    