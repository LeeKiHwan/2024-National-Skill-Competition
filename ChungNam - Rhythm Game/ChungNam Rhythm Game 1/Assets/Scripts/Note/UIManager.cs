using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI comboText;
    public TextMeshProUGUI hitTypeText;
    public TextMeshProUGUI hitAccuracyText;

    public Image hpImage;
    public Image groundEnergyImage;
    public Image skyEnergyImage;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        hpImage.fillAmount = Mathf.Lerp(hpImage.fillAmount, NoteManager.Instance.hp / 100f, Time.deltaTime * 10);
        groundEnergyImage.fillAmount = Mathf.Lerp(groundEnergyImage.fillAmount, NoteManager.Instance.groundEnergy / 100f, Time.deltaTime * 10);
        skyEnergyImage.fillAmount = Mathf.Lerp(skyEnergyImage.fillAmount, NoteManager.Instance.skyEnergy / 100f, Time.deltaTime * 10);
    }

    public void UpdateNoteUI(int hitAccuracy)
    {
        if (hitAccuracy >= 75) hitTypeText.text = "Perfect";
        else if (hitAccuracy >= 20) hitTypeText.text = "Good";
        else hitTypeText.text = "Miss";

        hitAccuracyText.text = hitAccuracy + "%";

        comboText.text = NoteManager.Instance.combo.ToString();
    }

}
