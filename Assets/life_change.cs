using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TextMeshProUGUI;
public class life_change : MonoBehaviour
{
    public float initiallife = 10;
    public float currlife;
    public float maxHP;
    public Text _text;
    private bool invincible = false;
    private bool defence = false;
    // Start is called before the first frame update
    void Start()
    {
        currlife = initiallife;
        _text = this.GetComponent<Text>();
        _text.text = "Life: " + currlife.ToString();

    }
    public void invincible_on()
    {
        invincible = true;
    }
    public void invincible_off()
    {
        invincible = false;
    }
    public void defence_on()
    {
        defence = true;
    }
    public void defence_off()
    {
        defence = false;
    }
    public void minusDisplay()
    {
        if (currlife != 0 && invincible == false)
        {
            if (defence == true)
            {
                currlife -= 0.4f;
            }
            else
            {
                currlife -= 1;
            }
             _text.text = "Life: " + currlife.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currlife == 0)
        {
            FindObjectOfType<game>().Loselevel();
        }
        
    }
}
