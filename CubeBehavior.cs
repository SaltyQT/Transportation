using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
	GameController theGameController;
	public int x, y;

	void Start () {
		theGameController = GameObject.Find ("GameControllerObject").GetComponent<GameController> ();
	}

	void Update () {
	
	}

	void OnMouseDown(){
		theGameController.ProcessClickedCube (this.gameObject, x, y);
	}
	void OnMouseOver(){
		theGameController.hoverOn (this.gameObject, x, y);
	}
	void OnMouseExit(){
		theGameController.hoverOff (this.gameObject, x, y);
	}

}
