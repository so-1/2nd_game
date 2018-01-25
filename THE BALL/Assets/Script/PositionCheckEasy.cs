using UnityEngine;
using System.Collections;

public class PositionCheckEasy : MonoBehaviour
{


    void Update()
    {
        Vector3 worldPos = this.transform.position;
        Camera camera = Camera.main;
        Vector3 viewportPos = camera.WorldToViewportPoint(worldPos);

        if(viewportPos.y<-1 || 2< viewportPos.y)
        {
            Destroy(this.gameObject);
        }
    }                                                                                                            
}
                             