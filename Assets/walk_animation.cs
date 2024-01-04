using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_animation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    float Rate = 0.1f;
    float Timer =0f;
    bool direction = false; //false ек├ф

    bool walk = false; //false ек├ф
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A) )
        {
            walk = true;
            direction = false;
            //spriteRenderer.sprite = image2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            walk = true;
            direction = true;
            //spriteRenderer.sprite = image2;
        }

        if (walk == true && direction == false)
        {
            if (Timer >= 0.2f) {
                if(spriteRenderer.sprite ==image2)
                    spriteRenderer.sprite = image1;
                else
                    spriteRenderer.sprite = image2;
                Timer = 0;
            }
        }
        if (walk == true && direction == true)
        {
            if (Timer >= 0.2f)
            {
                if (spriteRenderer.sprite == image2)
                    spriteRenderer.sprite = image1;
                else
                    spriteRenderer.sprite = image2;
                Timer = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.D)&& direction==true)
        {
            walk = false;
            Timer = 0;
            spriteRenderer.sprite = image3;
        }
        if ( Input.GetKeyUp(KeyCode.A)&& direction==false)
        {
            walk = false;
            Timer = 0;
            spriteRenderer.sprite = image3;
        }
    }
    
}
