using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Text = TMPro.TextMeshProUGUI;
public class count_score : MonoBehaviour
{
    public int initialmonsterlife=10;
    public  int currmonsterlife;
    public  Text _text;
    // Start is called before the first frame update
    void Start()
    {
        currmonsterlife = initialmonsterlife;
        _text = this.GetComponent<Text>();
        _text.text = "Monsterlife: " + currmonsterlife.ToString();
    }
    public int GET_life()
    {
        return currmonsterlife;
    }
    public void minus_monster_life()
    {
        if (currmonsterlife >= 1)
        {
            currmonsterlife -= 1;
        }
        _text.text = "Monsterlife: " + currmonsterlife.ToString();
    }
    public void plus_monster_life()
    {
        currmonsterlife += 1;
        _text.text = "Monsterlife: " + currmonsterlife.ToString();
    }
    public void score_to_zero()
    {
        _text.text = "Monsterlife: " + "0";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
