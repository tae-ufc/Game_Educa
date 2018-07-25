using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioController))]
public class PlayerController : MonoBehaviour {
	public LayerMask layerGound;
	public Transform groundCheckLeft,groundCheckRight;
	public GameObject FinalFase;
	private Player playerScript;
	public bool ativarControlles;
	private bool finalFase = false;
	void Start () {
		Camera.main.aspect = 1920f / 1080f;
		playerScript = new Player (GetComponent<Animator> (), GetComponent<Rigidbody2D> (), transform, GetComponent<AudioController>());
		AudioManager.PlayAudioLoopScene (true);
	}
	void FixedUpdate(){
		playerScript.fixedUpdatePlayer ();
	}
	void Update () {
		playerScript.isGround = (Physics2D.OverlapCircle (groundCheckRight.position, 0.01f, layerGound) || 
			Physics2D.OverlapCircle (groundCheckLeft.position, 0.01f, layerGound)) && playerScript.rgbPlayer.velocity.y<=0  ;
		if (ativarControlles) {
			if (!finalFase) {
				playerScript.inputControllerPlayer ();
			} else {
				playerScript.stopPlayer ();
			}
		} else {
			playerScript.animPlayer.SetBool ("isGround", playerScript.isGround);
		}
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
	void OnTriggerEnter2D(Collider2D objeto){
		if(objeto.gameObject.CompareTag ("Letra")){
			objeto.gameObject.GetComponent<Animator> ().SetTrigger ("Pegou");
			objeto.GetComponent<AudioController> ().PlayOneShootAll ();
			FinalFase.SetActive (true);
			finalFase = true;
		}
	}
}
