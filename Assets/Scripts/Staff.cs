using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour {
	private Transform _transform;

	public Transform castPos;
	public GameObject projectile;
	public float damage = 1f;
	public string caster;
	public string target;

	public void Start() {
		this._transform = GetComponent<Transform>();
		SetOwner();
	}

	public void SetOwner() {
		string ownerTag = this._transform.parent.tag;
		switch (ownerTag) {
			case "Player":
				this.caster = "Player";
				this.target = "Enemy";
				break;
			// case "Enemy":
			default:
				this.caster = "Enemy";
				this.target = "Player";
				break;
		}
	}

	public void Cast() {
		GameObject proj = Instantiate(projectile, castPos.position, _transform.rotation);
		proj.GetComponent<Projectile>().SetAttributes(this);
	}
}