using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    //public LevelFading levelManager;

    public GameObject winScreen, tileObj,player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //levelManager.FadeToNextLevel();
            winScreen.SetActive(true);
            //tileObj.SetActive(false);
            //player.SetActive(false);
        }

    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
