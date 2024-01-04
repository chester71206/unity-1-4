using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
   
    public GameObject swordbomb;
    public Transform left_laser_end;
    public Transform right_laser_end;

    public Transform eyes_transform;
    public float gunRange = 50f;
    public float fireRate = 8f;
    public float moveDuration = 3f; // 移動時間
    public float laserDuration = 0.05f;
    public Transform player;
    AudioSource audio;
    LineRenderer laserLine;
    float fireTimer = 8f;
    public life_change life_controler;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        // laserLine.material.color = Color.white;

    }
     void Start()
    {
        audio = GetComponent<AudioSource>();
        Debug.Log(laserLine.widthCurve);
    }
    void Update()
    {
        laserLine.SetPosition(0, eyes_transform.position);
        fireTimer += Time.deltaTime;

        if (fireTimer > fireRate)
        {
            fireTimer = 0;

            laserLine.SetPosition(0, eyes_transform.position);
            Vector3 temp = eyes_transform.position;
            temp.y = -4.25f;
            StartCoroutine(MoveLaser(eyes_transform.position, temp)); // 開始移動射線
        }
    }

    IEnumerator MoveLaser(Vector3 startPos, Vector3 endPos)
    {
        audio.Play();
        Vector3 newLaserPos;
        laserLine.enabled = true;
        float elapsedTime = 0;
        bool hitPlayer = false;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / moveDuration;
            Vector3 currentPos = Vector3.Lerp(eyes_transform.position, endPos, t);

            laserLine.SetPosition(1, currentPos);

            //RaycastHit2D hit = Physics2D.Raycast(currentPos, Vector2.down); // 往下射線檢測地板
            RaycastHit2D hit = Physics2D.Linecast(eyes_transform.position, currentPos);
            if (hit.collider != null && hit.collider.CompareTag("ground"))
            {
                endPos = hit.point; // 如果射到地板，更新終點為地板碰撞點
            }

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                hitPlayer = true;
                for (int i = 0; i < 50; i++)
                {
                    StartCoroutine(sword_animate());
                    life_controler.minusDisplay();
                }
            }

            yield return null;
        }
        // 如果沒有擊中玩家，繼續在地面上移動一段時間
        float extraTime = 0;
        Vector3 lastPos = endPos;
        if(lastPos.x>player.position.x)
        {
            newLaserPos = left_laser_end.position;
        }
        else
        {
            newLaserPos =right_laser_end.position;
        }
        while (extraTime < 1f) //&& lastPos.x!= newLaserPos.x
        {
            extraTime += Time.deltaTime;
            



            lastPos = Vector3.MoveTowards(lastPos, newLaserPos, Time.deltaTime * 50f);

            laserLine.SetPosition(1, lastPos);
            //RaycastHit2D hit = Physics2D.Raycast(lastPos, Vector2.down); // 往下射線檢測地板
            RaycastHit2D hit = Physics2D.Linecast(eyes_transform.position, lastPos);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                hitPlayer = true;
                for(int i = 0; i < 50; i++)
                {
                    StartCoroutine(sword_animate());
                    life_controler.minusDisplay();
                }
                
            }

            yield return null;
        }
        audio.Stop();
        laserLine.enabled = false;
    }
    IEnumerator sword_animate()
    {

        swordbomb.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        swordbomb.SetActive(false);
    }
}