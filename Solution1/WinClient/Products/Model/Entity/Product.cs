using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Entity
{
    /// <summary>
    /// With Web API, if Serializable atribute is applied,
    /// DataContract should also be used (System.Runtime.Serialization)
    /// </summary>
    //[DataContract]
    //[Serializable]
    public class Product
    {
        //[DataMember]
        [Required(ErrorMessage = "Id is required.")]
        public string Id { get; set; }
        //[DataMember]
        // Allow uppercase and lowercase characters and spaces. 
        [RegularExpression(@"[a-zA-Z'\s]+", ErrorMessage = "Name is not valid.")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        //[DataMember]
        [Range(0,1000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double CostPrice { get; set; }
        //[DataMember]
        [Range(0, 2000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public virtual double RetailPrice { get; set; }
        [Timestamp]
        [ScaffoldColumn(false)]
        public byte[] RowVersion { get; set; }

        public Product()
        {

        }
        public Product(string id, string name, double costPrice, double retailPrice = 0)
        {
            Id = id;
            Name = name;
            CostPrice = costPrice;
            RetailPrice = retailPrice;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj) =>
            obj is Product ? (obj as Product).Id == Id : false;


        public override int GetHashCode() =>
            Id == null ? base.GetHashCode() : Id.GetHashCode();
    }
}
