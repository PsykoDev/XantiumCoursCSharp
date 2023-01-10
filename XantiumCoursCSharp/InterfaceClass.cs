namespace XantiumCoursCSharp
{
	public class InterfaceClass : ImyMusic // on ajoute l'interface ici pour y avoir accès 
	{
		public InterfaceClass()
		{
		}

        public void Music() // on import la fonction qu'elle contient ( sinon ça fait une errue logique ) 
        {
            Console.WriteLine("Meow Sound c'est pas mal"); // ici on fait le code 
        }

        public void Musicnormal() // un fonction normal hors interface
        {
            Console.WriteLine("Meow Sound c'est pas mal"); // ici on fait le code 
        }
    }
}

