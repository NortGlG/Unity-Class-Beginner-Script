using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMovement : MonoBehaviour {
    // public
    public GameObject Cube;
    public GameObject SpawnPoint;
    public float Offset = 1f;
    public float Duration = 1f;
    public float EulerOffset = 3f;
    public Transform LookTarget;
    public float ScaleFactor = 2f;

    // private
    private Vector3 startLerp;
    private Vector3 endLerp;
    private float timeLerp;
    private bool isLerp;

    // Start Here
    void Start() {
        Cube.transform.position = SpawnPoint.transform.position;
        isLerp = false;
        timeLerp = 0;
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)){ // Warp
            Cube.transform.position = Cube.transform.position + (new Vector3(0, 0, Offset));
        }
        if(Input.GetKeyDown(KeyCode.W)){ // Start Lerp
            if(!isLerp) {
                isLerp = true;
                startLerp = Cube.transform.position;
                endLerp = Cube.transform.position + (new Vector3(0, 0, Offset));
            }
        }
        if(isLerp){ // Lerp
            timeLerp += Time.deltaTime;
            float timeRemain = timeLerp / Duration;
            timeRemain = Mathf.Clamp01(timeRemain);
            Cube.transform.position = Vector3.Lerp(startLerp, endLerp, timeRemain);
            if(timeRemain >= 1.0f){
                timeLerp = 0;
                isLerp = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.E)){ // Rotate Y by EulerOffset
            Cube.transform.eulerAngles = Cube.transform.eulerAngles + (new Vector3(0, EulerOffset, 0));
        }
        if(Input.GetKeyDown(KeyCode.R)){ // Look at Target
            Vector3 Direction = LookTarget.position - Cube.transform.position;
            Cube.transform.rotation = Quaternion.LookRotation(Direction);
        }
        if(Input.GetKeyDown(KeyCode.T)){ // Scale Up
            Cube.transform.localScale = Cube.transform.localScale * ScaleFactor;
        }
        if(Input.GetKeyDown(KeyCode.Y)){ // Scale Down
            Cube.transform.localScale = Cube.transform.localScale * (1 / ScaleFactor);
        }
    }
}
