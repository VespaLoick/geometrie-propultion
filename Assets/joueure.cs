using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class joueure : MonoBehaviour
{
    // Start is called before the first frame update
     
    public float vitesseh ;//= 3.0f;    
    public bool estmort = false;
    public GameObject joueurexplosion ;
    Rigidbody2D joueurephy ;

    private void MajVitesse()
    {
        Vector2 bougex = joueurephy.velocity  ;
        bougex[0] = vitesseh;
        joueurephy.velocity = bougex;
    }

    private void chekvitesse()//si touche un mur 
    {
        Vector2 bougex = joueurephy.velocity  ;
        Debug.Log("vitesse: " + bougex[0]);
        if(bougex[0] < (vitesseh / 4))
        {
            Debug.Log("dead:" + bougex[0]);
            estmort = true ;
        }
    }
    void OnTriggerEnter2D(Collider2D collideur)//si touche un pique
    {
        if( collideur.tag == "pique")
        {
            estmort = true;        
            Debug.Log("dead:" + collideur.tag);
        }
    }
    void Start()
    {       
        joueurephy = GetComponent<Rigidbody2D>();
        MajVitesse();
    }
    // Update is called once per frame
    void Update()
    {

        chekvitesse();
        if (estmort)
        {            
            Destroy(gameObject);
            Instantiate(joueurexplosion, transform.position,  transform.rotation);
        }        
        MajVitesse();
    }
}


