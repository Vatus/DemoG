using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayAndUI : MonoBehaviour {
	// элементы интерфейса привязываются только сдесь, в методы других классов (скриптов) передовать по параметру!! (не забывая его там реализовать)


	// дистанция рейкаста
	public float dist = 5f;

	//переменная переключает отображение дебаг текста на гуе
	public bool showDebugRey;
	//2 переменные дебаг текста на гуе одна текст как обьект вторая он же самый но как тип текст
	public GameObject UItext;
	public Text massage;

	//элементы интерфейса
	public GameObject actionIcon;
	public Text actionText; 

	//тут хоним объекты для вызова их методов
	private GameObject toUse;
	private GameObject toRead;
	private GameObject testCommit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	 void Update () {
		//создадим лучь и переменную для возврата попадания
		Ray ray = new Ray (transform.position, transform.forward); 
		RaycastHit hit;



	//попали в записку?	
	
			if (Physics.Raycast (ray, out hit, dist)) 
			{
			if (hit.collider.tag == "letter") {
				toRead = hit.collider.gameObject.gameObject;
				toRead.GetComponent <letterScript> ().setOldPosition (hit.collider.transform);
				toRead.GetComponent <letterScript> ().toRead (hit.collider.transform, actionIcon, actionText);
			} else {
				actionIcon.SetActive (false); // скрывание экшинайкона идеть именно сдесь для всех типов взаимодействий, это не очивидное поведение, но переписывать мне лень.
			}
			}	

	



	//попали в открываемую вещь?
		if (Physics.Raycast (ray, out hit, dist)) {
			if (hit.collider.tag == "yah") {
				
				toUse = hit.collider.gameObject.gameObject;
				toUse.GetComponent <openCloser> ().toUse (actionIcon, actionText);

		
					
			
			} //else {actionIcon.SetActive (false);
			
			
			
			//}

		}


		// просто покажем на экран куда попали по нажатию О
		if (Input.GetKeyDown (KeyCode.O)) {
			if (showDebugRey) { showDebugRey = false;  UItext.SetActive(false);
				return;
			}
			if (!showDebugRey) { showDebugRey = true;  UItext.SetActive(true);
			}
		}

		if (Physics.Raycast (ray, out hit, dist) && showDebugRey) {
			
			massage.text = "Я пырюсь на:" + (string)hit.collider.name; //+ (string)hit.distance;
		}

	}
}
