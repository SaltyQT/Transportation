using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
	GameController theGameController;

	void Start () {
		theGameController = GameObject.Find ("GameControllerObject").GetComponent<GameController> ();
	}

	void Update () {
	
	}

	void OnMouseDown(){
		theGameController.ProcessClickedCube (this.gameObject);
	}

}
