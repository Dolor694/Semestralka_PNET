namespace Gym.WebUI.Contexts
{
    // Context for keeping track of the user
    public sealed class UserContext
    {
        public int? UserId { get; private set; }

        public bool IsLoggedIn => UserId.HasValue;

        public event Action? OnChange;

        public void SetUserId(int userId)
        {
            UserId = userId;
            NotifyStateChanged();
        }

        public void Clear()
        {
            UserId = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}