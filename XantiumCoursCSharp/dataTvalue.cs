namespace XantiumCoursCSharp
{
	public static class dataTvalue  // class static pour y avoir accès partout 
	{
       public static string SafeFormat(this string fmt, params object[] args) // le this string fmt c'est la partie gauche de la fonction > "ici".SafeFormat() et le params object[] args est dans la fonction "Gauche".SafeFormat("ici") <
       {
           try
           {
               return String.Format(fmt, args); // si tout se passe bien ici on return le nouveau string formater 
           }
           catch (FormatException) { return fmt; } //si on à une erreur on return le string de base dans rien de plus ou moins
       }

        public static void Shuffle<T>(this Random rng, List<T> array) // ici on get une value T qu'on le connais pas comme au dessus le this Random rng c'est la parti gauche de la fonction
                                                                  // la partie droite celle dans la fonction 
        {
            int n = array.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                (array[k], array[n]) = (array[n], array[k]);
            }
        } 
    }
}

