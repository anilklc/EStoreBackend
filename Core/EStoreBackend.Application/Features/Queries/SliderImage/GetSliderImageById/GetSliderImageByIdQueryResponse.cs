using System.ComponentModel.DataAnnotations.Schema;

namespace EStoreBackend.Application.Features.Queries.SliderImage.GetSliderImageById
{
    public class GetSliderImageByIdQueryResponse
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public Guid SliderId { get; set; }
    }
}