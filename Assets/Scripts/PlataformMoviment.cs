using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMoviment : MonoBehaviour {
	public float speedPlataform;
	public enum Direction{ Left, Right};
	public Direction directionBegin;
	public Transform plataform, pointA, pointB;
	private Vector2 vectorSpeed;
	private Vector2 aux;
	void Start(){
		vectorSpeed.Set (speedPlataform, 0);
		switch (directionBegin) {
		case Direction.Left:
			aux = pointA.position;
			break;
		case Direction.Right:
			aux = pointB.position;
			break;
		}
	}
	void FixedUpdate(){
		if (plataform.position.x <= pointA.position.x) {
			aux = pointB.position;
		} else if (plataform.position.x >= pointB.position.x) {
			aux = pointA.position;
		}
		plataform.position = Vector2.MoveTowards (plataform.position, aux, speedPlataform);
			
	}
}
