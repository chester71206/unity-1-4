using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public GameObject[] fruits;
    
    void Start()
    {
        /*fruits[0]=GameObject.Find("Apple");
        fruits[1] = GameObject.Find("Banana");
        fruits[2] = GameObject.Find("Orange");
        fruits[3] = GameObject.Find("bomb");*/
    }
 public count_score scoreTextController;
    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0f, 0f);
        this.transform.Rotate(new Vector3(0f, 0f, 1f), 5);
        if (this.transform.position.x < -10.0)
        {
            int randomFruitIndex = Random.Range(1, fruits.Length);
            this.gameObject.SetActive(false);
            fruits[randomFruitIndex].gameObject.transform.position = new Vector3(10, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            fruits[randomFruitIndex].SetActive(true);
        }


    }

    /*public void OnTriggerEnter2D(Collider2D other)
    {
        //other.gameObject.SetActive(false);
       // scoreTextController.AddScoreAndDisplay();
    }*/

}
