using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public LayerMask layerGound;
	public Transform groundCheckLeft,groundCheckRight;
	private Player playerScript;
	void Start () {
		playerScript = new Player (GetComponent<Animator> (), GetComponent<Rigidbody2D> (), transform);
	}
	void FixedUpdate(){
		playerScript.fixedUpdatePlayer ();
	}
	void Update () {
		playerScript.isGround = (Physics2D.OverlapCircle (groundCheckRight.position, 0.01f, layerGound) || 
			Physics2D.OverlapCircle (groundCheckLeft.position, 0.01f, layerGound)) && playerScript.rgbPlayer.velocity.y<=0  ;
		playerScript.inputControllerPlayer ();
	}
	void OnCollisionEnter2D(Collision2D objeto){
		if (objeto.gameObject.CompareTag ("MovimentPlataform")) {
			if (playerScript.isGround) {
				transform.parent = objeto.transform;
			}

		}
	}
	void OnCollisionStay2D(Collision2D objeto){
		if (objeto.gameObject.CompareTag ("MovimentPlataform")) {
			if (playerScript.isGround) {
				transform.parent = objeto.transform;
			}
		}
	}
	void OnCollisionExit2D(Collision2D objeto){
		if (objeto.gameObject.CompareTag ("MovimentPlataform")) {
			transform.parent = null;

		}

	}
}
