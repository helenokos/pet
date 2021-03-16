using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_btn_script : MonoBehaviour {
    public void Click() {
        SceneManager.LoadScene(1);
    }
}
