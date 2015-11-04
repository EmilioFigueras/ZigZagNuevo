using UnityEngine;
using System.Collections;

public class Cubo : MonoBehaviour {
	static int cont = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (cont > 6) {
			Application.LoadLevel ("Practica2_Escena2");
			cont=0;
		}
	}

	void OnCollisionEnter (Collision colision){


		Debug.Log ("colision");
		Destroy(this.gameObject);
		cont++;

	} 


}
