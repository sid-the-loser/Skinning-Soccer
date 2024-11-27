using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamColorGrading : MonoBehaviour
{
    [SerializeField] private Material colorGradingMaterial;
    
    [SerializeField] private float defaultContribution;

    private bool _toggle;

    private void Start()
    {
        colorGradingMaterial.SetFloat("_Contribution", defaultContribution);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _toggle = !_toggle;
            
            colorGradingMaterial.SetFloat("_Contribution", _toggle ? 0 : defaultContribution);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, colorGradingMaterial);
    }
}
