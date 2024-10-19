namespace RoleplayGame;

public interface ICurador : IHechiceroHero

{
    public void Curar(int curar, IPersonajeHero curado);
}