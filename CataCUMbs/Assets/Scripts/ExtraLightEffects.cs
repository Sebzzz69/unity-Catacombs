using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ExtraLightEffects : MonoBehaviour
{
    Light2D lightScript;

    [Header("Flickering Lights")]
    [SerializeField] bool FlickeringLights;
    [SerializeField] float minFlickDelay;
    [SerializeField] float maxFlickDelay;

    private void Awake()
    {
        lightScript = GetComponent<Light2D>();
    }

    private void Start()
    {
        if (FlickeringLights)
        {
            InvokeRepeating("TriggerFlickeringLights", Random.Range(minFlickDelay, maxFlickDelay), Random.Range(minFlickDelay, maxFlickDelay));
        }
    }

    void TriggerFlickeringLights()
    {
        // Amount of flicks every trigger
        int amountOfFlicks = Random.Range(2, 6);

        StartCoroutine(PerformFlickeringLights(amountOfFlicks));
    }

    IEnumerator PerformFlickeringLights(int amountOfFlicks)
    {
        float currentIntensity = lightScript.intensity;

        for (int i = 0; i <= amountOfFlicks; i++)
        {
            // Time until turning lights off
            yield return new WaitForSeconds(Random.Range(0.015f, 0.05f));
            lightScript.intensity = 0;

            // Time until turning lights on
            yield return new WaitForSeconds(Random.Range(0.015f, 0.35f));
            lightScript.intensity = currentIntensity;
        }
    }
}