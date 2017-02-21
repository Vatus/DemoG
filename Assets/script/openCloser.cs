using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openCloser : MonoBehaviour {
	public AnimationClip stolOpen;
	public AnimationClip stolClose;
	public GameObject store;
	public AudioClip stolOpensfx;
	public AudioClip stolClosesfx;
	public bool isOpen;

	// Use this for initialization

	public void toUse (GameObject actionIcon , Text tip){
		actionIcon.SetActive (true);
	
		if (isOpen) {
			tip.text = "'E' Закрыть ящик";

		}
		if (!isOpen) {
			tip.text = "'E' Открыть ящик";

		}


		if (!store.GetComponent<Animation>().isPlaying) {
			if (Input.GetKeyDown (KeyCode.E)) {



				if (!isOpen) { 

					store.GetComponent<Animation> ().Play (stolOpen.name);
					AudioSource.PlayClipAtPoint (stolOpensfx, transform.position);
					isOpen = true;
					return;

				} 
				if (isOpen) {
					store.GetComponent<Animation> ().Play (stolClose.name);
					AudioSource.PlayClipAtPoint (stolClosesfx, transform.position);
					isOpen = false;
					return;

				}  

			}	
		}

	}


}
