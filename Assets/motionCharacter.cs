using UnityEngine;
using System.Collections;

public class motionCharacter : MonoBehaviour {
	public Transform Camera=null,Personaje=null;
	public float velocidadMovimiento = 2f,velocidadCamara=2f;
	public bool LimitarCamara=false;
	public int limiteInferior=45,limiteSuperior=45;
	private float x=0f, y=0f;
	void Start () {
		if (Camera == null)
			Camera=GameObject.FindGameObjectWithTag ("MainCamera").transform;
		if (Personaje == null)
			Personaje = this.gameObject.transform;
		
	}

	void FixedUpdate () {
		//		
//		Camera=GameObject.FindGameObjectWithTag ("MainCamera");
		//Movimiento Personaje x y
		Personaje.Translate(Input.GetAxis ("Horizontal")* velocidadMovimiento * Time.deltaTime, 0, Input.GetAxis ("Vertical")* velocidadMovimiento * Time.deltaTime);

		//Copia el angulo de la camara z
		Personaje.eulerAngles=new Vector3(0,Camera.eulerAngles.y,0);

		//Movimiento Camara

		if (LimitarCamara) {
			if (y >= -limiteInferior && y <= limiteSuperior) {
				y += Input.GetAxis ("Mouse Y")*velocidadCamara;
			}else{
				if (y < -limiteInferior) {
					if (Input.GetAxis ("Mouse Y") > 0) {
						y += Input.GetAxis ("Mouse Y")*velocidadCamara;
					}
				} else {
					if (Input.GetAxis ("Mouse Y") < 0) {
						y += Input.GetAxis ("Mouse Y")*velocidadCamara;
					}
				}
			}
		}else{
			y += Input.GetAxis ("Mouse Y")*velocidadCamara;
		}
		x += Input.GetAxis ("Mouse X")*velocidadCamara;
		Camera.rotation = Quaternion.Euler(-y,x,0 );
	}
}
