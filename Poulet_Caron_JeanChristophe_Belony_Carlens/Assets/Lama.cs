using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lama : MonoBehaviour
{
    public GameObject cible;
    public float distanceVision = 10.0f;
    public LayerMask masqueRaycast;
    public float vitesseChasse = 3.0f;
    public float vitessePatrouille = 3.0f;
    private Animator anim;
    private Rigidbody2D rig;
    private Vector3 visionDirection;
    private Vector3 mouvementDirection;

    public enum EnumLamas
    {
        eInactif = 1,
        ePatrouille = 2,
        eChasse = 4
    };
    public EnumLamas etat;
    private bool enMouvement()
    {
        return (etat & (EnumLamas.ePatrouille | EnumLamas.eChasse)) != 0;
    }

    private bool PatrouilleOuChasse()
    {
        return etat != EnumLamas.eInactif;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (enMouvement())
        {
            anim.SetFloat("Vitesse", mouvementDirection.magnitude);
            anim.SetFloat("Horizontal", mouvementDirection.x);
            anim.SetFloat("Vertical", mouvementDirection.y);
            float vitesse = etat == EnumLamas.eChasse ? vitesseChasse : vitessePatrouille;
            rig.velocity = mouvementDirection * vitesse;
        }
        else
        {
            rig.velocity = Vector2.zero;
            anim.SetFloat("Vitesse", 0.0f);
        }
    }


    void FixedUpdate()
    {
        if (PatrouilleOuChasse())
        {
            visionDirection = cible.transform.position - transform.position;
            visionDirection.Normalize();
            RaycastHit2D rayon = Physics2D.Raycast(transform.position, visionDirection, distanceVision, masqueRaycast);

            float distance_destination = distanceVision;
            EnumLamas vielEtat = etat;
            etat = EnumLamas.ePatrouille;
            if (rayon.collider != null)
            {
                distance_destination = rayon.distance;
                if (rayon.collider.gameObject.layer == LayerMask.NameToLayer("Joueur"))
                {
                    etat = EnumLamas.eChasse;
                    mouvementDirection = visionDirection;
                }
            }
            Vector3 depart = transform.position;
            Vector3 delta = visionDirection * distance_destination;
            Vector3 destination = depart + delta;
            Vector3 perpendiculaire = new Vector3(visionDirection.y, -visionDirection.x, visionDirection.z);
            Debug.DrawRay(transform.position, delta); //Ou bien Debug.DrawLine(depart,destination);
            const float largeurT = 0.5f;
            Debug.DrawRay(destination, perpendiculaire * largeurT);
            Debug.DrawRay(destination, -perpendiculaire * largeurT);

            if (vielEtat != etat)
            {
                if (etat == EnumLamas.ePatrouille)
                {
                    StartCoroutine(CoroutinePatrouille());
                }
                else if (etat == EnumLamas.eChasse)
                {
                    StopCoroutine(CoroutinePatrouille());
                }
            }
        }
    }

    IEnumerator CoroutinePatrouille()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            mouvementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            mouvementDirection.Normalize();
            yield return new WaitForSeconds(Random.Range(1.5f, 3.0f));
            mouvementDirection = Vector2.zero;
            yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Joueur"))
        {
            etat = EnumLamas.eInactif;
        }
    }
}
