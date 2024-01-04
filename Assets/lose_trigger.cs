using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lose_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public game game;
    void Start()
    {
        
    }
     void OnTrigger()
    {
        game.Loselevel();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
