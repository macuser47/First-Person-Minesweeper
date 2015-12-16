using UnityEngine;
using System.Collections;

public class FloorTileBehaviour : MonoBehaviour {

	// Use this for initialization
	int number = -1;

	public Renderer renderer;

	void Start () {
		//set up renderer
		renderer = GetComponent<Renderer>();
		renderer.enabled = true;

		bool derp = true;
		//load texture
		foreach (Vector2 pos in Game.minePositons) {
			if (pos.x * Game.blockSize != transform.position.x || pos.y * Game.blockSize != transform.position.z) {

				bool hasAdjacentMine = false;

				//checks if tile is mine tile is adjacent
				for (int x = -1; x <= 1; x++) {
					for (int z = -1; z <= 1; z++) {
						if (!hasAdjacentMine && !(x == 0 && z == 0)) {
							hasAdjacentMine = (transform.position.x == (pos.x + x) * Game.blockSize && transform.position.z == (pos.y + z)* Game.blockSize);
						}
					}
				}

				/*if ((
				(transform.position.x == (pos.x + 1) * Game.blockSize && transform.position.z == (pos.y) * Game.blockSize) ||
				(transform.position.x == (pos.x - 1) * Game.blockSize && transform.position.z == (pos.y) * Game.blockSize) ||
				(transform.position.x == (pos.x) * Game.blockSize && transform.position.z == (pos.y + 1) * Game.blockSize) ||
				(transform.position.x == (pos.x) * Game.blockSize && transform.position.z == (pos.y - 1) * Game.blockSize) ||
				//not diaginals
				(transform.position.x == (pos.x - 1) * Game.blockSize && transform.position.z == (pos.y) * Game.blockSize) ||
				(transform.position.x == (pos.x + 1) * Game.blockSize && transform.position.z == (pos.y) * Game.blockSize) ||
				(transform.position.x == (pos.x) * Game.blockSize && transform.position.z == (pos.y + 1) * Game.blockSize) ||
				(transform.position.x == (pos.x) * Game.blockSize && transform.position.z == (pos.y - 1) * Game.blockSize) ||
				//diagonals
				(transform.position.x == (pos.x + 1) * Game.blockSize && transform.position.z == (pos.y + 1) * Game.blockSize) ||
				(transform.position.x == (pos.x + 1) * Game.blockSize && transform.position.z == (pos.y - 1) * Game.blockSize) ||
				(transform.position.x == (pos.x - 1) * Game.blockSize && transform.position.z == (pos.y + 1) * Game.blockSize) ||
				(transform.position.x == (pos.x - 1) * Game.blockSize && transform.position.z == (pos.y - 1) * Game.blockSize) 
				)) {*/
				if (hasAdjacentMine) {
			//if (Mathf.Sqrt(((pos.x - (transform.position.x / Game.blockSize)) * (pos.x - (transform.position.x / Game.blockSize))) + ((pos.y - (transform.position.z / Game.blockSize)) * (pos.y - (transform.position.z / Game.blockSize)))) < 2) {
				//if (number == -1) {
				//	number++;
				//	System.Console.WriteLine("First match!");
				//}
					//if has an adjacent mine, increment the tile's numbers
					number++;
					System.Console.WriteLine("{0}th match!", number + 1);
				}
				else {
					System.Console.WriteLine("x:{0}, y{1} does not match x:{2}, y:{3}.", pos.x * Game.blockSize, pos.y * Game.blockSize, transform.position.x, transform.position.z);
				} 
			}
			else if(pos.x * Game.blockSize == transform.position.x && pos.y * Game.blockSize == transform.position.z){
				renderer.material = Game.numbers[7];
				derp = false;
			}
		}

		if (derp) {
			if (number != -1)
				renderer.material = Game.numbers[number];
			else {
				renderer.material = Game.noNumber;
				System.Console.WriteLine("No matches.");
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	}
}
