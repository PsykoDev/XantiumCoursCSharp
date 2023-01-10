namespace XantiumCoursCSharp;
class Program
{
    #region les enums
    enum Season
    {
        Summer, Fall, Winter, Spring
    }
    #endregion

    static string test = "0";

    static void Main(string[] args)
    {
        #region StaticClassDemo
        Console.WriteLine("StaticClassDemo\n");

        StaticClassDemo staticDemo = new("Non static print");

        staticDemo.PrintNonStatic(); // pour get un fonction non static on passe par un constucteur

        StaticClassDemo.PrintDesTrucs("Static class print"); // pour get un fonction static on peux le faire en direct avec le nom de la class

        #endregion

        #region les string / print
        Console.WriteLine("les string / print\n\n");

        Console.WriteLine($"Print {test}"); // le $ permet les { } pour y placer un variable ( très bon à utiliser sur Net7 pour les perfs ) 

        Console.WriteLine("Print " + test); // le + pour la concataination des strings ( pas dingue en perf parce qu'il fait un array pour tout combine en 1 string )

        Console.WriteLine(@"c:\test\rTest\nTest"); // le @ c'est pour les paths ( sans le @ le \t \r \n prend effet )

        int i = 0;    
        Console.WriteLine($"Print : {i.ToString()}"); // ici grace au $ on n'as pas besoin de faire un ToString() car ça le fait auto

        Console.WriteLine(); // \r print sur la même ligne et bouge le cursor a 0 après un print
                             // \t fait une tabulation
                             // \n saute un ligne

        Console.WriteLine("\n");
        #endregion

        #region init struct
        Console.WriteLine("init struct\n");

        List<string> tsts = new(); // init list type unique ( plus tu as d'element plus elle devient lent)

        Dictionary<string, string> dico = new(); // init dico 2 type ( linéaire, peux importe le nombre d'item ça reste très rapide )

        Queue<string> queue = new(); // init queue type unioque ajoute toujours la nouvelle data a la fin et unqueue la plus " vieille "

        PriorityQueue<string, int> priority = new(); // init de la queue a priorité, plus elle sera haute plus litem sera pris rapidement avec le unqueue

        ConcurrentQueue<string> cqueue = new(); // init de la ConcurrentQueue ( en cas de multi thread 1 thread peux prendre le owner sur elle et la lock le temps de faire se qu'il à besoin et release sont état après )

        HashSet<string> hash = new(); // init du hashSet qui est comme une list en bien plus rapide surtout pour de check dans beaucoup d'item grace au hash.containt(""); qui n'est pas dispo dans une list

        Stack<int> stack = new(); // init de la stack c'est comme en asm chaque item push dedans devras être retirer pour aller chercher celui que t'as besoin exemple en dessous

        stack.Push(0);
        stack.Push(1);
        //si je veux retouver mon 0 je dois retirer 1 avant retirer 0 et le stocker dans une var pour remettre le 1 dans la stack
        var un = stack.Pop(); // retourne le nombre 1
        var zero = stack.Pop(); // retourne le nombre 0

        stack.Push(un); // je remet 1 en place dans la stack 

        Console.WriteLine("\n");
        #endregion

        #region les interfaces
        Console.WriteLine("les interfaces\n");
        // une interface on la commence toujours par un I en maj exemple ( ImyMusic )

        InterfaceClass music = new(); // constructeur de la class

        var inter = (ImyMusic)music; // constructeur de l'interface

        inter.Music(); // get la fonction ( pour exemple ) de l'interface

        music.Musicnormal(); // get la fonction normal sans problème

        //inter.Musicnormal(); // ça ne marche pas vue que la fonction n'existe pas dans l'interface


        // autre expemple

        SportCar car = new("Meow");

        car.StartEngine();

        car.StopEngine();

        Console.WriteLine("\n");
        #endregion

        #region Les threads
        Console.WriteLine("Les threads\n");
        // comment on start un thread

        new Thread(() => { // start direct ici ( mais le code continue et ne l'attend pas )
            // mon code / fonction ici 
        });

        var thread =new Thread(() => { // ne start pas s'il ne rencontre pas le "  thread.Start(); " plus bas  ( mais le code continue et ne l'attend pas )
            // mon code / fonction ici 
        });
        thread.Start();

        Console.WriteLine("Avec Lock");
        Random random = new();
        for (int j = 1; j <= 10; j++)
            ThreadPool.QueueUserWorkItem(new WaitCallback(ShowNumber), j); // start 10 thread en " pool " ( ne sont pas detruit a la fin de leurs tâches )

        void ShowNumber(object number)
        {
            lock (random) // ici on lock le print pour 1 thread a la fois sinon c'est le bordel et il push quand c'est bon pour eux
            {
                Thread.Sleep(random.Next(500)); // ici on attend pour un print lent 
                Console.Write((int)number + ", ");
            }
        }

        Console.Read(); // obligé le stoppé le thread main sinon il fini sont execution et donc kill les autres thread qu'ils ai finit ou pas vu qu'il ne sont pas attendu 

        //sans lock: 8, 4, 9, 6, 1, 10, 7, 3, 2, 5
        //avec lock: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10

        Console.WriteLine("Sans Lock");
        Random random2 = new();
        for (int z = 1; z <= 10; z++)
            ThreadPool.QueueUserWorkItem(new WaitCallback(ShowNumber2), z); // start 10 thread en " pool " ( ne sont pas detruit a la fin de leurs tâches )

        void ShowNumber2(object number)
        {
            Thread.Sleep(random.Next(500)); // ici on attend pour un print lent 
            Console.Write((int)number + ", ");
        }

        Console.Read(); // obligé le stoppé le thread main sinon il fini sont execution et donc kill les autres thread qu'ils ai finit ou pas vu qu'il ne sont pas attendu 

        Console.WriteLine("\n");
        #endregion

        #region fonction
        Console.WriteLine("fonction\n");
        void F1() // fonction normal qui ne retourne rien 
        {
            Console.WriteLine("F1");
        }
        F1();

        string F2() // fonction qui retourne une data T
        {
            return "F2";
        }
        Console.WriteLine(F2());

        void F3(string text) // ne retourne rien mais prend un argument obligatoir
        {
            Console.WriteLine(text);
        }
        F3("F3");

        string F4(string text = "F4") // retourne une data T et possède un argument optionel
        {
            return text;
        }
        Console.WriteLine(F4());

        string F5(string autre) => autre; // la version one line qui retourne bien la data T
        Console.WriteLine(F5("F5"));

        // code dans dataTvalue.cs
        Console.WriteLine("{0} {1}".SafeFormat("F6", "Meow")); // au final on viens d'ajouter un fonction au type string

        tsts.Add("F7: F1");
        tsts.Add("F7: F2");
        tsts.Add("F7: F3");
        tsts.Add("F7: F4");
        tsts.Add("F7: F5");
        tsts.Add("F7: F6");
        tsts.Add("F7: F7");

        Random rng = new(); // on init le Random pour shuffle la list trop bien rangé au dessus
        // code dans dataTvalue.cs
        rng.Shuffle(tsts); // on balance la list dans le shuffle avec sont rng && on viens d'ajouter une fonction sur la class Random 

        tsts.ForEach(x => Console.WriteLine(x)); // on print la list après sont shuffle


        Console.WriteLine("\n");
        #endregion

        #region les enums
        Console.WriteLine("les enums\n");
        var hiver = Season.Winter; // get le string " Winter "
        var hivers = (int)Season.Winter; // get l'index dans l'enum de winter soit 2
        Console.WriteLine($"Normal {hiver}");
        Console.WriteLine($"int Cast {hivers}");

        Console.WriteLine("\n");
        #endregion

        #region Try Catch
        Console.WriteLine("Try Catch\n");
        try
        {
            // mon code qui est async ou a risque de cassé l'app s'il ne marche pas
            Console.WriteLine("Try\n");

            throw new Exception("ERROR"); // creation de l'erreur artificiel
        }
        catch (Exception e)
        {
            // le catch qui fait en sort qsue l'app reste en vie mais continue quand même
            Console.WriteLine("Catch\n");
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Finally\n");
            // se qu'on fait quoi qu'ill arrive que ça marche ou pas ( finally est optionnel )
        }

        Console.WriteLine("\n");
        #endregion

        #region Virtual Override Polymorphisme
        Console.WriteLine("Virtual Override Polymorphisme\n");

        VirtualOverride defautPlayer = new(-1, -1, Race.NPC); // NPC immortel
        defautPlayer.attack("Defaut attack"); // peux attack 


        Humain humain = new(pv: 10, mp: 500, sprintTime: 20); 
        humain.attack("Humain Attack");// peux attack 

        humain.Sprint(); // mais peux sprinter aussi


        Orc orc = new(pv: 10, mp: 500, blockCapacity: 1000);
        orc.attack("Orc Attack");// peux attack 

        orc.Block();// mais peux bloquer les coups aussi


        Meow meow = new(pv: 10, mp: 500, MaxJump: 2);
        meow.attack("Meow Attack");// peux attack 

        meow.DoubleJump();// mais peux double jump aussi

        Console.WriteLine("\n");
        #endregion

        #region unsafe
        int exemple2 = 1024;
        unsafe
        {
            // valid ou pas 
            int* p1, p2, p3;   // Ok
            // int* p1, *p2, *p3;   // Invalid in C#


            // exemple 1
            int[] a = new int[5] { 0, 20, 30, 40, 50 }; // on init un tableau de int 
            fixed (int* p = &a[0]) // on fix le pointeur p sur la ref du tableau a.First();
            {
                while (*p < a.Count()) // on deref p pour connaitre sa value qu'on compare a a.count();
                {
                    Console.WriteLine(a[*p]); // on print a deref de p 
                    *p += 1; // on deref p pour lui ajouter +1
                }
            }


            // exemple 2
            byte* exp2 = (byte*)&exemple2; // on implicite cast pour convertir de int en byte

            for (int b = 0; b < sizeof(int); ++b)
            {
                Console.Write(" {0:X2}", *exp2); // on print en hexa la value de exp2 converti en byte juste avant 
                // on ++ le byte* exp2 
                exp2++;
            }

            // exemple 3
            int val1 = 10;
            int val2 = 20;
            Meow(&val1, &val2);


            // Exemple 4
            Ptr ptr = new Ptr();
            Console.WriteLine("Avant le swap Swap: val1:{0}, val2: {1}", val1, val2);
            ptr.swap(&val1, &val2);
            Console.WriteLine("Après le swap Swap: val1:{0}, val2: {1}", val1, val2);
        }

        // un fonction unsafe qui n'est pas obligé d'être dans la balise unsafe pour être mise en place
        static unsafe void Meow(int* value, int* value2)
        {
            Console.WriteLine("Data is: {0} ", *value); // on deref value pour le print
            Console.WriteLine("Address is: {0X2}", (int)value);
            Console.WriteLine("Data is: {0} ", value->ToString()); // on met la value en string 
        }


        #endregion

        Console.WriteLine("Meow, World!");
    }
}



