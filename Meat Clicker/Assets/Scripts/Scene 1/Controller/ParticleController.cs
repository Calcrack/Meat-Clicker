using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public RectTransform panelTransform;
    private void Update()
    {
    }
    public void ParticlesStart()
    {
            ParticleSystem newParticleSystem = Instantiate(particleSystem, panelTransform);
            newParticleSystem.Play();
            Destroy(newParticleSystem.gameObject, 1f);
    }
}