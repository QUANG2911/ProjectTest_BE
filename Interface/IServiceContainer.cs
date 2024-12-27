using Microsoft.AspNetCore.Mvc;
using ProjectTest.DOTs;
using ProjectTest.DTOs;
using ProjectTest.Models;

namespace ProjectTest.Interface
{
    public interface IServiceContainer
    {
        //****************************CONTAINER**********************************
        Task<List<ContainerListDto>> GetContainerListAsync();

        ContainerDetailDTO GetInformationContainer(int id, DateTime dateChangeLocation);

        //****************************PHIEU NHAP**********************************

        Task<List<ContainerEntryFormListDto>> GetContainerEntryFormList(string idUser);

        ContainerEntryFormDetailDto GetInformationContainerEntryForm(string idEntryForm);

        ContainerEntryForm UpdateStatusContainerEntryForm(string idEntryForm, int status);

        void CreateContainerLocation(int containerSize, int bayNumber, int rowNumber, int tierNumber);

        void CreateDetailContainer(int idViTri, int idContainer);

        ContainerEntryForm CreateContainerEntryForm(string idUser, ContainerEntryFormDetailDto idEntryForm);

        void CreateContainer(string idContainer, string isoCode, string idUser, string typeContainer, int maxWeight, int tareWeight, string numContainer, int size, DateTime dateOfManufacture, DateTime dateOfContainerEntry);

        //****************************PHIEU XUAT**********************************
        Task<List<ContainerExitFormListDto>> GetContainerExitFormList(string idUser);

        Task<List<ContainerListExitDto>> GetInformationContainerExitForm(string idExitForm);

        ContainerExitForm UpdateStatusContainerExitForm(string idExitForm, int status);

        Task<List<ContainerListOfCustomerInSnpDto>> GetListContainerOfUserInSnp(string idUser);

        ContainerExitForm CreateContainerExitForm(string idUser, string idContainer, ContainerExitFormDetailDto containerExitFormDetailDto);


        //****************************LOAICONTAINER**********************************
        List<ContainerType> GetContainerType();

       

    }
}
