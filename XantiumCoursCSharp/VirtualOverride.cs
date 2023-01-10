namespace XantiumCoursCSharp
{
    public enum Race
    {
        Humain,
        Orc,
        Meow,
        NPC
    }

    public class VirtualOverride // la class defaut pour les autres player 
	{

        private int Pv { get; set; } = -1;
        private int Mp { get; set; } = -1;
        private Race race { get; set; }

        public VirtualOverride(int pv, int mp, Race race) // build mon player
		{
			Pv = pv;
			Mp = mp;
			this.race = race; // le this sert a focus celui du get set a cause du même nom entre les 2
		}

        public virtual void attack(string v) // j'init ma fonction defaut en virtual qui est l'attack
        {
            Console.WriteLine(v);
        }
	}


    class Humain : VirtualOverride // build player humain
    {
        private int Pv { get; set; }
        private int Mp { get; set; }
        private Race race { get; set; }
        private int srpint { get; set; }

        public Humain(int pv, int mp,int sprintTime ,Race race = Race.Humain) : base(pv, mp, race)
        {
            Pv = pv;
            Mp = mp;
            srpint = sprintTime;
            this.race = race; // le this sert a focus celui du get set a cause du même nom entre les 2
        }

        public override void attack(string v) // ici on override la fonction defaut par celle qui correspond a notre class 
        {
            base.attack($"Attack {race}");
        }

        public void Sprint() // on lui ajoute une autre capacité que les autre n'auront pas comme le sprint
        {
            Console.WriteLine($"Sprint {race}");
        }
    }

    class Orc : VirtualOverride // build player Orc
    {
        private int Pv { get; set; }
        private int Mp { get; set; }
        private Race race { get; set; }
        private int block { get; set; }

        public Orc(int pv, int mp,int blockCapacity ,Race race = Race.Orc) : base(pv, mp, race)
        {
            Pv = pv;
            Mp = mp;
            block = blockCapacity;
            this.race = race; // le this sert a focus celui du get set a cause du même nom entre les 2
        }

        public override void attack(string v)
        {
            base.attack($"Attack {race}");
        }

        public void Block() // on lui ajoute une autre capacité que les autre n'auront pas comme le Block
        {
            Console.WriteLine($"Block {race}");
        }
    }

    class Meow : VirtualOverride // build player Meow
    {
        private int Pv { get; set; }
        private int Mp { get; set; }
        private Race race { get; set; }
        private int jump { get; set; }

        public Meow(int pv, int mp,int MaxJump, Race race = Race.Meow) : base(pv, mp, race)
        {
            Pv = pv;
            Mp = mp;
            jump = MaxJump;
            this.race = race; // le this sert a focus celui du get set a cause du même nom entre les 2
        }

        public override void attack(string v)
        {
            base.attack($"Attack {race}");
        }

        public void DoubleJump() // on lui ajoute une autre capacité que les autre n'auront pas comme le DoubleJump
        {
            Console.WriteLine($"DoubleJump {race}");
        }
    }
}

