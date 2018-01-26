using System;



    public class Knight : AttackingUnit {

        public Knight(int hp, int atk, int def, int dodge,int crit) : base(hp,atk,def,dodge,crit)
        {

        }

        ~Knight()
        {
           // Console.WriteLine("The knight has fallen.");
        }
    }
