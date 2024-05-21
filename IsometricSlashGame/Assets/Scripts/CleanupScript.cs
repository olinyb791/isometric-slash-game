using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupScript : MonoBehaviour
{

    [SerializeField]
    private float time;
    // Start is called before the first frame update
    private void Awake()
    {
        time = 3f;
        StartCoroutine(ParticleCleanup());
        
    }

    IEnumerator ParticleCleanup()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
