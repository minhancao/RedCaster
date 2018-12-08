using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour{

    public InventoryUI ui;

    public Image icon;
    public Button button;
    public string desc;
    public GameObject highlight;
    
    Item item;

    public void AddItem(Item newItem){
        item = newItem;
        icon.sprite = item.icon;
        desc = item.Description;
        icon.enabled = true;
        button.enabled = true;
        name = item.name;
    }

    public void ClearSlot(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    //public void SelectSlot() {
    //    highlight.SetActive(true);
    //    /ui.ChangeDescription(item.Description);
    //}

    //public void DeselectSlot(){
    //    highlight.SetActive(false);
    //    ui.ChangeDescription("");
    //}
}
