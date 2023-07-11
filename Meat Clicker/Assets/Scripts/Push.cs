using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Push : MonoBehaviour
{
    public float Scales;
    public float Times;
    private Vector3 originalScale;
    private Button button;

    private void Start()
    {
        originalScale = transform.localScale;
        button = GetComponent<Button>();
        button.onClick.AddListener(ScaleDown);
    }

    private void ScaleDown()
    {
        transform.localScale = new Vector3(Scales, Scales, Scales);
        StartCoroutine(ScaleUpCoroutine());
    }

    private IEnumerator ScaleUpCoroutine()
    {
        yield return new WaitForSeconds(Times);
        transform.localScale = originalScale;
    }
}