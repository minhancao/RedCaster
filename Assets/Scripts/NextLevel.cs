using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    void OnTriggerEnter2D()
    {
        Debug.Log("Entered");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
