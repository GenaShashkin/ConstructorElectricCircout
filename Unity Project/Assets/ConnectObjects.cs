using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CreateWires : MonoBehaviour
{
    [SerializeField] private Color acitveColor,passiveColor;
    public void CreateWire(Material material)
    {
        material.color = acitveColor;
       while(Input.GetAxis("Fire1") < 0)
        {

        }
    }
}
