using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//variaveis
	private Rigidbody2D rb;
	private Animator playerAnimator;

	private float horizontal;
	public float speed;
    public float jumpForce;
	private bool faceRight;
    public Transform groundCheck;
    private bool grounded;
	private bool run;
	public LayerMask isGround;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();

		//inicializa com o valor do scale se for > 0 (olhando para direita)
		faceRight = transform.localScale.x > 0;
	}
	
	// Update is called once per frame
	void Update () {
        //horizontal recebe o valor do eixo X positivo para direita e negetivo para esquerda
        horizontal = Input.GetAxisRaw("Horizontal");
		if (horizontal != 0) {
			run = true;
		} else {
			run = false;
		}

        flip(horizontal);

		if (Input.GetButtonDown("Jump") && grounded == true)
        { 
			
            jump(jumpForce);
        }

		//atualiza o animator
		playerAnimator.SetBool("runAnimator", run);
		playerAnimator.SetFloat ("VelocidadeY", rb.velocity.y);
		playerAnimator.SetBool ("Grounded", grounded);

    }

	void FixedUpdate () {
		
		// retorna true se houver colisao nos pes
		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, isGround);

        move(horizontal);
    }

	private void move(float axisX){
		rb.velocity = new Vector2(axisX * speed, rb.velocity.y) ;
	}

	private void flip (float axisX){
	
		//se o eixo x for maior que 0 e a face para esquerda ou o eixo x < 0 e a face para direita
		if(axisX > 0 && !faceRight || axisX < 0 && faceRight){

			//se retorno for verdedadeiro vira a face para a direcao do valor positivo do eixo X
			//a face recebe ela ao contrario, ficando assim na posicao correta
			faceRight = !faceRight;
			//ao passar o negativo para o localScale, ele corrige o lado do sprite fazendo a regra do sinal
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
	}

    private void jump(float jumpForce) {
        rb.AddForce(new Vector2(0, jumpForce));
    }

	private void OnTriggerEnter2D(Collider2D col){
		//switch()
		//print(col.tag);
	}

	private void OnCollisionEnter2D(Collision2D col){
		//switch()
		//print(col.tag);
	}


	// funcao nativa do unity usada para mostrar o groundCheck
	private void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (groundCheck.position, 0.1f);
	}
}
