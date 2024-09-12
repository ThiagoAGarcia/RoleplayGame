namespace RoleplayGame
{
    public class Item
    {
        public string Nombre { get; set; }
        public int Ataque { get; set; }
        private int defensa;

        public int Defensa
        {
            get { return defensa; }
            set { defensa = value; }
        }

        public Item(string nombre, int valor)
        {
            this.Nombre = nombre;
            this.Ataque = valor;
            this.defensa = 0;
        }
    }
}