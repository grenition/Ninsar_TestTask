using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    public Material[] materials;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    //изменение материала по Id
    public void ChangeColor(int colorId)
    {
        if (colorId - 1 > materials.Length)
            return;
        meshRenderer.material = materials[colorId - 1];
    }
}
