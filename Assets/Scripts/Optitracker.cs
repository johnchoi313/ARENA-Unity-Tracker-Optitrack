using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------//
[System.Serializable]
public class OptitrackArenaObject {

    public GameObject obj;
    public string name; 
    public int rigidBodyId;
    public bool connected = false;

    public void ConnectOptitrack(OptitrackStreamingClient osc) { obj = GameObject.Find(name);
        if (obj != null) {
            if(obj.GetComponent<OptitrackRigidBody>() == null) {
                obj.AddComponent<OptitrackRigidBody>();
            }
            obj.GetComponent<OptitrackRigidBody>().enabled = true;
            obj.GetComponent<OptitrackRigidBody>().StreamingClient = osc;
            obj.GetComponent<OptitrackRigidBody>().RigidBodyId = rigidBodyId;
            connected = true;
            Debug.Log("Connected Optitrack Rigidbody [" + rigidBodyId + "] to ARENA Object with name \"" + name + "\".");
        }

    }    
    public void DisconnectOptitrack() {
        if (obj != null) {
            if(obj.GetComponent<OptitrackRigidBody>() != null) {
                obj.GetComponent<OptitrackRigidBody>().enabled = false;
            }
        }
        connected = false;    
        Debug.Log("Disconnected Optitrack Rigidbody [" + rigidBodyId + "] to ARENA Object with name \"" + name + "\".");
    }
}

//-------------------------------------//
public class Optitracker : MonoBehaviour {

    public List<OptitrackArenaObject> optitrackArenaObjects;

    public OptitrackStreamingClient osc;

    public void ConnectAllOptitrack() {
        foreach(OptitrackArenaObject optitrackArenaObject in optitrackArenaObjects) {             
            optitrackArenaObject.ConnectOptitrack(osc);
        }
    }
    public void DisconnectAllOptitrack() {
        foreach(OptitrackArenaObject optitrackArenaObject in optitrackArenaObjects) {             
            optitrackArenaObject.DisconnectOptitrack();
        }
    }

    // Start is called before the first frame update
    void Start() {
        
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            ConnectAllOptitrack();
        }
    }
}
