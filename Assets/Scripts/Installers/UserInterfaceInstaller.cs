using Zenject;

public class UserInterfaceInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<ScoreText>().AsSingle();
	}
}
