namespace PlayersAndMonsters.Core
{
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private IBattleField battleField;
        public ManagerController(IPlayerRepository playerRepository, ICardRepository cardRepository,
            IBattleField battleField)
        {
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            PlayerFactory playerFactory = new PlayerFactory();
            IPlayer player = playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            CardFactory cardFactory = new CardFactory();
            ICard card = cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {           
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);
            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                builder.AppendLine(string.Format(ConstantMessages.PlayerReportInfo,
                    player.Username, player.Health, player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    builder.AppendLine(string.Format(ConstantMessages.CardReportInfo,
                    card.Name, card.DamagePoints));
                }
                builder.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return builder.ToString().Trim();
        }
    }
}