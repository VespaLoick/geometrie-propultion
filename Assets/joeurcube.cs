using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joeurcube : MonoBehaviour
{
    public float vitessaut ;//= 8.0f ;
    public float vitesstourne ;//= -1.5f;
    Rigidbody2D joueurephy ;
    GameObject rotator;
    bool touchsol = false ;

    public bool doestouchsol(RaycastHit2D touchesol)
    {
        if (touchesol.collider == null)
        {
            return false ;
        }
        else 
        {
            float distance = Mathf.Abs(touchesol.point.y - transform.position.y);
            return distance < 0.33f ;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rotator = transform.GetChild (0).gameObject;
        joueurephy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //   RaycastHit2D rtouchesol = Physics2D.Raycast( joueurephy.transform.position , Vector2.down , 1.0f , LayerMask.GetMask("soll") );
        //   touchsol = doestouchsol(rtouchesol);
        if (Input.GetKey(KeyCode.Space) && touchsol ) //quand on touche espace et le sol
        { 
            
            Vector2 bougey = joueurephy.velocity  ;
            bougey[1] = vitessaut;
            joueurephy.velocity = bougey;
        }
        
        if(!touchsol) //quand ca tourne
        {
           rotator.transform.Rotate(0.0f, 0.0f, vitesstourne, Space.Self);            
        }
        else // quand ca retouche le sol on redresse le cube
        {                            
            if (rotator.transform.rotation.eulerAngles.z <= 315 && rotator.transform.rotation.eulerAngles.z > 225 )
            {
                rotator.transform.rotation = Quaternion.Euler(0,0,270);
            }
            else if (rotator.transform.rotation.eulerAngles.z <= 225 && rotator.transform.rotation.eulerAngles.z > 135  )
            {
                rotator.transform.rotation = Quaternion.Euler(0,0,180);
            }
            else if(rotator.transform.rotation.eulerAngles.z <= 135 && rotator.transform.rotation.eulerAngles.z > 45   )
            {
                 rotator.transform.rotation = Quaternion.Euler(0,0,90);
            }
            else
            {
                rotator.transform.rotation = Quaternion.Euler(0,0,0);
            }     
        }
        touchsol = false ;
    }

    void OnTriggerStay2D(Collider2D sol)
    {
        if( sol.tag == "sol")
            touchsol = true;  
    }
}
