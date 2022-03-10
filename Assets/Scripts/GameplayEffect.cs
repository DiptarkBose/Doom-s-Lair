using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EffectType
{
    Direct,
    // Temporary,
    // Persistent
}

public enum AttributeChangeType
{
    Add,
    Subtract,
    Multiply,
    Divide
}

[Serializable]
public class Effect
{
    public EffectType effectType;
    public AttributeChangeType attributeChangeType;
    public String attributeName;
    public float magnitude;
    // public float duration; // Used if EffectType is Temporary, otherwise leave as 0.
    // public float interval; // Specify the delay between each effect application, used in both Temporary and Persistent.
}

public class GameplayEffect : MonoBehaviour
{
    public Effect[] effects;

    public void ApplyEffect(AttributeSet attributeSet)
    {
        foreach (Effect effect in effects)
        {
            float attributeVal = (float)attributeSet.GetType().GetField(effect.attributeName).GetValue(attributeSet);
            if (attributeVal >= 0)
            {
                switch (effect.attributeChangeType)
                {
                    case AttributeChangeType.Add:
                        attributeSet.GetType().GetField(effect.attributeName).SetValue(attributeSet, Mathf.Clamp(attributeVal + effect.magnitude, 0, 100));
                        break;
                    case AttributeChangeType.Subtract:
                        attributeSet.GetType().GetField(effect.attributeName).SetValue(attributeSet, attributeVal - effect.magnitude);
                        float newAttributeVal = (float)attributeSet.GetType().GetField(effect.attributeName).GetValue(attributeSet);
                        if (effect.attributeName == "Health" && newAttributeVal <=0)
                        {
                            respawn();
                        }
                        break;
                    case AttributeChangeType.Multiply:
                        attributeSet.GetType().GetField(effect.attributeName).SetValue(attributeSet, Mathf.Clamp(attributeVal * effect.magnitude, 0, 100));
                        break;
                    case AttributeChangeType.Divide:
                        attributeSet.GetType().GetField(effect.attributeName).SetValue(attributeSet, Mathf.Clamp(attributeVal / effect.magnitude, 0, 100));
                        break;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController)
        {
            gameObject.GetComponentInParent<GameplayEffect>().ApplyEffect(playerController.attributeSet);
            playerController.UpdateUI();
        }
    }

    private void respawn()
    {
        SceneManager.LoadScene("AlphaScene");
    }
}
