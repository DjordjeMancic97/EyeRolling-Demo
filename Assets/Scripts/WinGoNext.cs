using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class WinGoNext : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(goNext());
        }
    }

    IEnumerator goNext()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
