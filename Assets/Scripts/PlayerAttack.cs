using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	private static readonly int Swing = Animator.StringToHash("swing");
	private Animator _animator;

	public float attackSpeed = 1f;
	private bool attack;
	private float timer;

	private void Start() {
		this._animator = GetComponent<Animator>();
		timer = 1f / attackSpeed;
	}

	private void Update() {
		timer += Time.deltaTime;
		attack = canAttack() && Input.GetButton("Fire1");
	}

	private void FixedUpdate() {
		if (attack) {
			this._animator.SetTrigger(Swing);
			attack = false;
			timer = 0;
		}
	}

	private bool canAttack() {
		return timer >= 1f / attackSpeed;
	}
}