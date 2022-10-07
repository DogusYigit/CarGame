using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
public class CarCodes : MonoBehaviour
{
    float horizontal;
    Rigidbody2D rigid;
    public float carSpeed;
    int point;
    float floatTime;
    int counter;
    public Text PointText;
    Vector3 difference;
    public GameObject Camera;
    Vector3 Total;
    public Text TimeText;
    public Text WarningText;
    void Start()    
    {
        rigid = GetComponent<Rigidbody2D>();
        difference = Camera.transform.position - transform.position;
        WarningText.text = "Last 10 sec";
    }

    
    void Update()
    {
        CarMove();
        timePrint();
        PointText.text = "Point :" + " " + point.ToString();
        TimeText.text = "Time : " + counter;
        //Warning panel
        if (counter == 1)
        {
            WarningText.gameObject.SetActive(false);
        }
        else if (counter == 10)
            {
                WarningText.gameObject.SetActive(true);
                WarningText.text = "Time out";
            }
        else if (counter == 11)
                {
                    SceneManager.LoadScene(0);
                }

       
        //Cam Control
        Total = transform.position + difference;
        Camera.transform.position = new Vector3(Total.x, Total.y, Camera.transform.position.z);
    }
    void CarMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        rigid.AddForce(new Vector3(horizontal * carSpeed, 0, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            point++;
            Destroy(collision.gameObject);
        }  
      
        if (collision.gameObject.tag == "Finish")
        {
            WarningText.gameObject.SetActive(true);
            WarningText.text = "Game Over";

            
            SceneManager.LoadScene(0);
            
        }
    }
    void timePrint()
    { 
        floatTime +=  Time.deltaTime;
        if (floatTime > 1)
        {
            counter++;
            floatTime = 0;
        }
        
    }


}   

