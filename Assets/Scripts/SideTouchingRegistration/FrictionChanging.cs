using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionChanging : MonoBehaviour
{
    private string Ground = nameof(Ground);

    private PhysicsMaterial2D _groundPhysMaterial;
    //private float _origGroundFriction;

    [SerializeField] private Rigidbody2D _playerRigidody;
    [SerializeField] private PhysicsMaterial2D _playerPhysicsMaterial;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == Ground)
        {
            _groundPhysMaterial = collider.gameObject.GetComponent<Rigidbody2D>().sharedMaterial;
            
            collider.gameObject.GetComponent<Rigidbody2D>().sharedMaterial = null;

            if (collider.gameObject.GetComponent<SurfaceEffector2D>())
                collider.gameObject.GetComponent<SurfaceEffector2D>().enabled = false;

            //_origGroundFriction = _groundPhysMaterial.friction;
            //_groundPhysMaterial.friction = 0f;

            _playerRigidody.sharedMaterial = _playerPhysicsMaterial;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == Ground)
        {
            //_groundPhysMaterial.friction = _origGroundFriction;

            collider.gameObject.GetComponent<Rigidbody2D>().sharedMaterial = _playerPhysicsMaterial;
            
            if (collider.gameObject.GetComponent<SurfaceEffector2D>())
                collider.gameObject.GetComponent<SurfaceEffector2D>().enabled = true;

            _playerRigidody.sharedMaterial = null;

            _groundPhysMaterial = null;
        }
    }
}
