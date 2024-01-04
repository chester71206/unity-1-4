using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_follow_player : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = player.position;
       // this.transform.position = Vector3(temp.x-5f,temp.y,temp.z);

    }
}
