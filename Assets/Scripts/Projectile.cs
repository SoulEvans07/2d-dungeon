using System;
using UnityEngine;

public class Projectile : MonoBehaviour {
	private Transform _transform;
	private Staff attributes;
	public float speed = 1f;

	private void Start() {
		this._transform = GetComponent<Transform>();
	}

	public void SetAttributes(Staff staff) {
		this.attributes = staff;
	}

	private void Update() {
		this._transform.position += this._transform.right * speed;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.name);
		if (other.CompareTag(attributes.target)) {
			Health enemy = other.GetComponent<Health>();
			enemy.TakeHit(attributes.damage);
		}

		if (other.CompareTag(attributes.target) || other.CompareTag("Obstacle")) {
			Destroy(this.gameObject);
		}
	}
}