using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction01 : MonoBehaviour
{
    public Button btn;
    public GameObject Introduction_now;
    public GameObject Introduction_next;
    // Start is called before the first frame update
    void Start()
    {
        Introduction_now.SetActive(true); 
        btn = GetComponent<Button>();
        btn.onClick.AddListener(confirm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void confirm()
    {
        Introduction_now.SetActive(false);
        Introduction_next.SetActive(true);
    }
}
