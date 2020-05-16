using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public Transform itemsParent;

    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
   
        //Within 'Inventory' we trigger 'onItemChangedCallBack' when removing or adding item
        //We also call 'UpdateUI' when removing/adding item
        inventory.onItemChangedCallBack += UpdateUI;

        //Through referencing itemsParent, 
        //Finds all the components within the 'InventorySlot'
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        
    }
	
	// Update is called once per frame
	void Update () {
        //"If you press the button for "Inventory..."
		if (Input.GetButtonDown("Inventory"))
        {
            //Changes active state of the inventory
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void UpdateUI()
    {
        for(int i = 0; i <slots.Length; i++)
        {
            //Checks if there is space to add items
            if(i < inventory.items.Count)
            {
                //Within the specific slot, add the new item into the 'item' array (found within Inventory)
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                //If there is no more items to add, Clears that slot
                slots[i].ClearSlot();
            }
        }
    }
}
