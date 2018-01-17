using UnityEngine;
using System.Collections;

public class PositionCheck : MonoBehaviour
{


    void Update()
    {

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }

    }
}
