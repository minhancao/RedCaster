using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    [SerializeField]
    private Image healthBarImage;

    [SerializeField]
    private Text healthText;

    private void Start()
    {
        if (healthBarImage == null) {
            Debug.LogError("STATUS INDICATOR: No health bar object referenced!");
        }
        if (healthText == null)
        {
            Debug.LogError("STATUS INDICATOR: No health text object referenced!");
        }

    }

    public void SetHealth(int _cur, int _max) // _variables are private and only available in scope of method
    {
        float _value = (float)_cur / _max;

        healthBarImage.fillAmount = _value;

        healthText.text = _cur + "/" + _max + " HP";

    }

}
