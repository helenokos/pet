using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class pet_controll_script : MonoBehaviour {
    private GameObject my_pet;
    private GameObject UI;
    private GameObject name_pet_UI;
    private GameObject warm;
    private GameObject cold;
    private Text show_pet_name;
    private Animator anim;
    private int my_pet_num = 0;
    private int cur_game_status = 0;
    private const int game_status_num = 4;
    private const int pet_num = 7;
    private string[] pet_name;
    private string[] pet_name_path;
    private string[] game_status;
    private bool ac_on = false;
    
    public Button confirm_name_btn;
    public Button[] btn;
    public int cnt = 0;
    public string my_name;


    void Start() {
        //default name
        my_name = "Alice";

        //setting game status
        game_status = new string[game_status_num] {"introduce", "opening", "name", "game"};

        //setting pet info & get object
        pet_name = new string[pet_num] {"egg", "slime", "Botamon", "meow", "Rabbiccino", "alien", "blue_Cat"};
        pet_name_path = new string[pet_num] {"/Pet/egg/egg", "/Pet/teenager/slime", "/Pet/teenager/Botamon", "/Pet/adult/meow", "/Pet/adult/Rabbiccino", "/Pet/adult/alien", "/Pet/adult/blue_Cat"};
        for (int i = 0; i < pet_num; ++i) {
            my_pet = GameObject.Find(pet_name_path[i]);
            my_pet.SetActive(false);
        }

        //get name pet UI & setting
        name_pet_UI = GameObject.Find("opening");
        confirm_name_btn.onClick.AddListener(confirm_name);
        name_pet_UI.SetActive(false);

        //get UI object & setting
        UI = GameObject.Find("UI");
        show_pet_name = GameObject.Find("/UI/狀態欄/pet_name").GetComponent<Text>();
        warm = GameObject.Find("/UI/ac/warm");
        warm.SetActive(true);
        cold = GameObject.Find("/UI/ac/cold");
        cold.SetActive(false);
        
        //setting btn listener
        btn[0].onClick.AddListener(ac); btn[1].onClick.AddListener(food); btn[2].onClick.AddListener(teach); btn[3].onClick.AddListener(pet); btn[4].onClick.AddListener(play); btn[5].onClick.AddListener(evolution);

        //setting my pet
        init_pet(my_pet_num);
    }

    void Update() {
        switch(game_status[cur_game_status]) {
        case "introduce": {
            anim.Play("Base Layer.open_animation");
            cur_game_status = 1;
            break;
        }
        default: {
            disable_btn_while_playing_anim();
            break;
        }
        }
    }

    void init_pet(int i) {
        my_pet.SetActive(false);
        my_pet_num = i;
        my_pet = GameObject.Find(pet_name_path[my_pet_num]);
        my_pet.SetActive(true);
        init_btn(i);
        init_status();
        anim = my_pet.GetComponent<Animator>();
    }

    void init_btn(int i) {
        if (i == 0) {
            btn[0].interactable = true; btn[1].interactable = false; btn[2].interactable = false; btn[3].interactable = false; btn[4].interactable = false;
        } else {
            btn[0].interactable = true; btn[1].interactable = true; btn[2].interactable = true; btn[3].interactable = true; btn[4].interactable = true;
        }
        if (game_status[cur_game_status] == "game" && can_evolution()) {
            btn[5].interactable = true;
        } else {
            btn[5].interactable = false;
        }
    }

    void init_status() {
        GameObject ac_obj = GameObject.Find("/UI/Button/冷氣");
        Airconditioner ac_script = ac_obj.GetComponent<Airconditioner>();
        ac_script.nowHP = 0;

        GameObject food_obj = GameObject.Find("/UI/Button/食物");
        food food_script = food_obj.GetComponent<food>();
        food_script.nowHP = 0;

        GameObject teach_obj = GameObject.Find("/UI/Button/教育");
        teach teach_script = teach_obj.GetComponent<teach>();
        teach_script.nowHP = 0;

        GameObject pet_obj = GameObject.Find("/UI/Button/撫摸");
        petting pet_script = pet_obj.GetComponent<petting>();
        pet_script.nowHP = 0;

        GameObject play_obj = GameObject.Find("/UI/Button/遊戲");
        play play_script = play_obj.GetComponent<play>();
        play_script.nowHP = 0;

        cnt = 0;
    }

    void disable_btn_while_playing_anim() {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("New State")) {
            if (game_status[cur_game_status] == "opening") {
                UI.SetActive(false);
            }
            for (int i = 0; i < 6; ++i)
                btn[i].interactable = false;
        } else {
            if (game_status[cur_game_status] == "opening") {
                cur_game_status = 2;
                name_pet();
            } else if (game_status[cur_game_status] == "game") {
                init_btn(my_pet_num);
            }
        }
    }

    void name_pet() {
        name_pet_UI.SetActive(true);
    }

    void confirm_name() {
        GameObject toggle_group_obj = GameObject.Find("/opening/name寵物");
        ToggleGroup toggle_group = toggle_group_obj.GetComponent<ToggleGroup>();
        var toggles = toggle_group.ActiveToggles();
        foreach (Toggle i in toggles) {
            my_name = i.GetComponentInChildren<Text>().text;
        }
        UI.SetActive(true);
        name_pet_UI.SetActive(false);
        show_pet_name.text = my_name;
        cur_game_status = 3;
    }

    public void check_ac() {
        if (my_pet_num == 0) return;
        GameObject ac_obj = GameObject.Find("/UI/Button/冷氣");
        Airconditioner ac_script = ac_obj.GetComponent<Airconditioner>();
        if ((ac_on && my_pet_num%2 == 1) || (!ac_on && my_pet_num%2 == 0)) {
            if (ac_script.nowHP < 100) {
                ac_script.nowHP += 20;
            }
        } else {
            if (ac_script.nowHP > 0) {
                ac_script.nowHP -= 20;
            }
        }
    }

    void ac() {
        GameObject ac_obj = GameObject.Find("/UI/Button/冷氣");
        Airconditioner ac_script = ac_obj.GetComponent<Airconditioner>();
        if (ac_on) {
            cold.SetActive(false);
            warm.SetActive(true);
            ac_on = false;            
            ac_script.ChatText.text += "冷氣已關閉\n";
        } else {
            warm.SetActive(false);
            cold.SetActive(true);
            ac_on = true;
            ac_script.ChatText.text += "冷氣已開啟\n";
        }
        check_ac();
    }
    
    void teach() {
        anim.Play("Base Layer."+pet_name[my_pet_num]+"_teach");
    }

    void food() {
        anim.Play("Base Layer."+pet_name[my_pet_num]+"_food");
    }

    void pet() {
        anim.Play("Base Layer."+pet_name[my_pet_num]+"_pet");
    }

    void play() {
        anim.Play("Base Layer."+pet_name[my_pet_num]+"_play");
    }

    bool can_evolution() {
        GameObject food_obj = GameObject.Find("/UI/Button/食物");
        food food_script = food_obj.GetComponent<food>();
        float value = food_script.nowHP;
        if (my_pet_num == 0 || (value >= 100 && my_pet_num < 3)) {
            return true;
        } else {
            return false;
        }
    }

    void evolution() {
        switch (my_pet_num) {
        case 0: {
            if (ac_on) {
                init_pet(1);
            } else {
                init_pet(2);
            }
            break;
        }
        case 1: {
            if (cnt < 10)
                init_pet(3);
            else
                init_pet(5);
            break;
        }
        case 2: {
            if (cnt < 10)
                init_pet(4);
            else
                init_pet(6);
            break;
        }
        }
        btn[5].interactable = false;
    }
}