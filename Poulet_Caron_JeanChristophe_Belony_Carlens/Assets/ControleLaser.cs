using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleLaser : MonoBehaviour
{
    private VolumetricLines.VolumetricLineBehavior laser;

    public LayerMask masqueRaycast;
    private GameObject emetteurLaser;
    private CapsuleCollider2D capsuleCollider;
    private Vector3 depart;
    private Vector3 direction;
    
    private RaycastHit2D hit;
    private Vector3 infinite_end_point;

    private void Start()
    {
        laser = GetComponent<VolumetricLines.VolumetricLineBehavior>();
        capsuleCollider = laser.GetComponent<CapsuleCollider2D>();
        emetteurLaser = transform.parent.gameObject;
        direction = emetteurLaser.transform.up.normalized;

        //set la position du laser
        infinite_end_point = direction * 100;
        laser.StartPos = new Vector3(0.0f, 0.5f, 0.0f);
        laser.EndPos = emetteurLaser.transform.InverseTransformPoint(infinite_end_point);
    }


    void FixedUpdate()
    {
        depart = emetteurLaser.transform.position;
        direction = emetteurLaser.transform.up.normalized;
        infinite_end_point = direction * 100;

        hit = Physics2D.Raycast(depart, direction, 100.0f, masqueRaycast);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Unlaserable"))
            {   
                laser.EndPos = emetteurLaser.transform.InverseTransformPoint((Vector3)hit.point);
                capsuleCollider.size = new Vector2(capsuleCollider.size.x, hit.point.y);
            }

        }
        else
        {
            laser.EndPos = emetteurLaser.transform.InverseTransformPoint(infinite_end_point);
            capsuleCollider.size = new Vector2(10.0f, infinite_end_point.y);
        }
    }

}
