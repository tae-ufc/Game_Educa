using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public LayerMask layerGound;
	public Transform groundCheckLeft,groundCheckRight;
	public bool isGround;
	private Player playerScript;
	void Start () {
		playerScript = new Player (GetComponent<Animator> (), GetComponent<Rigidbody2D> (), transform);
	}
	void FixedUpdate(){
		playerScript.fixedUpdatePlayer ();
	}
	void Update () {
		playerScript.isGround = Physics2D.OverlapCircle (groundCheckRight.position, 0.01f, layerGound) || 
			Physics2D.OverlapCircle (groundCheckLeft.position, 0.01f, layerGound)  ;
		playerScript.inputControllerPlayer ();
	}
}
