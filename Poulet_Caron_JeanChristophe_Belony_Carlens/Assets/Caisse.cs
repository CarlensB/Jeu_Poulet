using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caisse : MonoBehaviour
{

    private Rigidbody2D rig;
    private bool ispushed =false;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ispushed)
        {
            //rig.AddForce(new Vector3(1.0f, 0.0f, 0.0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ispushed = true;
    }





}
