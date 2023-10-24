// See https://aka.ms/new-console-template for more information

using TiSApac.SG.Framework.Utilities;

string sINIFile = Directory.GetCurrentDirectory()+ @"\variables.INI";

INI ini = new INI();
string sExportFolder = ini.GetKeyValue("Paths", "OUT_eFLOW_export_path", sINIFile);
string sScanImages = ini.GetKeyValue("Paths", "ScanImages", sINIFile);



Console.WriteLine("Export Folder: ",sExportFolder);
Console.WriteLine("Scan Image Folder", sScanImages);


string sProcDate = "20331024";
string sBatchID = "2548";
string sUI = "1010101010101";
string oUI = "1010101010101";


string tpath1 = string.Empty;
string tpath2 = string.Empty;
string sFromPath = string.Empty;
string sDestPath = string.Empty;
string filename = string.Empty;

    try
    {
        if (Directory.Exists(sExportFolder))
        {
            tpath1 = Path.Combine(sScanImages, sProcDate);
            if (!Directory.Exists(tpath1))
            {
                Directory.CreateDirectory(tpath1);
            }
            tpath2 = Path.Combine(tpath1, sBatchID);
            if (!Directory.Exists(tpath2))
            {
                Directory.CreateDirectory(tpath2);
            }
            filename = string.Empty;
            filename = sUI + "c" + ".TIF";
            sFromPath = Path.Combine(sExportFolder, oUI + ".TIF");
            sDestPath = Path.Combine(tpath2, filename);
            if (File.Exists(sFromPath))
            {
                //  if (!File.Exists(sDestPath))
                //  {
                File.Copy(sFromPath, sDestPath, true);
                //  }
            }

        }
        
    }
    catch (Exception ex)
    {
        Console.WriteLine("exception:" + ex.ToString());
        throw;
    }
