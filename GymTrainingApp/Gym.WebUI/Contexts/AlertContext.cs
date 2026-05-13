namespace Gym.WebUI.Contexts
{
    // Allert context for keeping track of pending messages to be displayed on the next page load
    public sealed class AlertContext
    {
        public string? PendingSuccessMessage { get; private set; }

        public event Action? OnChange;

        public void SetSuccessMessage(string message)
        {
            PendingSuccessMessage = message;
            NotifyStateChanged();
        }

        public string? PopSuccessMessage()
        {
            var message = PendingSuccessMessage;
            PendingSuccessMessage = null;
            NotifyStateChanged();
            return message;
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}