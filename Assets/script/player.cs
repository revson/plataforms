using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	//variaveis
	private Rigidbody2D rb;

	private float horizontal;
	public float speed;
	private bool faceRight;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		//inicializa com o valor do scale se for > 0 (olhando para direita)
		faceRight = transform.localScale.x > 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		//horizontal recebe o valor do eixo X positivo para direita e negetivo para esquerda
		horizontal = Input.GetAxisRaw ("Horizontal");
		move (horizontal);
		flip (horizontal);
	}

	private void move(float axisX){
		rb.velocity = new Vector2(axisX * speed, rb.velocity.y) ;
	}

	private void flip (float axisX){
	
		//se o eixo x for maior que 0 e a face para esquerda ou o eixo x < 0 e a face para direita
		if(axisX > 0 && !faceRight || axisX < 0 && faceRight){

			//se retorno for verdedadeiro vira a face para a direcao do eixo
			//a face recebe ela ao contrario, ficando assim na posicao correta
			faceRight = !faceRight;
			//ao passar o negativo para o localScale, ele corrige o lado do sprite fazendo a regra do sinal
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
	}
}
