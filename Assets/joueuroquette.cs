using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueuroquette : MonoBehaviour
{
    public float accverticale;
    public float anglemax;
    public float vitessemax;
    public GameObject cube;
    Rigidbody2D joueurephy ;
    GameObject rotator;
    float vitesse = 0; 
        

    void Start()
    {
        rotator = transform.GetChild (0).gameObject;
        joueurephy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //quand on touche espace et le sol
        {          
            vitesse = vitesse + (accverticale * Time.deltaTime);
            if(vitesse > vitessemax)
                vitesse = vitessemax;
            Vector2 bougey = joueurephy.velocity  ;
            bougey[1] = vitesse;
            joueurephy.velocity = bougey;
        }
        else 
        {
            vitesse = joueurephy.velocity.y;
        }
        //reglage de l'angle de la fusé
        float angle = (joueurephy.velocity.y/vitessemax)*(anglemax);
        gameObject.transform.rotation = Quaternion.Euler(0,0,angle) ;
    }

    void OnTriggerStay2D(Collider2D sol)
    {
        if( sol.tag == "cube")
        {
            spawncube();
        }
    }
    bool checkcube = true;
    void spawncube()
    {
        if (checkcube)
        {
            checkcube = false;
            Destroy(gameObject);
            Instantiate(cube, transform.position,  transform.rotation);
        }
    }
}
