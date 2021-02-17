
using System.Collections.Generic;

using UnityEngine;

public class ObjectData : MonoBehaviour
{
    #region variables for Electic circout
    /// <summary>
    /// Амперы
    /// </summary>
    public float Ampers;
    /// <summary>
    /// Сопротивление 
    /// </summary>
    public float Resition;
    /// <summary>
    /// Напряжение
    /// </summary>
    public float Voltage;

    /// <summary>
    /// Показывает, объект источник энергии (true) или нет (false).
    /// </summary>
    public bool isSourceElectric;
    #endregion

    /// <summary>
    /// Список подключённых объектов по плюсу
    /// </summary>
    public List<GameObject> arrayConnectedByPlusObjects;

    /// <summary>
    /// Список подключённых объектов по минусу
    /// </summary>
    public List<GameObject> arrayConnectedByMinusOBjects;

    /// <summary>
    /// Метод для добавления объекта в список
    /// </summary>
    /// <param name="objectForArray"></param>
    /// <returns></returns>
    public bool TryAddObjectInArrayConnectedByPlus(GameObject objectForArray)
    {
        if (!arrayConnectedByPlusObjects.Contains(objectForArray))
        {
            arrayConnectedByPlusObjects.Add(objectForArray);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Метод для добавления объекта в список
    /// </summary>
    /// <param name="objectForArray"></param>
    /// <returns></returns>
    public bool TryAddObjectInArrayConnectedByMinus(GameObject objectForArray)
    {
        if (!arrayConnectedByMinusOBjects.Contains(objectForArray))
        {
            arrayConnectedByMinusOBjects.Add(objectForArray);
            return true;
        }
        return false;
    }

    private void Start()
    {
        arrayConnectedByPlusObjects.Add(gameObject);
        arrayConnectedByMinusOBjects.Add(gameObject);
    }
}
