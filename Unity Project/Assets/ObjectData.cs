
using System.Collections.Generic;

using UnityEngine;

public class ObjectData : MonoBehaviour
{
    #region variables for Electic circout
    /// <summary>
    /// ������
    /// </summary>
    public float Ampers;
    /// <summary>
    /// ������������� 
    /// </summary>
    public float Resition;
    /// <summary>
    /// ����������
    /// </summary>
    public float Voltage;

    /// <summary>
    /// ����������, ������ �������� ������� (true) ��� ��� (false).
    /// </summary>
    public bool isSourceElectric;
    #endregion

    /// <summary>
    /// ������ ������������ �������� �� �����
    /// </summary>
    public List<GameObject> arrayConnectedByPlusObjects;

    /// <summary>
    /// ������ ������������ �������� �� ������
    /// </summary>
    public List<GameObject> arrayConnectedByMinusOBjects;

    /// <summary>
    /// ����� ��� ���������� ������� � ������
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
    /// ����� ��� ���������� ������� � ������
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
