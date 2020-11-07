using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown : MonoBehaviour
{
    public GameObject Mpanel;
    public GameObject Ppanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void DeactivateM()
    {
        if (Mpanel.activeSelf == true)
        {
            Mpanel.SetActive(false);
        }
        else
        {
            Mpanel.SetActive(true);
        }

    }
    public void DeactivateP()
    {
        if (Ppanel.activeSelf == true)
        {
            Ppanel.SetActive(false);
        }
        else
        {
            Ppanel.SetActive(true);
        }
       
    }

}
