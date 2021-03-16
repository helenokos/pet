using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anim_event : MonoBehaviour {
    private Text ChatText;
    private GameObject main_obj;
    private pet_controll_script main_script;

    void Start() {
        ChatText = GameObject.Find("/UI/ChatRoom/ChatRoomPanel/TextShowPanel/ChatText").GetComponent<Text>();
        main_obj = GameObject.Find("Pet");
        main_script = main_obj.GetComponent<pet_controll_script>();
    }

    void Update() {

    }

    public void Food() {
        ChatText.text += main_script.my_name;
        ChatText.text += "吃吃吃...yummy\n";
        GameObject food_obj = GameObject.Find("/UI/Button/食物");
        food food_script = food_obj.GetComponent<food>();
        food_script.nowHP += 20;

        GameObject src_obj = GameObject.Find("Pet");
        pet_controll_script src_script = src_obj.GetComponent<pet_controll_script>();
        src_script.check_ac();
        ++src_script.cnt;
    }

    public void book() {
        ChatText.text += main_script.my_name;
        ChatText.text += "獲得新靈感\n";
        GameObject teach_obj = GameObject.Find("/UI/Button/教育");
        teach teach_script = teach_obj.GetComponent<teach>();
        teach_script.nowHP += 20;

        GameObject src_obj = GameObject.Find("Pet");
        pet_controll_script src_script = src_obj.GetComponent<pet_controll_script>();
        src_script.check_ac();        
        ++src_script.cnt;
    }
    
    public void touch() {
        ChatText.text += main_script.my_name;
        ChatText.text += "很享受撫摸\n";
        GameObject pet_obj = GameObject.Find("/UI/Button/撫摸");
        petting pet_script = pet_obj.GetComponent<petting>();
        pet_script.nowHP += 20;

        GameObject src_obj = GameObject.Find("Pet");
        pet_controll_script src_script = src_obj.GetComponent<pet_controll_script>();
        src_script.check_ac();
        ++src_script.cnt;
    }

    public void game() {
        ChatText.text += main_script.my_name;
        ChatText.text += "玩得很開心\n";
        GameObject play_obj = GameObject.Find("/UI/Button/遊戲");
        play play_script = play_obj.GetComponent<play>();
        play_script.nowHP += 20;

        GameObject src_obj = GameObject.Find("Pet");
        pet_controll_script src_script = src_obj.GetComponent<pet_controll_script>();
        src_script.check_ac();
        ++src_script.cnt;
    }

}
