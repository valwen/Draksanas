
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefautItem = false;
    protected GameObject player;

    protected PlayerAbilities playerAbilities
    {
        get
        {
            if (player == null)
            {
                return null;
            }
            else
            {
                return player.GetComponent<PlayerAbilities>();
            }
        }
    }

    public void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }

    // Call this method to remove the item from inventory
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
        Debug.Log("Item removed");
    }


}
