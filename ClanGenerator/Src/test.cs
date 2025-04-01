using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;

namespace MonMod
{
    public class MonModSubModule : MBSubModuleBase
    {
        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            base.OnGameStart(game, gameStarter);

            if (game.GameType is Campaign)
            {
                CampaignGameStarter campaignGameStarter = (CampaignGameStarter)gameStarter;
                campaignGameStarter.AddBehavior(new ClanGenerator.ClanGeneratorBehavior());
            }
        }
    }
}