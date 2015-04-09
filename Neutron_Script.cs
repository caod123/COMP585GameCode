/// <summary>
/// 2D Space Shooter Example
/// By Bug Games www.Bug-Games.net
/// Programmer: Danar Kayfi - Twitter: @DanarKayfi
/// Special Thanks to Kenney for the CC0 Graphic Assets: www.kenney.nl
/// 
/// This is the Neutron Script:
/// - Normal & Angular Velocity
/// - Hit/Explosion on Trigger Enter
/// 
/// </summary>

using UnityEngine;
using System.Collections;

public class Neutron_Script: MonoBehaviour 
{
	//Public Var
	public float maxTumble; 			//Maximum Speed of the angular velocity
	public float minTumble; 			//Minimum Speed of the angular velocity
	public float speed; 				//Neutron Speed
	public int health; 					//Neutron Health (how much hit can it take)
	public GameObject LaserGreenHit; 	//LaserGreenHit Prefab
	public GameObject Explosion; 		//Explosion Prefab
	public int ScoreValue; 				//How much the Neurton give score after explosion
	
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D>().angularVelocity = Random.Range(minTumble, maxTumble); 		//Angular movement based on random speed values
		GetComponent<Rigidbody2D>().velocity = -1 * transform.up * speed; 						//Negative Velocity to move down towards the player ship
	}
	
	//Called when the Trigger entered
	void OnTriggerEnter2D(Collider2D other)
	{
		//Excute if the object tag is equal to player
		if(other.tag == "Player")
		{
			Instantiate (Explosion, transform.position , transform.rotation); 		//Instantiate Explosion
			SharedValues_Script.score +=ScoreValue; 								//Increment score by ScoreValue
			SharedValues_Script.neutrons += 1;										//Increment neutron
			Destroy(gameObject); 													//Destroy the Neutron
		}
	}
}