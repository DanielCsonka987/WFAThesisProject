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
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject.ProfileManage
{
    public class PersonalProfileModelPDFhc
    {
        private Document doc;
        private Section thePage;
        private Paragraph paragraph;
        private string path;
        //it works with PDFSharp-MigraDoc-GDI by empria Software BmbH v. 1.32.4334
        public PersonalProfileModelPDFhc(SetOfUserDetails userDet, string pathOfOutput, List<string> chem,
            List<string[]> accid)
        {
            string filename = userDet.userLastName + "Adatlapja" + DateTime.Today.Year.ToString() +
                    DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + ".pdf";
            try
            {
                if (!Directory.Exists(pathOfOutput))
                {
                    Directory.CreateDirectory(pathOfOutput);
                }
                this.path += pathOfOutput + filename;
            }
            catch (Exception e)
            {
                throw new ErrorMigraDocFileCreation("Probléma van a fájl célmappájával (ModPers-PDFfolder) " + e.Message);

            }
            adjustPageMetaDatas(userDet);
            adjustHeader(userDet);
            addChemicalsToPDF(chem);
            addAccidentsToPDF(accid);
            addFooterToPDF();
            finishPDF(path);
        }

        #region passive adjustors of the healthcare-form creation
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

        #region methods of the healthcare-form creation
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
            string headerText1 = "Kémiai-egészségügyi adatlap";
            string headerText2 = userDet.userLastName + " " + userDet.userFirstName + " TAJ-szám: " + userDet.userTaj;
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
        /// list contains the name of each chemical, that may harm the person, not just the user!
        /// </summary>
        /// <param name="chemName">all the chemicals' name in string</param>
        public void addChemicalsToPDF(List<string> chemicals)
        {
            Section textField = doc.LastSection;
            Paragraph paragraph = textField.AddParagraph();
            paragraph.AddFormattedText("Környezetében a kémiai anyagok:", TextFormat.Underline);
            paragraph.AddLineBreak();
            if (chemicals == null)
            {
                paragraph.AddFormattedText("Nincs feljegyzett adat!", StyleNames.Heading1);
            }
            else
            {
                foreach (string s in chemicals)
                {
                    paragraph.AddFormattedText(s.ToString() + "; ", StyleNames.Heading1);
                }
            }
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
        }
        /// <summary>
        /// list contains the needed details of the accident, like: date, description, with whom happend
        /// </summary>
        /// <param name="accid">an accident content in string</param>
        public void addAccidentsToPDF(List<string[]> allAccidents)
        {
            Section textField = doc.LastSection;
            Paragraph paragraph = textField.AddParagraph();
            paragraph.AddFormattedText("Feljegyzett baleset: ", TextFormat.Underline);
            paragraph.AddLineBreak();
            if (allAccidents == null)
            {
                paragraph.AddFormattedText("Nincs feljegyzett adat!");
                paragraph.AddLineBreak();
            }
            else
            {
                foreach (string[] s in allAccidents)
                {
                    if (s[0] != null || s[1] != null)
                    {
                        paragraph.AddFormattedText(" Dátum: " + s[0] + " - " + s[1].ToString() + " ", StyleNames.Normal);
                        paragraph.AddLineBreak();
                    }
                }
            }
        }

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
        public void finishPDF(string path)
        {
            try
            {
                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
                renderer.Document = doc;
                renderer.RenderDocument();
                renderer.PdfDocument.Save(path);
            }
            catch (Exception e)
            {
                throw new ErrorMigraDocFileCreation("Nem sikerült a PDF fájl létrehozása (ModPersPDFMod) " + e.Message);
            }
            Process.Start(path);
        }
        #endregion
    }
}
