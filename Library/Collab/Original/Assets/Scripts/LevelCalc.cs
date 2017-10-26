using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class LevelCalc : MonoBehaviour {
	
	private int [] hp = new int[6] {4500, 3000, 1000, 1000, 1000, 1000 };
    private int[] dd = new int[6] { 0, 0, 0, 0, 0, 0 };

	private int pMana = 1000;
	private int dTemp = 0;

	private System.Random rnd = new System.Random();
	private Vector3 backButtonOriginalPos;

	public int level;
	public Button backButton;
	public Text[] textBox;


	// Hide a button from 2D canvas
	void hideBackButton() {
		backButtonOriginalPos = backButton.transform.position;

		Vector3 pos = backButton.transform.position;
		pos.x -= 1000f;
		backButton.transform.position = pos;
	}


	// Unhide this same button
	void showBackButton() {
		backButton.transform.position = backButtonOriginalPos;
	}


	// Called once at init
    void Start() {
		hideBackButton();
    }


	// Write into csv highscores
	void writeHighScoreIntoFile() {

		// Get scores
		int partyDamage = dd[1] + dd[2] + dd[3] + dd[4] + dd[5];
		int bossDamage = dd[0];

		// Determine if higher than previous runs, rewrite if so
		// Start by reading old score

		String filepath = "./CSV/highscore_level_" + level + ".txt";
		String [] lines = new String[2];
		lines = System.IO.File.ReadAllLines(filepath);

		int oldPartyDamage = Convert.ToInt32(lines[0]);
		int oldBossDamage = Convert.ToInt32(lines[1]);

		String pdam = (partyDamage > oldPartyDamage ? partyDamage : oldPartyDamage).ToString();
		String bdam = (bossDamage > oldBossDamage ? bossDamage : oldBossDamage).ToString();

		System.IO.File.WriteAllText(filepath, pdam + "\n" + bdam);
	}




    // Update is called once per frame
    void Update () {

		// Check if anyone died, if so, present option to return to main menu
        for (int i = 0; i < 6; i++) {
            if (hp[i] <= 0) {

				// Determine who died, take appropriate action
				if (i == 0) { // Boss died -- You Win

					backButton.GetComponentInChildren<Text>().text = "You Win! Main Menu";

				} else { // You Lose
					backButton.GetComponentInChildren<Text>().text = "You Lose! Main Menu";

				}


				// GAME OVER, reset everything
				showBackButton();
				writeHighScoreIntoFile ();
				return;
            }
        }


		// Change conditions 
		if (level == 1) {

		}


        
		// Boss Damage
		dTemp = rnd.Next(45, 56);
		hp[1] -= dTemp;
		dd[0] += dTemp;

		for (int j = 2; j < 6; j++)
		{
			dTemp = rnd.Next(5, 21);
			hp[j] -= dTemp;
			dd[0] += dTemp;
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

		// Cast Small Heal

		// give the Preist 2 slots in the heal roulette
		dTemp = rnd.Next(2, 7);
		if(dTemp == 6)
		{
			dTemp = 5;
		}
		// update hp and mana
		hp[dTemp] += 15;
		pMana -= 5;

		// Cast Big Heal
		hp[1] += 20;
		pMana -= 8;

		// Mana Regen
		pMana += 2;

        if (level == 2)
        {
            dTemp = rnd.Next(0, 2);
            if(dTemp == 0)
            {
                // Cast Big Heal
                hp[1] += 20;
                pMana -= 8;
            }
            else
            {
                // Cast Small Heal
                dTemp = rnd.Next(2, 7);
                if (dTemp == 6)
                {
                    dTemp = 5;
                }
            }
        }else if (level == 3)
        {
            dTemp = Mathf.RoundToInt(dd[0]/100);
            hp[1] -= dTemp;
            dd[0] += dTemp;
        }



		String [] allHealths = new String[6];
		StringBuilder healthStringBuilder = new StringBuilder();
		
		// Write health onto canvas AND csv file
		for (int i = 0; i < 6; ++i) {
			String health = hp[i].ToString();

			textBox[i+12].text = health;
			allHealths[i] = health;
		}

		// Write a single line into csv containing every player's health
		healthStringBuilder.AppendLine(string.Join(",", allHealths));
		System.IO.File.AppendAllText("./CSV/health_level_" + level + ".csv", healthStringBuilder.ToString());


		// Write damage dealt onto canvas
		textBox[18].text = dd[0].ToString();
		textBox[19].text = dd[1].ToString();
		textBox[20].text = dd[2].ToString();
		textBox[21].text = dd[3].ToString();
		textBox[22].text = dd[4].ToString();
		textBox[23].text = dd[5].ToString();
	}
}
