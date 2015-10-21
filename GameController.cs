using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private GameObject[,] allCubes;
	public GameObject cubePrefab;
	public Material planeMaterial;
	public Material mainMaterial;
	public Material deactivateMaterial;
	public Material hoverMaterial;
	public Airplane thePlane;
	int gridHeight = 9;
	int gridWidth = 16;

	void Start () {
		thePlane = new Airplane ();
		allCubes = new GameObject[gridWidth, gridHeight];
		for (int width = 0; width < gridWidth; width++){
			for (int height = 0; height < gridHeight; height++) {
				allCubes [width, height] = (GameObject) Instantiate(cubePrefab, new Vector3(width*1.5f - 11,height*1.5f - 5,2.5f), Quaternion.identity);
				allCubes[width, height].GetComponent<CubeBehavior>().x = width;
				allCubes[width, height].GetComponent<CubeBehavior>().y = height;
			}
		}
		thePlane.x = 0;
		thePlane.y = 8;
		allCubes [0,8].GetComponent<Renderer> ().material = planeMaterial;
	}

	void Update () {
	
	}

	public void ProcessClickedCube(GameObject clickedCube, int x, int y){
		if (x == thePlane.x && y == thePlane.y){
			if (thePlane.active == true){
				clickedCube.GetComponent<Renderer> ().material = deactivateMaterial;
				thePlane.active = false;
			} else {
				clickedCube.GetComponent<Renderer> ().material = planeMaterial;
				thePlane.active = true;
			}
		} else if (thePlane.active == true) {

			foreach (GameObject oneCube in allCubes) {
				 oneCube.GetComponent<Renderer> ().material = mainMaterial;
			}
			clickedCube.GetComponent<Renderer> ().material = planeMaterial;
			thePlane.x = x;
			thePlane.y = y;
		} else {
		}
	}
	//In order to determine whether or not a plane cube is active, it lights up when the mouse hovers over it
	public void hoverOn(GameObject hoverCube, int x, int y){
		if (x == thePlane.x && y == thePlane.y && thePlane.active == true){
			hoverCube.GetComponent<Renderer>().material = hoverMaterial;
		}
	}
	public void hoverOff(GameObject hoverCube, int x, int y){
		if (x == thePlane.x && y == thePlane.y && thePlane.active == true){
			hoverCube.GetComponent<Renderer>().material = planeMaterial;
		}
	}

}
