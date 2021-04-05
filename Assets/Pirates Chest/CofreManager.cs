using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreManager : MonoBehaviour
{
    private Animator animatorApertura;
    void Start()
    {
        animatorApertura = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GameManager gm = GameManager.Instance;
            if (gm.TienesLlave())
            {
                animatorApertura.enabled = true;
            }
        }
    }
}
