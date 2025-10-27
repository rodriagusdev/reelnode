using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Tls.Crypto.Impl;
using Reelnode;

namespace Reelnode
{
    public static class AdministradorPDF
    {
        // === COLORES DEL TEMA CYBERPUNK ===
        private static BaseColor azulOscuro = new BaseColor(
            AdministradorTema.AzulOscuroNeon.R,
            AdministradorTema.AzulOscuroNeon.G,
            AdministradorTema.AzulOscuroNeon.B
        );
        private static BaseColor verdeNeon = new BaseColor(
            AdministradorTema.VerdeClaroNeon.R,
            AdministradorTema.VerdeClaroNeon.G,
            AdministradorTema.VerdeClaroNeon.B
        );
        private static BaseColor rosaNeon = new BaseColor(
            AdministradorTema.RosaNeon.R,
            AdministradorTema.RosaNeon.G,
            AdministradorTema.RosaNeon.B
        );
        private static BaseColor cyanNeon = new BaseColor(
            AdministradorTema.CyanNeon.R,
            AdministradorTema.CyanNeon.G,
            AdministradorTema.CyanNeon.B
        );
        private static BaseColor fondoTabla = new BaseColor(20, 20, 30);

        // En el PDF pinto las paginas, pero sin esta funcion, solo se pinta la primera.
        // Es necesaria para pitnar todas las paginas que existan
        class FondoPaginaEvento : PdfPageEventHelper
        {
            private BaseColor _fondo;

            public FondoPaginaEvento(BaseColor fondo)
            {
                _fondo = fondo;
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfContentByte cb = writer.DirectContentUnder;
                cb.SetColorFill(_fondo);
                cb.Rectangle(0, 0, document.PageSize.Width, document.PageSize.Height);
                cb.Fill();
            }
        }

        public static void ExportarDataGridToPDF(DataGridView dgv, string rutaPDF)
        {
            Document documento = new Document(PageSize.A4, 40, 40, 40, 40);

            using (FileStream fs = new FileStream(rutaPDF, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(documento, fs);

                // Fondo en todas las páginas
                writer.PageEvent = new FondoPaginaEvento(
                    new BaseColor(
                        AdministradorTema.AzulOscuroNeon.R,
                        AdministradorTema.AzulOscuroNeon.G,
                        AdministradorTema.AzulOscuroNeon.B
                    )
                );

                documento.Open();

                // Título
                var titulo = new Paragraph(
                    "📊 Exportación de datos",
                    new Font(Font.FontFamily.COURIER, 18, Font.BOLD, new BaseColor(0, 255, 180))
                )
                { Alignment = Element.ALIGN_CENTER };
                documento.Add(titulo);
                documento.Add(new Paragraph("\n"));

                // Configuración de colores y fuentes
                BaseColor neonHeader = new BaseColor(
                    AdministradorTema.CyanNeon.R,
                    AdministradorTema.CyanNeon.G,
                    AdministradorTema.CyanNeon.B
                );
                BaseColor fondoTabla = new BaseColor(20, 20, 30);
                Font fuenteEncabezado = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, neonHeader);
                Font fuenteCuerpo = new Font(Font.FontFamily.HELVETICA, 9, Font.NORMAL, BaseColor.WHITE);

                // Filtrar columnas visibles. No quier mostrar ni Password ni Avatar ya uqe es una URL
                var columnasVisibles = dgv.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Name != "Password" && c.Name != "Avatar")
                    .ToList();

                PdfPTable tabla = new PdfPTable(columnasVisibles.Count) { WidthPercentage = 100 };

                // Cargo encabezados
                foreach (var col in columnasVisibles)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(col.HeaderText, fuenteEncabezado))
                    {
                        BackgroundColor = new BaseColor(30, 30, 50),
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5
                    };
                    tabla.AddCell(celda);
                }

                // Cargo filas
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    foreach (var col in columnasVisibles)
                    {
                        var valor = row.Cells[col.Index].Value?.ToString() ?? "";
                        PdfPCell celda = new PdfPCell(new Phrase(valor, fuenteCuerpo))
                        {
                            BackgroundColor = fondoTabla,
                            BorderColor = neonHeader,
                            Padding = 4,
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        tabla.AddCell(celda);
                    }
                }

