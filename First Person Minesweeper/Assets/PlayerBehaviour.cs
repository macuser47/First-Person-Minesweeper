using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBehaviour : MonoBehaviour {

	void Awake () {
		//init player positon
		Vector2 playerTile = new Vector2 (Random.Range(1, Game.gridSize + 1), Random.Range(1, Game.gridSize + 1));
		transform.position = new Vector3 (playerTile.x * Game.blockSize, /*0.76f*/ 10f, playerTile.y * Game.blockSize);

		Game.playerStartTile = playerTile;

		//This is very work-around but there was no other way to do it.
		Game.minePositons = new List<Vector2>();

		for (int i = 0; i < Game.mineCount; i++) {
			Vector2 rand = new Vector2(Random.Range(1, Game.gridSize + 1), Random.Range(1, Game.gridSize + 1));
			//recalculate if there is already a mine there or it is within one block of the player starting position (< 2 beacuse diagonals are 1.414 away)
			if (Game.minePositons.Contains(rand) || Mathf.Sqrt(((rand.x - playerTile.x) * (rand.x - playerTile.x)) + ((rand.y - playerTile.y) * (rand.y - playerTile.y))) < 2)
				i--;
			else
			{
				Game.minePositons.Add(rand);
				System.Console.WriteLine("Added to minePositions x:{0}, y:{1}", rand.x, rand.y);
			}
		}


	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
