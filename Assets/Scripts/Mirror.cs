using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour {
	public Collider mirrorTrue;
	public Collider mirrorDecoyOne;
	public Collider mirrorDecoyTwo;
	public Collider chair;
	public Collider deskChair;
	public Collider table;
	public Collider wall1;
	public Collider wall2;
	public Collider wall3;
	public Collider wall4;
	public Collider wall5;
	public Collider wall6;
	public Collider wall7;
	public Collider wall8;
	public Collider door;
	public Collider trapdoor;
	public TextMesh onScreen;
	string textScreen = "";
	bool hasKey = false;
	bool mirrorYes = false;
	bool broken = false;
	bool chairYes = false;
	bool moved = false;
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rayHit =  new RaycastHit();

		if (Physics.Raycast (ray, out rayHit, 1000f) && Input.GetMouseButtonDown(0)) {
			if (rayHit.collider == mirrorTrue) {
				textScreen = "";
				if (broken == true) {
					textScreen += "It's a broken mirror.";
				} else if (broken == false) {
					textScreen += "You do not see your reflection.\nThe mirror is creeping you out.\nSmash the mirror? Y/N";
					mirrorYes = true;
				}
			} else if (rayHit.collider == mirrorDecoyOne || rayHit.collider == mirrorDecoyTwo) {
				textScreen = "";
				textScreen += "You see your reflection.";
			} else if (rayHit.collider == chair) {
				textScreen = "";
				if (moved == false) {
					textScreen += "There's a chair here. \nWould you like to move it? Y/N";
					chairYes = true;
				} else if (moved == true) {
					textScreen += "It's a chair.";
				}
			} else if (rayHit.collider == deskChair) {
				textScreen = "";
				textScreen += "It's a chair.";
			} else if (rayHit.collider == table) {
				textScreen = "";
				textScreen += "It's a table.";
			} else if (rayHit.collider == wall1 || rayHit.collider == wall2 || rayHit.collider == wall3 ||
			           rayHit.collider == wall4 || rayHit.collider == wall5 || rayHit.collider == wall6 ||
			           rayHit.collider == wall7 || rayHit.collider == wall8) {
				textScreen = "";
				textScreen += "These walls are very tall. \nYou cannot jump over \nor dig beneath them.";
			} else if (rayHit.collider == door) {
				door.gameObject.transform.Rotate (0f,90f,0f);
			} else if (rayHit.collider == trapdoor) {
				textScreen = "";
				textScreen += "It's a trap door.";
				if (hasKey == true && moved == true) {
					trapdoor.gameObject.transform.Rotate (90f,0f,0f);
					textScreen = "";
					textScreen += "You opened the trapdoor. \nCongratulations! \nYou found a way out.\nTHE END";
				} else {
					textScreen += "\nThis trapdoor is locked.\nPerhaps you should find a key.";
				}
			} else {
				textScreen = "";
			}
		}

		if (mirrorYes == true) {
			if (Input.GetKeyDown (KeyCode.Y)) {
				textScreen = "";
				textScreen += "You broke the mirror. \nThere was a key inside!\n You obtained a key.";
				mirrorTrue.gameObject.transform.position = Vector3.zero;
				mirrorYes = false;
				broken = true;
				hasKey = true;
			} else if (Input.GetKeyDown (KeyCode.N)) {
				textScreen = "";
				mirrorYes = false;
			}
		}

		if (chairYes == true) {
			if (Input.GetKeyDown (KeyCode.Y)) {
				textScreen = "";
				textScreen += "You move the chair.";
				chair.gameObject.transform.Translate(5f, 0f, 0f);
				chairYes = false;
				moved = true;
			} else if (Input.GetKeyDown (KeyCode.N)) {
				textScreen = "";
				chairYes = false;
			}
		}
			
			onScreen.text = textScreen;
	}
}