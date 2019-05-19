using System;
using UnityEngine;

public class Health : MonoBehaviour {
	public float maxHealth = 10f;
	private float health;
	
	private void Start() {
		health = maxHealth;
	}

	public void TakeHit(float damage) {
		health -= damage;
		
		Debug.Log(this.gameObject.name + " -" + damage + "hp, remaining: " + health);
		
		if (health <= 0) {
			health = 0;
			Die();
		}
	}

	private void Die() {
		Destroy(this.gameObject);
	}
}