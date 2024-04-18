using UnityEngine;
using UnityEngine.UI;

public class ToggleBetweenObjects : MonoBehaviour
{
    public GameObject objectToActivate;    // Objekt k aktivaci p�i ka�d�m kliknut�
    public GameObject objectToDeactivate;  // Objekt k deaktivaci p�i ka�d�m kliknut�

    private bool isObject1Active = true;   // P��znak aktu�ln�ho stavu (true = objectToActivate je aktivn�)

    private void Start()
    {
        // P�i�azen� funkce OnClick k onClick ud�losti tla��tka
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }

        // Nastaven� po��te�n�ho stavu objekt� podle aktu�ln� hodnoty isObject1Active
        UpdateObjectState();
    }

    private void OnClick()
    {
        // P�ep�n�n� mezi objekty p�i ka�d�m kliknut�
        isObject1Active = !isObject1Active;

        // Aktualizace stavu objekt� podle nov� hodnoty isObject1Active
        UpdateObjectState();
    }

    private void UpdateObjectState()
    {
        // Aktivace/deaktivace objekt� podle hodnoty isObject1Active
        if (isObject1Active)
        {
            // Zapne prvn� objekt a vypne druh�
            objectToActivate.SetActive(true);
            objectToDeactivate.SetActive(false);
        }
        else
        {
            // Zapne druh� objekt a vypne prvn�
            objectToActivate.SetActive(false);
            objectToDeactivate.SetActive(true);
        }
    }
}
