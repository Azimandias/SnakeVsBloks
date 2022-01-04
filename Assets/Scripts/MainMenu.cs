using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Movement Points;
    private void Start()
    {
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }
}
