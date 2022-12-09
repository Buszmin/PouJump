using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Collider2D col;
    
    public void colliderSleep()
    {
        col.enabled = false;
        StartCoroutine(waitSecAndColOn());
    }

    IEnumerator waitSecAndColOn() // fix bug with moving platforms and edges;
    {
        yield return new WaitForSeconds(1f);
        col.enabled = true;
    }
}
