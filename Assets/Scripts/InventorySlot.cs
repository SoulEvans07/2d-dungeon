using System;
using UnityEngine;

[Serializable]
public class InventorySlot {
	private static readonly int UseTrigger = Animator.StringToHash("use");
	
	public GameObject slot;
	private GameObject item;
	public Animator _animator;

	public void Init() {
		if (slot.transform.childCount == 1) {
			this.item = slot.transform.GetChild(0).gameObject;
			this._animator = item.GetComponent<Animator>();
		}
	}

	public void Use() {
		if (_animator) {
			_animator.SetTrigger(UseTrigger);
		}
	}

	public void Selected(bool selected, PlayerAttack player) {
		if (item) {
			if (selected) {
				player.weapon = item.transform;
			}
			item.SetActive(selected);
		}
	}
}