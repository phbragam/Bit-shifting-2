using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8 | 1 << 9;
        // a visualização das layers no unity não representa o inteiro propriamente dito
        // mas sim a posição do bit ativo em uma sequência binária
        // acredito que seja dessa forma para facilitar operações booleanas com as layers
        // 1 << 8 = 1 0000 0000 (0b) = 256 (b10)
        //int layerMask = 256;

        //layerMask = ~layerMask;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
            out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance
                , Color.yellow);
            Debug.Log("Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000
                , Color.red);
            Debug.Log("Missed");
        }
    }
}
