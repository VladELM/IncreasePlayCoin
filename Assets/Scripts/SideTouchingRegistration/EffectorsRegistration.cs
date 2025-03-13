using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorsRegistration : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<AreaEffector2D>())
            _player.GetComponent<Management>().enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<AreaEffector2D>())
            _player.GetComponent<Management>().enabled = true;
    }
}
