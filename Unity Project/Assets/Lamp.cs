
using UnityEngine;

public class Lamp : ObjectElecticCircout
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Color32 activeColor, defaultColor;

    public ObjectData data;

    private void Awake()
    {
        data = GetComponent<ObjectData>();
    }

    private void TurnLamp()
    {
        if(data.arrayConnectedByMinusOBjects.Count > 0)
        {
            if (data.Ampers > 0)
            {
                sprite.color = activeColor;
            }
            else
            {
                sprite.color = defaultColor;
            }
        }
        else
        {
            sprite.color = defaultColor;    
        }
        
    }

    public override void ChangeParamsByConnectedObjects()
    {

        foreach (var item in data.arrayConnectedByPlusObjects)
        {
            if (item != gameObject && !item.CompareTag("Блок питания"))
            {
                item.GetComponent<ObjectData>().Ampers = data.Ampers;
            }
        }

    }

    private void Update()
    {
        TurnLamp();
        ChangeParamsByConnectedObjects();
    }
}
