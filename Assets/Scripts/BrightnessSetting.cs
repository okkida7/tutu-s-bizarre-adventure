using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BrightnessSetting : MonoBehaviour
{
    public Volume volume;
    public float timeScale = 1f;

    private ColorAdjustments colorAdjustments;
    private VolumeParameter<float> postExposure = new VolumeParameter<float>();

    private void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        if(colorAdjustments == null){
            Debug.LogError("No ColorAdjustments found");
        }
    }

    private void Update()
    {
        if(colorAdjustments == null)
        {
            return;
        }
        postExposure.value = Mathf.PingPong(Time.time * timeScale, 180f);
        colorAdjustments.postExposure.SetValue(postExposure);
    }


}
