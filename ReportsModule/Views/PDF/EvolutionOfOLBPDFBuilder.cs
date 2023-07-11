using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ReportsModule.Viewer;
using ReportsModule.ViewModels;

namespace ReportsModule.Views.PDF
{
    public class EvolutionOfOLBPDFBuilder
    {
        EvolutionOfOLBModel _ViewModel;
        string sFilePDF;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont1 = new Font(Font.TIMES_ROMAN, 12, Font.BOLD);
        Font hfont2 = new Font(Font.TIMES_ROMAN, 10, Font.BOLD);
        Font hFont2 = new Font(Font.TIMES_ROMAN, 9, Font.BOLD);
        Font bfont1 = new Font(Font.TIMES_ROMAN, 8, Font.BOLD);//body
        Font bFont2 = new Font(Font.TIMES_ROMAN, 8, Font.BOLD);//body
        Font bFont3 = new Font(Font.TIMES_ROMAN, 12, Font.BOLD);//body
        Font thFont = new Font(Font.TIMES_ROMAN, 9, Font.BOLD); //table Header
        Font tHfont1 = new Font(Font.TIMES_ROMAN, 11, Font.BOLD); //table Header
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL);//table cell
        Font tdFont1 = new Font(Font.TIMES_ROMAN, 8, Font.BOLD);//table cell
        Font rms6Normal = new Font(Font.TIMES_ROMAN, 9, Font.NORMAL);
        Font rms10Bold = new Font(Font.HELVETICA, 10, Font.BOLD);
        Font rms6Bold = new Font(Font.TIMES_ROMAN, 10, Font.BOLD);
        Font rms8Bold = new Font(Font.HELVETICA, 8, Font.BOLD);
        Font rms9Bold = new Font(Font.HELVETICA, 9, Font.BOLD);
        Font rms10Normal = new Font(Font.HELVETICA, 10, Font.NORMAL);

        public EvolutionOfOLBPDFBuilder(EvolutionOfOLBModel evolutionofolbmodel, string FileName)
        {
            if (evolutionofolbmodel == null)
                throw new ArgumentNullException("evolutionofolbmodel is null");
            _ViewModel = evolutionofolbmodel;

            sFilePDF = FileName;
        }

        public string GetPDF()
        {
            BuildPDF();
            return sFilePDF;
        }
        /*Build the document **/
        private void BuildPDF()
        {
            try
            {
                if (System.IO.File.Exists(sFilePDF))
                {
                    System.IO.File.Delete(sFilePDF);
                }

                //step 1 creation of the document
                document = new Document(PageSize.A4);

                // step 2:create a writer that listens to the document
                PdfWriter.GetInstance(document, new FileStream(sFilePDF, FileMode.Create));

                //open document
                document.Open();

                //document header
                AddDocHeader();

                //document body
                AddDocBody();

                //document footer
                AddDocFooter();

                //close document
                document.Close();
            }
            catch (DocumentException de)
            {
                this.Message = de.Message;
            }
            catch (IOException ioe)
            {
                this.Message = ioe.Message;
            }
            catch (Exception ex)
            {
                this.Message = ex.Message;
            }
            finally
            {
                if (document.IsOpen()) document.Close();
            }
        }
        //document header
        private void AddDocHeader()
        {
            Table olbandLlpLoanTable = new Table(5);
            olbandLlpLoanTable.WidthPercentage = 100;
            olbandLlpLoanTable.Padding = 1;
            olbandLlpLoanTable.Spacing = 1;
            olbandLlpLoanTable.Border = Table.NO_BORDER;

            Cell companyNameCell = new Cell(new Phrase(_ViewModel.CompanyName.ToUpper(), new Font(Font.TIMES_ROMAN, 12, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyNameCell.Colspan = 5;
            companyNameCell.Border = Cell.NO_BORDER;
            olbandLlpLoanTable.AddCell(companyNameCell);

            Cell companyAddressCell = new Cell(new Phrase(_ViewModel.CompanyAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyAddressCell.Colspan = 5;
            companyAddressCell.Border = Cell.NO_BORDER;
            olbandLlpLoanTable.AddCell(companyAddressCell);

            Cell companyTelephoneCell = new Cell(new Phrase("Phone: " + _ViewModel.CompanyTelephone, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyTelephoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyTelephoneCell.Colspan = 1;
            companyTelephoneCell.Border = Cell.NO_BORDER;
            olbandLlpLoanTable.AddCell(companyTelephoneCell);

            Cell companyEmailCell = new Cell(new Phrase("Email: " + _ViewModel.CompanyEmail, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyEmailCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyEmailCell.Colspan = 2;
            companyEmailCell.Border = Cell.NO_BORDER;
            olbandLlpLoanTable.AddCell(companyEmailCell);

            Cell companyWebsiteCell = new Cell(new Phrase("WebSite: " + _ViewModel.CompanyWebsite, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyWebsiteCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyWebsiteCell.Colspan = 2;
            companyWebsiteCell.Border = Cell.NO_BORDER;
            olbandLlpLoanTable.AddCell(companyWebsiteCell);

            Cell PrintedonCell = new Cell(new Phrase("Printed on: " + _ViewModel.PrintedOn.ToString("dd-dddd-MMMM-yyyy"), new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            PrintedonCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            PrintedonCell.Colspan = 4;
            PrintedonCell.Border = Cell.NO_BORDER;
            olbandLlpLoanTable.AddCell(PrintedonCell);

            //create the logo  
            PDFGen pdfgen = new PDFGen();
            Image imgCell = pdfgen.DoGetImageFile(_ViewModel.CompanyLogo);
            imgCell.Alignment = Image.ALIGN_MIDDLE;
            Cell logoCell = new Cell(imgCell);
            logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            logoCell.Border = Cell.NO_BORDER;
            logoCell.Add(new Phrase(_ViewModel.CompanySlogan, new Font(Font.TIMES_ROMAN, 8, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            olbandLlpLoanTable.AddCell(logoCell);

            Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.TIMES_ROMAN, 12, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportNameCell.Colspan = 5;
            reportNameCell.Border = Cell.NO_BORDER;
            olbandLlpLoanTable.AddCell(reportNameCell);

            document.Add(olbandLlpLoanTable);
        }
        //document body
        private void AddDocBody()
        {

        }
        //document footer
        private void AddDocFooter()
        {
            Table olbandLlpLoanTable = new Table(1);
            olbandLlpLoanTable.WidthPercentage = 100;
            olbandLlpLoanTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            olbandLlpLoanTable.AddCell(sgCell);

            document.Add(olbandLlpLoanTable);

        }














    }
}