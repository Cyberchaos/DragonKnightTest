using System;

    public class Dragon : AttackingUnit {
        public Dragon(int hp, int atk, int def, int dodge,int crit) : base(hp,atk,def,dodge,crit)
        {

        }

        ~Dragon()
        {
           // Console.WriteLine("The dragon has fallen.");
        }
      
    }
