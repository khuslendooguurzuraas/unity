using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public GameObject rightPosition, leftPosition, deadPrefab;
    bool changePosition, startGame;
    public float speed;
    void Start()
    {
        
    }

    
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);
        if(changePosition ==true && startGame==true)
        {
            transform.position = Vector3.Lerp(transform.position, 
            new Vector3(rightPosition.transform.position.x, transform.position.y, transform.position.z), 10f *Time.deltaTime);
        }

        if(changePosition == false && startGame == true)
        {
            transform.position = Vector3.Lerp(transform.position, 
            new Vector3(leftPosition.transform.position.x, transform.position.y, transform.position.z), 10f *Time.deltaTime);
        }


       if (Input.GetMouseButtonDown(0))
       {
        startGame = true;

            if(changePosition==false)
            {
             changePosition= true;
            }
            else if(changePosition==true)
            {
                changePosition = false;
            }
        }
    } 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "wall")
        {
            transform.gameObject.SetActive(false);
            for(int i=0; i<17; i++)
            {
                Instantiate(deadPrefab, transform.position, Quaternion.identity);
            }
        }
        if(other.tag== "finish")
        {
            Debug.Log("Finish");
        }
    }
}

