using UnityEngine.SceneManagement;
using UnityEngine;

public class goToMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
    }
}
