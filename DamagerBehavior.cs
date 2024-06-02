using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerBehavior : MonoBehaviour {
    // public
    public int DamageValue;
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Terrain")){
            Destroy(gameObject);
            FXManager.Instance.AddHitPlayerFX(transform);
        }
    }
}
