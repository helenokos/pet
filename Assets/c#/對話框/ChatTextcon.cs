using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatTextcon : MonoBehaviour
{
    public Text ChatText;
    public ScrollRect scrollRect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Canvas.ForceUpdateCanvases();  //控制可以滑动滑杆
        scrollRect.verticalNormalizedPosition = 0f; //将该值设置为0，可以控制文本框过多时，当前文本不被遮挡
        Canvas.ForceUpdateCanvases();  //控制可以滑动滑杆
    }
}
