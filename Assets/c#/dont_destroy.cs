using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont_destroy : MonoBehaviour {
    private static GameObject[] objs;
    void Awake() {
        if (objs != null) {
            foreach (GameObject obj in objs)
                Destroy(obj); 
        }
        objs = GameObject.FindGameObjectsWithTag("BE");
        foreach (GameObject obj in objs)
            DontDestroyOnLoad(obj);        
    }
}