using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster
{
    internal class RetroButton
    {
        public static void ApplyStyle(Button button, string buttonText)
        {
            button.FlatStyle = FlatStyle.Flat; // Usa un estilo plano
            button.FlatAppearance.BorderSize = 0; // Sin borde estándar
            button.BackColor = Color.FromArgb(192, 192, 192); // Fondo gris claro
            button.Text = ""; // Se manejará manualmente para personalizar el dibujo

            // Asigna el evento Paint
            button.Paint += (s, e) =>
            {
                // Fondo del botón
                e.Graphics.FillRectangle(new SolidBrush(button.BackColor), button.ClientRectangle);

                // Bordes tridimensionales
                var borderPenLight = new Pen(Color.White, 1);  // Borde claro (parte superior/izquierda)
                var borderPenDark = new Pen(Color.Gray, 1);    // Borde oscuro (parte inferior/derecha)
                var borderPenShadow = new Pen(Color.Black, 1); // Sombra profunda (interior)

                // Dibuja bordes claros
                e.Graphics.DrawLine(borderPenLight, 0, 0, button.Width - 1, 0); // Arriba
                e.Graphics.DrawLine(borderPenLight, 0, 0, 0, button.Height - 1); // Izquierda

                // Dibuja bordes oscuros
                e.Graphics.DrawLine(borderPenDark, button.Width - 1, 0, button.Width - 1, button.Height - 1); // Derecha
                e.Graphics.DrawLine(borderPenDark, 0, button.Height - 1, button.Width - 1, button.Height - 1); // Abajo

                // Dibuja sombra interior
                e.Graphics.DrawLine(borderPenShadow, 1, button.Height - 2, button.Width - 2, button.Height - 2); // Sombra inferior
                e.Graphics.DrawLine(borderPenShadow, button.Width - 2, 1, button.Width - 2, button.Height - 2); // Sombra derecha

                // Dibuja el texto
                TextRenderer.DrawText(
                    e.Graphics,
                    buttonText,
                    button.Font,
                    button.ClientRectangle,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            };
        }

        public static void backgroundStyle(Form form)
        {
            form.BackColor = Color.FromArgb(192, 192, 192); // Fondo gris claro

            // Configuramos el evento Paint del formulario
            form.Paint += (s, e) =>
            {
                // Opcional: Añadir un borde o patrón al formulario
                var borderPen = new Pen(Color.DarkGray, 2);

                // Dibuja un borde alrededor del formulario
                e.Graphics.DrawRectangle(borderPen, 0, 0, form.ClientSize.Width - 1, form.ClientSize.Height - 1);
            };
        }
    }
}
