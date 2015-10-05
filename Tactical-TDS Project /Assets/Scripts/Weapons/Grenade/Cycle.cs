using UnityEngine;
using System.Collections;

public enum Types { Teleport, Frag, Flash }

public class Cycle : MonoBehaviour {

    public Types types;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (types == Types.Flash) {
                types = 0;
            }
            else {
                types += 1;
            }
        }
    }
}