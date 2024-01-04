using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;
public class time_controler : MonoBehaviour
{
    public Text timeText;
    public float currentTime = 180f;
    private bool isCounting = true;

    // Start is called before the first frame update
    public float GET_time()
    {
        return currentTime;
    }
    void Start()
    {
        UpdateTimeText();
        InvokeRepeating("CountDown", 1f, 1f); // 延遲1秒後，每1秒執行一次CountDown方法
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void time_stop()
    {
        isCounting = false;
       // CancelInvoke("CountDown");
    }
    void CountDown()
    {
        if (isCounting)
        {
            currentTime--;
            UpdateTimeText();

            if (currentTime <= 0)
            {
                // 時間到，執行遊戲結束或其他相關操作
                isCounting = false;
            }
        }
    }
    void UpdateTimeText()
    {
        timeText.text = "Time: " + currentTime.ToString("F0"); // "F0" 將浮點數顯示為整數
    }
}


//另種寫法:
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;
public class time_controler : MonoBehaviour
{
    public Text timeText;
    public float currentTime = 60f;
    private bool isCounting = true;
    private float timerInterval = 1f; 
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTimeText();
        timer = timerInterval; 
        //InvokeRepeating("CountDown", 1f, 1f); // 延遲1秒後，每1秒執行一次CountDown方法
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting)
        {
            timer -= Time.deltaTime; 

            if (timer <= 0)
            {
                CountDown();
                timer = timerInterval; 
            }
        }

    }
    public void time_stop()
    {
        isCounting = false;
       // CancelInvoke("CountDown");
    }
    void CountDown()
    {
        if (isCounting)
        {
            currentTime--;
            UpdateTimeText();

            if (currentTime <= 0)
            {
                // 時間到，執行遊戲結束或其他相關操作
                isCounting = false;
            }
        }
    }
    void UpdateTimeText()
    {
        timeText.text = "Time: " + currentTime.ToString("F0"); // "F0" 將浮點數顯示為整數
    }
}

 */