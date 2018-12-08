using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public Text name;
    public Text desc;
    Inventory inventory;


    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }

    void UpdateUI() 
    {
        Debug.Log("Updating UI");

        for (int i = 0; i < slots.Length; i++){
            if (i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i]);
            }
            else{
                slots[i].ClearSlot();
            }
        }
    }

    public void ChangeDescription(string sentence){
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        desc.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            desc.text += letter;
            yield return null; // waits a single frame
        }
    }
    public void SelectSlot(int index){
        for (int i = 0; i < slots.Length; i++){
            slots[i].highlight.SetActive(false);
        }
        slots[index].highlight.SetActive(true);
        name.text = slots[index].name;
        ChangeDescription(slots[index].desc);
    }
}
