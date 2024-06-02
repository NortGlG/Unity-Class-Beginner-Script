using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {
    // public
    public static FXManager Instance;
    [Header("Particle Effect")]
    public GameObject FX_Jump;
    public GameObject FX_HitPlayer;
    public GameObject FX_Dead;
    [Header("Audio Clip")]
    public AudioClip AC_Jump;
    public AudioClip AC_HitPlayer;
    public AudioClip AC_Music;
    public AudioClip AC_Score;
    public AudioClip AC_Dead;

    // private
    private AudioSource source;

    // Start Here
    private void Start(){
        source = GetComponent<AudioSource>();
        source.clip = AC_Music;
        source.Play();
    }
    public void PlaySound(AudioClip index){
        source.PlayOneShot(index);
    }
    private void Awake(){
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void AddJumpFX(Transform index){
        GameObject fx = Instantiate(FX_Jump, index.position, Quaternion.identity);
        source.PlayOneShot(AC_Jump);
        Destroy(fx, 3f);
    }
    public void AddHitPlayerFX(Transform index){
        GameObject fx = Instantiate(FX_HitPlayer, index.position, Quaternion.identity);
        source.PlayOneShot(AC_HitPlayer);
        Destroy(fx, 3f);
    }
    public void AddScoreFX(Transform index){
        source.PlayOneShot(AC_Score);
    }
    public void AddDeadFX(Transform index){
        GameObject fx = Instantiate(FX_Dead, index.position, Quaternion.identity);
        source.PlayOneShot(AC_Dead);
        Destroy(fx, 3f);
    }
}
