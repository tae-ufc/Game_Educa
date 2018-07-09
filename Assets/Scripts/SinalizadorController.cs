using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinalizadorController : MonoBehaviour {

	public GameObject Ativado, Desativado;
	public string palavra;
	private CriarLetras criaLetras;
	void Start(){
		criaLetras = Object.FindObjectOfType<CriarLetras> ();
	}
	void OnTriggerEnter2D(Collider2D objeto){
		if (objeto.gameObject.CompareTag ("Player")) {
			Ativado.SetActive (true);
			Desativado.SetActive (false);
			criaLetras.instanciarPalavra (palavra);
		}

	}
	void OnTriggerStay2D(Collider2D objeto){
		if (objeto.gameObject.CompareTag ("Player")) {
			criaLetras.instanciarPalavra (palavra);
		}

	}
	void OnTriggerExit2D(Collider2D objeto){
		if (objeto.gameObject.CompareTag ("Player")) {
			Ativado.SetActive (false);
			Desativado.SetActive (true);
			criaLetras.terminarPalavra ();
		}

	}
}
