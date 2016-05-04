using UnityEngine;
using System.Collections;

public class motionCharacter : MonoBehaviour {
	public GameObject Camera=null,Personaje=null;
	public float velocidadMovimiento = 2f,velocidadCamara=2f;

	void Start () {
		if (Camera == null)
			GameObject.FindGameObjectWithTag ("MainCamera");
		if (Personaje == null)
			Personaje = this.gameObject;
	}

	void FixedUpdate () {
		Personaje.gameObject.transform.position += new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")) * velocidadMovimiento * Time.deltaTime;
		Camera.gameObject.transform.position = Input.mousePosition;
	}
}
