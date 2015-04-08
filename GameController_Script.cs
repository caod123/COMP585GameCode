/// <summary>
/// 2D Space Shooter Example
/// By Bug Games www.Bug-Games.net
/// Programmer: Danar Kayfi - Twitter: @DanarKayfi
/// Special Thanks to Kenney for the CC0 Graphic Assets: www.kenney.nl
/// 
/// This is the GameController Script:
/// - Control The Waves of the asteroid and the enemies
/// 
/// </summary>

using UnityEngine;
using System.Collections;

//Asteroid Properties
[System.Serializable]
public class Asteroid 
{
	public GameObject asteroidBigObj; 		//Object Prefab
	public int Count; 						//Number of the object in 1 wave
	public float SpawnWait; 				//Time to wait before a new spawn
	public float StartWait; 				//Time to Start spawning
	public float WaveWait; 					//Time to wait till a new wave
}

//EnemyBlue Properties
[System.Serializable]
public class EnemyBlue 
{
	public GameObject enemyBlueObj;			//Object Prefab
	public int Count;						//Number of the object in 1 wave
	public float SpawnWait;					//Time to wait before a new spawn
	public float StartWait;					//Time to Start spawning
	public float WaveWait;					//Time to wait till a new wave
}

//EnemyGreen Properties
[System.Serializable]
public class EnemyGreen 
{
	public GameObject enemyGreenObj;		//Object Prefab
	public int Count;						//Number of the object in 1 wave
	public float SpawnWait;					//Time to wait before a new spawn
	public float StartWait;					//Time to Start spawning
	public float WaveWait;					//Time to wait till a new wave
}

//EnemyRed Properties
[System.Serializable]
public class EnemyRed 
{
	public GameObject enemyRedObj;		//Object Prefab
	public int Count;					//Number of the object in 1 wave
	public float SpawnWait;				//Time to wait before a new spawn
	public float StartWait;				//Time to Start spawning
	public float WaveWait;				//Time to wait till a new wave
}


public class GameController_Script : MonoBehaviour 
{	
	//Public Var
	public Asteroid asteroid;			//make an Object from Class asteroid
	public EnemyBlue enemyBlue;			//make an Object from Class enemyBlue
	public EnemyGreen enemyGreen;		//make an Object from Class enemyGreen
	public EnemyRed enemyRed;			//make an Object from Class enemyRed
	public Vector2 spawnValues;			//Store spawning (x,y) values

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (asteroidSpawnWaves());  	//Start IEnumerator function
		StartCoroutine (enemyBlueSpawnWaves());		//Start IEnumerator function
		StartCoroutine (enemyGreenSpawnWaves());	//Start IEnumerator function
		StartCoroutine (enemyRedSpawnWaves());		//Start IEnumerator function
	}

	// Update is called once per frame
	void Update () 
	{
		//Excute when keyboard button R pressed
		if(Input.GetKey("r"))
		{
			Application.LoadLevel(0);		//Load Level 0 (same Level) to make a restart
		}
	}

	//Asteroid IEnumerator Coroutine
	IEnumerator asteroidSpawnWaves()
	{
		yield return new WaitForSeconds (asteroid.StartWait); 															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < asteroid.Count; i++)
			{
				int edge = Random.Range(0,4);

				Vector3 spawnPosition;

				switch(edge) {
					case 1:	//right edge
						spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), 0f);		//Random Spawn Position
						break;
					case 2: //bottom edge
						spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), -spawnValues.y, 0f);
						break;
					case 3: //left edge
						spawnPosition = new Vector3 (-spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), 0f);
						break;
					default: //top edge
						spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0f);
						break;
				}
				Quaternion spawnRotation = Quaternion.identity;
				spawnRotation.z = Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - spawnPosition, Vector3.forward).z;		//Default Rotation
				Debug.Log (spawnPosition + " " + spawnRotation);
				Instantiate (asteroid.asteroidBigObj, spawnPosition, spawnRotation); 									//Instantiate Object
				yield return new WaitForSeconds (asteroid.SpawnWait); 													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (asteroid.WaveWait); 														//wait for seconds before the next wave
		}
	}

	//EnemyBlue IEnumerator Coroutine
	IEnumerator enemyBlueSpawnWaves()
	{
		yield return new WaitForSeconds (enemyBlue.StartWait);															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < enemyBlue.Count; i++)
			{
				int edge = Random.Range(0,4);
				
				Vector3 spawnPosition;
				
				switch(edge) {
				case 1:	//right edge
					spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), 0f);		//Random Spawn Position
					break;
				case 2: //bottom edge
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), -spawnValues.y, 0f);
					break;
				case 3: //left edge
					spawnPosition = new Vector3 (-spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), 0f);
					break;
				default: //top edge
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0f);
					break;
				}
				Quaternion spawnRotation = Quaternion.identity;
				spawnRotation.z = Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - spawnPosition, Vector3.forward).z;		//Default Rotation
				Instantiate (enemyBlue.enemyBlueObj, spawnPosition, spawnRotation);										//Instantiate Object
				yield return new WaitForSeconds (enemyBlue.SpawnWait);													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (enemyBlue.WaveWait);														//wait for seconds before the next wave
		}
	}

	//EnemyGreen IEnumerator Coroutine
	IEnumerator enemyGreenSpawnWaves()
	{
		yield return new WaitForSeconds (enemyGreen.StartWait);															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < enemyGreen.Count; i++)
			{
				int edge = Random.Range(0,4);
				
				Vector3 spawnPosition;
				
				switch(edge) {
				case 1:	//right edge
					spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), 0f);		//Random Spawn Position
					break;
				case 2: //bottom edge
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), -spawnValues.y, 0f);
					break;
				case 3: //left edge
					spawnPosition = new Vector3 (-spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), 0f);
					break;
				default: //top edge
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0f);
					break;
				}
				Quaternion spawnRotation = Quaternion.identity;
				spawnRotation.z = Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - spawnPosition, Vector3.forward).z;		//Default Rotation
				Instantiate (enemyGreen.enemyGreenObj, spawnPosition, spawnRotation);									//Instantiate Object
				yield return new WaitForSeconds (enemyGreen.SpawnWait);													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (enemyGreen.WaveWait);														//wait for seconds before the next wave
		}
	}

	//EnemyRed IEnumerator Coroutine
	IEnumerator enemyRedSpawnWaves()
	{
		yield return new WaitForSeconds (enemyRed.StartWait);															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < enemyRed.Count; i++)
			{
				int edge = Random.Range(0,4);
				
				Vector3 spawnPosition;
				
				switch(edge) {
				case 1:	//right edge
					spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), 0f);		//Random Spawn Position
					break;
				case 2: //bottom edge
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), -spawnValues.y, 0f);
					break;
				case 3: //left edge
					spawnPosition = new Vector3 (-spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), 0f);
					break;
				default: //top edge
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0f);
					break;
				}
				Quaternion spawnRotation = Quaternion.identity;
				spawnRotation.z = Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - spawnPosition, Vector3.forward).z;		//Default Rotation
				Instantiate (enemyRed.enemyRedObj, spawnPosition, spawnRotation);										//Instantiate Object
				yield return new WaitForSeconds (enemyRed.SpawnWait);													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (enemyRed.WaveWait);														//wait for seconds before the next wave
		}
	}
		
}
