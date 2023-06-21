using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public void LoadNextScene(int SceneID)
    {
        
        SceneManager.LoadScene(1);
    }
}
