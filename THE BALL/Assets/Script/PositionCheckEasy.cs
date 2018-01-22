using UnityEngine;
using System.Collections;

public class PositionCheckEasy : MonoBehaviour
{


    void Update()
    {

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }

    }
}
