using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("DestroyObj");
    }

    IEnumerator DestroyObj()
    {
        if (this.gameObject.tag == "balachao" || this.gameObject.tag == "balaparede")
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }

    }
}
