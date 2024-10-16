using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorJump : MonoBehaviour
{
    public GameObject cupObject;
    public GameObject sphereTrig;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        sphereTrig.SetActive(true);
        StartCoroutine(DeactivateSphere());
    }

    IEnumerator DeactivateSphere()
    {
        yield return new WaitForSeconds(0.5f);
        sphereTrig.SetActive(false);
        yield return new WaitForSeconds(2.5f);
    }
}
