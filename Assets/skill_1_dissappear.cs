using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skill_1_dissappear : MonoBehaviour
{
    public Animator animator;
    public Button bookButton;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // 假設 entry 是你的消失動畫
        animator.enabled = false; // 根據 flag 啟用/禁用動畫播放
       // bookButton.interactable = false;
    }
    public void start_press()
    {
        // 在這裡加入你的按鈕按下時要做的事情
        // 啟用按鈕的互動狀態
        bookButton.interactable = true;
    }
    public void stop_press()
    {
        bookButton.interactable = false;
    }
    public void turn_animate()
    {
        animator.enabled = true;
    }
     public void turn_on()
    {
        animator.SetInteger("state", 1);
    }
    public void SETACTIVE_false()
    {
        gameObject.SetActive(false);
    }
    public void SETACTIVE_true()
    {
        gameObject.SetActive(true);
    }
    public void turn_off()
    {
        animator.SetInteger("state", 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
