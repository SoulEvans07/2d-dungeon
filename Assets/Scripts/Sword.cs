using System;
using UnityEngine;

public class Sword : MonoBehaviour {
	private Transform _transform;
	
	public float damage = 1f;
	public string target;

	public void Start() {
		this._transform = GetComponent<Transform>();
		SetOwner();
	}

	public void SetOwner() {
		string ownerTag = this._transform.parent.tag;
		switch (ownerTag) {
			case "Player":
				this.target = "Enemy";
				break;
			// case "Enemy":
			default:
				this.target = "Player";
				break;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(target)) {
			Health enemy = other.GetComponent<Health>();
			enemy.TakeHit(damage);
		}
	}
}