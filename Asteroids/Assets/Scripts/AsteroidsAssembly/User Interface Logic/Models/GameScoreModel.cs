namespace AsteroidsAssembly.UserInterface
{
    public class GameScoreModel
    {
        public int Score { get; private set; }

        public void AddScore(int add) => Score += add;
    }
}