using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryTab
{
    public string tabName;  // Název záložky (pro identifikaci v editoru)
    public GameObject tabContent;  // Obsah záložky inventáøe
    public Button tabButton;  // Tlaèítko pro pøepínání záložky inventáøe
    public GameObject activeObject;  // Aktivní objekt pøi stisknutí tlaèítka
    public GameObject inactiveObject;  // Neaktivní objekt po stisknutí tlaèítka
}

public class InventoryTabController : MonoBehaviour
{
    public InventoryTab[] inventoryTabs;  // Pole pro konfiguraci jednotlivých záložek inventáøe

    private int currentTabIndex = 0;  // Index aktuálnì zobrazené záložky inventáøe

    private void Start()
    {
        // Pøiøazení funkcí ke každému tlaèítku záložky
        for (int i = 0; i < inventoryTabs.Length; i++)
        {
            int tabIndex = i;  // Uložení indexu pro použití v anonymní funkci

            inventoryTabs[i].tabButton.onClick.AddListener(() =>
            {
                ShowInventoryTab(tabIndex);  // Zobrazení vybrané záložky inventáøe
            });
        }

        // Nastavení inicialní záložky (první záložka je aktivní, ostatní jsou neaktivní)
        ShowInventoryTab(0);
    }

    // Funkce pro zobrazení vybrané záložky inventáøe
    private void ShowInventoryTab(int tabIndex)
    {
        // Skrytí aktuálnì zobrazené záložky inventáøe
        if (inventoryTabs[currentTabIndex].tabContent != null)
        {
            inventoryTabs[currentTabIndex].tabContent.SetActive(false);
        }

        // Zobrazení vybrané záložky inventáøe
        inventoryTabs[tabIndex].tabContent.SetActive(true);

        // Aktualizace aktuálního indexu záložky
        currentTabIndex = tabIndex;

        // Aktivace/deaktivace tlaèítek podle aktuální záložky
        UpdateTabButtons();
    }

    // Funkce pro aktualizaci stavu tlaèítek (aktivní/neaktivní)
    private void UpdateTabButtons()
    {
        // Procházení všech záložek inventáøe
        foreach (InventoryTab tab in inventoryTabs)
        {
            // Aktivace/deaktivace objektù podle aktuální záložky
            tab.activeObject.SetActive(tab == inventoryTabs[currentTabIndex]);
            tab.inactiveObject.SetActive(tab != inventoryTabs[currentTabIndex]);
        }
    }
}
