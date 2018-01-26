using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEngine : MonoBehaviour {
    private AttackingUnit[] units = new AttackingUnit[2];
    private bool gameOngoing = true;
    private int gameTime = 0;
    private const int REFRESH = 60;

    public AttackingUnit[] Units
    {
        get
        {
            return units;
        }

        set
        {
            units = value;
        }
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Fuckin MEMEZ mEmEZZZZZZZZZ MeMeZZZZssss");

        Instantiate(Resources.Load("Dragon"), new Vector3(1, 0, -1), Quaternion.identity);
        Instantiate(Resources.Load("Knight"), new Vector3(-2, -1, -1), Quaternion.identity);

        GameObject hp = (GameObject)Instantiate(Resources.Load("hp20"), new Vector3(1, 1, -2), Quaternion.identity);
        hp.transform.localScale = new Vector3(2, 2, 2);

        Instantiate(Resources.Load("hp20"), new Vector3(-2, -0.5f, -2), Quaternion.identity);

        playing();

    }

    void playing() {
        units[0] = new Knight(300, 80, 30, 90, 33);
        units[1] = new Dragon(1500, 120, 60, 0, 25);
    }

    public void playGame()
    {
        
        System.Random r = new System.Random();

            int starter = r.Next(0, 2);
            if (starter == 0)
            {
                //Knight starts
                if (!units[0].isDead())
                {
                    units[0].AttackEnemy(units[1]);
                    if (!units[1].isDead())
                    {
                        units[1].AttackEnemy(units[0]);
                    }
                    else gameOngoing = false;
                    Debug.Log("Knight's HP: " + units[0].Hp + "\nDragon's HP: " + units[1].Hp);
                }
                else

                    gameOngoing = false;
            }
            else
            {
                //dragon starts
                if (!units[1].isDead())
                {
                    units[1].AttackEnemy(units[0]);
                    if (!units[0].isDead())
                    {
                        units[0].AttackEnemy(units[1]);
                    }
                    else gameOngoing = false;
                    Debug.Log("Knight's HP: " + units[0].Hp + "\nDragon's HP: " + units[1].Hp);

                }
                else
                    gameOngoing = false;
            }
  
        if (units[0].isDead())
        {
            Debug.Log("The Dragon won this fight!");
            gameOngoing = false;
        }
        if (units[1].isDead())
        {
            Debug.Log("The Knight won this fight!");
            gameOngoing = false;
        };
    }

    // Update is called once per frame
    void Update () {
        gameTime++;
        if (gameTime % REFRESH == 0)
        {
            if (gameOngoing)
            playGame();
            redraw();
        }
    }

    void redraw() {
        GameObject[] deleteMe = GameObject.FindGameObjectsWithTag("DeleteMe");
        foreach (GameObject temp in deleteMe)
        {
            Destroy(temp.gameObject);
        }
        if (!units[0].isDead()) {
            Instantiate(Resources.Load("Knight"), new Vector3(-2, -1, -1), Quaternion.identity);
            Instantiate(Resources.Load(determineHP(units[0].Hp, units[0].MaxHP)), new Vector3(-2, -0.5f, -2), Quaternion.identity);
        }
        if (!units[1].isDead())
        {
            Instantiate(Resources.Load("Dragon"), new Vector3(1, 0, -1), Quaternion.identity);
            GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(units[1].Hp, units[1].MaxHP)), new Vector3(1, 1, -2), Quaternion.identity);
            hp.transform.localScale = new Vector3(2, 2, 2);
        }
    }


    void lol() {
        //Delete everything on stage

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("GetRekt");
        foreach (GameObject child in allObjects)
        {
            Destroy(child.gameObject);
        }
        //Redraw sprites if not dead
        if (!Units[0].isDead())
        {
            
            Instantiate(Resources.Load("Knight"), new Vector3(-2, -1, -1), Quaternion.identity);
            Instantiate(Resources.Load(determineHP(Units[0].Hp, Units[0].MaxHP)), new Vector3(-2, -0.5f, -2), Quaternion.identity);
        }
        if (!Units[1].isDead())
        {
            Instantiate(Resources.Load("Dragon"), new Vector3(1, 0, -1), Quaternion.identity);
            GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(Units[1].Hp, Units[1].MaxHP)), new Vector3(1, 1, -2), Quaternion.identity);
            hp.transform.localScale = new Vector3(2, 2, 2);
        }
    }

    string determineHP(int hp, int MaxHP)
    {
        string returnVal = "hp";
        double hpPerc = ((double)hp / (double)MaxHP) * 20;
        hpPerc = Math.Ceiling(hpPerc);
        int roundHP = Convert.ToInt32(hpPerc);
        returnVal += roundHP;
        return returnVal;
    }
}
