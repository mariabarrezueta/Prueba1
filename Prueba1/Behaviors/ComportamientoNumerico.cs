using Microsoft.Maui.Controls;

namespace Prueba1.Behaviors
{
    public class ComportamientoNumerico : Behavior<Entry>
    {
        public int MaxLength { get; set; }

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
            if (entry.Text.Length > MaxLength)
            {
                entry.Text = entry.Text.Substring(0, MaxLength);
            }
        }
    }
}
