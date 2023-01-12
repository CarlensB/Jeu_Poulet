using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cochon : MonoBehaviour
{
    public Animator animator;
    public float vitesse = 1.0f;
    private Vector3 direction;
    private Rigidbody2D rig;

    public void spawn(Vector3 directionRecu)
    {
       
        direction = directionRecu;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Vitesse", vitesse);
        rig = GetComponent<Rigidbody2D>();

        rig.velocity = direction * vitesse;

    }

}