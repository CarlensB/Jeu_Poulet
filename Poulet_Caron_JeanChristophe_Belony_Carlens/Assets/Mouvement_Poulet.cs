using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement_Poulet : MonoBehaviour
{
    public float vitesse = 5.0f;
    public float tempsMarcheCelebration;
    public float tempsPicossement;
    public LayerMask masqueRaycast;
    private Vector3 mouvement;
    private Vector3 dernierMouvement;
    public Animator animator;
    private Rigidbody2D rig;
    private bool isControlable;
    public GameObject explosion;


    void Start()
    {
        mouvement.z = 0.0f;
        dernierMouvement = new Vector3(0.0f, -1.0f, 0.0f);
        isControlable = true;
        rig = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        //Gerer les touches du mouvement
        if (isControlable){
            mouvement.x = Input.GetAxisRaw("Horizontal");
            mouvement.y = Input.GetAxisRaw("Vertical");
        }
        if (mouvement.sqrMagnitude > 0.001f){
            dernierMouvement = mouvement;
        }

        //Gerer les animations de idle
        animator.SetFloat("LastHorizontal", dernierMouvement.x);
        animator.SetFloat("LastVertical", dernierMouvement.y);

        //Gerer les animations de mouvement
        animator.SetFloat("Speed", mouvement.sqrMagnitude);
        animator.SetFloat("Horizontal", mouvement.x);
        animator.SetFloat("Vertical", mouvement.y);
    }


    private void FixedUpdate()
    {
        rig.velocity = mouvement.normalized * vitesse;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isControlable = false;
        mouvement = Vector3.zero;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemie"))
        {
            Camera.main.transform.parent = null;
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        if(collision.name == "DouzaineOeufsEnOr")
        {
            StartCoroutine(Celebration());
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemie"))
        {
            isControlable = false;
            mouvement = Vector3.zero;
            Camera.main.transform.parent = null;
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }


    IEnumerator Celebration()
    {
        while (true)
        {
            mouvement.x = 1.0f; //Marche sur une courte distance dans une direction
            yield return new WaitForSeconds(tempsMarcheCelebration);
            mouvement.x = 0.0f; //picosse une fois
            yield return new WaitForSeconds(tempsPicossement);                                
            mouvement.x = -1.0f; //Marche dans la direction opposé pendant la même distance
            yield return new WaitForSeconds(tempsMarcheCelebration);
            mouvement.x = 0.0f; //picosse une autre fois
            yield return new WaitForSeconds(tempsPicossement);
        }

    }




}
