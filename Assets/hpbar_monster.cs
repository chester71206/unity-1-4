using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpbar_monster : MonoBehaviour
{
    public float HP;
    public int MaxHP;
    [SerializeField] RectTransform _hp;
    public count_score monsterlife_controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP = monsterlife_controller.currmonsterlife;
        _hp.GetComponent<RectTransform>().localScale = new Vector3(HP / MaxHP, 1, 1);
    }
    public void AddHP()
    {
        //if (isCountingDown) 
        HP = (HP + 1 > MaxHP) ? MaxHP : (HP + 1);
    }
    public void minusHP()
    {
        //if (isCountingDown)
        //{
        if (HP-1 > 0)
        {
            HP = HP - 1;
        }
        else
        {
            HP = 0;
        }

        //}

    }

}
