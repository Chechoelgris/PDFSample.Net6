using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;
using System.IO;

Console.WriteLine("Hello, World!");

var document = Document.Create(container =>
{
    container.Page(page =>
    {
        // Set page size and margin
        page.Size(PageSizes.A4.Landscape());
        page.Margin(0, Unit.Centimetre); // Reduce margin to accommodate border
        page.PageColor(Colors.White);
        page.DefaultTextStyle(x => x.FontSize(12));
        page.Background().BorderRight(10).BorderLeft(10).BorderColor(Colors.Red.Accent4).AspectRatio(15);

        page.Content().Padding(0).Element(element =>
        {
            element
                 
                .Padding(10)
                .Column(column =>
                {
                    column.Spacing(8);

                    // Logo en la cabecera
                    column.Item().Row(row =>
                    {
                        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "logo-mitta.png");
                        if (File.Exists(imagePath))
                        {

                            column.Item().AlignCenter().Height(50)
                            .Image(imagePath);

                        }
                        else
                        {
                            row.ConstantItem(120).Height(50).Text("Image not found!");
                        }

                        
                        
                    });

                    column.Item().Text("CERTIFICADO").ExtraBlack().ExtraBold().LetterSpacing(0.5f)
                        .FontSize(30).AlignCenter();
                    column.Item().PaddingBottom(5).PaddingTop(0).Text("GPS MITTA").LetterSpacing(0.6f)
                        .FontSize(24).AlignCenter().WordSpacing(0.3f);

                    // Subtitle
                    
                    column.Item().PaddingRight(25).PaddingLeft(25).Text(text =>
                    {
                        text.AlignCenter();
                        text.Span("MITTA S.A. RUT 83.547.100-4").ExtraBold().FontSize(13);
                        text.Span(" certifica por medio del presente documento, que ha implementado el servicio y sistema de Flota Conectada en la siguiente patente:").FontSize(13);
                        text.Span(" Flota Conectada").ExtraBold().FontSize(13);
                        text.Span(" en la siguiente patente:").FontSize(13);
                    });

                    // Convert InfoTableComponent to a table
                    column.Item().PaddingHorizontal(50).AlignCenter().Table(table =>
                    {
                        
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                        });

                        

                        table.Cell().Element(CellStyle).Text("PATENTE:").ExtraBlack().ExtraBold();
                        table.Cell().Element(CellStyle).Text("SXKS-19");

                        table.Cell().Element(CellStyle).Text("ID GPS:").ExtraBlack().ExtraBold();
                        table.Cell().Element(CellStyle).Text("G94FY2YTBV81");

                        table.Cell().Element(CellStyle).Text("MARCA Y MODELO GPS:").ExtraBlack().ExtraBold();
                        table.Cell().Element(CellStyle).Text("GEOTAB / GO9");

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2).AlignCenter();
                        }
                    });


                    // Additional information
                    column.Item().Padding(10).AlignCenter().Text("Se extiende este certificado a solicitud de nuestro cliente,\npara hacer uso en lo que estime conveniente.");

                    // Footer with logo and additional information
                    column.Item().Padding(5).AlignCenter().Text("DEPARTAMENTO DE FLOTA").FontSize(10).ExtraBlack();
                    column.Item().AlignCenter().Height(50).Image(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "logo-mitta.png"));

                    // Contact information
                    column.Item().Padding(5).AlignCenter().Text("Por favor valide la existencia o vigencia del presente móvil llamando al 800 370 111.\nO escríbanos a servicioclientes@mitta.cl para poder verificar la información.")
                        .FontSize(10).AlignCenter();
                    column.Item().Padding(5).AlignCenter().Hyperlink("https://my.flotaconectada.cl").Text("https://my.flotaconectada.cl")
                        .FontSize(10).AlignCenter().Bold();



                    column.Item().PaddingRight(25).PaddingLeft(25).Row(row =>
                    {
                        row.RelativeItem().Text(text =>
                        {
                            text.Span("Fecha de emisión del certificado: ").ExtraBold();
                            text.Span($"{DateTime.Now:dd/MM/yyyy}").FontSize(13);
                        });


                        row.RelativeItem().AlignRight().Text(text =>
                        {
                            text.Span("Fecha de caducidad del certificado: ").ExtraBold();
                            text.Span($"{DateTime.Now.AddMonths(6):dd/MM/yyyy}").FontSize(13);
                        });
                    });

                });
        });

        
    });
});

