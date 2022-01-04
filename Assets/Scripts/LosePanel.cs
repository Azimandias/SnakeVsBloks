using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    public void Start()
    {

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
