using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float explosionvitesse ;
    public GameObject textedebut ;

    float animetime ;
    void Start()
    {        
       textedebut = GameObject.Find("textedudebut");       
       textedebut.GetComponent<TextMesh>().text = "aie";
       
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKey(KeyCode.Space) ) //quand on touche espace et le sol
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
