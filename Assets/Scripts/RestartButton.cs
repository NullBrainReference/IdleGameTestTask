using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void Restart()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