                documento.Add(tabla);
                documento.Close();
            }
        }

        public static void ExportadorDashboard(string rutaPDF)
        {
            Document documento = new Document(PageSize.A4, 40, 40, 40, 40);

            using (FileStream fs = new FileStream(rutaPDF, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(documento, fs);

                // Agrego el evento para pintar fondo en todas las páginas
                writer.PageEvent = new FondoPaginaEvento(azulOscuro);

                documento.Open();

                // === FONDO DE PÁGINA ===
                PdfContentByte fondo = writer.DirectContentUnder;
                fondo.SetColorFill(azulOscuro);
                fondo.Rectangle(0, 0, documento.PageSize.Width, documento.PageSize.Height);
                fondo.Fill();

                // ===== TÍTULO =====
                var titulo = new Paragraph(
                    "📊 REPORTE DE MÉTRICAS DEL DASHBOARD",
                    new Font(Font.FontFamily.COURIER, 20, Font.BOLD, verdeNeon)
                )
                {
                    Alignment = Element.ALIGN_CENTER,
                };
                documento.Add(titulo);

                documento.Add(
                    new Paragraph(
                        "\nFecha de generación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                        new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.LIGHT_GRAY)
                    )
                );
                documento.Add(new Paragraph("\n──────────────────────────────────────────────\n"));

                // ===== MÉTRICAS GENERALES =====
                var peliculas = AdministradorPeliculas.peliculasCargadas ?? new List<Pelicula>();
                var series = AdministradorSeries.seriesCargadas ?? new List<Serie>();
                List<Genero> generos = UtilsBD.CargarGeneros() ?? new List<Genero>();
                List<Network> networks = UtilsBD.CargarNetworks() ?? new List<Network>();

                documento.Add(
                    new Paragraph(
                        "🎬 Total de películas: " + peliculas.Count,
                        new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                    )
                );
                documento.Add(
                    new Paragraph(
                        "📺 Total de series: " + series.Count,
                        new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                    )
                );
                documento.Add(
                    new Paragraph(
                        "🏷️ Total de géneros: " + generos.Count,
                        new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                    )
                );
                documento.Add(
                    new Paragraph(
                        "🌐 Total de networks: " + networks.Count,
                        new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                    )
                );

                // ===== NUEVAS MÉTRICAS DE USUARIO =====
                var ultimoUsuario = AdministradorUsuarios.CargarUltimoUsuarioRegistrado();
                var usuariosTotales = AdministradorUsuarios.CargarUsuariosRegistrados();
                var usuariosUltimoMes = AdministradorUsuarios.CargarUsuariosRegistradosUltimoMes();
                var usuarioMasCalificador = AdministradorUsuarios.CargarUsuarioMasCalificador();
                var usuarioMasComentador = AdministradorUsuarios.CargarUsuarioMasComentador();
                var usuariosMasActivos = AdministradorUsuarios.CargarUsuariosMasActivos(5);

                documento.Add(new Paragraph("\n──────────────────────────────────────────────\n"));
                documento.Add(
                    new Paragraph(
                        "👥 MÉTRICAS DE USUARIOS",
                        new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD, verdeNeon)
                    )
                );
                documento.Add(
                    new Paragraph(
                        $"👤 Total de usuarios registrados: {usuariosTotales}",
                        new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                    )
                );
                documento.Add(
                    new Paragraph(
                        $"🗓️ Usuarios registrados en el último mes: {usuariosUltimoMes}",
                        new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                    )
                );

                if (ultimoUsuario != null)
                    documento.Add(
                        new Paragraph(
                            $"🆕 Último usuario registrado: {ultimoUsuario.NombreUsuario} ({ultimoUsuario.FechaRegistro})",
                            new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                        )
                    );

                if (usuarioMasCalificador != null)
                    documento.Add(
                        new Paragraph(
                            $"⭐ Usuario más calificador: {usuarioMasCalificador.NombreUsuario} ({usuarioMasCalificador.Cantidad} calificaciones)",
                            new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                        )
                    );

                if (usuarioMasComentador != null)
                    documento.Add(
                        new Paragraph(
                            $"💬 Usuario más comentador: {usuarioMasComentador.NombreUsuario} ({usuarioMasComentador.Cantidad} comentarios)",
                            new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                        )
                    );

                if (usuariosMasActivos != null)
                {
                    documento.Add(
                        new Paragraph(
                            "\n🔥 Usuarios más activos (Top 5):",
                            new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                        )
                    );
                    int rank = 1;
                    foreach (var kvp in usuariosMasActivos)
                    {
                        documento.Add(
                            new Paragraph(
                                $"{rank}. {kvp.Key} – {kvp.Value} visualizaciones",
                                new Font(
                                    Font.FontFamily.HELVETICA,
                                    11,
                                    Font.NORMAL,
                                    BaseColor.WHITE
                                )
                            )
                        );
                        rank++;
                    }
                }

                // ===== MÉTRICAS DESTACADAS =====
                documento.Add(new Paragraph("\n──────────────────────────────────────────────\n"));
                documento.Add(
                    new Paragraph(
                        "🏆 CONTENIDO DESTACADO",
                        new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD, verdeNeon)
                    )
                );

                var pelisMasVistas = AdministradorPeliculas.CargarPeliculasMasVistas(50);
                var seriesMasVistas = AdministradorSeries.CargarSeriesMasVistas(50);

                if (pelisMasVistas.Any())
                {
                    double califPromedio = AdministradorCalificaciones.ObtenerCalificacionPromedio(
                        "sp_obtener_pelicula_calificacion_promedio",
                        pelisMasVistas.First().Id,
                        EnumTipoId.p_id_pelicula
                    );

                    documento.Add(
                        new Paragraph(
                            $"🎞️ Película más vista: {pelisMasVistas.First().Nombre}",
                            new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                        )
                    );
                    documento.Add(
                        new Paragraph(
                            $"⭐ Promedio de calificación: {califPromedio:F1}/5",
                            new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, rosaNeon)
                        )
                    );
                }

                if (seriesMasVistas.Any())
                {
                    double califPromedio = AdministradorCalificaciones.ObtenerCalificacionPromedio(
                        "sp_obtener_serie_calificacion_promedio",
                        seriesMasVistas.First().Id,
                        EnumTipoId.p_id_serie
                    );

                    documento.Add(
                        new Paragraph(
                            $"📺 Serie más vista: {seriesMasVistas.First().Nombre}",
                            new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.WHITE)
                        )
                    );
                    documento.Add(
                        new Paragraph(
                            $"⭐ Promedio de calificación: {califPromedio:F1}/5",
                            new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, rosaNeon)
                        )
                    );
                }

                // ===== TABLAS CYBERPUNK =====
                Font fuenteEncabezado = new Font(
                    Font.FontFamily.HELVETICA,
                    10,
                    Font.BOLD,
                    cyanNeon
                );
                Font fuenteCuerpo = new Font(
                    Font.FontFamily.HELVETICA,
                    9,
                    Font.NORMAL,
                    BaseColor.WHITE
                );

                // === TABLA PELÍCULAS ===
                documento.Add(
                    new Paragraph(
                        "\n🎬 Películas Cargadas\n\n",
                        new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, verdeNeon)
                    )
                );

                string[] encabezadosPelis =
                {
                    "Título",
                    "Fecha Estreno",
                    "Director",
                    "Network",
                    "Géneros",
                    "Duración",
                };
                PdfPTable tablaPelis = new PdfPTable(encabezadosPelis.Length)
                {
                    WidthPercentage = 100,
                };

                foreach (var enc in encabezadosPelis)
                {
                    var cell = new PdfPCell(new Phrase(enc, fuenteEncabezado))
                    {
                        BackgroundColor = new BaseColor(30, 30, 50),
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5,
                    };
                    tablaPelis.AddCell(cell);
                }

                foreach (var pelisItem in peliculas)
                {
                    var network = networks.FirstOrDefault(n => n.Id == pelisItem.Network);
                    var listGenerosPelis = string.Join(
                        ", ",
                        generos.Where(g => pelisItem.Generos.Contains(g.Id)).Select(g => g.Nombre)
                    );

                    string[] valores =
                    {
                        pelisItem.Nombre,
                        pelisItem.FechaEstreno.ToString("dd/MM/yyyy"),
                        pelisItem.Director,
                        network?.Nombre ?? "Sin nombre",
                        listGenerosPelis,
                        pelisItem.Duracion.ToString(),
                    };

                    foreach (var val in valores)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(val, fuenteCuerpo))
                        {
                            BackgroundColor = fondoTabla,
                            BorderColor = verdeNeon,
                            Padding = 4,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                        };
                        tablaPelis.AddCell(celda);
                    }
                }
                documento.Add(tablaPelis);

                // === TABLA SERIES ===
                documento.Add(
                    new Paragraph(
                        "\n📺 Series Cargadas\n\n",
                        new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, cyanNeon)
                    )
                );

                string[] encabezadosSeries =
                {
                    "Título",
                    "Fecha Estreno",
                    "Fecha Fin",
                    "Director",
                    "Network",
                    "Géneros",
                    "Temps",
                };
                PdfPTable tablaSeries = new PdfPTable(encabezadosSeries.Length)
                {
                    WidthPercentage = 100,
                };

                foreach (var enc in encabezadosSeries)
                {
                    var cell = new PdfPCell(new Phrase(enc, fuenteEncabezado))
                    {
                        BackgroundColor = new BaseColor(30, 30, 50),
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5,
                    };
                    tablaSeries.AddCell(cell);
                }

                foreach (var serieItem in series)
                {
                    var networkSerie = networks.FirstOrDefault(n => n.Id == serieItem.Network);
                    var listGenerosSeries = string.Join(
                        ", ",
                        generos.Where(g => serieItem.Generos.Contains(g.Id)).Select(g => g.Nombre)
                    );

                    string[] valores =
                    {
                        serieItem.Nombre,
                        serieItem.FechaEstreno.ToString("dd/MM/yyyy"),
                        serieItem.FechaFin.ToString("dd/MM/yyyy"),
                        serieItem.Director,
                        networkSerie?.Nombre ?? "Sin nombre",
                        listGenerosSeries,
                        serieItem.Temporadas.ToString(),
                    };

                    foreach (var val in valores)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(val, fuenteCuerpo))
                        {
                            BackgroundColor = fondoTabla,
                            BorderColor = cyanNeon,
                            Padding = 4,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                        };
                        tablaSeries.AddCell(celda);
                    }
                }

                documento.Add(tablaSeries);
                documento.Close();
            }
        }
    }
}
