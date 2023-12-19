using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public float timeToMove;
    public float limit;
    public bool IsMove;
    public float velocity;
    Vector3 inicial;
    void Start()
    {
        inicial = transform.position;
        IsMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMove)
        {
            timeToMove = 0;
            timeToMove += velocity * Time.deltaTime;
            Vector3 tmp = new Vector3(Mathf.Clamp(gameObject.transform.position.x - timeToMove, 0+ inicial.x, 4f+ inicial.x), gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = tmp;
        }
        else
        {
            timeToMove = 0;
            timeToMove += velocity * Time.deltaTime;
            Vector3 tmp = new Vector3(Mathf.Clamp(gameObject.transform.position.x + timeToMove, 0+ inicial.x, 4f+ inicial.x), gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = tmp;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsMove = true;
            Debug.Log("Entre");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("sali");
            IsMove = false;
           
        }
    }

}
