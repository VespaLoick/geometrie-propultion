using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textedudebut : MonoBehaviour
{
    // Start is called before the first frame update
    public static int nbessais = 0 ;
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<TextMesh>().text == "aie")
        {
            nbessais++;
        }
        GetComponent<TextMesh>().text = ("nombre d'essais : " + nbessais);
    }
}
