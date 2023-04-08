using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    private Player player;
    [Header("Effects")]
    public GameObject telekineticEffectPrefab;
    
    [Header("Body Part")]
    public GameObject staffHead;
    private GameObject _telekineticEffect;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void LateUpdate()
    {
        if (player.isTelekinetic && !player.gameOver)
        {
            if (_telekineticEffect != null) return;
            _telekineticEffect = Instantiate(telekineticEffectPrefab, staffHead.transform.position, staffHead.transform.rotation);
        }
        else Destroy(_telekineticEffect);
    }
}

