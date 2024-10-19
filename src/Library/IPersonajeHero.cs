using System;

namespace RoleplayGame
{
    public interface IPersonajeHero
    {
        string Nombre { get; set; }
        static int Vida;
        static int Ataque;
        static int VidaInicial;

        public void ConseguirPV(int PV);
        
        public int VerVidaInicial();
        public int VerVida();
        public void CambiarVida(int vida);
        void AgregarItemAtaque(IAtaque item);
        
        void AgregarItemDefensa(IDefensa item);
        
        int ValorAtaque();
        void RecibirAtaque(IPersonajeEnemigo ataque);

        void RecibirHechizo(IHechiceroEnemigo atacante, Hechizo hechizo);
        
        List<IAtaque> ItemsAtaque { get; }
    }
}