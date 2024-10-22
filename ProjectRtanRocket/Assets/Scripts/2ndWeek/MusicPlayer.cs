using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip bgmOnLaunch;

    private LandingCheckEventContainer landingEventContainer;

    private void Awake()
    {
        landingEventContainer = GetComponent<LandingCheckEventContainer>();
    }

    private void Start()
    {
        landingEventContainer.OnLaunchEvent += PlayBgmOnLaunch;
        landingEventContainer.OnLandingEvent += StopBgmOnLanding;
    }

    public void PlayBgmOnLaunch()
    {
        AudioManager.Instance.PlayBGM(bgmOnLaunch, 0.4f, true);
    }

    public void StopBgmOnLanding()
    {
        AudioManager.Instance.StopBGM();
    }
}
