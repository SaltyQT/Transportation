using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private GameObject[,] allCubes;
	public GameObject cubePrefab;
	public Material planeMaterial;
	public Material mainMaterial;
	public Material deactivateMaterial;
	public Material hoverMaterial;
	public Material startPointMaterial;
	public Material cargoBayMaterial;
	public Text cargoText;
	public Text scoreText;
	public Airplane thePlane;
	int cargoAdd = 10;
	int gridHeight = 9;
	int gridWidth = 16;
	int score = 0;
	float timeToAct = 0.0f;
	float turnLength = 1.5f;

	void Start () {
		thePlane = new Airplane ();
		allCubes = new GameObject[gridWidth, gridHeight];
		for (int width = 0; width < gridWidth; width++){
			for (int height = 0; height < gridHeight; height++) {
				allCubes[width, height] = (GameObject) Instantiate(cubePrefab, new Vector3(width*1.5f - 11,height*1.5f - 5,2.5f), Quaternion.identity);
				allCubes[width, height].GetComponent<CubeBehavior>().x = width;
				allCubes[width, height].GetComponent<CubeBehavior>().y = height;
			}
		}
		thePlane.x = 0;
		thePlane.y = 8;
		thePlane.cargo = 0;
		thePlane.cargoCapacity = 90;
		allCubes [0,8].GetComponent<Renderer> ().material = planeMaterial;
		allCubes [15, 0].GetComponent<Renderer> ().material = cargoBayMaterial;
		timeToAct = turnLength;
	}

	void Update () {
		if (Time.time >= timeToAct){ 
			thePlane.MoveNow();
			if (thePlane.x == 0 && thePlane.y == 8 && thePlane.cargo < thePlane.cargoCapacity){
				thePlane.cargo += cargoAdd;
			}
			if (thePlane.x == 15 && thePlane.y == 0 && thePlane.cargo > 0){
				score += thePlane.cargo;
				thePlane.cargo = 0;
			}
			timeToAct += turnLength;
		}
		scoreText.text = "Score: " + score.ToString ();
		cargoText.text = "Cargo: " + thePlane.cargo.ToString ();
		PlaneMoveSet();
		DrawCubes();
	}
	
	void PlaneMoveSet() {
		if (Input.GetKeyDown ("right")) {
			thePlane.SetMoveDirection(1,0);
		}
		if (Input.GetKeyDown ("left")) {
			thePlane.SetMoveDirection(-1,0);
		}
		if (Input.GetKeyDown ("down")) {
			thePlane.SetMoveDirection(0,-1);
		}
		if (Input.GetKeyDown ("up")) {
			thePlane.SetMoveDirection(0,1);
		}
	}

	void DrawCubes(){
		for (int width = 0; width < gridWidth; width++){
			for (int height = 0; height < gridHeight; height++) {
				allCubes[width, height].GetComponent<Renderer> ().material = mainMaterial;
			}
		}
		allCubes [0,8].GetComponent<Renderer> ().material = startPointMaterial;
		allCubes [15, 0].GetComponent<Renderer> ().material = cargoBayMaterial;
		allCubes [thePlane.x, thePlane.y].GetComponent<Renderer> ().material = planeMaterial;
	}


	//take out ClickPlane probs??????
	public void ClickPlane(GameObject clickedCube, int x, int y){
		if (x == thePlane.x && y == thePlane.y){
			if (thePlane.active == true){
				clickedCube.GetComponent<Renderer> ().material = deactivateMaterial;
				thePlane.active = false;
			} else {
				clickedCube.GetComponent<Renderer> ().material = planeMaterial;
				thePlane.active = true;
			}
//			//below this (the else if) will probs come out
//		} else if (thePlane.active == true) {
//
//			foreach (GameObject oneCube in allCubes) {
//				 oneCube.GetComponent<Renderer> ().material = mainMaterial;
//			}
//			clickedCube.GetComponent<Renderer> ().material = planeMaterial;
//			thePlane.x = x;
//			thePlane.y = y;
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
