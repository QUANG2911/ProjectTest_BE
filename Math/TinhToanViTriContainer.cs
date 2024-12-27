using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ProjectTest.Interface;
using ProjectTest.Models;

namespace ProjectTest.Math
{
    

    public class TinhToanViTriContainer : IContainerLocation
    {
        public string getContainerLocation(int typeBay, int bayLocation, int rowLocation, int tierLocation)
        {
            // viTri tạo mới để đặt container
            string idBlock = "";
            string stringLocation = "";

            if (typeBay == 20)
            {
                idBlock = "A";
                stringLocation = getBayContainer20feet(bayLocation, rowLocation, tierLocation);
            }
            else
            {
                idBlock = "B";
                stringLocation = getBayContainer40feet(bayLocation, rowLocation, tierLocation);
            }

            stringLocation = idBlock + "/" + stringLocation;
            return stringLocation;
        }

        public string getBayContainer20feet(int bayLocation, int rowLocation, int tierLocation)
        {
            string stringLocation = "";

            if (bayLocation == 4 && rowLocation == 3 && tierLocation == 4)
                return "full";

            if (bayLocation < 4)
            {
                bayLocation = bayLocation + 1;
                stringLocation = rowLocation + "/" + tierLocation;
            }
            else
            {
                bayLocation = 1;
                stringLocation = getRowTierContainer(rowLocation, tierLocation);

            }
            stringLocation = bayLocation + "/" + stringLocation;
            return stringLocation;
        }

        public string getBayContainer40feet(int bayLocation, int rowLocation, int tierLocation)
        {
            string stringLocation = "";

            if (bayLocation == 2 && rowLocation == 3 && tierLocation == 4)
                return "full";

            if (bayLocation < 2)
            {
                bayLocation = bayLocation + 1;
                stringLocation = rowLocation + "/" + tierLocation;
            }
            else
            {
                bayLocation = 1;
                stringLocation = getRowTierContainer(rowLocation, tierLocation);

            }
            stringLocation = bayLocation + "/" + stringLocation;
            return stringLocation;
        }

        public string getRowTierContainer(int rowLocation, int tierLocation)
        {
            if (rowLocation < 3)
                rowLocation = rowLocation + 1;
            else
            {
                rowLocation = 1;
                if (tierLocation < 4)
                    tierLocation = tierLocation + 1;
                else tierLocation = 1;
            }
            string stringLocation = rowLocation + "/" + tierLocation;
            return stringLocation;
        }
    }
}
