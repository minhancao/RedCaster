using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    public static Controls player;

    public KeyCode jump { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode down { get; set; }
    public KeyCode cast { get; set; }
    public KeyCode shield { get; set; }
    public KeyCode interact { get; set; }
    public KeyCode inventory { get; set; }


    private void Awake()
    {
        if (player == null){
            DontDestroyOnLoad(gameObject);
            player = this;
        }
        else if (player != this){
            Destroy(gameObject);
        }

        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "W"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
        cast = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("castKey", "Q"));
        shield = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("shieldKey", "Space"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "E"));
        inventory = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("inventoryKey", "I"));
    }

}