document.ShowInPreviewer();
static void FormatoUno()
{
    /*
    var document = Document.Create(container =>
    {
        container.Page(page =>
        {
            // Set page size and margin
            page.Size(PageSizes.A4.Landscape());
            page.Margin(0);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(14));

            page.Content().Element(element =>
            {
                element
                    .Padding(2, Unit.Centimetre)
                    .Border(6)
                    .BorderColor(Colors.Red.Accent4)
                    .Padding(10)
                    .Column(column =>
                    {
                        column.Spacing(15);

                        // Header section with logo and title
                        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "logo-mitta.png");
                        if (File.Exists(imagePath))
                        {
                            byte[] imageData = File.ReadAllBytes(imagePath);
                            column.Item().AlignCenter().Height(50).Width(100).Image(imageData);
                        }
                        else
                        {
                            column.Item().Text("Image not found!").AlignCenter();
                        }

                        column.Item().Text("CERTIFICADO DE INSTALACIÓN DE DISPOSITIVO")
                            .SemiBold().FontSize(24).FontColor(Colors.Black).AlignCenter();

                        column.Item().Text("Autorentas del Pacífico SPA, MITTA S.A. RUT 83.547.100-4 certifica por medio del presente documento, que ha implementado el servicio y sistema de monitoreo Flota Conectada con GPS en la siguiente empresa y patente:")
                            .FontSize(12).AlignCenter();

                        // Information tables
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Component(new InfoTableComponent(
                                ("PATENTE:", "SXTP-70"),
                                ("ID GPS:", "G9BH1UWR78R7"),
                                ("MARCA Y MODELO GPS:", "GEOTAB / GO9"),
                                ("VEHÍCULO:", "TOYOTA\nHILUX DX 2.4 MT 4X4 DSL DC E6\n2023")
                            ));

                            row.RelativeItem().Component(new InfoTableComponent(
                                ("EMPRESA:", "Corporación Nacional Cobre"),
                                ("RUT:", "61.704.000-K"),
                                ("DIRECCIÓN:", "Huérfanos 1270, Stgo.")
                            ));
                        });

                        column.Item().Text("https://my.mittaflotaconectada.cl/codelco_vp/\nUsuario: CLobo005@codelco.cl\nContraseña: codelco_vp2023")
                            .AlignCenter();

                        column.Item().Text("Se extiende este certificado a solicitud de nuestro cliente, para hacer uso en lo que estime conveniente.").AlignCenter();
                        column.Item().Text($"Generado el {DateTime.Now:dd/MM/yyyy} Por favor valide la existencia o vigencia del presente móvil llamando al 800 378 111.\nO escríbanos a servicioclientes@mitta.cl")
                            .FontSize(10).AlignCenter();
                    });
            });

         
        });
    });

    document.ShowInPreviewer();

   
*/
}

public class InfoTableComponent : IComponent
{
    private readonly (string Label, string Value)[] _entries;

    public InfoTableComponent(params (string Label, string Value)[] entries)
    {
        _entries = entries;
    }

    public void Compose(IContainer container)
    {
        container.Column(column =>
        {
            foreach (var (label, value) in _entries)
            {
                column.Item().Row(row =>
                {
                    row.RelativeItem().Background(Colors.Grey.Lighten3).Padding(5).Text(label).Bold();
                    row.RelativeItem().Background(Colors.Grey.Lighten2).Padding(5).Text(value);
                });
            }
        });
    }
}