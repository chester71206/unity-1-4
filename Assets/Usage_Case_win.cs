using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using System.Runtime.InteropServices;

public class Usage_Case_win : MonoBehaviour
{
    FlowerSystem flowerSys;
    private string myName;
    private bool progress = true;
    private bool startGame = false;
    private bool fightBoss = false;
    private bool BossDead = true;
    private bool GameOver = false;
    private bool isGameEnd = false;
    private int stage = 2;
    public bool touch = false;


    void Start()
    {
        var audioDemoFile = Resources.Load<AudioClip>("BGM_Joseph") as AudioClip;
        if (!audioDemoFile)
        {
            Debug.LogWarning("The audio file : 'bgm' is necessary for the demonstration. Please add to the Resources folder.");
        }

        flowerSys = FlowerManager.Instance.CreateFlowerSystem("FlowerSample", false);
        flowerSys.SetupDialog();

        // Setup Variables.
        myName = "蛋頭";
        flowerSys.SetVariable("MyName", myName);

        // Define your customized commands.
        flowerSys.RegisterCommand("UsageCase", CustomizedFunction);
        // Define your customized effects.
        flowerSys.RegisterEffect("customizedRotation", EffectCustomizedRotation);
    }

    void Update()
    {
        // ----- Integration DEMO -----
        // Your own logic control.
        if (flowerSys.isCompleted && !isGameEnd)
        {
            if (progress == startGame && stage == 0)
            {
                flowerSys.ReadTextFromResource("start");
                stage++;
            }
            else if (progress == fightBoss && stage == 1)
            {
                flowerSys.ReadTextFromResource("fightBoss");
                stage++;
            }
            else if (progress == BossDead && stage == 2)
            {
                flowerSys.ReadTextFromResource("BossDead");
                stage++;
            }
            else if (progress == GameOver && stage == -1)
            {
                flowerSys.ReadTextFromResource("Dead");
                stage = 0;
                startGame = true;
            }
        }

        if (!isGameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Continue the messages, stoping by [w] or [lr] keywords.
                flowerSys.Next();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Resume the system that stopped by [stop] or Stop().
                flowerSys.Resume();
            }
        }
    }

    private void CustomizedFunction(List<string> _params)
    {
        var resultValue = int.Parse(_params[0]) + int.Parse(_params[1]);
        Debug.Log($"Hi! This is called by CustomizedFunction with the result of parameters : {resultValue}");
    }

    IEnumerator CustomizedRotationTask(string key, GameObject obj, float endTime)
    {
        Vector3 startRotation = obj.transform.eulerAngles;
        Vector3 endRotation = obj.transform.eulerAngles + new Vector3(0, 180, 0);
        // Apply default timer Task.
        yield return flowerSys.EffectTimerTask(key, endTime, (percent) => {
            // Update function.
            obj.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, percent);
        });
    }

    private void EffectCustomizedRotation(string key, List<string> _params)
    {
        try
        {
            // Parse parameters.
            float endTime;
            try
            {
                endTime = float.Parse(_params[0]) / 1000;
            }
            catch (Exception e)
            {
                throw new Exception($"Invalid effect parameters.\n{e}");
            }
            // Extract targets.
            GameObject sceneObj = flowerSys.GetSceneObject(key);
            // Apply tasks.
            StartCoroutine(CustomizedRotationTask($"CustomizedRotation-{key}", sceneObj, endTime));
        }
        catch (Exception)
        {
            Debug.LogError($"Effect - SpriteAlphaFadeIn @ [{key}] failed.");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 檢查碰撞的物體是否是玩家
        if (collision.gameObject.tag == "Ball" && stage == 1)
        {
            // 將 touch 設置為 true
            startGame = false;
            fightBoss = true;
        }
        else if (collision.gameObject.tag == "Ball2" && stage == 2)
        {
            fightBoss = false;
            BossDead = true;
        }
        else if (collision.gameObject.tag == "dead")
        {
            stage = -1;
            GameOver = true;
        }
    }
}
