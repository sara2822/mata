using UnityEngine;
using System.Collections;

public class gameStart : MonoBehaviour {
	
	private SpriteRenderer FadeIn;
	public float FadeInSpeed = 0.9f;
	private float alpha = 1f;
	private bool newLevelLoaded = false;
	private bool loadNewLevel = false;
	
	// Use this for initialization
	void Start () {
		FadeIn = gameObject.GetComponent <SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.GetRayIntersection (ray);

		if (hit && loadNewLevel == false) {
			if (hit.collider.name == "colider" && Input.GetMouseButton (0)) {
				loadNewLevel = true;
				Debug.Log (loadNewLevel);
			}
		}
		if (loadNewLevel == true) {
			alpha -= FadeInSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);
				Debug.Log (alpha);
			
			FadeIn.color = new Color (FadeIn.color.r, FadeIn.color.g, FadeIn.color.b, alpha);
			if (alpha <= 0.01f && newLevelLoaded == false) {
					Application.LoadLevel (Application.loadedLevel + 1);
					newLevelLoaded = true;
			}
		}	
	}
}
