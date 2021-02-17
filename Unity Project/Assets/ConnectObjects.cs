

using UnityEngine;
using UnityEngine.UI;

public class ConnectObjects : MonoBehaviour
{   /// <summary>
    /// флаг, показывающий,  идёт ли сейчас подключение объектов;                                  
    /// </summary>
    public bool ConnectionInProgress;

    /// <summary>
    /// хранят информацию типа GameObject о подключаемых объектах.
    /// </summary>
    public GameObject FirstObject;

    /// <summary>
    ///  флаг, для проверки, идёт ли подключение к плюсу.
    /// </summary>
    public bool IsConnectToPlus;

    [SerializeField] private Text debugUIText;

    /// <summary>
    /// хранит главную камеру.
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
    /// проверить есть ли второй объект для подключения, если нет то:
    /// Проверить нажата ли кнопка ЛКМ, если да то:
    /// Выпустить луч из позиции курсора  и проверить тэг (minus or plus) у объекта в который он попал 
    /// и создать соедение между объектами.
    /// </summary>
    private void CreateConnection()
    {
        if (ConnectionInProgress)
        {   
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit2D hit2D = Physics2D.Raycast(GetPositionCursor(), Vector3.forward);

                switch (hit2D.collider.tag)
                {
                    case "Plus":

                        CreateConnectionPlus(hit2D.collider.gameObject);
                        SetDefaultVolums();
                        break;
                    case "Minus":
                        CreateConnectionMinus(hit2D.collider.gameObject);
                        SetDefaultVolums();
                        break;



                }
            }
        }
        
    }

    /// <summary>
    /// Создаёт соединение к плюсу.
    /// </summary>
    /// <param name="hit">Данные попаданя луча.</param>
    private void CreateConnectionPlus(GameObject secondObject)
    {
       
        var ParrentSecondObject = secondObject.GetComponent<Kid>().GetParrent();
        var SecondObjectData = ParrentSecondObject.GetComponent<ObjectData>();
        var FirstObjectData = FirstObject.GetComponent<ObjectData>();

        if (!SecondObjectData.TryAddObjectInArrayConnectedByPlus(FirstObject))
        {
            Debug.Log("Fail!");
        }
        if (!FirstObjectData.TryAddObjectInArrayConnectedByPlus(ParrentSecondObject))
        {
            Debug.Log("Fail!");
        }


        Debug.Log("Connect by plus done!");
    }

    /// <summary>
    ///  Создаёт соединение к плюсу.
    /// </summary>
    /// <param name="hit">Данные попадания луча.</param>
    private void CreateConnectionMinus(GameObject secondObject)
    {
         
        var ParrentSecondObject = secondObject.gameObject.GetComponent<Kid>().GetParrent();
        var SecondObjectData = ParrentSecondObject.GetComponent<ObjectData>();
        var FirstObjectData = FirstObject.GetComponent<ObjectData>();

        if (!SecondObjectData.TryAddObjectInArrayConnectedByMinus(FirstObject))
        {
            Debug.Log("Fail!");
        }
        if (!FirstObjectData.TryAddObjectInArrayConnectedByMinus(ParrentSecondObject))
        {
            Debug.Log("Fail!");
        }

        

        Debug.Log("Connect by Minus done!");
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


    /// <summary>
    /// Устанавливает нулевые значения полям.
    /// </summary>
    private void SetDefaultVolums()
    {
        FirstObject = null;
        ConnectionInProgress = false;
        IsConnectToPlus = false;
    }
}
