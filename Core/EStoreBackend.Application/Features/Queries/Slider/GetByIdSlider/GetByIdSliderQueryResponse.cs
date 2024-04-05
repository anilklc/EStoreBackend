namespace EStoreBackend.Application.Features.Queries.Slider.GetByIdSlider
{
    public class GetByIdSliderQueryResponse
    {
        public string Id { get; set; }
        public string SliderTitle { get; set; }
        public string SliderSubtitle { get; set; }
        public string SliderTargetUrl { get; set; }
        public bool SliderActive { get; set; }
    }
}