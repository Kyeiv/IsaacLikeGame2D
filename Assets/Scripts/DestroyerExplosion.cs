using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    public void DestroyerObject() {
        Destroy(this.gameObject);
    }
}
