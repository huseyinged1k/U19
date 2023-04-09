using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    private Player player;
    [Header("Effects")]
    public GameObject telekineticEffectPrefab;
    public GameObject shrinkEffectPrefab;
    public GameObject growEffectPrefab;
    
    [Header("Body Part")] 
    public GameObject staffHead;
    public GameObject magicCircle;
    
    
    private GameObject _telekineticEffect;
    private GameObject _shrinkEffect;
    private GameObject _growEffect;
    private SoundEffects soundEffects;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        soundEffects = player.GetComponent<SoundEffects>();
    }

    private void Update()
    {
        //TODO: gec calisiyor bakilacak
        if(player.rb.velocity.y >= 0) soundEffects.PlaySound("jump");
        
        if (player.isTelekinetic && !player.gameOver)
        {
            if (_telekineticEffect != null) return;
            
            _telekineticEffect = Instantiate(telekineticEffectPrefab, staffHead.transform.position, staffHead.transform.rotation);
            soundEffects.PlaySound("telekinetic");
            return;
        }
        else Destroy(_telekineticEffect);

        if (player.isShrink && !player.gameOver)
        {
            if (_shrinkEffect != null) return;
            
            _shrinkEffect = Instantiate(shrinkEffectPrefab, magicCircle.transform.position, magicCircle.transform.rotation);
            soundEffects.PlaySound("shrink");
            Invoke("DelayedFalse", 1f);
            return;
        }
        else Destroy(_shrinkEffect);
        
        if (player.isGrow && !player.gameOver)
        {
            if (_growEffect != null) return;
            
            _growEffect = Instantiate(growEffectPrefab, magicCircle.transform.position, magicCircle.transform.rotation);
            soundEffects.PlaySound("grow");
            Invoke("DelayedFalse", 1f); 
            return;
        }
        else Destroy(_growEffect);
        
        soundEffects.StopSound();
    }

    void DelayedFalse()
    {
        player.isShrink = false;
        player.isGrow = false;
    }
}

