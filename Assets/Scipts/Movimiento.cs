using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {
		
	private static int cont = 0;
	int cont_ini;
	public float speed;
	public Button boton;
	public Text countText;
	public Text countText2;
	private int puntuacionMax;
	public Text winText;
	
	public float force;
	private bool changeDir;
	private Vector3 dir;
	private Rigidbody rb;
	
	// Use this for initialization
	void Start () {

		cont_ini = cont;
		changeDir = false;
		rb = GetComponent<Rigidbody>();
		dir = new Vector3 (0, 0, 0);
		SetCountText ();
		SetCountText2 ();
		boton.gameObject.SetActive (false);
		
		//PlayerPrefs.SetInt("puntuacionMax", 0);
		//winText.text = "";
	}
	void Update(){
		if (transform.position.y < -1) {
			this.transform.position= new Vector3(-8.4f,5.5f,-16.2f);
			rb.Sleep();
			dir= new Vector3(0,0,0);
		}
		if (Input.GetMouseButtonDown (0)) {
			rb.Sleep ();
			if(changeDir){
				dir= new Vector3(0,0,1);
				changeDir= false;
				
			}else{
				dir= new Vector3(1,0,0);
				changeDir=true;
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		rb.MovePosition (transform.position + dir * Time.deltaTime * force);
	}

	public void OnCollisionEnter(Collision node)
	{
		if (node.gameObject.tag == "Destruye") {
			Destroy (node.gameObject);
			cont++;
			SetCountText ();
			
		}
		if (node.gameObject.tag == "Suelo") {
			cont = cont_ini;
			Application.LoadLevel (Application.loadedLevelName);
			
		}
		if (node.gameObject.tag == "Final") {
			Application.LoadLevel ("Practica3_2");
			
		}
		if (node.gameObject.tag == "Final2") {
			Application.LoadLevel ("Practica3_1");
			
		}
		if (node.gameObject.tag == "FinalTotal") {
			if(cont>PlayerPrefs.GetInt("puntuacionMax")){
				winText.text = "Has superado el record"; 
				PlayerPrefs.SetInt("puntuacionMax", cont);
				SetCountText2();

			}else{
				winText.text="Record no superado";
			}
			cont=0;
			boton.gameObject.SetActive (true);
			this.gameObject.SetActive (false);
			//Destroy (this.gameObject);


			
		}
	}

	void SetCountText(){
		countText.text = "Destruidos: " + cont.ToString();
	}

	void SetCountText2(){
		countText2.text = "Record: " + PlayerPrefs.GetInt("puntuacionMax");
	}

}
