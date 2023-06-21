using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLineController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            // Restart the scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
