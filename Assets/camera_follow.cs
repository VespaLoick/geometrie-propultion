using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    // Start is called before the first frame update
    public float decalagearriere = 4;
    GameObject joeur; 
  
    void Start()
    {     
        GameObject[] joeurtmptab =  GameObject.FindGameObjectsWithTag("Player"); 
        if (joeurtmptab[0] != null) //
        {
            joeur = joeurtmptab[0];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(joeur)
        {
            Vector2 deblacement = new Vector2(joeur.transform.position.x + decalagearriere , transform.position.y );           
            transform.position = deblacement;
        }
        else
        {
            GameObject[] joeurtmptab =  GameObject.FindGameObjectsWithTag("Player"); 
            if (joeurtmptab[0] != null) //
            {
                joeur = joeurtmptab[0];
            }            
        }
    }


}
