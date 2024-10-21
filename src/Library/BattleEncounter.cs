namespace RoleplayGame;

public class BattleEncounter
{
    // El encuentro de combate se compone de una lista de héroes y una lista de enemigos, que se enfrentarán entre sí. 
    // De forma tal que se cumplan las reglas para el mismo tomadas del repo.
    // Se elimino que al final los personajes se curaran porque no tenia sentido, teniendo en cuenta que solo los Elfos podian.
    
    private List<PersonajeHero> heroes;
    private List<PersonajeEnemigo> enemigos;
    
    public List<PersonajeHero> Heroes
    {
        get { return heroes; }
    }
    public List<PersonajeEnemigo> Enemigos
    {
        get { return enemigos; }
    }

    public BattleEncounter(List<PersonajeHero> heroes, List<PersonajeEnemigo> enemigos)
    {
        this.heroes = heroes;
        this.enemigos = enemigos;
    }

    public void DoEncounter()
    {
        while (heroes.Any(h => h.Vida > 0) && enemigos.Any(e => e.Vida > 0))
        {
            
            for (int i = 0; i < enemigos.Count; i++)
            {
                var enemigo = enemigos[i];
                if (enemigo.Vida <= 0) continue; // Enemigo debe estar vivo
                
                var heroe = heroes[i % heroes.Count]; // Se distribuye el ataque entre heroes
                if (heroe.Vida > 0)
                {
                    Console.WriteLine($"{enemigo.Nombre} ataca a {heroe.Nombre}");
                    heroe.RecibirAtaque(enemigo);
                }
            }
            foreach (var heroe in heroes)
            {
                if (heroe.Vida > 0) // Se supone que ataca a heroes vivos
                {
                    foreach (var enemigo in enemigos)
                    {
                        if (enemigo.Vida > 0)
                        {
                            Console.WriteLine($"{heroe.Nombre} ataca a {enemigo.Nombre}");
                            enemigo.RecibirAtaque(heroe);

                            
                            if (enemigo.Vida <= 0)
                            {
                                heroe.ConseguirPV(enemigo.ObtenerPv() );
                                Console.WriteLine($"{heroe.Nombre} ha vencido a {enemigo.Nombre} y gana {enemigo.ObtenerPv()} VP");

                               
                            }
                        }
                    }
                }
            }
        }

        // Final Batalla:
        if (heroes.All(h => h.Vida <= 0))
        {
            Console.WriteLine("Todos los héroes han muerto. Los enemigos ganan.");
        }
        else if (enemigos.All(e => e.Vida <= 0))
        {
            Console.WriteLine("Todos los enemigos han muerto. Los héroes ganan.");
        }
    }
}
        
    

