using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Text")]
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI hitTypeText;
    public TextMeshProUGUI hitAccuracyText;

    [Header("Image")]
    public Image hpImage;
    public Image groundEnergyImage;
    public Image skyEnergyImage;

    [Header("Skill")]
    public GameObject cloud;
    public Transform cloudParent;
    public GameObject noteUI;

    [Header("Monster Spawn")]
    public Transform spawnTextParent;
    public GameObject spawnText;
    public Text bossSpawnText;

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

    public void AddSpawnText(int line)
    {
        Text t = Instantiate(spawnText, spawnTextParent).GetComponent<Text>();
        t.text = line + "번 지역의 몬스터 출현!";

        if (spawnTextParent.childCount > 4)
        {
            Destroy(spawnTextParent.GetChild(0).gameObject);
        }
    }

    public IEnumerator BossSpawnText(string boss, int sec)
    {
        for (int i=sec; i>0; i--)
        {
            bossSpawnText.text = i + "초 뒤, " + boss + " 등장";
            yield return new WaitForSeconds(1);
        }

        bossSpawnText.text = "";

        yield break;
    }

    public IEnumerator SpawnCloud()
    {
        int rand = Random.Range(2, 6);

        for (int i=0; i<rand; i++)
        {
            GameObject c = Instantiate(cloud, cloudParent);
            c.transform.localPosition = Vector2.zero + new Vector2(Random.Range(-250f, 250f), Random.Range(-100, 100));
            Destroy(c, 0.5f);
        }

        yield break;
    }

    public IEnumerator Reverse()
    {
        noteUI.transform.localEulerAngles = new Vector3(0, 0, 180);
        yield return new WaitForSeconds(5);
        noteUI.transform.localEulerAngles = new Vector3(0, 0, 0);

        yield break;
    }
}
