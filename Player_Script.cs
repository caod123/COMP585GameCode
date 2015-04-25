/// <summary>
/// 2D Space Shooter Example
/// By Bug Games www.Bug-Games.net
/// Programmer: Danar Kayfi - Twitter: @DanarKayfi
/// Special Thanks to Kenney for the CC0 Graphic Assets: www.kenney.nl
/// 
/// This is the Player Ship Script:
/// - Player Ship Movement
/// - Fire Control
/// - Screen Boundary Control
/// - Explosion/Game Over Trigger
/// 
/// </summary>

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, yMin, yMax; //Screen Boundary dimentions checking 
}

public class Player_Script : MonoBehaviour 
{
	//Public Var
	public float speed; 			//Player Ship Speed
	public float rotationSpeed;		//Player Ship Rotation Speed
	public Boundary boundary; 		//make an Object from Class Boundary
	public Transform shotSpawn;		//Where the Fire Spawn
	private GameObject shot;
	public float fireRate = 0.01F;	//Fire Rate between Shots
	public GameObject Explosion;	//Explosion Prefab

	//Private Var
	private float nextFire = 0.0F;	//First fire & Next fire Time


	// Update is called once per frame
	void Update () 
	{
			//Excute When the Current Time is bigger than the nextFire time
			if ((SharedValues_Script.protons > 0) && Input.GetKeyUp (KeyCode.Q) && Time.time > nextFire) {
				nextFire = Time.time + fireRate; 								//Increment nextFire time with the current system time + fireRate
				shot = Resources.Load("Prefabs/PlayerShip-Laser-Red", typeof(GameObject)) as GameObject;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation); 	//Instantiate fire shot 
				GetComponent<AudioSource> ().Play (); 							//Play Fire sound
				SharedValues_Script.protons -= 1;
			}

		//Excute When the Current Time is bigger than the nextFire time
		if ((SharedValues_Script.electrons > 0) && Input.GetKeyUp (KeyCode.E) && Time.time > nextFire) {
			nextFire = Time.time + fireRate; 								//Increment nextFire time with the current system time + fireRate
			shot = Resources.Load("Prefabs/PlayerShip-Laser-Green", typeof(GameObject)) as GameObject;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); 	//Instantiate fire shot 
			GetComponent<AudioSource> ().Play (); 							//Play Fire sound
			SharedValues_Script.electrons -= 1;
		}

		//Excute When the Current Time is bigger than the nextFire time
		if ((SharedValues_Script.neutrons > 0) && Input.GetKeyUp (KeyCode.W) && Time.time > nextFire) {
			nextFire = Time.time + fireRate; 								//Increment nextFire time with the current system time + fireRate
			shot = Resources.Load("Prefabs/PlayerShip-Laser-Blue", typeof(GameObject)) as GameObject;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); 	//Instantiate fire shot 
			GetComponent<AudioSource> ().Play (); 							//Play Fire sound
			SharedValues_Script.neutrons -= 1;
		}

		if (Input.GetKeyUp (KeyCode.Space) && SharedValues_Script.protons > 0) {
			Element.synthesizeElement(SharedValues_Script.protons, SharedValues_Script.neutrons, SharedValues_Script.electrons);
		}

	}

	// FixedUpdate is called one per specific time
	void FixedUpdate ()
	{
		float rotate = Input.GetAxis ("Horizontal"); 				//Get if Any Horizontal Keys pressed
		float moveVertical = Input.GetAxis ("Vertical");					//Get if Any Vertical Keys pressed
//		GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.up) * moveVertical * speed; 							//Add Velocity to the player ship rigidbody
	//	GetComponent<Rigidbody2D>().angularVelocity = -rotate*100;
	    Vector3 newRotation = transform.rotation.eulerAngles;
    	newRotation.z -= rotationSpeed*rotate;
    	transform.rotation = Quaternion.Euler (newRotation);

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
			GetComponent<Rigidbody2D> ().velocity = transform.TransformDirection (Vector3.up) * moveVertical * speed;
		else {
			if (GetComponent<Rigidbody2D> ().velocity != Vector2.zero) {
				GetComponent<Rigidbody2D> ().velocity *= 0.99f;
			}
		}
		//Lock the position in the screen by putting a boundaries
		if ((GetComponent<Rigidbody2D>().position.x >= boundary.xMax) ||
		(GetComponent<Rigidbody2D>().position.x <= boundary.xMin) ||
		(GetComponent<Rigidbody2D>().position.y >= boundary.yMax) ||
		(GetComponent<Rigidbody2D>().position.y <= boundary.yMin)) 
		GetComponent<Rigidbody2D>().position = new Vector2 
			(
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),  //X
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)	 //Y
			);
	}

	//Called when the Trigger entered
	void OnTriggerEnter2D(Collider2D other)
	{
		//Execute if the object tag was equal to one of these
		if ((other.tag == "Enemy" || other.tag == "EnemyShot") && SharedValues_Script.lives > 0) 
		{
			Instantiate (Explosion, transform.position , transform.rotation); 				//Instantiate Explosion
			SharedValues_Script.lives -= 1;
			Destroy(other.gameObject); 															//Destroy other object
		}

		//Excute if the object tag was equal to one of these
		if((other.tag == "Enemy" || other.tag == "EnemyShot") && SharedValues_Script.lives == 0) 
		{
			Instantiate (Explosion, transform.position , transform.rotation); 				//Instantiate Explosion
			SharedValues_Script.gameover = true; 											//Trigger That its a GameOver
			Destroy(gameObject); 															//Destroy Player Ship Object
		}
	}
}
