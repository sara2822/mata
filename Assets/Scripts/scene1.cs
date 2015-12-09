using UnityEngine;
using System.Collections;

public class scene1 : MonoBehaviour {
	// original game object tukaj je mama, ona kontrolira celotno sceno

	public GameObject Boy;
	public GameObject Girl;
	private int sceneIT; //odvijanje scene 
	public GameObject choosePlayer;
	public GameObject insertName;


	public bool playerChosen;

	// Use this for initialization
	void Start () {
		sceneIT = 0;
	}

	
	// Update is called once per frame 
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.GetRayIntersection (ray);

		if (sceneIT == 0) {
			choosePlayer.SetActive(true);
			if (hit && !playerChosen) {
				if (hit.collider.name == "Girl"  && Input.GetMouseButton (0)){
					Boy.SetActive(false);
					playerChosen = true;
					sceneIT++;
					choosePlayer.SetActive(false);
				}
				if (hit.collider.name == "Boy"  && Input.GetMouseButton (0)) {
					Girl.SetActive(false);
					playerChosen = true;
					sceneIT++;
					choosePlayer.SetActive(false);

				}
			}
		}
		if (sceneIT == 1) {
			insertName.SetActive(true);
		}
	
	}
}
