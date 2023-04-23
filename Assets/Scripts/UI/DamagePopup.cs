using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    public enum Font
    {
        DamageTaken,
        DamageDeal,
    }

    public static DamagePopup Create(Vector3 position, int damageAmount, Font font)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.Instance.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, font);
        return damagePopup;
    }

    private TextMeshPro textMesh;
    private Color color;
    private float moveXSpeed;
    private float moveYSpeed = 1f;
    private float fadeTimeOut = .5f;
    private float fadeSpeed = 5f;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(int damage, Font font)
    {
        textMesh.text = damage.ToString();
        textMesh.fontSharedMaterial = GetFontMaterial(font);
        color = textMesh.color;
        moveXSpeed = Random.Range(-2f, 2f);
    }

    public Material GetFontMaterial(Font font)
    {
        switch (font)
        {
            default:
                return GameAssets.Instance.fontDefault;
            case Font.DamageTaken:
                return GameAssets.Instance.fontDamageTaken;
            case Font.DamageDeal:
                return GameAssets.Instance.fontDamageDeal;
        }
    }

    private void Update()
    {
        transform.position += new Vector3(moveXSpeed, moveYSpeed, 0f) * Time.deltaTime;
        fadeTimeOut -= Time.deltaTime;
        if (fadeTimeOut <= 0f)
        {
            color.a -= fadeSpeed * Time.deltaTime;
            textMesh.color = color;
            if (color.a <= 0)
                Destroy(gameObject);
        }
    }
}
