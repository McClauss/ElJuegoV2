using UnityEngine;

public class RealTimeReflex : MonoBehaviour
{
    void Update()
    {
        GetComponent<ReflectionProbe>().RenderProbe();
    }
}
