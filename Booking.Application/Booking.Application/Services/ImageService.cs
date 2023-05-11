using Booking.Application.DTOs.ResponseDTO;
using Booking.Application.Interfaces;
using Booking.Data.UnitOfWork;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services
{
    public class ImageService : IImageService
    {

        private readonly IRoomRepository roomRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageRepository imageRepository;

        public ImageService(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IImageRepository imageRepository)
        {
            this.roomRepository = roomRepository;
            this.unitOfWork = unitOfWork;
            this.imageRepository = imageRepository;
        }

        public  async Task<Response<Image>> PostImage(IFormFile file, int roomId)
        {
            Response<Image> response = new Response<Image>();
            var findRoom = await roomRepository.GetById(roomId);
            if(findRoom == null)
            {
                response.AddMessage("Quarto não encontrado", $"Não foi encontrado nenhum quarto com id {roomId}");
                return response;
            }
            var convert = ConvertImage(file, roomId, false);
                response.AddData(convert);
            imageRepository.PostImage(convert);
            await unitOfWork.CommitAsync();
            return response;
        }

        public async Task<Response<Image>> UpdateOrPostMainImage(IFormFile file, int roomId)
        {
            Response<Image> response = new Response<Image>();
            var findRoom = await roomRepository.GetById(roomId);
            if (findRoom == null)
            {
                response.AddMessage("Quarto não encontrado", $"Não foi encontrado nenhum quarto com id {roomId}");
                return response;
            }
            var findImageMain = await imageRepository.GetMainImage(roomId);
            if(findImageMain.Count() > 0)
            {
                var convertImage = ConvertImage(file, roomId,true);
                findImageMain.First().ImageBase = convertImage.ImageBase;
                findImageMain.First().FormatImage = convertImage.FormatImage;
                response.AddData(findImageMain.First());
                imageRepository.UpdateImageMain(findImageMain.First());
                await unitOfWork.CommitAsync();
                return response;
            };
            var convert = ConvertImage(file, roomId,true);
            response.AddData(convert);
            imageRepository.PostImage(convert);
            await unitOfWork.CommitAsync();
            return response;
        }
        public Image ConvertImage(IFormFile file, int roomId,bool decision)
        {
            byte[] imageData = new byte[file.Length];
            using (var stream = file.OpenReadStream())
            {
                stream.Read(imageData, 0, imageData.Length);
            }
            string base64String = Convert.ToBase64String(imageData);
            Image image = new Image { CreatedAt = new DateTime(), FormatImage = file.ContentType, RoomId = roomId, ImageBase = base64String, MainImage = decision };
            return image;
        }
    }
}
