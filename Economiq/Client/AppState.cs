namespace Economiq.Client
{
    public class AppState
    {
        public bool IsLoggedIn { get; private set; }
#pragma warning disable CS8618 // Non-nullable property 'PageTitle' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string PageTitle { get; private set; }
#pragma warning restore CS8618 // Non-nullable property 'PageTitle' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable event 'OnStateChange' must contain a non-null value when exiting constructor. Consider declaring the event as nullable.
        public event Action OnStateChange;
#pragma warning restore CS8618 // Non-nullable event 'OnStateChange' must contain a non-null value when exiting constructor. Consider declaring the event as nullable.

        public void SetPageTitle(string title)
        {
            PageTitle = title;
            NotifyStateChanged();
        }

        public void SetUserLoggedIn()
        {
            IsLoggedIn = true;
            NotifyStateChanged();
        }

        public void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}