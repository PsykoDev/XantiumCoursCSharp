
namespace XantiumCoursCSharp
{
	sealed class StaticClassDemo
	{
		string MyconstructorText { get; set; }
		public StaticClassDemo(string textNonStaticAvecConstucteur) // constructeur de la class ( peux être delete si pas besoin ou en cas de besoin static ) 
		{
			MyconstructorText = textNonStaticAvecConstucteur; // init de la valeur via le constructeur 
        }

		public static void PrintDesTrucs(string text) // la fonction static qui peux être get en direct via le nom de la class mais pas via le constructeur
		{
			Console.WriteLine("Static Class Print: "+ text);
        }


        public void PrintNonStatic() // la fonction qui peux être get uniquement via le constructeur mais impossible via le nom de la class
		{
            Console.WriteLine("Class Print: " + MyconstructorText);
        }
	}
}