using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryTab
{
    public string tabName;  // N�zev z�lo�ky (pro identifikaci v editoru)
    public GameObject tabContent;  // Obsah z�lo�ky invent��e
    public Button tabButton;  // Tla��tko pro p�ep�n�n� z�lo�ky invent��e
    public GameObject activeObject;  // Aktivn� objekt p�i stisknut� tla��tka
    public GameObject inactiveObject;  // Neaktivn� objekt po stisknut� tla��tka
}

public class InventoryTabController : MonoBehaviour
{
    public InventoryTab[] inventoryTabs;  // Pole pro konfiguraci jednotliv�ch z�lo�ek invent��e

    private int currentTabIndex = 0;  // Index aktu�ln� zobrazen� z�lo�ky invent��e

    private void Start()
    {
        // P�i�azen� funkc� ke ka�d�mu tla��tku z�lo�ky
        for (int i = 0; i < inventoryTabs.Length; i++)
        {
            int tabIndex = i;  // Ulo�en� indexu pro pou�it� v anonymn� funkci

            inventoryTabs[i].tabButton.onClick.AddListener(() =>
            {
                ShowInventoryTab(tabIndex);  // Zobrazen� vybran� z�lo�ky invent��e
            });
        }

        // Nastaven� inicialn� z�lo�ky (prvn� z�lo�ka je aktivn�, ostatn� jsou neaktivn�)
        ShowInventoryTab(0);
    }

    // Funkce pro zobrazen� vybran� z�lo�ky invent��e
    private void ShowInventoryTab(int tabIndex)
    {
        // Skryt� aktu�ln� zobrazen� z�lo�ky invent��e
        if (inventoryTabs[currentTabIndex].tabContent != null)
        {
            inventoryTabs[currentTabIndex].tabContent.SetActive(false);
        }

        // Zobrazen� vybran� z�lo�ky invent��e
        inventoryTabs[tabIndex].tabContent.SetActive(true);

        // Aktualizace aktu�ln�ho indexu z�lo�ky
        currentTabIndex = tabIndex;

        // Aktivace/deaktivace tla��tek podle aktu�ln� z�lo�ky
        UpdateTabButtons();
    }

    // Funkce pro aktualizaci stavu tla��tek (aktivn�/neaktivn�)
    private void UpdateTabButtons()
    {
        // Proch�zen� v�ech z�lo�ek invent��e
        foreach (InventoryTab tab in inventoryTabs)
        {
            // Aktivace/deaktivace objekt� podle aktu�ln� z�lo�ky
            tab.activeObject.SetActive(tab == inventoryTabs[currentTabIndex]);
            tab.inactiveObject.SetActive(tab != inventoryTabs[currentTabIndex]);
        }
    }
}
