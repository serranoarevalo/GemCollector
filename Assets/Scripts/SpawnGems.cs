using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGems : MonoBehaviour {

	public int XRange;
	public int YRange;
	public int NumberOfObjects = 8;
	public List<GameObject> GemTable = new List<GameObject> ();

	void Start(){

		Spawn ();
		
	}

	void Spawn(){
		for (int i = 0; i < NumberOfObjects; i++) {

			Vector3 spawnPos = new Vector3 (Random.Range (-XRange, XRange), Random.Range (-3f, YRange), 0f);
			int randomObject = Random.Range (0, GemTable.Count);
			Instantiate (GemTable [randomObject], spawnPos, Quaternion.identity);

		}
	}
}
