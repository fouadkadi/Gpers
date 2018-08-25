using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration.Assemblies;
using System.Drawing;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using _Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

namespace Authentification
{
    class ExcelManip
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public ExcelManip(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public string readExcelcell(int i, int j)
        {
            if (ws.Cells[i, j].Value2 != null)
                return ws.Cells[i, j].Value2 + "";
            else
                return "0";
        }

        public void WriteToCell(int i, int j, string s)
        {
            ws.Cells[i, j].Value2 = s;
        }

        public void save()
        {
            wb.Save();
        }

        public void saveas(string path)
        {
            wb.SaveAs(path);
        }

        public void Close()
        {
            wb.Close();
        }

        public void insererLogo(string path)
        {
            ws.Shapes.AddPicture(path, Microsoft.Office.Core.MsoTriState.msoFalse,
                Microsoft.Office.Core.MsoTriState.msoCTrue, 20, 20, 64, 64);
        }

        public void creer_fichier_entretien(string path_logo, string RaisonSociale, string Specialite, string NomPrenom, string poste, string Responsable, string dateEmbauche, List<objectif> obj)
        {
            insererLogo(path_logo);
            WriteToCell(5, 2, RaisonSociale.ToUpper());
            WriteToCell(6, 2, Specialite.ToUpper());
            ws.Cells[11, 2] = "NON & PRENOM DU COLLABORETEUR : " + NomPrenom.ToUpper();
            WriteToCell(17, 5, poste.ToUpper());
            WriteToCell(17, 2, Responsable.ToUpper());
            WriteToCell(12, 8, dateEmbauche);
            WriteToCell(14, 11, DateTime.Now.Date.ToString());
            int cpt1 = 94;
            int cpt2 = 103;
            int cpt3 = 112;
            DateTime auj = DateTime.Now.Date;
            foreach (var rec in obj)
            {
               
                if (DateTime.Compare(rec.fin.Value, auj) < 0)
                {
                    MessageBox.Show("helo");
                    switch (rec.type.ToLower())
                    {
                        case "l":
                            WriteToCell(cpt3, 3, rec.o);
                            cpt3++;
                            break;
                        case "m":
                            WriteToCell(cpt2, 3, rec.o);
                            cpt2++;
                            break;
                        case "c":
                            WriteToCell(cpt1, 3, rec.o);
                            cpt1++;
                            break;


                    }

                }

            }

        }

        public void ancien(string chem)
        {
            ExcelManip obb = new ExcelManip(chem, 1);
            int cpt1 = 70;
            int cpt2 = 94;
            if (obb.readExcelcell(14, 11) != "0")
                WriteToCell(13, 11, obb.readExcelcell(14, 11));
            for (int i = 0; i < 6; i++)
            {
                if (obb.readExcelcell(cpt2, 3) != "0")
                {
                    WriteToCell(cpt1, 3, obb.readExcelcell(cpt2, 3));
                    WriteToCell(cpt1, 8, obb.readExcelcell(cpt2, 8));
                }

                cpt1++;
                cpt2++;

            }
            cpt1 = 77;
            cpt2 = 103;
            for (int i = 0; i < 6; i++)
            {

                if (obb.readExcelcell(cpt2, 3) != "0")
                {
                    WriteToCell(cpt1, 3, obb.readExcelcell(cpt2, 3));
                    WriteToCell(cpt1, 8, obb.readExcelcell(cpt2, 8));
                }
                cpt1++;
                cpt2++;

            }
            cpt1 = 84;
            cpt2 = 112;
            for (int i = 0; i < 6; i++)
            {
                if (obb.readExcelcell(cpt2, 3) != "0")
                {
                    WriteToCell(cpt1, 3, obb.readExcelcell(cpt2, 3));
                    WriteToCell(cpt1, 8, obb.readExcelcell(cpt2, 8));
                }
                cpt1++;
                cpt2++;

            }
            obb.Close();

        }
    }
}
