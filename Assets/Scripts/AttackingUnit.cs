using System;
using UnityEngine;

    public abstract class AttackingUnit {
        private int hp, atk, def, dodge,crit, maxHP;
        private System.Random r;

        public int Hp
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }

        public int Atk
        {
            get
            {
                return atk;
            }

            set
            {
                atk = value;
            }
        }

        public int Def
        {
            get
            {
                return def;
            }

            set
            {
                def = value;
            }
        }

        public int Dodge
        {
            get
            {
                return dodge;
            }

            set
            {
                dodge = value;
            }
        }

        public int Crit
        {
            get
            {
                return crit;
            }

            set
            {
                crit = value;
            }
        }

    public int MaxHP
    {
        get
        {
            return maxHP;
        }

        set
        {
            maxHP = value;
        }
    }

    public AttackingUnit(int hp, int atk, int def, int dodge, int crit)
        {
            this.Hp = hp;
        this.MaxHP = hp;
            this.Atk = atk;
            this.Def = def;
            this.Dodge = dodge;
            this.Crit = crit;
            r = new System.Random();
        }

        public bool DodgeAttack() {
            bool returnVal = false;

            int chance = r.Next(1, 101);
            if (chance <= Dodge)
                returnVal = true;

            return returnVal;
        }

        public int critDamage()
        {
            return 3 * Atk;
        }

        public int Damage(AttackingUnit enemy, int damage)
        {
            damage -= enemy.Def;
            enemy.Hp -= damage;
            if (enemy.Hp < 0)
            {
                enemy.Hp = 0;
            }

            return damage;
        }

        public bool isDead()
        {
            if (Hp <= 0)
                return true;
            else return false;
        }

        public void AttackEnemy(AttackingUnit enemy)
        {
            if (enemy != null && !enemy.DodgeAttack())
            {
                int atkDamage;

                int chance = r.Next(1, 101);
                if (chance <= Crit)
                    atkDamage = critDamage();
                else atkDamage = Atk;
                atkDamage = Damage(enemy, atkDamage);
                Debug.Log(this.GetType().ToString() + " did " + atkDamage + " to the " + enemy.GetType().ToString());
            }
            else Debug.Log("The " + enemy.GetType().ToString() + " dodged!");
        }

    }
