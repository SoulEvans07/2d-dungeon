using UnityEditor;
using UnityEngine;

public class EnemyBasicAI : MonoBehaviour {
	private Transform _transform;
	private CircleCollider2D _proximityCollider;
	private Vector3 move;

	public EnemyMovement _controller;
	public float watchRadius = 10f;
	public float attackRadius = 1f;
	public float crowdRadius = 0.5f;

	public LayerMask attackMask;

	void Awake() {
		this._transform = transform;
		this._proximityCollider = GetComponent<CircleCollider2D>();
		this._proximityCollider.radius = watchRadius;
	}

	private void OnTrigger(Collider2D other) {
		if (other.CompareTag("Player") && LineOfSight(other.transform.position)) {
			OnPlayer(other);
		} else {
			_controller.Stop();
		}
	}

	private void OnPlayer(Collider2D player) {
		float distance = Vector2.Distance(player.transform.position, _transform.position);
		if (distance > attackRadius) {
			_controller.target = player.transform.position;
		} else {
			_controller.Stop();
			// attack
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		OnTrigger(other);
	}

	private void OnTriggerStay2D(Collider2D other) {
		OnTrigger(other);
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			_controller.Stop();
		}
	}

	private bool LineOfSight(Vector2 target) {
		RaycastHit2D hit = Physics2D.Raycast(_transform.position, target - (Vector2) _transform.position, watchRadius,
			attackMask);
		return hit.collider != null && hit.collider.CompareTag("Player");
	}

	private void OnDrawGizmos() {
		// Watch radius
		Handles.color = Color.cyan;
		Handles.DrawWireDisc(transform.position, Vector3.forward, watchRadius);
		// Attack radius
		Handles.color = Color.red;
		Handles.DrawWireDisc(transform.position, Vector3.forward, attackRadius);
		// Crowd radius
		Handles.color = new Color(1f, 0.5f, 0.5f);
		Handles.DrawWireDisc(transform.position, Vector3.forward, crowdRadius);
		// Line of sight
		if (_controller.target != transform.position) {
			Handles.color = Color.yellow;
			Handles.DrawLine(transform.position, _controller.target);
		}
	}
}