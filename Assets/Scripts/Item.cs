using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    // overrides old name definition
    new public string name = "New Item";
    public Sprite icon = null;
    public string Description = ". . .";
}
