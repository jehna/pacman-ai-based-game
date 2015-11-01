using UnityEngine;
using System.Collections;

public class LevelBuilder : MonoBehaviour {

	public TextAsset level1;

	void Awake() {
		Transform floorTile = Resources.Load<Transform> ("Floor");

		string rawLevel = level1.text;
		string[] lines = rawLevel.Split ('\n');
		for (int lineNum = 0; lineNum < lines.Length; lineNum++) {
			int y = lineNum;
			char[] blocks = lines[lineNum].ToCharArray();
			for(int blockNum = 0; blockNum < blocks.Length; blockNum++) {
				int x = blockNum;
				char block = blocks[blockNum];
				Vector3 position = new Vector3(x,y,0);
				Object spawn = SpawnForChar(block.ToString());
				if (spawn != null) {
					Instantiate(spawn, position, Quaternion.identity);
				}
				Instantiate(floorTile, floorTile.position + position, floorTile.rotation);
			}
		}
	}

	Object SpawnForChar(string character) {
		switch (character) {
		case " ": return Resources.Load<Transform>("Point");
		case "-": return null; //Resources.Load('point');
		case "E": return Resources.Load("Enemy");
		case "@": return Resources.Load("User");
		case "x": return Resources.Load("Wall");
		}
		return null;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
