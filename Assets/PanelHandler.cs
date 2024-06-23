using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelHandler : MonoBehaviour
{
    public GameObject closeButton; // X 버튼의 GameObject를 참조합니다.
    public Vector2 panelSize = new Vector2(500, 500); // 원하는 패널 크기를 설정합니다.

    void Start()
    {
        DOTween.Init();
        transform.localScale = Vector3.one * 0.1f;
        gameObject.SetActive(false);

        if (closeButton != null)
        {
            closeButton.SetActive(false); // X 버튼을 비활성화합니다.
        }
        else
        {
            Debug.LogError("closeButton is not assigned in PanelHandler!");
        }
    }

    public void Show()
    {
        Debug.Log("Show method called");
        Debug.Log("Before setting active: " + gameObject.activeSelf);

        gameObject.SetActive(true);

        Debug.Log("After setting active: " + gameObject.activeSelf);
        Debug.Log("Current Scale: " + transform.localScale);

        var rectTransform = GetComponent<RectTransform>();
        Debug.Log("Panel Position: " + rectTransform.anchoredPosition);
        Debug.Log("Panel Size: " + rectTransform.sizeDelta);

        // 패널의 위치와 크기를 중앙에 맞추고 적절한 크기로 설정
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.sizeDelta = panelSize;

        Debug.Log("After reset Panel Position: " + rectTransform.anchoredPosition);
        Debug.Log("After reset Panel Size: " + rectTransform.sizeDelta);

        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.1f, 0.2f));
        seq.Append(transform.DOScale(1f, 0.1f));
        seq.Play().OnComplete(() =>
        {
            if (closeButton != null)
            {
                closeButton.SetActive(true); // 애니메이션이 끝난 후 X 버튼을 활성화합니다.
            }
        });
    }

    public void Hide()
    {
        Debug.Log("Hide method called");
        Debug.Log("Current Scale: " + transform.localScale);

        if (closeButton != null)
        {
            closeButton.SetActive(false); // 패널이 숨겨질 때 X 버튼을 비활성화합니다.
        }

        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.1f, 0.1f));
        seq.Append(transform.DOScale(0.1f, 0.2f));

        seq.Play().OnComplete(() =>
        {
            gameObject.SetActive(false);
            Debug.Log("After setting inactive: " + gameObject.activeSelf);
        });
    }
}
