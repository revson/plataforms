using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	private player scPlayer; //script Player
	public Transform L,R; // limite da camera no eixo X
	private Vector3 destinyX, destinyY;
	public float speed, cameraHeight;

	// Use this for initialization
	void Start () {

		scPlayer = FindObjectOfType (typeof(player)) as player;
	}

	// Update is called once per frame
	void Update () {

		// configurando o destino X e Y da camera
		destinyX = new Vector3 (scPlayer.transform.position.x, transform.position.y, transform.position.z );
		destinyY = new Vector3 (transform.position.x, scPlayer.transform.position.y + cameraHeight, transform.position.z );

		//aplicando acompanhamento da camera no eixo Y suavizado
		transform.position = Vector3.Lerp (transform.position, destinyY, speed * Time.deltaTime);

		//estabelecendo limite da camera e aplicando acompanhamento da camera no eixo X suavizado no personagem
		if(scPlayer.transform.position.x > L.position.x && scPlayer.transform.position.x < R.position.x){
			transform.position = Vector3.Lerp (transform.position, destinyX, speed * Time.deltaTime);
		}else if(transform.position.x > L.position.x && transform.position.x < R.position.x){
			transform.position = Vector3.Lerp (transform.position, destinyX, speed * Time.deltaTime);
		}

	}
}
