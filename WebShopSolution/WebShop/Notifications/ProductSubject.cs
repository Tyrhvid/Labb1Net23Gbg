using WebShop.Models;

namespace WebShop.Notifications
{
    // Subject som håller reda på observatörer och notifiera
    public class ProductSubject
    {
        // Lista över registrerade observatöre
        private readonly List<INotificationObserver> _observers = new List<INotificationObserver>();

        public void Attach(INotificationObserver observer)
        {
            // Lägg till en observatör
            _observers.Add(observer);
        }

        public void Detach(INotificationObserver observer)
        {
            // Ta bort en observatör
            _observers.Remove(observer);
        }

        public void Notify(Product product)
        {
            // Notifiera aöla observatörer om en ny produkt
            foreach (var observer in _observers)
            {
                observer.Update(product);
            }
        }
    }
}
