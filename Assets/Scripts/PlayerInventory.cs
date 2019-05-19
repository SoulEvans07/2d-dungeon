using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	private PlayerAttack player;
	public int selected;
	public InventorySlot[] inventory;

	public void Start() {
		player = GetComponent<PlayerAttack>();
		for (int i = 0; i < inventory.Length; i++) {
			inventory[i].Init();
			inventory[i].Selected(i == selected, player);
		}
	}

	public void Use() {
		inventory[selected].Use();
	}

	private void Update() {
		for (int i = 0; i < inventory.Length; i++) {
			if (Input.GetKeyDown($"{i+1}")) {
				this.Select(i);
			}
		}
	}

	private void Select(int select) {
		this.selected = select;
		for (int i = 0; i < inventory.Length; i++) {
			inventory[i].Selected(i == this.selected, player);
		}
	}
}