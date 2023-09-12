using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinaria.Utilidades
{
    public static class Formulario
    {
        public static class Tipos
        {
            public enum Fecha
            {
                Anio,
                Mes,
                Semana,
                Dia
            }
        }
        public static class Cargar
        {
            public static void Dtp(DateTimePicker dtpDesde, DateTimePicker dtpHasta, Tipos.Fecha tipoDesde, int valorDesde)
            {
                dtpHasta.Value = DateTime.Now.AddDays(1);

                switch (tipoDesde)
                {
                    case Tipos.Fecha.Anio:
                        dtpDesde.Value = DateTime.Now.AddYears(-valorDesde);
                        break;
                    case Tipos.Fecha.Mes:
                        dtpDesde.Value = DateTime.Now.AddMonths(-valorDesde);
                        break;
                    case Tipos.Fecha.Semana:
                        dtpDesde.Value = DateTime.Now.AddDays(-valorDesde * 7);
                        break;
                    case Tipos.Fecha.Dia:
                        dtpDesde.Value = DateTime.Now.AddDays(-valorDesde);
                        break;
                }
            }
            public static void Combo<T>(ComboBox combo, List<T> lista)
            {
                combo.Items.Clear();
                foreach (T item in lista)
                {
                    combo.Items.Add(item);
                }
            }
        }
        public static class Validar
        {
            private static void remplazar(string criterio, string valor, TextBox textBox)
            {
                int selectionStart = textBox.SelectionStart;
                textBox.Text = Regex.Replace(textBox.Text, criterio, valor);
                textBox.SelectionStart = selectionStart;
            }
            public static void Int(TextBox textBox)
            {
                remplazar("[^0-9]", "", textBox);
            }
            public static void Decimal(TextBox textBox)
            {
                remplazar("[^0-9,]", "", textBox);
            }
        }
        public static class Mensaje
        {
            public static DialogResult Confirmacion(string descripcion, string titulo)
            {
                return MessageBox.Show(descripcion, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            public static DialogResult Error(string descripcion, string titulo)
            {
                return MessageBox.Show(descripcion, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            public static DialogResult Informacion(string descripcion, string titulo)
            {
                return MessageBox.Show(descripcion, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            public static DialogResult Advertencia(string descripcion, string titulo)
            {
                return MessageBox.Show(descripcion, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
