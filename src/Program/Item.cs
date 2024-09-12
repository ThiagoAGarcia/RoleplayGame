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

        // Items fijos
        public static Item Espada { get; } = new Item { Nombre = "Espada", Ataque = 30, Defensa = 5 };
        public static Item Escudo { get; } = new Item { Nombre = "Escudo", Ataque = 10, Defensa = 50 };
        public static Item Arco { get; } = new Item { Nombre = "Arco", Ataque = 25, Defensa = 10 };
        public static Item Armadura { get; } = new Item { Nombre = "Armadura", Ataque = 5, Defensa = 40 };
    }
}