using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendPlayerPosition : MonoBehaviour {

    public OSC osc;

    public Vector3 pos;

    public int state = 0; //0 = idle | 1 = walk | 2 = fly

    // Update is called once per frame
    void Update() {
        OscMessage message = new OscMessage();

        pos = transform.position;

        message.address = "/playerXY"; //actually sending X and Z position, Unity uses Y as vertical
        message.values.Add(pos.x);
        message.values.Add(pos.z);
        osc.Send(message);

        message.address = "/playerZ";
        message.values.Add(pos.y);
        osc.Send(message);

        /*
        message.address = "/rotationXYZ"; //actually sending X and Z position, Unity uses Y as vertical
        message.values.Add(transform.rotation.x);
        message.values.Add(transform.rotation.z);
        message.values.Add(transform.rotation.y);
        osc.Send(message);
        */

        message.address = "/state";
        message.values.Add(state);
        osc.Send(message);
    }
}
