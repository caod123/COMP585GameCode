/// <summary>
/// 2D Space Shooter Example
/// By Bug Games www.Bug-Games.net
/// Programmer: Danar Kayfi - Twitter: @DanarKayfi
/// Special Thanks to Kenney for the CC0 Graphic Assets: www.kenney.nl
/// 
/// This is the Electron Script:
/// - Normal & Angular Velocity
/// - Hit/Explosion on Trigger Enter
/// 
/// </summary>

using UnityEngine;
using System.Collections;

public class Electron_Script : MonoBehaviour 
{
	//Public Var
	public float maxTumble; 			//Maximum Speed of the angular velocity
	public float minTumble; 			//Minimum Speed of the angular velocity
	public float speed; 				//Electron Speed
	public int health; 					//Electron Health (how much hit can it take)
	public GameObject LaserGreenHit; 	//LaserGreenHit Prefab
	public GameObject Explosion; 		//Explosion Prefab
	public int ScoreValue; 				//How much the Electron give score after explosion
	private int ammount;
	private static float scale = 0.03f;
	
	// Use this for initialization
	void Start () 
	{
		speed = Random.Range (1, 3);
		ammount = Random.Range(1, 5);
		GetComponent<Rigidbody2D>().angularVelocity = Random.Range(minTumble, maxTumble); 		//Angular movement based on random speed values
		GetComponent<Rigidbody2D>().velocity = -1 * transform.up * speed; 						//Negative Velocity to move down towards the player ship
		transform.localScale += new Vector3((float)ammount*scale, (float)ammount*scale, (float)ammount*scale);
	}
	
	//Called when the Trigger entered
	void OnTriggerEnter2D(Collider2D other)
	{
		//Excute if the object tag is equal to player
		if(other.tag == "Player")
		{
			Instantiate (Explosion, transform.position , transform.rotation); 		//Instantiate Explosion
			SharedValues_Script.score +=ScoreValue; 								//Increment score by ScoreValue
			SharedValues_Script.electrons += ammount;										//Increment electron
			Destroy(gameObject); 													//Destroy the Electron
		}
	}
}