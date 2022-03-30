namespace PlayersAndMonsters.Models.BattleFields.Contracts
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;
    public class BattleField : IBattleField
    {
        private const int HealthIncrease = 40;
        private const int DamageIncrease = 30;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ConstantMessages.PlayerDead);
            }
            IncreasingPlayer(attackPlayer);
            IncreasingPlayer(enemyPlayer);

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
          
            while (true)
            {
                int attackPlayerDamage = attackPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);               
                enemyPlayer.TakeDamage(attackPlayerDamage);
                if (enemyPlayer.IsDead)
                {
                    break;
                }
                int enemyPlayerDamage = enemyPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerDamage);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void IncreasingPlayer(IPlayer player)
        {
            if (player.GetType() == typeof(Beginner))
            {
                player.Health += HealthIncrease;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += DamageIncrease;
                }
            }
        }
    }
}
