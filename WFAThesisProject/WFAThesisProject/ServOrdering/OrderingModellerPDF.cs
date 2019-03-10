using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using WFAThesisProject.Exceptions;
using WFAThesisProject.ServOrdering;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject
{
    class OrderingModellerPDF
    {
        private Document doc;
        private Section thePage;
        private Paragraph paragraph;

        public OrderingModellerPDF(SetOfUserDetails userDet, string pathOfOutput,
            List<OrderingNoted> listThatNeedToBePDF)
        {
            string filename = "Rendeles_" + userDet.userLastName + "_" + DateTime.Today.Year.ToString() +
                    DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + ".pdf";
            int indexer = 0;
            try
            {
                if (!Directory.Exists(pathOfOutput))
                {
                    Directory.CreateDirectory(pathOfOutput);

                }
                while (File.Exists(pathOfOutput+filename))
                {
                    filename = "Rendeles_" + userDet.userLastName + "_"
                        + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString()
                        + DateTime.Today.Day.ToString() + "_" + indexer + ".pdf";
                    indexer++;
                }
            }
            catch (Exception e)
            {
                throw new ErrorMigraDocFileCreation("Probléma van a fájl nevével vagy elérésével (ModOrdPDFfolder) "
                    + e.Message);
            }
            try
            {
                adjustPageMetaDatas(userDet);
                adjustHeader(userDet);
                addOrderingRecToPDF(listThatNeedToBePDF);
                addFooterToPDF();
                finishPDF(pathOfOutput, filename);
            }
            catch (Exception e)
            {
                throw new ErrorMigraDocFileCreation("Probléma van a fájl létrehozásával (ModOrdPDF) "
                    + e.Message);
            }
        }

        #region passive adjustors of the healthcare-form creation
        /// <summary>
        /// adjust the page parameters
        /// </summary>
        private void adjustPageSize()
        {
            doc.DefaultPageSetup.PageFormat = PageFormat.A4;
            doc.DefaultPageSetup.LeftMargin = "2cm";
            doc.DefaultPageSetup.RightMargin = "2cm";
            doc.DefaultPageSetup.TopMargin = "2cm";
            doc.DefaultPageSetup.BottomMargin = "2cm";
            doc.DefaultPageSetup.HeaderDistance = "1.5cm";
            doc.DefaultPageSetup.FooterDistance = "1.5cm";
        }
        /// <summary>
        /// adjust the styles on the page
        /// </summary>
        private void adjustPageSytle()
        {
            //Arial, Calibri, Times New Roman, 
            //x Cambria, 
            Style pdfsty = null;
            pdfsty = doc.Styles[StyleNames.Header];
            pdfsty.Font.Size = 15;
            pdfsty.Font.Name = "Times New Roman";
            pdfsty.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            pdfsty = doc.Styles[StyleNames.Heading1];
            pdfsty.Font.Size = 13;
            pdfsty.Font.Bold = true;
            pdfsty.Font.Italic = true;
            pdfsty.Font.Name = "Calibri";
            pdfsty.ParagraphFormat.PageBreakBefore = false;
            pdfsty.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            pdfsty.Font.Size = 12;
            pdfsty = doc.Styles[StyleNames.Normal];
            pdfsty.Font.Name = "Times New Roman";
            pdfsty.ParagraphFormat.PageBreakBefore = false;
            pdfsty.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            pdfsty.Font.Size = 12;
            pdfsty = doc.Styles[StyleNames.Footer];
            pdfsty.ParagraphFormat.Alignment = ParagraphAlignment.Right;
        }
        #endregion

        /// <summary>
        /// adjust the metadata of the healthcare-form pdf
        /// </summary>
        /// <param name="name">the name of the person</param>
        private void adjustPageMetaDatas(SetOfUserDetails userDet)
        {
            doc = new Document();
            doc.Info.Author = userDet.userLastName + " " + userDet.userFirstName;
            doc.Info.Subject = "healt-datasheet with chemicals and accidents";
            doc.Info.Title = "Healthcare datasheet of " + userDet.userLastName + " " + userDet.userFirstName;
            adjustPageSize();   //passive
            adjustPageSytle();  //passive
        }
        /// <summary>
        /// define the header content of the healthcare-form
        /// </summary>
        /// <param name="name">the name of the person</param>
        /// <param name="taj">the taj-number of the person</param>
        private void adjustHeader(SetOfUserDetails userDet)
        {
            string headerText1 = "Rendelési lista";
            string headerText2 = userDet.userLastName + " " + userDet.userFirstName + " Beosztás: " + userDet.userPosition;
            thePage = new Section();
            thePage = doc.AddSection();
            paragraph = thePage.Headers.FirstPage.AddParagraph();        //this is a problematic line!!
            paragraph = thePage.AddParagraph();
            paragraph.AddFormattedText(headerText1, StyleNames.Header);
            paragraph.AddLineBreak();
            paragraph.AddFormattedText(headerText2, StyleNames.Header);
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("Nyomtatás ideje: ", StyleNames.Header);
            paragraph.AddDateField();
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
        }

        /// <summary>
        /// add the records to the PDF
        /// </summary>
        /// <param name="listThatNeedToBePDF">OrderingNoted records</param>
        private void addOrderingRecToPDF(List<OrderingNoted> listThatNeedToBePDF)
        {
            //thePage = doc.AddSection();
            // Create table 
            Table table = thePage.AddTable();
            // Define a columns 
            Column column = table.AddColumn();
            column.Style = StyleNames.Heading1;
            column.Width = 120;
            column = table.AddColumn();
            column.Style = StyleNames.Normal;
            column.Width = 250;
            column = table.AddColumn();
            column.Style = StyleNames.Normal;
            column.Width = 70;
            column = table.AddColumn();
            column.Style = StyleNames.Normal;
            column.Width = 70;
            // Create two rows with content 
            Row row = table.AddRow();
            
            row.Cells[0].AddParagraph("Termék kód:");
            row.Cells[1].AddParagraph("Termék neve:");
            row.Cells[2].AddParagraph("Mennyiség:");
            row.Cells[3].AddParagraph("Azonosító:");
            
            foreach (OrderingNoted rec in listThatNeedToBePDF)
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph(rec.termekKod);
                row.Cells[1].AddParagraph(rec.termekNev);
                row.Cells[2].AddParagraph(rec.beszerzMennyis.ToString());
                row.Cells[3].AddParagraph(rec.beszerId.ToString());
            }
        }


        /// <summary>
        /// adjust the footer on the PDF
        /// </summary>
        private void addFooterToPDF()
        {
            Section footer = doc.LastSection;
            Paragraph paragraph = footer.Footers.Primary.AddParagraph();
            paragraph.AddPageField();
            footer.PageSetup.StartingNumber = 1;
        }

        /// <summary>
        /// finishes the creating of the healthcare-form pdf
        /// </summary>
        /// <param name="destination">the final destination of the pdf file</param>
        public void finishPDF(string pathOfOutput, string filename)
        {
            try
            {
                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
                renderer.Document = doc;
                renderer.RenderDocument();
                renderer.PdfDocument.Save(pathOfOutput + filename);
            }
            catch (Exception e)
            {
                throw new ErrorMigraDocFileCreation("Nem sikerült a PDF fájl létrehozása (ModOrdPDF) " + e.Message);
            }
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WorkingDirectory = Path.GetDirectoryName(pathOfOutput);
                startInfo.FileName = filename;
                Process.Start(startInfo);
            }
            catch (Exception e)
            {
                throw new ErrorMigraDocFileOpening("Nem sikerült a PDF fájl megnyitása (ModOrdPDF) " + e.Message);
            }
        }
    }
}
