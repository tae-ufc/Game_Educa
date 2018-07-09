using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriarLetras : MonoBehaviour {

	public string palavra;
	public GameObject bloco;
	public Transform parentBloco;
	private GameObject[] arrayObjetos;
	private Animator anim;
	private bool chave=true;
	void Start () {
		anim = GetComponent<Animator> ();
		//instanciarPalavra (palavra);
	}
	private Color randomColor(){
		Color cor = new Color();
		switch (Random.Range (0, 4)) {
		case 0:
			cor = Color.green;
			break;
		case 1:
			cor = Color.red;
			break;
		case 2:
			cor = Color.blue;
			break;
		case 3:
			cor = Color.yellow;
			break;
		case 4:
			cor = Color.white;
			break;
		}
		return cor;

	}
	public void instanciarPalavra(string palavra){
		if (chave) {
			anim.SetBool ("sair", false);
			float distance = 0;
			int cont = 0;
			arrayObjetos = new GameObject[palavra.Length];
			gameObject.SetActive (false);
			foreach (char letra in palavra) {
				GameObject objeto = Instantiate (bloco, parentBloco, true);
				arrayObjetos [cont] = objeto;
				objeto.transform.localPosition = new Vector3 (distance,
					0, objeto.transform.localPosition.z);
				objeto.GetComponentInChildren<Text> ().text = letra.ToString ();
				distance += 1.5f;
				foreach (Image imageFilho in objeto.GetComponentsInChildren<Image> ()) {
					if (imageFilho.gameObject.name == "BlocoLetra_1") {
						imageFilho.color = randomColor ();
					}
				}
				cont++;
			}
			parentBloco.localPosition = new Vector3 (-((distance - 1.4f)) / 2, parentBloco.localPosition.y,
				parentBloco.localPosition.z);
			gameObject.SetActive (true);
			chave = false;
		}

	}
	public void terminarPalavra(){
		anim.SetBool ("sair", true);
	}
	public void destruirObjeto(){
		foreach (GameObject objeto in arrayObjetos) {
			Destroy (objeto);
		}
		chave = true;
	}
}
