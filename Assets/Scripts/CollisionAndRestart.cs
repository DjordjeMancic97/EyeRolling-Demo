using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionAndRestart : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody rb;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            StartCoroutine(Test());
        }
    }

    IEnumerator Test()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
