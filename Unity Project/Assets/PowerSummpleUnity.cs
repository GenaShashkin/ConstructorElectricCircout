using System.Collections;
using System.Collections.Generic;
using System.Data;

using UnityEngine;

public class PowerSummpleUnity : ObjectElecticCircout
{
    private ObjectData data;

    private void Awake()
    {
        data = GetComponent<ObjectData>();
    }

    public override void ChangeParamsByConnectedObjects()
    {
        if (data.arrayConnectedByMinusOBjects.Count > 1)
        {
            foreach (var item in data.arrayConnectedByPlusObjects)
            {
                if (item != gameObject)
                {
                    item.GetComponent<ObjectData>().Ampers = data.Ampers;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        ChangeParamsByConnectedObjects();
    }

}
