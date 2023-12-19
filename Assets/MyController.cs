using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.VFX;

public class MyController : MonoBehaviour
{
    public GameObject portal1;
    public GameObject point1;
    public GameObject portal2;
    public GameObject point2;
    VisualEffect myv;
    VisualEffect myv1;
    public float tamaño;
    bool cerca;
    void Start()
    {
        myv = portal1.GetComponent<VisualEffect>();
        myv1 = portal2.GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
       
        SizePortal(tamaño, myv1);
        SizePortal(tamaño, myv);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Por")
        {
            if (other.gameObject.GetComponent<VisualEffect>() == myv)
            {
                StartCoroutine(Tp1(point2));
            }
            else
            {
                StartCoroutine(Tp1(point1));
            }           
        }
    }
    IEnumerator Tp1(GameObject portal)
    {
        tamaño = 2;
        yield return new WaitForSecondsRealtime(0.54f);
        this.gameObject.SetActive(false);
        transform.position = portal.transform.position;
        transform.rotation = portal.transform.rotation;
        this.gameObject.SetActive(true);
    }
    public void SizePortal(float size, VisualEffect ve)
    {
        
        ve.SetFloat("size", size);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Por")
        {
            tamaño = 0.33f;
        }
        }

}
