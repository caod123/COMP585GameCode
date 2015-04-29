/// <summary>
/// 2D Space Shooter Example
/// By Bug Games www.Bug-Games.net
/// Programmer: Danar Kayfi - Twitter: @DanarKayfi
/// Special Thanks to Kenney for the CC0 Graphic Assets: www.kenney.nl
/// 
/// This is the SharedValues Script:
/// - Shared Value Script between all other scripts
/// - In-Game & GameOver GUI
/// 
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SharedValues_Script : MonoBehaviour 
{
	//Public Var
	public GUIText scoreText; 				//GUI Score
	public GUIText GameOverText; 			//GUI GameOver
	public GUIText FinalScoreText; 			//GUI Final Score
	public GUIText ReplayText; 				//GUI Replay
	public GUIText protonText;			//GUI Protons
	public GUIText electronText;			//GUI Electrons
	public GUIText neutronText;			//GUI Neutrons
	public GUIText MenuText;				//GUI Menu
	public GUIText elementText;				//GUI Element
	public GUIText livesText;				//GUI Lives
	public GUIText extraLifeText;			//GUI Extra Life
	public GUIText synthesizableText;		//GUI Synthesizable Element

	//Public Shared Var
	public static int score = 0; 			//Total in-game Score
	public static int previousScore = 0; 			//Total in-game Previous Score
	public static int protons = 0;		//Total in-game Protons
	public static int electrons = 0;		//Total in-game Electrons
	public static int neutrons = 0;		//Total in-game Neutrons
	public static bool gameover = false; 	//GameOver Trigger
	public static string element = "";	//Element that was synthesized
	public static int lives = 3;			//Total in-game Lives
	public static float elementTime = 0.0F;	//Time to show last synthesized element
	public static float extraLifeTime = 0.0F;	//Time to show the extra life given
	public static bool extraLifeGiven = false;  //ExtraLife Trigger
	public static int cluster = 0;			//Total in-game Cluster amount
	public static float clusterTime = 0.0F;	//Time to show the cluster amount
	public static string particle = "";		//Particle that was just collected

	// Use this for initialization
	void Start () 
	{
		gameover = false; 					//return the Gameover trigger to its initial state when the game restart
		score = 0; 							//return the Score to its initial state when the game restart
		previousScore = 0; 							//return the Previous Score to its initial state when the game restart
		protons = 0;						//return the Protons to its initial state when the game restarts
		electrons = 0;						//return the Electrons to its initial state when the game restarts
		neutrons = 0;						//return the Neutrons to its initial state when the game restarts
		element = "";						//return the Element to its initial state when the game restarts
		lives = 3;						//return the Lives to its initial state when the game restarts
		elementTime = 0.0F;						//return the Element Time to its initial state when the game restarts
		extraLifeTime = 0.0F;						//return the Extra Life Time to its initial state when the game restarts
		extraLifeGiven = false; 					//return the Extra Life trigger to its initial state when the game restart
		cluster = 0;						//return the Cluster to its initial state when the game restarts
		clusterTime = 0.0F;						//return the Cluster Time to its initial state when the game restarts
		particle = "";						//return the Particle to its initial state when the game restarts
	}

	// Fixed Update is called one per specific time
	void FixedUpdate ()
	{
		scoreText.text = "Score: " + score; 			//Update the GUI Score
		livesText.text = "x " + lives; //Update the lives
		synthesizableText.text = "[Space]: " + Element.getSynthesizableElement (protons, neutrons, electrons);

		//Update the element Text
		if (elementTime > 0) {
			elementText.text = element;
			elementTime -= 1;
		} else {
			elementText.text = "";
		}

		//Update the inventory and the cluster collected amount
		if (particle == "protons" && clusterTime > 0) {
			protonText.text = protons + "\n+" + cluster + " P+"; //Update the protons
			clusterTime -= 1;
		} else if (particle == "electrons" && clusterTime > 0) {
			electronText.text = electrons + "\n+" + cluster + " e-";	//Update the electrons
			clusterTime -= 1;
		} else if (particle == "neutrons" && clusterTime > 0) {
			neutronText.text = neutrons + "\n+" + cluster + " N";	//Update the neutrons
			clusterTime -= 1;
		} else {
			protonText.text = "" + protons;
			electronText.text = "" + electrons;
			neutronText.text = "" + neutrons;
		}

		//Check to see if extra life should be given
		if (score >= previousScore + 1000) {
			previousScore = score;
			extraLifeGiven = true;
		}

		//Give an extra life
		if (extraLifeGiven) {
			lives += 1;
			extraLifeGiven = false;
			extraLifeTime = 100.0F;
		}

		if (extraLifeTime > 0) {
			extraLifeText.text = "You earned an extra life";
			extraLifeTime -= 1;
		} else {
			extraLifeText.text = "";
		}

		//Excute when the GameOver Trigger is True
		if (gameover == true)
		{
			GameOverText.text = "GAME OVER"; 			//Show GUI GameOver
			FinalScoreText.text = "" + score; 			//Show GUI FinalScore
			if (!PlayerPrefs.HasKey ("hiscore"))
				PlayerPrefs.SetInt ("hiscore", 0);
			if (score > PlayerPrefs.GetInt ("hiscore"))
				PlayerPrefs.SetInt ("hiscore", score);
			ReplayText.text = "PRESS R TO REPLAY"; 		//Show GUI Replay
			MenuText.text = "PRESS M TO RETURN TO MENU";
		}
	}

}
