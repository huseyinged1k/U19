using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    //public LevelFading levelManager;

    public GameObject winScreen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //levelManager.FadeToNextLevel();
            winScreen.SetActive(true);
        }
    }
}
