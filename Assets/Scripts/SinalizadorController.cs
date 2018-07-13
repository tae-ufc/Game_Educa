using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinalizadorController : MonoBehaviour {

	public GameObject Ativado, Desativado;
	public string palavra;
	private CriarLetras criaLetras;
	public SpriteGlow.SpriteGlowEffect spriteGlow;
	void Start(){
		criaLetras = Object.FindObjectOfType<CriarLetras> ();
		spriteGlow.enabled = false;
	}
	void OnTriggerEnter2D(Collider2D objeto){
		if (objeto.gameObject.CompareTag ("Player")) {
			Ativado.SetActive (true);
			Desativado.SetActive (false);
			criaLetras.instanciarPalavra (palavra);
			spriteGlow.enabled = true;
		}

	}
	void OnTriggerStay2D(Collider2D objeto){
		if (objeto.gameObject.CompareTag ("Player")) {
			criaLetras.instanciarPalavra (palavra);
			spriteGlow.enabled = true;
		}

	}
	void OnTriggerExit2D(Collider2D objeto){
		if (objeto.gameObject.CompareTag ("Player")) {
			Ativado.SetActive (false);
			Desativado.SetActive (true);
			criaLetras.terminarPalavra ();
			spriteGlow.enabled = false;
		}

	}
}
