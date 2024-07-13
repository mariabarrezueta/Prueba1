using Microsoft.Maui.Controls;

namespace Prueba1.Behaviors
{
    public class ComportamientoExpira : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            if (entry.Text.Length == 2 && !entry.Text.Contains('/'))
            {
                entry.Text += "/";
            }
        }
    }
}
