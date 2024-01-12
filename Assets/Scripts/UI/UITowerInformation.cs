using TMPro;
using UnityEngine;

public class UITowerInformation : MonoBehaviour
{
    public static UITowerInformation Instance;

    [SerializeField] private TMP_Text Desc;
    [SerializeField] private TMP_Text SalesGain;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        gameObject.SetActive(false);
    }
    public void SetInformations(TowersStats info)
    {
        gameObject.SetActive(true);
        Desc.SetText(info.Desc);
        SalesGain.SetText((info.Cost / 2).ToString());
    }
}
