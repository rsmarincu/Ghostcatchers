using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    Ghost ghost;

    public void AddGhost(Ghost newGhost)
    {
        ghost = newGhost;

        icon.sprite = ghost.icon;
        icon.enabled = true;
    }

    public void RemoveGhost()
    {
        ghost = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
