using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRSelector : MonoBehaviour
{
    public float maxDistance;
    public Image imagenExterior;
    public float speed;
    float tiempoActivacion = 0;
    
    void Update()
    {
        RaycastHit hitInfo;
        bool hayAlgo = Physics.Raycast(transform.position, transform.forward, out hitInfo, maxDistance);
        if (hayAlgo) {
            if (hitInfo.transform.gameObject.name == "Key")
            {
                tiempoActivacion = tiempoActivacion + speed * Time.deltaTime;
                tiempoActivacion = Mathf.Min(1, tiempoActivacion);
                imagenExterior.fillAmount = tiempoActivacion;
                if (tiempoActivacion >= 1)
                {
                    Destroy(hitInfo.transform.gameObject);
                    GameManager gm = GameManager.Instance;
                    gm.RecogerLlave();
                }
            } else
            {
                tiempoActivacion = 0;
                imagenExterior.fillAmount = 0;
            }
        } else
        {
            tiempoActivacion = 0;
            imagenExterior.fillAmount = 0;
        }
    }
}
