using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class GoldSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyGui;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GoldUpdate();
        
    }

    public void GoldUpdate()
    {
        moneyGui.text = PlayerStatus.instance.Gold.ToString(CultureInfo.InvariantCulture);
    }
}
