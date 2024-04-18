using UnityEngine;
using UnityEngine.UI;

public class ToggleBetweenObjects : MonoBehaviour
{
    public GameObject objectToActivate;    // Objekt k aktivaci pøi každém kliknutí
    public GameObject objectToDeactivate;  // Objekt k deaktivaci pøi každém kliknutí

    private bool isObject1Active = true;   // Pøíznak aktuálního stavu (true = objectToActivate je aktivní)

    private void Start()
    {
        // Pøiøazení funkce OnClick k onClick události tlaèítka
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }

        // Nastavení poèáteèního stavu objektù podle aktuální hodnoty isObject1Active
        UpdateObjectState();
    }

    private void OnClick()
    {
        // Pøepínání mezi objekty pøi každém kliknutí
        isObject1Active = !isObject1Active;

        // Aktualizace stavu objektù podle nové hodnoty isObject1Active
        UpdateObjectState();
    }

    private void UpdateObjectState()
    {
        // Aktivace/deaktivace objektù podle hodnoty isObject1Active
        if (isObject1Active)
        {
            // Zapne první objekt a vypne druhý
            objectToActivate.SetActive(true);
            objectToDeactivate.SetActive(false);
        }
        else
        {
            // Zapne druhý objekt a vypne první
            objectToActivate.SetActive(false);
            objectToDeactivate.SetActive(true);
        }
    }
}
