using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度，你可以根據需要調整

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 水平軸向的輸入（左右移動）
        float verticalInput = Input.GetAxis("Vertical"); // 垂直軸向的輸入（上下移動）

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime; // 計算移動的向量

        transform.Translate(movement); // 將計算出的移動向量應用到物體的位置上
    }
}

