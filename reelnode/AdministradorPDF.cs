using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Tls.Crypto.Impl;
using Reelnode;

namespace ProjectoNuevo
{
    public static class AdministradorPDF
    {
        public static void ExportadorDashboard(string rutaPDF) 
        { 
            //CREACION DEL DOCUMENTO PDF
            Document documento = new Document(PageSize.A4, 40, 40, 40, 40);

            /*PdfWriter: es una clase de la librería iTextSharp que se encarga de escribir 
             *los datos del documento en un destino (generalmente un archivo o un flujo de memoria).
         
            FileStream: es una clase de .NET que representa un flujo de bytes hacia un archivo físico.
            Se usa para escribir o leer archivos en disco.

            “Crea un escritor de PDF que tome todo lo que agregue al documento documento,
             y lo guarde en el archivo ubicado en rutaArchivo.”
             */

            PdfWriter.GetInstance(documento, new FileStream(rutaPDF, FileMode.Create));

            //TITULO DEL DOCUMENTO
            var titulo = new Paragraph("Reporte de metricas del Dashboard", new Font(Font.FontFamily.COURIER, 20, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);

            //FECHA DE GENERACION DE DOCUMENTO
            documento.Add(new Paragraph("\n Fecha de Generacion: " + DateTime.Now.ToString("dd/MM/yyyy/ HH:mm:ss")));
            documento.Add(new Paragraph("\n------------------------------------------------------------\n"));

            //METRICAS GENERALES
            int totalPelis = UtilsBD.peliculasCargadas.Count;
            int totalSeries = UtilsBD.seriesCargadas.Count;
            int totalGeneros = UtilsBD.generosCargados.Count;
            int totalNetworks = UtilsBD.networksCargadas.Count;

            //VISUALIZACION METRICAS GENERALES
            documento.Add(new Paragraph("🎬 Total de Peliculas: " + totalPelis));
            documento.Add(new Paragraph("📺 Total de Series: " + totalSeries));
            documento.Add(new Paragraph("🏷️ Total de Generos: " + totalGeneros));
            documento.Add(new Paragraph("🌐 Total de Networks: " + totalNetworks));
            documento.Add(new Paragraph("\n------------------------------------------------------------\n"));

            //METRICAS DESTACADAS

            //PELICULA MAS VISTA
            if (UtilsBD.pelisMasVistas.Any()) 
            {
                documento.Add(new Paragraph("⭐ Pelicula mas vista: " + UtilsBD.pelisMasVistas.First().Nombre));
            }

            //PROMEDIO CALIFICACION PELI MAS VISTA
            if (UtilsBD.pelisMasVistas.Any()) 
            {
                documento.Add(new Paragraph("⭐ Promedio de calificacion de la pelicula mas vista: " + UtilsBD.pelisMasVistas.First().CalificacionPromedio));
            }

            //SERIE MAS VISTA
            if (UtilsBD.seriesMasVistas.Any()) 
            {
                documento.Add(new Paragraph("🔥 Serie mas vista: " + UtilsBD.seriesMasVistas.First().Nombre));
            }

            //PROMEDIO CALIFICACION SERIE MAS VISTA
            if (UtilsBD.seriesMasVistas.Any()) 
            {
                documento.Add(new Paragraph("⭐ Promedio calificacion de la serie mas vista: " + UtilsBD.seriesMasVistas.First().CalificacionPromedio));
            }
            documento.Add(new Paragraph("\n------------------------------------------------------------\n"));

            //TOP 5 PELICULAS MAS VISTAS
            documento.Add(new Paragraph("🎥 Top 5 Películas más vistas:\n"));
            int topPelis = Math.Min(5, UtilsBD.pelisMasVistas.Count);

            for (int i = 0; i < topPelis; i ++) 
            { 
                var peli = UtilsBD.pelisMasVistas[i];
                documento.Add(new Paragraph($"{i + 1}. {peli.Nombre} - {peli.CalificacionPromedio: F1/5}"));
            }

            //TOP 5 SERIES MAS VISTAS
            documento.Add(new Paragraph("\n📺 Top 5 Series más vistas:\n"));
            int topSeries = Math.Min(5, UtilsBD.seriesMasVistas.Count);

            for (int i = 0; i < topSeries; i ++) 
            { 
                var serie = UtilsBD.seriesMasVistas[i];
                documento.Add(new Paragraph($"{i + i}. {serie.Nombre} - {serie.CalificacionPromedio: F1/5}"));
            }

            documento.Add(new Paragraph("\n------------------------------------------------------------\n"));

            //TABLAS DE CONTENIDO CARGADO (SERIES Y PELICULAS)
            documento.Add(new Paragraph("📊 INFORME DE CONTENIDOS CARGADOS"));
            documento.Add(new Paragraph(""));

            //TABLA DE PELICULAS CARGADAS
            PdfPTable tablaPelis = new PdfPTable(11);
            tablaPelis.WidthPercentage = 100;
            tablaPelis.AddCell("ID: ");
            tablaPelis.AddCell("Titulo: ");
            tablaPelis.AddCell("Fecha Estreno: ");
            tablaPelis.AddCell("Descripcion: ");
            tablaPelis.AddCell("Director: ");
            tablaPelis.AddCell("Imagen URL: ");
            tablaPelis.AddCell("Network: ");
            tablaPelis.AddCell("Tipo: ");
            tablaPelis.AddCell("Trailer URL: ");
            tablaPelis.AddCell("Genero: ");
            tablaPelis.AddCell("Duracion: ");

            foreach (var pelis in UtilsBD.peliculasCargadas) 
            {
                tablaPelis.AddCell(pelis.Id.ToString());
                tablaPelis.AddCell(pelis.Nombre);
                tablaPelis.AddCell(pelis.FechaEstreno.ToString("dd/MM/yyyy"));
                tablaPelis.AddCell(pelis.Descripcion);
                tablaPelis.AddCell(pelis.ImagenURL);

                // Obtener el nombre del Network usando el ID (para evitar el error)
                var network = UtilsBD.networksCargadas.FirstOrDefault(n => n.Id == pelis.Network);

                tablaPelis.AddCell(network != null ? network.Nombre: "Sin nombre");
                tablaPelis.AddCell(pelis.Tipo);
                tablaPelis.AddCell(pelis.TrailerURL);
                
                //Obtener los generos de la lista
                var listGenerosPelis = string.Join(",", UtilsBD.generosCargados.Where(gp => pelis.Generos.Contains(gp.Id)).Select(g => g.Nombre));

                tablaPelis.AddCell(listGenerosPelis);
                tablaPelis.AddCell(pelis.Duracion.ToString());
            }

            documento.Add(new Paragraph("🎬 Películas Cargadas"));
            documento.Add(tablaPelis);
            documento.Add(new Paragraph("\n"));

            //TABLA DE SERIES AGREGADAS
            PdfPTable tablaSeries = new PdfPTable(12);
            tablaSeries.WidthPercentage = 100;
            tablaSeries.AddCell("ID: ");
            tablaSeries.AddCell("Titulo: ");
            tablaSeries.AddCell("Fecha Estreno: ");
            tablaSeries.AddCell("Fecha Fin: ");
            tablaSeries.AddCell("Descripcion: ");
            tablaSeries.AddCell("Director: ");
            tablaSeries.AddCell("Imagen URL: ");
            tablaSeries.AddCell("Network: ");
            tablaSeries.AddCell("Tipo: ");
            tablaSeries.AddCell("Trailer URL: ");
            tablaSeries.AddCell("Genero: ");
            tablaSeries.AddCell("Temporadas: ");

            foreach (var series in UtilsBD.seriesCargadas) 
            {
                tablaSeries.AddCell(series.Id.ToString());
                tablaSeries.AddCell(series.Nombre);
                tablaSeries.AddCell(series.FechaEstreno.ToString("dd/MM/yyyy"));
                tablaSeries.AddCell(series.FechaFin.ToString("dd/MM/yyyy"));
                tablaSeries.AddCell(series.Descripcion);
                tablaSeries.AddCell(series.Director);
                tablaSeries.AddCell(series.ImagenURL);

                //Obtener el Network de la Serie usando el ID
                var networkSerie = UtilsBD.networksCargadas.FirstOrDefault(s => s.Id == series.Network);
                tablaSeries.AddCell(networkSerie != null ? networkSerie.Nombre: "Sin nombre");
                tablaSeries.AddCell(series.Tipo);
                tablaSeries.AddCell(series.TrailerURL);

                //Obtener los generos de la lista
                var listGenerosSeries = string.Join(",", UtilsBD.generosCargados.Where(gs => series.Generos.Contains(gs.Id)).Select(g => g.Nombre));

                tablaSeries.AddCell(listGenerosSeries);
                tablaSeries.AddCell(series.Temporadas.ToString());
            }

            documento.Add(new Paragraph("📺 Series Cargadas"));
            documento.Add(tablaSeries);
            documento.Close();
        }
    }
}