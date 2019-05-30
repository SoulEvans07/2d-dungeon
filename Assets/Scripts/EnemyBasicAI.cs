using System;
using UnityEditor;
using UnityEngine;

public class EnemyBasicAI : MonoBehaviour {
	private CircleCollider2D _proximityCollider;
	private Vector3 move;

	public EnemyMovement _controller;
	public float watchRadius = 10f;
	public float attackRadius = 1f;

	void Awake() {
		this._proximityCollider = GetComponent<CircleCollider2D>();
		this._proximityCollider.radius = watchRadius;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			_controller.target = other.transform.position;
		}
	}
	
	private void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			_controller.target = other.transform.position;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			_controller.Stop();
		}
	}

	private void OnDrawGizmos() {
		// Watch radius
		Handles.color = Color.cyan;
		Handles.DrawWireDisc(transform.position, Vector3.forward, watchRadius);
		// Attack radius
		Handles.color = Color.red;
		Handles.DrawWireDisc(transform.position, Vector3.forward, attackRadius);
	}
}