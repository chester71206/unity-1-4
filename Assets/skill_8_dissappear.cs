using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_8_dissappear : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // 假設 entry 是你的消失動畫
        animator.enabled = false; // 根據 flag 啟用/禁用動畫播放
    }
    public void turn_animate()
    {
        animator.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
