using UnityEngine;
using System.Collections;

public class DragModels : MonoBehaviour {

	private float distance;
	private bool dragging = false;
	private bool rotating = false;
	private Vector3 offset;
	private Transform toDrag;

	public float sensitivity = 1f;

	private bool editorDragging = false;
	private bool editorRotating = false;

	void Start () {

	}
	
	void Update () {
		Vector3 v3;
	
		//Se o número de toques for menor que 1 saia do Update
		if (Input.touchCount < 1) {
			dragging = false;
			return;
		}

		//Se a contagem de touches for igual a 1
		//Executar código para arrastar objetos
		if (editorDragging) {
			Touch touch = Input.touches [0];
			Vector3 pos = touch.position;

			if (touch.phase == TouchPhase.Began) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (pos);

				if (Physics.Raycast (ray, out hit) && (hit.collider.tag == "Dragable")) {
					print ("Dragging");
					toDrag = hit.collider.transform;

					distance = hit.transform.position.z - Camera.main.transform.position.z;
					v3 = new Vector3 (pos.x, pos.y, distance);
					v3 = Camera.main.ScreenToWorldPoint (v3);
					offset = toDrag.position - v3;
					dragging = true;
				}
			}
			if (dragging && touch.phase == TouchPhase.Moved) {
				print ("touch phase moved");
				v3 = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
				v3 = Camera.main.ScreenToWorldPoint (v3);
				toDrag.position = v3 + offset;
			}
			if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
				print ("touch phase ended canceled");
				dragging = false;
			}
		}

		//Se a contagem de touches for igual a 2
		//Executar código para girar objetos
		if (editorRotating) {
			Touch touch = Input.touches [0];
			Vector3 pos = touch.position;

			if (touch.phase == TouchPhase.Began) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (pos);

				if (Physics.Raycast (ray, out hit) && (hit.collider.tag == "Dragable")) {
					print ("Rotating");
					toDrag = hit.collider.transform;
					distance = hit.transform.position.z - Camera.main.transform.position.z;
					v3 = new Vector3 (pos.x, pos.y, distance);
					v3 = Camera.main.ScreenToWorldPoint (v3);
					offset = toDrag.position - v3;
					rotating = true;
				}

			}
			if (rotating && touch.phase == TouchPhase.Moved) {
				v3 = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
				v3 = Camera.main.ScreenToWorldPoint (v3);
				offset = toDrag.position - v3;

				Vector3 angles = new Vector3 (-0, offset.x, 0);
			

				toDrag.transform.eulerAngles += angles * sensitivity;
			}
			if (rotating && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
				print ("touch phase ended canceled");
				rotating = false;
			}
		}
	}

	public void EditorDragging(){
		editorDragging = !editorDragging;
	}
	public void EditorRotating(){
		editorRotating = !editorRotating;
	}
}

