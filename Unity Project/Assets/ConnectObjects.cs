using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ConnectObjects : MonoBehaviour
{   /// <summary>
    /// ConnectionjInProgress  - флаг, показывающий,  идёт ли сейчас подключение объектов;                                  
    /// </summary>
    public bool ConnectionInProgress;
    /// <summary>
    /// FirstObject, SecondObject - хранят информацию типа GameObject о подключаемых объектах.
    /// </summary>
    public GameObject FirstObject, SecondObject;
    /// <summary>
    /// IsConnectToPlus - флаг, для проверки, идёт ли подключение к плюсу.
    /// </summary>
    public bool IsConnectToPlus;
    /// <summary>
    /// camera - хранит главную камеру.
    /// </summary>
    private Camera camera;

    /// <summary>
    /// Получает во время загрузки сцены камеру и записывает значение в camera
    /// </summary>
    private void Awake()
    {
        camera = Camera.main;
    }

    /// <summary>
    ///  Каждый кадр вызывает методы
    /// </summary>
    private void Update()
    {
        CreateConnection();
    }

    /// <summary>
    /// Метод для создания подключений.
    /// 
    /// Если идёт подключение, то:
    ///     проверить есть ли второй объект для подключения, если нет то:
    ///         Проверить нажата ли кнопка ЛКМ, если да то:
    ///             Выпустить луч из позиции курсора  и проверить тэг (minus or plus) у объекта в который он попал.
    /// </summary>
    private void CreateConnection()
    {
        if (ConnectionInProgress)
        {
            if (!SecondObject)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {            
                    RaycastHit2D hit2D = Physics2D.Raycast(GetPositionCursor(), Vector3.forward);
                    
                    if (hit2D.collider.CompareTag("plus") && IsConnectToPlus)
                    {
                        Debug.Log("Connected Plus!");
                        SecondObject = hit2D.collider.gameObject;
                        SetDefaultVolums();
                    }

                    if (hit2D.collider.CompareTag("minus") && !IsConnectToPlus)
                    {
                        Debug.Log("Connected Minus!");
                        SecondObject = hit2D.collider.gameObject;
                        SetDefaultVolums();
                    }


                }
            }
        }
    }
    /// <summary>
    /// Получает координаты курсора.
    /// </summary>
    /// <returns>Возвращаяет координаты курсора</returns>
    private Vector2 GetPositionCursor()
    {
        Vector2 cursor = Input.mousePosition;
        cursor = camera.ScreenToWorldPoint(cursor);
        return cursor;
    }

    private void SetDefaultVolums()
    {
        FirstObject = null;
        SecondObject = null;
        ConnectionInProgress = false;
        IsConnectToPlus = false;
    }
}
