namespace DGod.SuparCar.ViewModels
{
    public class MetaDataConfigViewModel
    {
        public MetaDataHeaderModel MetaDataHeader { get; set; }

        public string CanonicalUrl { get; set; }

        public string AlternateUrl { get; set; }
        
        public int PageNumber { get; set; } = 1;
    }
    
    public class MetaDataHeaderModel
    {
        public string Title { get; set; } = "DGod Car Template";

        public string MetaTitle { get; set; } = "DGod Car Template";

        public string MetaKeyword { get; set; } =
            "dgod, car, template";

        public string MetaDescription { get; set; } =
            "DGod Car Template";

        public string MetaImage { get; set; }

        public string MetaRobots { get; set; } = "index,follow,all";

        // public string MetaViewport { get; set; } = "width=device-width, initial-scale=1.0, viewport-fit=cover";
    }
}

