using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ProjectTest.Interface;
using ProjectTest.Models;

namespace ProjectTest.Math
{
    

    public class TinhToanViTriContainer : I_ViTriContainer
    {
        public string getViTriContainer(int LoaiBay, int ViTriBay, int ViTriRow, int ViTriTier)
        {
            // viTri tạo mới để đặt container
            string maBlock = "";
            string ChuoiViTri = "";

            if (LoaiBay == 20)
            {
                maBlock = "A";
                ChuoiViTri = getBayContainer20feet(ViTriBay, ViTriRow, ViTriTier);
            }
            else
            {
                maBlock = "B";
                ChuoiViTri = getBayContainer40feet(ViTriBay, ViTriRow, ViTriTier);
            }

            ChuoiViTri = maBlock + "/" + ChuoiViTri;
            return ChuoiViTri;
        }

        public string getBayContainer20feet(int ViTriBay, int ViTriRow, int ViTriTier)
        {
            string chuoi = "";

            if (ViTriBay == 4 && ViTriRow == 3 && ViTriTier == 4)
                return "full";

            if (ViTriBay < 4)
            {
                ViTriBay = ViTriBay + 1;
                chuoi = ViTriRow + "/" + ViTriTier;
            }
            else
            {
                ViTriBay = 1;
                chuoi = getRowTierContainer(ViTriRow, ViTriTier);

            }
            chuoi = ViTriBay + "/" + chuoi;
            return chuoi;
        }

        public string getBayContainer40feet(int ViTriBay, int ViTriRow, int ViTriTier)
        {
            string chuoi = "";

            if (ViTriBay == 2 && ViTriRow == 3 && ViTriTier == 4)
                return "full";

            if (ViTriBay < 2)
            {
                ViTriBay = ViTriBay + 1;
                chuoi = ViTriRow + "/" + ViTriTier;
            }
            else
            {
                ViTriBay = 1;
                chuoi = getRowTierContainer(ViTriRow, ViTriTier);

            }
            chuoi = ViTriBay + "/" + chuoi;
            return chuoi;
        }

        public string getRowTierContainer(int ViTriRow, int ViTriTier)
        {
            if (ViTriRow < 3)
                ViTriRow = ViTriRow + 1;
            else
            {
                ViTriRow = 1;
                if (ViTriTier < 4)
                    ViTriTier = ViTriTier + 1;
                else ViTriTier = 1;
            }
            string chuoi = ViTriRow + "/" + ViTriTier;
            return chuoi;
        }
    }
}
