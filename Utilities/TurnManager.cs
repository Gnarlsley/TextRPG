using EntityType;

namespace Utilities
{
    class TurnManager
    {
        private Player _player;
        private List<Enemy> _enemies;
        private int _currentTurn;

        public TurnManager(Player player, List<Enemy> enemies)
        {
            _player = player;
            _enemies = enemies;
            _currentTurn = 0;
        }

        public void StartTurn()
        {
            Console.WriteLine("You choose to battle, so it begins");

            while (_player.Health > 0 && _enemies.Count > 0)
            {
                PlayerTurn();
                if (_enemies.Count == 0) break;
                EnemyTurn();
            }

            if (_player.Health <= 0)
            {
                Console.WriteLine("The battle is over, you have lost");
                GamePanel.isTaskRunning = false;
            }
            else
            {
                Console.WriteLine("The battle is over, you are victorious");
                GamePanel.isTaskRunning = false;
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("You are up, make your move.\n1 - Attack\n2 - Defend\n3 - Dodge");
            string action = Console.ReadLine();
            if (action == "1")
            {
                PlayerAttack();
            }
            else if (action == "2")
            {
                PlayerDefend();
            }
            else if (action == "3")
            {
                PlayerDodge();
            }
        }

        private void PlayerAttack()
        {
            Enemy target = _enemies[0];
            Console.WriteLine($"You swing at {target.Name}");
            target.Health -= _player.Damage;
            if (target.Health <= 0)
            {
                Console.WriteLine($"The {target.Name} has been defeated");
                _enemies.Remove(target);
            }
        }

        private void PlayerDefend()
        {
            
        }

        private void PlayerDodge()
        {

        }

        private void EnemyTurn()
        {
            foreach (var enemy in _enemies)
            {
                Console.WriteLine($"The {enemy.Name} attacks you");
                _player.Health -= enemy.Damage;
                if (_player.Health <= 0) break;
            }
        }
    }
}