using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class CertificateTemplateGenerator
{
    public byte[] GenerateCertificateContent(string courseName, DateTime completionDate, string userName)
    {
        using (var certificateMemoryStream = new MemoryStream())
        {
            using (var document = new Document(PageSize.A4))
            {
                var writer = PdfWriter.GetInstance(document, certificateMemoryStream);
                document.Open();

                // Add decorative border (Replace the path with your decorative border image)
                var borderImage = Image.GetInstance("wwwroot/Images/logo1.png");
                // Calculate the scaling percentage based on the image and page size
                float widthPercentage = (document.PageSize.Width - document.LeftMargin - document.RightMargin) / borderImage.Width * 50;
                float heightPercentage = (document.PageSize.Height - document.TopMargin - document.BottomMargin) / borderImage.Height * 50;
                float scalingPercentage = Math.Min(widthPercentage, heightPercentage);
                borderImage.ScalePercent(scalingPercentage);
                document.Add(borderImage);


                // Add title
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 42, BaseColor.DARK_GRAY);
                var titleParagraph = new Paragraph("Certificate of Completion", titleFont);
                titleParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(titleParagraph);

                document.Add(new Paragraph("\n\n\n")); // Add some space between title and course details

                // Add course name
                var courseFont = FontFactory.GetFont(FontFactory.HELVETICA, 26, BaseColor.DARK_GRAY);
                var courseParagraph = new Paragraph("This is to certify that", courseFont);
                courseParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(courseParagraph);

                var courseNameFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 32, BaseColor.BLACK);
                var courseNameParagraph = new Paragraph(courseName, courseNameFont);
                courseNameParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(courseNameParagraph);

                document.Add(new Paragraph("\n")); // Add some space between course name and completion date

                // Format completion date to day-month-year (e.g., 28 July 2023)
                var formattedCompletionDate = completionDate.ToString("dd MMMM yyyy");
                var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 24, BaseColor.DARK_GRAY);
                var dateParagraph = new Paragraph("has been successfully completed on", dateFont);
                dateParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(dateParagraph);

                var completionDateFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 28, BaseColor.BLACK);
                var completionDateParagraph = new Paragraph(formattedCompletionDate, completionDateFont);
                completionDateParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(completionDateParagraph);

                document.Add(new Paragraph("\n\n\n")); // Add some space between completion date and user name

                // Add user name
                var userNameFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 26, BaseColor.DARK_GRAY);
                var userNameParagraph = new Paragraph("awarded to", userNameFont);
                userNameParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(userNameParagraph);

                var userNameFont2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 36, BaseColor.BLACK);
                var userNameParagraph2 = new Paragraph(userName, userNameFont2);
                userNameParagraph2.Alignment = Element.ALIGN_CENTER;
                document.Add(userNameParagraph2);

                document.Close();
            }

            return certificateMemoryStream.ToArray();
        }
    }
}
