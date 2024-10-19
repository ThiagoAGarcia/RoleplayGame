using System;

namespace RoleplayGame
{
    public interface IPersonajeEnemigo
    {
        string Nombre { get; set; }
        static int Vida;
        static int Ataque;
        static int VidaInicial;
        public int VerVidaInicial();
        public int VerVida();
        public void CambiarVida(int vida);
        void AgregarItemAtaque(IAtaque item);
        
        void AgregarItemDefensa(IDefensa item);
        
        int ValorAtaque();
        void RecibirAtaque(IPersonajeHero ataque);

        void RecibirHechizo(IHechiceroHero hechicerohEroAtacante, Hechizo hechizo);
    }
}