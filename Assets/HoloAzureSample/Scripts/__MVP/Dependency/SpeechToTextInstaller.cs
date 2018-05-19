using HoloAzureSample.SpeechToText.MVP;
using UnityEngine;
using Zenject;

namespace HoloAzureSample.SpeechToText.MVP
{
    public class SpeechToTextInstaller : MonoInstaller<SpeechToTextInstaller>
    {
        [SerializeField] private string _subscriptionKey = "��������Azure�̃L�[������͂��遚";

        /// <summary>
        /// DI�R���e�i�̃Z�b�g�A�b�v
        /// </summary>
        public override void InstallBindings()
        {
            // Presenter
            Container.Bind<SpeechToTextPresenter>()
                .AsSingle()
                .NonLazy();

            // API
            Container.Bind<IUsefulSpeechToTextApi>()
                .To<AzureApiGateway>()
                .FromMethod(CreateApiGateway)
                .AsSingle()
                .NonLazy();

            // Usecase
            Container.Bind<SpeechToTextUsecase>().AsSingle();
        }

        private AzureApiGateway CreateApiGateway(InjectContext _)
        {
            return new AzureApiGateway(_subscriptionKey);
        }
    }
}
