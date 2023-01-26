using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideOnKey : MonoBehaviour {
    public KeyCode key;
    public GameObject obj;
    void Update() { if(Input.GetKeyDown(key)) { obj.SetActive(!obj.activeSelf); } }
}
