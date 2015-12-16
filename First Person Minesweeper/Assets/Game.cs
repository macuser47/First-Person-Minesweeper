using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public static int blockSize = 5;
	public static int gridSize = 10;
	public static int mineCount = 15;

	public Material one;
	public Material two;
	public Material three;
	public Material four;
	public Material five;
	public Material six;
	public Material seven;
	public Material eight;
	public Material def;

	public static Material noNumber;

	public static Material[] numbers = new Material[8];

	public static Vector2 playerStartTile;

	public static List<Vector2> minePositons;

	public static Vector2 goneBlock = Vector2.zero;

	public static List<Vector2> blockDeletes = new List<Vector2>();

	public Transform FloorTile;

	public Transform block;

	//FOR TESTING ONLY
	public static GameObject player;

	// Use this for initialization
	void Awake () {
		//init number materials
		numbers[0] = one;
		numbers[1] = two;
		numbers[2] = three;
		numbers[3] = four;
		numbers[4] = five;
		numbers[5] = six;
		numbers[6] = seven;
		numbers[7] = eight;

		noNumber = def;

		//init floor prefabs
		for (int x = 1; x <= gridSize; x++) {
			for (int z = 1; z <= gridSize; z++) {
				Instantiate(FloorTile, new Vector3(x * Game.blockSize, -0.1f, z * Game.blockSize), Quaternion.identity);
			}
		}
	}

	void Start () {
		//instantiate blocks
		for (int x = 1; x <= gridSize; x++) {
			for (int z = 1; z <= gridSize; z++) {
				Instantiate(block, new Vector3(x * Game.blockSize, 2.423f, z * Game.blockSize), Quaternion.identity);
			}
		}

		//hide cursor
		Cursor.visible = false;

		player = GameObject.Find("Player");
	}

	public static void die() {
		Vector3 temp = Game.player.transform.position;
		temp.y += 10;
		Game.player.transform.position = temp;
	}
	
	// Update is called once per frame
	void Update () {
		if (goneBlock != Vector2.zero) {
			checkSurroundings(goneBlock);
			goneBlock = Vector2.zero;
		}

	}

	void checkSurroundings(Vector2 vector)
	{
		Vector2[] adjacent = {new Vector2(vector.x - 1, vector.y - 1),
			new Vector2(vector.x - 1, vector.y),
			new Vector2(vector.x - 1, vector.y + 1),
			new Vector2(vector.x, vector.y - 1),
			new Vector2(vector.x, vector.y + 1),
			new Vector2(vector.x + 1, vector.y - 1),
			new Vector2(vector.x + 1, vector.y),
			new Vector2(vector.x + 1, vector.y + 1),};

		bool isBlank = true;

		for (int i = 0; i < adjacent.Length; i++) {
			if (isBlank)
				isBlank = !(minePositons.Contains(adjacent[i]));
		}

		if (isBlank) {
			for (int i = 0; i < adjacent.Length; i++) {
				if (!(blockDeletes.Contains(adjacent[i])) && adjacent[i].x > 0 && adjacent[i].x < gridSize + 1 && adjacent[i].y > 0 && adjacent[i].y < gridSize + 1) {
					blockDeletes.Add(adjacent[i]);
					checkSurroundings(adjacent[i]);
				}
			}
		}
		
	}
}
