using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMover : MonoBehaviour {

    public string pigeonName;
    public GameObject pigeon;
    public bool attached = false;

    public sendPlayerPosition spp;

    public List<Transform> targets;
    public Transform target;

    public bool moving = false;
    public float moveSpeed = 1;

    public float idleTimer;
    public float idleTimeMin = 3;
    public float idleTimeMax = 10;

    public void Start() {
        idleTimer = Random.Range(idleTimeMin, idleTimeMax);
        int r = Random.Range(0, targets.Count);
        target = targets[r];        
    }

    // Update is called once per frame
    void Update() {

        //attach random pigeon mover (with space key).
        if(!attached) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                pigeon = GameObject.Find(pigeonName);
                if (pigeon != null) { attached = true;
                    Debug.Log("Attached pigeon to ARENA Object with name \"" + pigeonName + "\".");
                }
            }
        } else {
            pigeon.transform.position = transform.position;
            pigeon.transform.rotation = transform.rotation;
        }

        //If Moving, then move closer to target
        if(moving) {
            if(Vector3.Distance(target.position, transform.position) > 0.2f) {
               spp.state = 1;
               transform.LookAt(target.position);
               transform.Translate(0,0,moveSpeed*Time.deltaTime);
            } else {
               moving = false;
               idleTimer = Random.Range(idleTimeMin, idleTimeMax);
               Debug.Log("Pigeon switched to idle.");
            }

        } 
        //If not moving, then idle.
        else {
            //randomly move over time
            if(idleTimer > 0) {
                idleTimer -= Time.deltaTime;
                spp.state = 0;
                moving = false;
            } else {
                int r = Random.Range(0, targets.Count);
                target = targets[r];
                moving = true;
                Debug.Log("Pigeon switched to move.");
            }
        }
    }
}
