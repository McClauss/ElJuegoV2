using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProces : MonoBehaviour
{
    public PostProcessVolume volumenZona1,volumenZona2;
    private Bloom _bloom;
    private Vignette _vignette;
    
    void Start()
    {
        volumenZona2.profile.TryGetSettings(out _bloom);
        volumenZona1.profile.TryGetSettings(out _vignette);
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.transform.gameObject.tag=="Jugador"){
                _vignette.intensity.value+=0.3f;
                _bloom.intensity.value+=100;      
        }
    }
}
