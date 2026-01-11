namespace Core.Interfaces
{
    public interface IView
    {
        bool IsVisible { get; }
        void Show();
        void Hide();
    }
}
