using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWay : MonoBehaviour {

	public Transform groundPlatform;
	public Transform groundCheck;
	private Collider2D colisor;

	private float posY; //pos y do personagem

	//vai verificar a altura do player em relacao a plataforma para habilitar o chao evitando colisoes nas laterais e por baixo
	void Start () {
		// usar o find somente quando tiver um unico objeto na cena
		groundCheck = GameObject.Find ("GroundCheck").transform; //pega o transform do objeto de checagem

		colisor = GetComponent<BoxCollider2D> (); //pega o colisor da plataforma
	}
	
	// Update is called once per frame
	void Update () {

		posY = groundCheck.position.y; //pega a posicao Y do objeto de checagem

		//verifica se o player esta acima do chao da plataforma e o ativa
		if (posY > groundPlatform.position.y) {
			colisor.enabled = true;
		} else {
			colisor.enabled = false;
		}

	}
}
