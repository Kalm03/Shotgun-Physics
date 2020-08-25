using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin p;

    float startingIntensity;
    float shakeTime;
    float shakeTimeTot;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        p = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCam(float intensity, float time)
    {
        p.m_AmplitudeGain = startingIntensity = intensity;
        shakeTime = shakeTimeTot = time;
    }

    private void Update()
    {
        if (shakeTime>0)
        {
            shakeTime -= Time.deltaTime;
            if (shakeTime<=0)
            {
                p.m_AmplitudeGain = 0f;

                Mathf.Lerp(startingIntensity, 0f, shakeTime / shakeTimeTot);
            }
        }
    }
}
