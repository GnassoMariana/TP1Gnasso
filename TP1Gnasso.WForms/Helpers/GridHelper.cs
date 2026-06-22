using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Service.DTOs.Genre;
using TP1Gnasso.Service.DTOs.Size;
using TP1Gnasso.Service.DTOs.SportShoe;

namespace TP1Gnasso.WForms.Helpers
{
    public class GridHelper
    {
        /// de la grilla que me pasan
        /// </summary>
        /// <param name="grid">Grilla a la cual le creo la fila</param>
        /// <returns>Fila de la grilla resultante</returns>
        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }
        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case  SportShoeListDto tipoDto:
                    r.Cells[0].Value = tipoDto.SportShoeId;
                    r.Cells[1].Value = tipoDto.Model;
                    r.Cells[2].Value = tipoDto.Brand;
                    r.Cells[3].Value = tipoDto.Genre;
                    r.Cells[4].Value = tipoDto.Sport;
                    r.Cells[5].Value = tipoDto.Size;
                    r.Cells[6].Value = tipoDto.Price;
                    r.Cells[7].Value = tipoDto.ReleaseDate;
                    r.Cells[8].Value = tipoDto.Active;
                    break;
                //case FormaDePagoListDto formaDto:
                //    r.Cells[0].Value = formaDto.FormaDePagoId;
                //    r.Cells[1].Value = formaDto.Nombre;
                //    r.Cells[2].Value = formaDto.Activo;
                //    break;

            }

            r.Tag = obj;
        }
        /// <summary>
        /// Método estático para agregar una fila a una grilla
        /// </summary>
        /// <param name="r">Fila a agregar</param>
        /// <param name="grid">Grilla en la cual se agrega la fila</param>
        public static void AgregarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Add(r);
        }
        /// <summary>
        /// Método estático para eliminar una fila a una grilla
        /// </summary>
        /// <param name="r">Fila a eliminar</param>
        /// <param name="grid">Grilla en la cual se desea quitar la fila</param>
        public static void QuitarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Remove(r);
        }

        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }

        public static void LoadComboBoxSizes(ComboBox sizesCombo, List<SizeListDto> sizes)
        {
            
            sizesCombo.DataSource = sizes;
            sizesCombo.DisplayMember = nameof(SizeListDto.Number);
            sizesCombo.ValueMember = nameof(SizeListDto.SizeId);
        }

        public static void LoadComboBoxGenre(ComboBox genresCombo, List<GenreListDto> genres)
        {
            genresCombo.DataSource = genres;
            genresCombo.DisplayMember = nameof(GenreListDto.Name);
            genresCombo.ValueMember = nameof(GenreListDto.GenreId);
        }

    }
    

}

