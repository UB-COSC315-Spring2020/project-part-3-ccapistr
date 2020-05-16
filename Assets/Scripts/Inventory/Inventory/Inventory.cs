using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    
    //Shared by all instances in a class 'Inventory'. through the name "instance"
    public static Inventory instance;
    
    #region Singleton
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            
        }
        /** Instance equals to this components.
        * 
        *  We will be able to access this component 
        *  by using "inventory.instance"
        *  
        *  This means that we can only have 1 Inverntory at ALL TIMES
        */
        instance = this;

    }
    #endregion
    //methods can subscribe to a delegate, triggerd: all methods are called
    //returns no value
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 20;

    //Creates a list of type 'Item' named "items"
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);

            //Triggers event, updates UI when change occurs within inventory (add/remove item)
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
        return true;

    }

    public void Remove(Item item)
    {
        items.Remove(item);

        //Triggers event, updates UI when change occurs within inventory (add/remove item)
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
