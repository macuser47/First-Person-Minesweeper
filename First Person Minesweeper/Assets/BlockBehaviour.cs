using UnityEngine;
using System.Collections;

public class BlockBehaviour : MonoBehaviour {

	bool active = true;

	Vector2 relativePosition;

	// Use this for initialization
	void Start () {
		relativePosition = new Vector2 (transform.position.x / Game.blockSize, transform.position.z / Game.blockSize);
	}
	
	// Update is called once per frame
	void Update () {
		//delete block
		if (Game.blockDeletes.Contains(relativePosition)) {
			active = false;
		}

		if (!active) {
			Destroy(this.gameObject);
		}
	
	}

	void OnCollisionEnter(Collision col) {
		//explode if mine
		if (Game.minePositons.Contains(relativePosition)) {
			Game.die();
		}

		//destoy self
		if (col.gameObject.name == "Player") {
			Game.goneBlock = relativePosition;
			active = false;
		}
	}
}
