using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class WallController : MonoBehaviour
{
    public Material miMaterial;
    public float disol;
    public bool acercar;
    float tmp = 0;
    void Start()
    {
        disol=miMaterial.GetFloat("_VerticalDisolve");
    }

    // Update is called once per frame
    void Update()
    {
        if (acercar)
        {
            tmp = tmp + (Time.deltaTime*1.2f);
            miMaterial.SetFloat("_VerticalDisolve", Mathf.Clamp(tmp, 0, 2));
        }
        else
        {
            tmp -= 1.2f * Time.deltaTime;
            miMaterial.SetFloat("_VerticalDisolve", Mathf.Clamp(tmp, 0, 2));
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("asd");
            acercar = true;
            tmp = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("asdqw412");
            acercar = false ;
            tmp = 1.1f;
        }
    }
}
