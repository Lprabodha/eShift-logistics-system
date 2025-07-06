using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Helpers
{
    public static class PlaceholderHelper
    {
        /// <summary>
        /// Sets a placeholder text for a TextBox control.
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="placeholder"></param>
        /// <param name="isPassword"></param>
        private static Dictionary<TextBox, string> _placeholders = new();

        public static void SetPlaceholder(TextBox textbox, string placeholder, bool isPassword = false)
        {
            _placeholders[textbox] = placeholder;

            textbox.Text = placeholder;
            textbox.ForeColor = Color.Gray;
            textbox.UseSystemPasswordChar = false;

            textbox.GotFocus += (s, e) =>
            {
                if (textbox.Text == placeholder)
                {
                    textbox.Text = "";
                    textbox.ForeColor = Color.Black;
                    textbox.UseSystemPasswordChar = isPassword;
                }
            };

            textbox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                {
                    textbox.Text = placeholder;
                    textbox.ForeColor = Color.Gray;
                    textbox.UseSystemPasswordChar = false;
                }
            };
        }

        public static string GetInput(TextBox textbox)
        {
            if (_placeholders.TryGetValue(textbox, out string? placeholder))
            {
                return textbox.Text == placeholder ? "" : textbox.Text.Trim();
            }

            return textbox.Text.Trim();
        }
    }
}
