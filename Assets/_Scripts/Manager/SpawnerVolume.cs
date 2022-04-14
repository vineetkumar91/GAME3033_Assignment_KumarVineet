using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVolume : MonoBehaviour
{
    private BoxCollider boxCollider;

    
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Get a random position from that collider
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPositionInBounds()
    {
        Bounds boxBounds = boxCollider.bounds;
        return new Vector3(Random.Range(boxBounds.min.x, boxBounds.max.x), transform.position.y,
            Random.Range(boxBounds.min.z, boxBounds.max.z));
    }
}
