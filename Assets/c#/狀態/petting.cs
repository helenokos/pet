using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class petting : MonoBehaviour {
    public Text ChatText;
    public Image status;
    private Button btn;
    private float MinHp = 0;    //最小生命值
    private float MaxHp = 100;  //最大生命值
    public float nowHP;        //當前生命值
    public Text percentage;
    private string percentageHP;
    

    // Start is called before the first frame update
    void Start() {
        nowHP = MinHp;
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update() {
        status.fillAmount = nowHP / MaxHp;
        percentageHP = nowHP.ToString();
        percentage.text = percentageHP + "%";
    }

    void hp() {
        if(nowHP < 100) {
            nowHP += 20;
        }
    }
}
