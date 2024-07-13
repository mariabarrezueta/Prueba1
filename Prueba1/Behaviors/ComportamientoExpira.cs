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
            string newText = entry.Text.Replace("/", "");

            if (newText.Length > 4)
            {
                newText = newText.Substring(0, 4);
            }

            if (newText.Length >= 2)
            {
                if (int.TryParse(newText.Substring(0, 2), out int month))
                {
                    if (month < 1 || month > 12)
                    {
                        newText = "12";
                    }

                    if (newText.Length > 3)
                    {
                        int year = int.Parse(newText.Substring(2, 2));
                        if (year < 24)
                        {
                            newText = newText.Substring(0, 2) + "24";
                        }
                    }

                    newText = newText.Insert(2, "/");
                }
            }

            entry.Text = newText;
        }
    }
}

