using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Text = TMPro.TextMeshProUGUI;
public class gamemannager : MonoBehaviour
{
    public List<int> player_skills = new List<int>();
    public womanaction Womanaction;
    public GameObject loselevelUI;
    public GameObject win;
    public bool endgame = false;
    public Text highscore_text;
    public bool wingame=false;
    // Start is called before the first frame update
    public void ClearPlayerSkills()
    {
        // 使用 Array.Clear 方法清除整個陣列
        player_skills.Clear();
    }
    public void lose_level()
    {
        loselevelUI.SetActive(true);
        Debug.Log("HI");
        endgame = true;
       // checkhigh_score();
        //UpdateHighScoreText();

    }
    public void win_level()
    {
        win.SetActive(true);
        wingame = true;
    }
    public  void presseasy()
    {
        SceneManager.LoadScene(1);
       // Debug.Log("2341");
    }
    public void pressmid()
    {
        SceneManager.LoadScene(2);
       // Debug.Log("2341");
    }
    public void presshard()
    {
        SceneManager.LoadScene(3);
       // Debug.Log("2341");
    }
    void Start()
    {
       // DontDestroyOnLoad(gameObject);
        //UpdateHighScoreText();
    }



    // Update is called once per frame
    void checkhigh_score()
    {
        //if (Womanaction.score > PlayerPrefs.GetInt("HighScore", 0))
       // {
       //     PlayerPrefs.SetInt("HighScore", Womanaction.score);
       // }
    }
    void UpdateHighScoreText()
    {
       // highscore_text.text = $"History High Score:{PlayerPrefs.GetInt("HighScore", 0)}";
    }
    void Update()
    {
        if (endgame == true ||　wingame==true)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
        }
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
            Debug.Log("2341");
        }*/
    }
}
