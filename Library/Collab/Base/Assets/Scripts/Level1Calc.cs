using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level1Calc : MonoBehaviour {
    int[] hp = new int[6] {4500, 3000, 1000, 1000, 1000, 1000 };
    int[] dd = new int[6] { 0, 0, 0, 0, 0, 0 };
    bool gameOver = false;
    int dTemp = 0;
    System.Random rnd = new System.Random();
	
    // Use this for initialization
	void Start () {
        for (int i = 0; i < 6; i++)
        {
            if (hp[i] <= 0)
            {
                gameOver = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (gameOver == true)
        {
            // end game code here
        }

        else
        {

            // Boss Damage
            dTemp = rnd.Next(45, 56);
            hp[1] -= dTemp;
            dd[0] += dTemp;
            for (int j = 2; j < 6; j++)
            {
                dTemp = rnd.Next(5, 21);
                hp[j] -= dTemp;
                dd[0] = dTemp;
            }


            // Warrior Damage
            hp[0] -= 5;
            dd[1] += 5;



            // Rogue Damage
            dTemp = rnd.Next(15, 21);
            hp[0] -= dTemp;
            dd[2] += dTemp;


            // Mage Damage
            dTemp = rnd.Next(1, 31);
            hp[0] -= dTemp;
            dd[3] += dTemp;


            // Moonkin Damage

            dTemp = rnd.Next(5, 15);
            hp[0] -= dTemp;
            dd[4] += dTemp;


            //Priest Damage = 0

            //Priest Healing

        }

	}
}
