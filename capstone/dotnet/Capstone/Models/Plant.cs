namespace Capstone.Models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string Kingdom { get; set; }
        public string? Family { get; set; }

        public string? Subfamily { get; set; }
        public string? Genus { get; set; }
        public string Species { get; set; }
        public string? CommonName { get; set; }
        public string? Order { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }

        public Plant() { }

         public Plant(int PlantId,
         string kingdom,
         string family,

         string subfamily,
         string genus,
         string species,
         string commonName,
         string order,
         string description,
             string imgurl)
        {
            Kingdom = kingdom;
            Family = family;
            Subfamily = subfamily;
            Genus = genus;
            Species = species;
            CommonName = commonName;
            Order = order;
            Description = description;
            ImgUrl = imgurl;
        }

        //methods


    }
}
