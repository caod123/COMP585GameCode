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
using System.Collections;

public class SharedValues_Script : MonoBehaviour 
{
	//Public Var
	public GUIText scoreText; 				//GUI Score
	public GUIText GameOverText; 			//GUI GameOver
	public GUIText FinalScoreText; 			//GUI Final Score
	public GUIText ReplayText; 				//GUI Replay
	public GUIText inventoryText;			//GUI Inventory
	public GUIText MenuText;				//GUI Menu
	public GUIText elementText;				//GUI Element
	public GUIText livesText;				//GUI Lives

	//Public Shared Var
	public static int score = 0; 			//Total in-game Score
	public static int protons = 0;		//Total in-game Protons
	public static int electrons = 0;		//Total in-game Electrons
	public static int neutrons = 0;		//Total in-game Neutrons
	public static bool gameover = false; 	//GameOver Trigger
	public static string element = "";	//Element that was synthesized
	public static int lives = 3;
	public static float elementTime = 0.0F;

	// Use this for initialization
	void Start () 
	{
		gameover = false; 					//return the Gameover trigger to its initial state when the game restart
		score = 0; 							//return the Score to its initial state when the game restart
		protons = 0;						//return the Protons to its initial state when the game restarts
		electrons = 0;						//return the Electrons to its initial state when the game restarts
		neutrons = 0;						//return the Neutrons to its initial state when the game restarts
		element = "";						//return the Element to its initial state when the game restarts
		lives = 3;						//return the Lives to its initial state when the game restarts
		elementTime = 0.0F;						//return the Element Time to its initial state when the game restarts
	}

	// Fixed Update is called one per specific time
	void FixedUpdate ()
	{
		scoreText.text = "Score: " + score; 			//Update the GUI Score
		inventoryText.text = "[Q] Protons: " + protons + "\n[W] Electrons: " + electrons + "\n[E] Neutrons: " + neutrons;	//Update the inventory
		livesText.text = "Lives: " + lives;

		if (elementTime > 0) {
			elementText.text = element;
			elementTime -= 1;
		} else {
			elementText.text = "";
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
