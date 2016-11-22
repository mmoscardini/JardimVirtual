using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour {

	public GameObject modelHolder;

	public GameObject plant01;
	public GameObject plant02;

	bool isMenuImagesActive;

	public void ResetScene (){
		SceneManager.LoadScene (0);
	}


	//UI Menu
	public void DrowDownMenu () {
		foreach (Transform child in transform) {
			if (isMenuImagesActive) {
				child.gameObject.SetActive (false);
			} else {
				child.gameObject.SetActive (true);
			}
		}

		isMenuImagesActive = !isMenuImagesActive;
	}

	public void Planta01(){
		//Destrua todos os filhos do ModelHolder
		foreach (Transform child in modelHolder.transform) {
			Destroy (child.gameObject);
		}
		Instantiate (plant01, modelHolder.transform,true);
	}

	public void Planta02(){
		//Destrua todos os filhos do ModelHolder
		foreach (Transform child in modelHolder.transform) {
			Destroy (child.gameObject);
		}
		Instantiate (plant02, modelHolder.transform,true);
	}
}
