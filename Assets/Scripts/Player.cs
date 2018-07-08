using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player{
	private Animator animPlayer;
	private Rigidbody2D rgbPlayer;
	private Vector2 forceJump;
	private Vector3 scaleInicial;
	private float speedPlayer = 10f, horizontal, vertical;
	private int idAnimation;
	private Transform playerTransform;
	public bool isGround;
	public Player(Animator animPlayer, Rigidbody2D rgbPlayer, Transform playerTransform){
		this.animPlayer = animPlayer;
		this.rgbPlayer = rgbPlayer;
		this.playerTransform = playerTransform;
		this.forceJump = new Vector2 (0, 500f);
		this.scaleInicial = playerTransform.localScale;
	}
	public void fixedUpdatePlayer(){
		animPlayer.SetFloat ("speedY", rgbPlayer.velocity.y);
	}
	public void inputControllerPlayer(){
		horizontal = Input.GetAxisRaw ("Horizontal");
		vertical =  Input.GetAxisRaw ("Vertical");

		if (horizontal > 0) {
			idAnimation = 1;
			playerTransform.localScale = scaleInicial;
			rgbPlayer.velocity = new Vector2 (speedPlayer, rgbPlayer.velocity.y);
		} else if (horizontal < 0) {
			idAnimation = 1;
			playerTransform.localScale = new Vector3(-1*scaleInicial.x,scaleInicial.y,scaleInicial.z);
			rgbPlayer.velocity = new Vector2 (-speedPlayer, rgbPlayer.velocity.y);
		} else if (horizontal == 0) {
			rgbPlayer.velocity = new Vector2 (0, rgbPlayer.velocity.y);
			idAnimation = 0;
		}
		if (Input.GetButtonDown ("Jump")&&isGround) {
			rgbPlayer.AddForce (forceJump);
		}
		animPlayer.SetInteger ("idAnimation", idAnimation);
		animPlayer.SetBool ("isGround", isGround);
	}

}
