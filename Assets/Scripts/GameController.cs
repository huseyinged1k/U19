using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject pausePop,winPop;
    public void Replay()
    {
        Time.timeScale = 1;
        pausePop.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseBtn()
    {
        pausePop.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeBtn()
    {
        pausePop.SetActive(false);

        Time.timeScale = 1;
    }

}
