using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalRotationSpeed;
    private int verticalRotationMulti = 0;
    private CharacterController cc;
    private float z;
    private float x;
    private Transform transformCamara;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        transformCamara = Camera.main.transform;
    }

    
    void Update()
    {
#if UNITY_EDITOR
        x = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.E))
        {
            verticalRotationMulti = -1;
        } else if (Input.GetKey(KeyCode.Q))
        {
            verticalRotationMulti = 1;
        } else
        {
            verticalRotationMulti = 0;
        }
        z = Input.GetAxis("Vertical");
        cc.transform.Rotate(
            verticalRotationSpeed * Time.deltaTime * verticalRotationMulti, 
            x * Time.deltaTime * rotationSpeed, 
            0);
        Avanzar();
#endif
#if UNITY_ANDROID
        Touch[] ts = Input.touches;//Recoger todos los punteros (dedos)
        if (ts.Length == 0) return;//Si no hay pulsación, nos salimos
        Touch t = ts[0];//Cogemos el primer puntero.
        switch(t.phase)
        {
            case TouchPhase.Began:
                //TODO Lo que corresponda
                z = 1;
                break;
            case TouchPhase.Stationary:
                //TODO Lo que corresponda
                break;
            case TouchPhase.Moved:
                //TODO Lo que corresponda
                break;
            case TouchPhase.Ended:
                //TODO Lo que corresponda
                z = 0;
                break;
            case TouchPhase.Canceled:
                //TODO Lo que corresponda
                z = 0;
                break;
        }
        Avanzar();
#endif
    }

    private void Avanzar()
    {
        cc.SimpleMove(transformCamara.forward * z * speed);
    }
}
