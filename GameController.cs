using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private GameObject[] allCubes;
	public GameObject cubePrefab;
	public Material clickMaterial;
	public Material mainMaterial;
	int numCubes = 16;

	void Start () {
		allCubes = new GameObject[numCubes];
		for (int i = 0; i < numCubes; i++) {
			allCubes [i] = (GameObject) Instantiate(cubePrefab, new Vector3(i*1.5f - 11,0,2.5f), Quaternion.identity);
		}
	}

	void Update () {
	
	}

	public void ProcessClickedCube(GameObject clickedCube){
		foreach (GameObject oneCube in allCubes) {
			 oneCube.GetComponent<Renderer> ().material = mainMaterial;
		}
		clickedCube.GetComponent<Renderer> ().material = clickMaterial;
	}

}
