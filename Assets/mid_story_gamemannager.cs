using Flower;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mid_story_gamemannager : MonoBehaviour
{
   // public FlowerSystem flowerSystem;
    public UsageCase usageCase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J)){
            //flowerSystem.RemoveDialog();
            //(flowerSystem.CmdFunc_dialogHide_Task(_params));
            // flowerSystem.RemoveDialog();
            SceneManager.LoadScene(2);
        }
    }
}
