using UnityEngine;

public class SwordBlade : MonoBehaviour {
	public Sword attributes;
	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(attributes.target)) {
			Health enemy = other.GetComponent<Health>();
			enemy.TakeHit(attributes.damage);
		}
	}
}