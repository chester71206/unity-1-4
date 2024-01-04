using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mpbar_player : MonoBehaviour
{
    public float MP;
    public float MaxMP;
    public float MPchange;
    [SerializeField] RectTransform _mp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mp.GetComponent<RectTransform>().localScale = new Vector3(MP / MaxMP, 1, 1);
        if(MP< MaxMP)
        {
            MP += MPchange * Time.deltaTime;
        }
      
    }
    public void AddMP()
    {
        //if (isCountingDown) 
        MP++;
    }
    public void minusMP()
    {
        MP--;
        //}

    }
}
