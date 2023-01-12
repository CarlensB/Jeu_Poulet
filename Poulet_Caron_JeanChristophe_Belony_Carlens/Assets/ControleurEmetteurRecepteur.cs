using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurEmetteurRecepteur : MonoBehaviour
{
    public GameObject emetteur;
    public GameObject recepteur;
    private Vector3 direction;

    void Start()
    {
        //On vérifie si l'emetteur et le recepteur sont sur une ligne droite
        //Si non, on les mets sur la même ligne
        
        float diffX = recepteur.transform.position.x - emetteur.transform.position.x;
        float diffY = recepteur.transform.position.y - emetteur.transform.position.y;
        if(diffX != 0 && diffY != 0)
        {
            if(diffX < diffY)
            {
                //recepteur.transform.position.x = emetteur.transform.position.x;
            }
            else
            {
                //recepteur.transform.position.y = emetteur.transform.position.y;
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        direction =  recepteur.transform.position - emetteur.transform.position;
        Debug.Log(direction);
        Debug.DrawLine(transform.position, recepteur.transform.position);
    }

    void FixedUpdate()
    {

    }


    public Vector3 getDirection()
    {
        return direction;
    }
}
