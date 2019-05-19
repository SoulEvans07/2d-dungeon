using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	private static readonly int Swing = Animator.StringToHash("swing");
	private Transform _transform;
	private Animator _animator;

	public Camera _camera;
	private Vector3 mouse;
	private float weapon_angle;
	public Transform weapon;
	public float attackSpeed = 1f;
	private bool attack;
	private float timer;

	private void Start() {
		this._transform = GetComponent<Transform>();
		this._animator = GetComponent<Animator>();
		timer = 1f / attackSpeed;
	}

	private void Update() {
		timer += Time.deltaTime;
		mouse = _camera.ScreenToWorldPoint(Input.mousePosition);
		this.attack = canAttack() && Input.GetButton("Fire1");
		this.weapon_angle = getAngle();
	}

	private void FixedUpdate() {
		Flip();
		Rotate();
		Attack();
	}

	private void Attack() {
		if (attack) {
			this._animator.SetTrigger(Swing);
			attack = false;
			timer = 0;
		}
	}

	private void Flip() {
		if (this._transform.localScale.x < 0 && weapon.localScale.x > 0 ||
		    this._transform.localScale.x > 0 && weapon.localScale.x < 0) {
			Vector3 scale = weapon.localScale;
			scale.x = this._transform.localScale.x;
			scale.y = this._transform.localScale.x;
			weapon.localScale = scale;
		}
	}

	private void Rotate() {
		weapon.rotation = Quaternion.Euler(0, 0, this.weapon_angle);
	}

	private bool canAttack() {
		return timer >= 1f / attackSpeed;
	}

	private float getAngle() {
		Vector3 pos = this._transform.position;

		Vector3 offset = new Vector2(mouse.x - pos.x, mouse.y - pos.y);
		return Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
	}
}