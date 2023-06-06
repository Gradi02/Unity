using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraEffects : MonoBehaviour
{
    public Transform target;
    private VehicleControl carScript;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private GameObject cam;
    private float currentSpeed;
    private float cameraViewOffset; // Oddalenie kamery
    private float camRotXOffSet; // Odchylenie kamery
    private bool nitro = false;

    [SerializeField] private Vector3 StartPos = new(0,3.5f,-7);
    [SerializeField] private Quaternion StartRot = new(10,0,0,0);

    private float shakeAmplitude = 0;
    private float nitroFov = 0;
    float camFov=0;
    private float minFOV=0, maxFOV=40;

    private void Start()
    {
        cam.transform.localPosition = StartPos;
        cam.transform.localRotation = StartRot;
    }

    void Update()
    {
        carScript = (VehicleControl)target.GetComponent<VehicleControl>();
        currentSpeed = carScript.speed;
        speedText.text = ((int)carScript.speed).ToString();

        
        // Oddalanie kamery
        cameraViewOffset = (currentSpeed + 0.1f) / 10;
        cam.transform.localPosition = new Vector3(0, 3.5f + (cameraViewOffset / 30), -7 - (cameraViewOffset / 20));

        camFov = 60 + (cameraViewOffset / 2);

        // Odchylanie kamery
        camRotXOffSet = (currentSpeed + 0.1f) / 40;
        cam.transform.localRotation = Quaternion.Euler(10 - camRotXOffSet, cam.transform.localRotation.y + shakeAmplitude, cam.transform.localRotation.z + shakeAmplitude);
        
        if (nitro)
        {
            float randomFloat = Random.Range(-0.5f, 0.5f);
            shakeAmplitude = Mathf.Lerp(cam.transform.localPosition.y, randomFloat, 1);

            nitroFov += Time.deltaTime * 20;
        }
        else
        {
            shakeAmplitude = 0;
            nitroFov -= Time.deltaTime * 5;
        }

        nitroFov = Mathf.Clamp(nitroFov, minFOV, maxFOV);
        cam.GetComponent<Camera>().fieldOfView = camFov+nitroFov;
    }


    public void SetNitroCamera(bool change)
    {
        nitro = change;
    }
}
