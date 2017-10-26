using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;
using UnityEngine.UI;
public class Scoreboard : MonoBehaviour {

	public Text[] textBox;
	private int counter = 0;

	// Use this for initialization
	void Start () {

		String folderpath = "./Data/";

		// Write dummy data if nothing is here yet / first run
		if (!Directory.Exists(folderpath)) {
			Directory.CreateDirectory(folderpath);
		}

		// For every level, load in highscores
		for (int i = 1; i <= 3; ++i) {

			String filepath = "./Data/highscore_level_" + i + ".txt";

			// If file hasnt been created everything must be 0
			if (!System.IO.File.Exists (filepath)) {
				textBox[counter++].text = 0 + "";
				textBox[counter++].text = 0 + "";
				continue;
			}

			String [] lines = new String[2];
			lines = System.IO.File.ReadAllLines(filepath);

			textBox[counter++].text = lines[0];
			textBox[counter++].text = lines[1];
		}
	}
}
