using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class letterScript : MonoBehaviour {

	public LayerMask mask;
	public bool isRead = false;
	private Vector3 oldPosition;
	private Quaternion oldAngel;
	private bool kostyl;

	public AudioClip paperGet;
	public AudioClip paperSet;




	// Use this for initialization
	void Start () {
		kostyl = true;
		

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	public void  setOldPosition(Transform letter){
		if (kostyl) {
			
			oldPosition = letter.position;
			oldAngel = letter.rotation;
			kostyl = false;
		}
	
	}

	public void toRead(Transform letter, GameObject actionIcon, Text tip) {
		
		actionIcon.SetActive (true);

		if (!isRead) {
			tip.text = "'E' Прочитать записку";
		}


	


		if (!isRead) 
		{
			

			if (Input.GetKeyDown (KeyCode.E)) {
				isRead = true;
				AudioSource.PlayClipAtPoint (paperGet, transform.position);

		}
		} else 
		{
			letter.position = Camera.main.transform.position + Camera.main.transform.forward * .8f;	
			letter.LookAt (Camera.main.transform);

			actionIcon.SetActive (false);
			if (Input.GetKeyUp (KeyCode.E)) {

				isRead = false;
				AudioSource.PlayClipAtPoint (paperSet, transform.position);
				letter.position = oldPosition;
				letter.rotation = oldAngel;


			}



		}
	}
}
