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
using DAL;

namespace ReportsModule.Views.PDF
{
    public class ClientInformationViewModelPDFBuilder
    {
        ClientInformationViewModel _ViewModel;
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

        public ClientInformationViewModelPDFBuilder(ClientInformationViewModel clientinformationmodel, string FileName)
        {
            if (clientinformationmodel == null)
                throw new ArgumentNullException("ClientInformationViewModel is null");
            _ViewModel = clientinformationmodel;

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
            Table _clientInfoTable = new Table(5);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Padding = 1;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Border = Table.NO_BORDER;

            Cell companyNameCell = new Cell(new Phrase(_ViewModel.CompanyName.ToUpper(), new Font(Font.TIMES_ROMAN, 12, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyNameCell.Colspan = 5;
            companyNameCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(companyNameCell);

            Cell companyAddressCell = new Cell(new Phrase(_ViewModel.CompanyAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyAddressCell.Colspan = 5;
            companyAddressCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(companyAddressCell);

            Cell companyTelephoneCell = new Cell(new Phrase("Phone: " + _ViewModel.CompanyTelephone, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyTelephoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyTelephoneCell.Colspan = 1;
            companyTelephoneCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(companyTelephoneCell);

            Cell companyEmailCell = new Cell(new Phrase("Email: " + _ViewModel.CompanyEmail, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyEmailCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyEmailCell.Colspan = 2;
            companyEmailCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(companyEmailCell);

            Cell companyWebsiteCell = new Cell(new Phrase("WebSite: " + _ViewModel.CompanyWebsite, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            companyWebsiteCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            companyWebsiteCell.Colspan = 2;
            companyWebsiteCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(companyWebsiteCell);

            Cell PrintedonCell = new Cell(new Phrase("Printed on: " + _ViewModel.PrintedOn.ToString("dd-dddd-MMMM-yyyy"), new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            PrintedonCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            PrintedonCell.Colspan = 4;
            PrintedonCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(PrintedonCell);

            //create the logo  
            PDFGen pdfgen = new PDFGen();
            Image imgCell = pdfgen.DoGetImageFile(_ViewModel.CompanyLogo);
            imgCell.Alignment = Image.ALIGN_MIDDLE;
            Cell logoCell = new Cell(imgCell);
            logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            logoCell.Border = Cell.NO_BORDER;
            logoCell.Add(new Phrase(_ViewModel.CompanySlogan, new Font(Font.TIMES_ROMAN, 8, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            _clientInfoTable.AddCell(logoCell);

            Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName + Environment.NewLine, new Font(Font.TIMES_ROMAN, 12, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportNameCell.Colspan = 5;
            reportNameCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(reportNameCell);

            document.Add(_clientInfoTable);
        }
        //document body
        private void AddDocBody()
        {
            //Add Personal Information
            AddPersonalInformation();

            //Add Personal Information Credit  
            AddPersonalInformationCredit();

            //Add Personal Information Savings
            AddPersonalInformationSavings();
        }


        //Add Personal Information
        private void AddPersonalInformation()
        {
            //Add table Report header
            AddTableReportHeadersPersonalInformation();

            //Add table headers
            AddTableHeadersPersonalInformation();

            if (_ViewModel._PersonalInformation != null)
            {
                foreach (var st in _ViewModel._PersonalInformation)
                {
                    //Add table details  
                    AddTableDetailsPersonalInformation(st);
                }
            }

            //Add table totals
            AddTableTotalsPersonalInformation();
        }

        //table Report header
        private void AddTableReportHeadersPersonalInformation()
        {
            Table _clientInfoTable = new Table(16);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Padding = 1;
            _clientInfoTable.Border = Table.NO_BORDER;

            Cell reportNameCell = new Cell(new Phrase(_ViewModel.PersonalInfoReportName + Environment.NewLine, new Font(Font.TIMES_ROMAN, 12, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportNameCell.Colspan = 16;
            reportNameCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(reportNameCell);

            document.Add(_clientInfoTable);
        }

        //table headers
        private void AddTableHeadersPersonalInformation()
        {
            Table _clientInfoTable = new Table(16);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Padding = 1;

            Cell first_nameCell = new Cell(new Phrase("first_name", thFont));
            first_nameCell.Border = Cell.RECTANGLE;
            first_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(first_nameCell);

            Cell last_nameCell = new Cell(new Phrase("last_name", thFont));
            last_nameCell.Border = Cell.RECTANGLE;
            last_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(last_nameCell);

            Cell father_nameCell = new Cell(new Phrase("father_name", thFont));
            father_nameCell.Border = Cell.RECTANGLE;
            father_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(father_nameCell);

            Cell id_numberCell = new Cell(new Phrase("id_number", thFont));
            id_numberCell.Border = Cell.RECTANGLE;
            id_numberCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(id_numberCell);

            Cell genderCell = new Cell(new Phrase("gender", thFont));
            genderCell.Border = Cell.RECTANGLE;
            genderCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(genderCell);

            Cell districtCell = new Cell(new Phrase("district", thFont));
            districtCell.Border = Cell.RECTANGLE;
            districtCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(districtCell);

            Cell cityCell = new Cell(new Phrase("city", thFont));
            cityCell.Border = Cell.RECTANGLE;
            cityCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(cityCell);

            Cell addressCell = new Cell(new Phrase("address", thFont));
            addressCell.Border = Cell.RECTANGLE;
            addressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(addressCell);

            Cell sec_districtCell = new Cell(new Phrase("sec_district", thFont));
            sec_districtCell.Border = Cell.RECTANGLE;
            sec_districtCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_districtCell);

            Cell sec_cityCell = new Cell(new Phrase("sec_city", thFont));
            sec_cityCell.Border = Cell.RECTANGLE;
            sec_cityCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_cityCell);

            Cell sec_addressCell = new Cell(new Phrase("sec_address", thFont));
            sec_addressCell.Border = Cell.RECTANGLE;
            sec_addressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_addressCell);

            Cell phoneCell = new Cell(new Phrase("phone", thFont));
            phoneCell.Border = Cell.RECTANGLE;
            phoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(phoneCell);

            Cell sec_phoneCell = new Cell(new Phrase("sec_phone", thFont));
            sec_phoneCell.Border = Cell.RECTANGLE;
            sec_phoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_phoneCell);

            Cell sec_pers_phoneCell = new Cell(new Phrase("sec_pers_phone", thFont));
            sec_pers_phoneCell.Border = Cell.RECTANGLE;
            sec_pers_phoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_pers_phoneCell);

            Cell pictureCell = new Cell(new Phrase("picture", thFont));
            pictureCell.Border = Cell.RECTANGLE;
            pictureCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(pictureCell);

            Cell picture2Cell = new Cell(new Phrase("picture2", thFont));
            picture2Cell.Border = Cell.RECTANGLE;
            picture2Cell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(picture2Cell);

            document.Add(_clientInfoTable); 
        }
         
        //table details 
        private void AddTableDetailsPersonalInformation(ClientPersonalInformationModel ci)
        {
            Table _clientInfoTable = new Table(16);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Padding = 1;

            Cell first_nameCell = new Cell(new Phrase(ci.first_name, thFont));
            first_nameCell.Border = Cell.RECTANGLE;
            first_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(first_nameCell);

            Cell last_nameCell = new Cell(new Phrase(ci.last_name, thFont));
            last_nameCell.Border = Cell.RECTANGLE;
            last_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(last_nameCell);

            Cell father_nameCell = new Cell(new Phrase(ci.father_name, thFont));
            father_nameCell.Border = Cell.RECTANGLE;
            father_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(father_nameCell);

            Cell id_numberCell = new Cell(new Phrase(ci.id_number, thFont));
            id_numberCell.Border = Cell.RECTANGLE;
            id_numberCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(id_numberCell);

            Cell genderCell = new Cell(new Phrase(ci.gender, thFont));
            genderCell.Border = Cell.RECTANGLE;
            genderCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(genderCell);

            Cell districtCell = new Cell(new Phrase(ci.district, thFont));
            districtCell.Border = Cell.RECTANGLE;
            districtCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(districtCell);

            Cell cityCell = new Cell(new Phrase(ci.city, thFont));
            cityCell.Border = Cell.RECTANGLE;
            cityCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(cityCell);

            Cell addressCell = new Cell(new Phrase(ci.address, thFont));
            addressCell.Border = Cell.RECTANGLE;
            addressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(addressCell);

            Cell sec_districtCell = new Cell(new Phrase(ci.sec_district, thFont));
            sec_districtCell.Border = Cell.RECTANGLE;
            sec_districtCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_districtCell);

            Cell sec_cityCell = new Cell(new Phrase(ci.sec_city, thFont));
            sec_cityCell.Border = Cell.RECTANGLE;
            sec_cityCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_cityCell);

            Cell sec_addressCell = new Cell(new Phrase(ci.sec_address, thFont));
            sec_addressCell.Border = Cell.RECTANGLE;
            sec_addressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_addressCell);

            Cell phoneCell = new Cell(new Phrase(ci.phone, thFont));
            phoneCell.Border = Cell.RECTANGLE;
            phoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(phoneCell);

            Cell sec_phoneCell = new Cell(new Phrase(ci.sec_phone, thFont));
            sec_phoneCell.Border = Cell.RECTANGLE;
            sec_phoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_phoneCell);

            Cell sec_pers_phoneCell = new Cell(new Phrase(ci.sec_pers_phone, thFont));
            sec_pers_phoneCell.Border = Cell.RECTANGLE;
            sec_pers_phoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(sec_pers_phoneCell);

            Cell pictureCell = new Cell(new Phrase(ci.picture, thFont));
            pictureCell.Border = Cell.RECTANGLE;
            pictureCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(pictureCell);

            Cell picture2Cell = new Cell(new Phrase(ci.picture2, thFont));
            picture2Cell.Border = Cell.RECTANGLE;
            picture2Cell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(picture2Cell);

            document.Add(_clientInfoTable); 
        }

        //table totals
        private void AddTableTotalsPersonalInformation()
        {

        }

        //Add Personal Information Credit  
        private void AddPersonalInformationCredit()
        {
            //Add table Report header
            AddTableReportHeadersCreditInformation();

            //Add table headers
            AddTableHeadersPersonalInformationCredit();

            if (_ViewModel._PersonalInformationCredit != null)
            {
                foreach (var st in _ViewModel._PersonalInformationCredit)
                {
                    //Add table details  
                    AddTableDetailsPersonalInformationCredit(st);
                }
            }

            //Add table totals
            AddTableTotalsPersonalInformationCredit();
        }

        //table Report header
        private void AddTableReportHeadersCreditInformation()
        {
            Table _clientInfoTable = new Table(10);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Padding = 1;
            _clientInfoTable.Border = Table.NO_BORDER;

            Cell reportNameCell = new Cell(new Phrase(_ViewModel.CreditInfoReportName + Environment.NewLine, new Font(Font.TIMES_ROMAN, 12, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportNameCell.Colspan = 10;
            reportNameCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(reportNameCell);

            document.Add(_clientInfoTable);
        }

        //table headers
        private void AddTableHeadersPersonalInformationCredit()
        {
            Table _clientInfoTable = new Table(10);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Padding = 1;

            Cell contract_codeCell = new Cell(new Phrase("contract_code", thFont));
            contract_codeCell.Border = Cell.RECTANGLE;
            contract_codeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(contract_codeCell);

            Cell statusCell = new Cell(new Phrase("status", thFont));
            statusCell.Border = Cell.RECTANGLE;
            statusCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(statusCell);

            Cell amountCell = new Cell(new Phrase("amount", thFont));
            amountCell.Border = Cell.RECTANGLE;
            amountCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(amountCell);

            Cell olbCell = new Cell(new Phrase("olb", thFont));
            olbCell.Border = Cell.RECTANGLE;
            olbCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(olbCell);

            Cell creation_dateCell = new Cell(new Phrase("creation_date", thFont));
            creation_dateCell.Border = Cell.RECTANGLE;
            creation_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(creation_dateCell);

            Cell start_dateCell = new Cell(new Phrase("start_date", thFont));
            start_dateCell.Border = Cell.RECTANGLE;
            start_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(start_dateCell);

            Cell close_dateCell = new Cell(new Phrase("close_date", thFont));
            close_dateCell.Border = Cell.RECTANGLE;
            close_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(close_dateCell);

            Cell group_nameCell = new Cell(new Phrase("group_name", thFont));
            group_nameCell.Border = Cell.RECTANGLE;
            group_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(group_nameCell);

            Cell total_late_daysCell = new Cell(new Phrase("total_late_days", thFont));
            total_late_daysCell.Border = Cell.RECTANGLE;
            total_late_daysCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(total_late_daysCell);

            Cell has_atrCell = new Cell(new Phrase("has_atr", thFont));
            has_atrCell.Border = Cell.RECTANGLE;
            has_atrCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(has_atrCell); 

            document.Add(_clientInfoTable); 
        }

        //table details 
        private void AddTableDetailsPersonalInformationCredit(ClientPersonalInformationCreditModel ci)
        {
            Table _clientInfoTable = new Table(10);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Padding = 1;

            Cell contract_codeCell = new Cell(new Phrase(ci.contract_code, thFont));
            contract_codeCell.Border = Cell.RECTANGLE;
            contract_codeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(contract_codeCell);

            Cell statusCell = new Cell(new Phrase(ci.status, thFont));
            statusCell.Border = Cell.RECTANGLE;
            statusCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(statusCell);

            Cell amountCell = new Cell(new Phrase(ci.amount.ToString(), thFont));
            amountCell.Border = Cell.RECTANGLE;
            amountCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(amountCell);

            Cell olbCell = new Cell(new Phrase(ci.olb.ToString(), thFont));
            olbCell.Border = Cell.RECTANGLE;
            olbCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(olbCell);

            Cell creation_dateCell = new Cell(new Phrase(ci.creation_date.ToString(), thFont));
            creation_dateCell.Border = Cell.RECTANGLE;
            creation_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(creation_dateCell);

            Cell start_dateCell = new Cell(new Phrase(ci.start_date.ToString(), thFont));
            start_dateCell.Border = Cell.RECTANGLE;
            start_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(start_dateCell);

            Cell close_dateCell = new Cell(new Phrase(ci.close_date.ToString(), thFont));
            close_dateCell.Border = Cell.RECTANGLE;
            close_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(close_dateCell);

            Cell group_nameCell = new Cell(new Phrase(ci.group_name, thFont));
            group_nameCell.Border = Cell.RECTANGLE;
            group_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(group_nameCell);

            Cell total_late_daysCell = new Cell(new Phrase(ci.total_late_days.ToString(), thFont));
            total_late_daysCell.Border = Cell.RECTANGLE;
            total_late_daysCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(total_late_daysCell);

            Cell has_atrCell = new Cell(new Phrase(ci.has_atr.ToString(), thFont));
            has_atrCell.Border = Cell.RECTANGLE;
            has_atrCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(has_atrCell);

            document.Add(_clientInfoTable);
        }

        //table totals
        private void AddTableTotalsPersonalInformationCredit()
        {

        }

        //Add Personal Information Savings
        private void AddPersonalInformationSavings()
        {
            //Add table Report header
            AddTableReportHeadersSavingsInformation();

            //Add table headers
            AddTableHeadersPersonalInformationSavings();

            if (_ViewModel._PersonalInformationSavings != null)
            {
                foreach (var st in _ViewModel._PersonalInformationSavings)
                {
                    //Add table details  
                    AddTableDetailsPersonalInformationSavings(st);
                }
            }

            //Add table totals
            AddTableTotalsPersonalInformationSavings();
        }

        //table Report header
        private void AddTableReportHeadersSavingsInformation()
        {
            Table _clientInfoTable = new Table(7);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Padding = 1;
            _clientInfoTable.Border = Table.NO_BORDER;

            Cell reportNameCell = new Cell(new Phrase(_ViewModel.SavingsInfoReportName + Environment.NewLine, new Font(Font.TIMES_ROMAN, 12, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
            reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportNameCell.Colspan = 7;
            reportNameCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(reportNameCell);

            document.Add(_clientInfoTable);
        }

        //table headers
        private void AddTableHeadersPersonalInformationSavings()
        {
            Table _clientInfoTable = new Table(7);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Padding = 1;

            Cell savings_codeCell = new Cell(new Phrase("savings_code", thFont));
            savings_codeCell.Border = Cell.RECTANGLE;
            savings_codeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(savings_codeCell);

            Cell balance_amountCell = new Cell(new Phrase("balance_amount", thFont));
            balance_amountCell.Border = Cell.RECTANGLE;
            balance_amountCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(balance_amountCell);

            Cell product_nameCell = new Cell(new Phrase("product_name", thFont));
            product_nameCell.Border = Cell.RECTANGLE;
            product_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(product_nameCell);

            Cell product_codeCell = new Cell(new Phrase("product_code", thFont));
            product_codeCell.Border = Cell.RECTANGLE;
            product_codeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(product_codeCell);

            Cell product_typeCell = new Cell(new Phrase("product_type", thFont));
            product_typeCell.Border = Cell.RECTANGLE;
            product_typeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(product_typeCell);

            Cell creation_dateCell = new Cell(new Phrase("creation_date", thFont));
            creation_dateCell.Border = Cell.RECTANGLE;
            creation_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(creation_dateCell);

            Cell closed_dateCell = new Cell(new Phrase("closed_date", thFont));
            closed_dateCell.Border = Cell.RECTANGLE;
            closed_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(closed_dateCell); 

            document.Add(_clientInfoTable); 
        }

        //table details 
        private void AddTableDetailsPersonalInformationSavings(ClientPersonalInformationSavingsModel ci)
        {
            Table _clientInfoTable = new Table(7);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Spacing = 1;
            _clientInfoTable.Padding = 1;

            Cell savings_codeCell = new Cell(new Phrase(ci.savings_code, thFont));
            savings_codeCell.Border = Cell.RECTANGLE;
            savings_codeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(savings_codeCell);

            Cell balance_amountCell = new Cell(new Phrase(ci.balance_amount.ToString(), thFont));
            balance_amountCell.Border = Cell.RECTANGLE;
            balance_amountCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(balance_amountCell);

            Cell product_nameCell = new Cell(new Phrase(ci.product_name, thFont));
            product_nameCell.Border = Cell.RECTANGLE;
            product_nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(product_nameCell);

            Cell product_codeCell = new Cell(new Phrase(ci.product_code, thFont));
            product_codeCell.Border = Cell.RECTANGLE;
            product_codeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(product_codeCell);

            Cell product_typeCell = new Cell(new Phrase(ci.product_type, thFont));
            product_typeCell.Border = Cell.RECTANGLE;
            product_typeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(product_typeCell);

            Cell creation_dateCell = new Cell(new Phrase(ci.creation_date.ToString(), thFont));
            creation_dateCell.Border = Cell.RECTANGLE;
            creation_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(creation_dateCell);

            Cell closed_dateCell = new Cell(new Phrase(ci.closed_date.ToString(), thFont));
            closed_dateCell.Border = Cell.RECTANGLE;
            closed_dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            _clientInfoTable.AddCell(closed_dateCell);

            document.Add(_clientInfoTable); 
        }

        //table totals
        private void AddTableTotalsPersonalInformationSavings()
        {

        }

        //document footer
        private void AddDocFooter()
        {
            Table _clientInfoTable = new Table(1);
            _clientInfoTable.WidthPercentage = 100;
            _clientInfoTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            _clientInfoTable.AddCell(sgCell);

            document.Add(_clientInfoTable);

        }













    }
}