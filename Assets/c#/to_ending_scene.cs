using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class to_ending_scene : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        this.GetComponent<Button>().onClick.AddListener(ending_sc);
    }

    // Update is called once per frame
    void ending_sc() {
        SceneManager.LoadScene(2);
    }
}
