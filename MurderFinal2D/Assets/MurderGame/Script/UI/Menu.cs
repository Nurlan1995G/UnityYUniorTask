using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject gameObject)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
